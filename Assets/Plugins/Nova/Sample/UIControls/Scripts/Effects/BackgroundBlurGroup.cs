using Nova;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NovaSamples.Effects
{
    /// <summary>
    /// Synchronizes a <see cref="BackgroundCamera"/> and list of <see cref="BlurEffects"/> so that the blur effects get updated whenever the background content is rendered.
    /// </summary>
    /// <remarks>
    /// This component is simply a utility intended to ease the setup for background blur UI elements, but it's not a required piece of the blur effect pipeline. 
    /// A similar (and potentially more optimized and/or more suited to a given project) background texture setup can be created manually, and then
    /// bluring the content can be achieved by assigning the manually rendered background texture to any <see cref="BlurEffect.InputTexture"/>. 
    /// Whenever the background texture re-renders, a call to <see cref="BlurEffect.Reblur"/> will update the final blurred output on the
    /// <see cref="BlurEffect.UIBlock"/>.
    /// </remarks>
    [ExecuteAlways, DisallowMultipleComponent]
    public class BackgroundBlurGroup : MonoBehaviour
    {
        private const int TextureDepth = 24;

        [Header("Background")]
        [Tooltip("The camera which will render the background image for the list of blur effects.\n\nThis component will control when the assigned camera renders, so it will keep the camera disabled to avoid duplicated work.")]
        public Camera BackgroundCamera = null;


        [Header("Effects")]
        [Tooltip("The Blur Effect components which will use output of the Background Camera as their blur input.")]
        public List<BlurEffect> BlurEffects = null;

        [Header("Perspective")]
        [Tooltip("If assigned, ALL* properties (including transform) from the Property Match Camera will be copied to the Background Camera before the Background Camera is rendered. If unassigned, the Background Camera's manual configuration will not be modified.\n\n*The Background Camera's culling mask and target texture will be preserved. \"Perspective Target\" and \"Zero Camera Z Rotation\" take precedence over the copied transform rotation when enabled.")]
        public Camera PropertyMatchCamera = null;
        [Tooltip("If assigned, the Background Camera will rotate to face the given target. This can be used to correct the background perspective of a world space blur effect, which otherwise suffers from distortion as content moves towards the camera periphery.\n\nFor best perspective results, the Blur Effects list should contain only a single Blur Effect, and this Perspective Target should be assigned to the Blur Effect's transform.\n\n\"Grain\" on the Blur Effect should also be set to zero, as the grain will appear to stretch/distort even with this Perspective Target assigned.")]
        public Transform PerspectiveTarget = null;
        [Tooltip("Locks the Background Camera's transform's z-axis rotation at 0 when enabled. Mainly useful in the XR context if the background camera is a child of the XR (i.e. head mounted) camera.")]
        public bool ZeroCameraZRotation = false;

        [Header("Performance")]
        [Tooltip("The background camera will render the target display resolution divided by \"2 ^ DownscaleFactor\".\n\n0 => Full Res\n1 => Half Res\n2 => Quarter Res\nEtc.")]
        [Range(BlurEffect.MinDownscale, BlurEffect.MaxDownscale - 1)]
        public int RenderDownscaleFactor = 0;
        [Tooltip("The automated cadence the background camera should render. This component will also automatically update the blur effects every time the camera renders.")]
        public UpdateFrequency RenderFrequency = UpdateFrequency.FrameInterval;
        [ShowIf(nameof(RenderFrequency), UpdateFrequency.FrameInterval), Min(1), Tooltip("Render every this number of frames. A value of 1 will render on every frame. Only applicable when \"Render Frequency\" is set to \"Frame Interval\".")]
        public int RenderFrameInterval = 1;

        [NonSerialized, HideInInspector]
        private RenderTexture allocatedTexture = null;

        [NonSerialized, HideInInspector]
        private ScreenSpace screenSpace = null;

        private Action onScreenSpaceUpdate = null;
        private Action OnScreenSpaceUpdate
        {
            get
            {
                if (onScreenSpaceUpdate == null)
                {
                    onScreenSpaceUpdate = ScreenSpaceRender;
                }

                return onScreenSpaceUpdate;
            }
        }

        private bool RenderOnUpdate => RenderFrequency == UpdateFrequency.FrameInterval && Time.renderedFrameCount % RenderFrameInterval == 0;

        /// <summary>
        /// Calls Render on the <see cref="BackgroundCamera"/> and tells the list of <see cref="BlurEffects"/> to <see cref="BlurEffect.Reblur"/>.
        /// </summary>
        /// <param name="immediately">
        /// If <c>false</c>, this will queue the request to run after <see cref="ScreenSpace.OnPostCameraSync"/> 
        /// when applicable but will perform the update immediately if the <see cref="ScreenSpace"/> component isn't found.<br/>
        /// If <c>true</c>, this will render and reblur immediately.<br/>
        /// Defaults to <c>false</c>.
        /// </param>
        public void UpdateEffects(bool immediately = false)
        {
            if (immediately)
            {
                RenderAndBlur();
                return;
            }

            if (BackgroundCamera == null)
            {
                return;
            }

            if (BlurEffects == null || BlurEffects.Count == 0)
            {
                return;
            }

            BlurEffect firstEffect = GetFirstEffect();

            if (firstEffect != null)
            {
                if (screenSpace != null)
                {
                    return;
                }

                UIBlock root = firstEffect.UIBlock.Root;

                if (root != null && root.TryGetComponent(out screenSpace) && screenSpace.isActiveAndEnabled)
                {
                    screenSpace.OnPostCameraSync += OnScreenSpaceUpdate;

                    return;
                }
            }

            RenderAndBlur();
        }

        private void OnEnable()
        {
            if (RenderFrequency == UpdateFrequency.ManualOnly || RenderOnUpdate)
            {
                return;
            }

            UpdateEffects();
        }

        private void LateUpdate()
        {
            if (!RenderOnUpdate)
            {
                return;
            }

            UpdateEffects();
        }

        private void OnDisable()
        {
            DequeueRender();

            if (allocatedTexture == null)
            {
                return;
            }

            if (BlurEffects != null)
            {
                for (int i = 0; i < BlurEffects.Count; i++)
                {
                    BlurEffect effect = BlurEffects[i];

                    if (effect == null || effect.InputTexture != allocatedTexture)
                    {
                        continue;
                    }

                    effect.InputTexture = null;
                }
            }

            if (BackgroundCamera != null && BackgroundCamera.targetTexture == allocatedTexture)
            {
                BackgroundCamera.targetTexture = null;
            }

            RenderTexture.ReleaseTemporary(allocatedTexture);
            allocatedTexture = null;
        }

        private void RenderAndBlur()
        {
            EnsureTextureDimensions();

            if (BackgroundCamera == null)
            {
                return;
            }

            Camera cropCamera = null;

            if (PerspectiveTarget != null)
            {
                BackgroundCamera.transform.LookAt(PerspectiveTarget);
                cropCamera = BackgroundCamera;
            }

            if (ZeroCameraZRotation)
            {
                Vector3 eulerAngles = BackgroundCamera.transform.eulerAngles;
                eulerAngles.z = 0;
                BackgroundCamera.transform.eulerAngles = eulerAngles;
            }

            BackgroundCamera.enabled = false;
            BackgroundCamera.Render();

            if (BlurEffects == null)
            {
                return;
            }

            for (int i = 0; i < BlurEffects.Count; ++i)
            {
                BlurEffect effect = BlurEffects[i];

                if (effect == null || !effect.isActiveAndEnabled)
                {
                    continue;
                }

                effect.BlurFrequency = UpdateFrequency.ManualOnly;
                effect.CropCamera = cropCamera != null ? cropCamera : effect.CropCamera;
                effect.InputTexture = BackgroundCamera.targetTexture;
                effect.BlurMode = BlurMode.BackgroundBlur;
                effect.Reblur();
            }
        }

        private void DequeueRender()
        {
            if (screenSpace != null)
            {
                screenSpace.OnPostCameraSync -= OnScreenSpaceUpdate;
            }

            screenSpace = null;
        }

        private void ScreenSpaceRender()
        {
            RenderAndBlur();

            DequeueRender();
        }

        private void EnsureTextureDimensions()
        {
            if (BackgroundCamera == null)
            {
                if (allocatedTexture != null)
                {
                    RenderTexture.ReleaseTemporary(allocatedTexture);
                    allocatedTexture = null;
                }

                return;
            }

            Camera reference = PropertyMatchCamera;
            int baseWidth;
            int baseHeight;

            if (PropertyMatchCamera != null)
            {
                int culling = BackgroundCamera.cullingMask;
                RenderTexture targetTexture = BackgroundCamera.targetTexture;
                BackgroundCamera.CopyFrom(PropertyMatchCamera);
                BackgroundCamera.cullingMask = culling;
                BackgroundCamera.targetTexture = targetTexture;
            }
            else
            {
                BlurEffect blur = GetFirstEffect();

                if (blur != null)
                {
                    reference = BlurEffect.GetReferenceCamera(blur.UIBlock, null, out _);
                }
            }

            if (reference != null)
            {
                baseWidth = reference.pixelWidth;
                baseHeight = reference.pixelHeight;
            }
            else 
            { 
                Display[] displays = Display.displays;

                if (displays == null)
                {
                    return;
                }
                
                Display display = BackgroundCamera.targetDisplay < 0 || BackgroundCamera.targetDisplay >= displays.Length ? Display.main : displays[BackgroundCamera.targetDisplay];

                baseWidth = display.renderingWidth;
                baseHeight = display.renderingHeight;
            }

            int width = Mathf.Max(Mathf.RoundToInt(baseWidth / Mathf.Pow(2, RenderDownscaleFactor)), 1);
            int height = Mathf.Max(Mathf.RoundToInt(baseHeight / Mathf.Pow(2, RenderDownscaleFactor)), 1);

            if (BackgroundCamera.targetTexture != allocatedTexture || (allocatedTexture != null && allocatedTexture.width == width && allocatedTexture.height == height))
            {
                return;
            }

            RenderTexture newlyAllocated = RenderTexture.GetTemporary(width, height, TextureDepth);
            newlyAllocated.name = "Background Content";

            if (allocatedTexture != null)
            {
                Graphics.Blit(allocatedTexture, newlyAllocated);

                RenderTexture.ReleaseTemporary(allocatedTexture);
            }

            allocatedTexture = newlyAllocated;
            BackgroundCamera.targetTexture = allocatedTexture;
        }

        private BlurEffect GetFirstEffect()
        {
            for (int i = 0; i < BlurEffects.Count; ++i)
            {
                BlurEffect effect = BlurEffects[i];

                if (effect != null && effect.isActiveAndEnabled)
                {
                    return effect;
                }
            }

            return null;
        }

        private void Reset()
        {
            if (BlurEffects == null || BlurEffects.Count == 0)
            {
                // See if there's one attached to this object if unassigned
                if (TryGetComponent(out BlurEffect effect))
                {
                    BlurEffects = new List<BlurEffect>() { effect };
                }
            }

            if (BackgroundCamera == null)
            {
                // See if there's one attached to this object if unassigned
                BackgroundCamera = GetComponent<Camera>();
            }
        }
    }
}
