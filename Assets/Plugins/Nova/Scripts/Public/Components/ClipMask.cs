// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_10;
using System;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Clips the rendered bounds of a <see cref="UIBlock"/> hierarchy to a rounded-corner rectangle or custom texture.
    /// Supports applying a color <see cref="Tint">tint</see> or fade to the <see cref="UIBlock"/> hierarchy as well.
    /// </summary>
    /// <remarks>
    /// Clipping can be performed via a <see cref="ClipMask.Mask">mask</see> texture or using the rectangular bounds of the
    /// <see cref="UIBlock"/> on this gameobject. If the attached <see cref="UIBlock"/> is a <see cref="UIBlock2D"/>, the <see cref="ClipMask"/>
    /// defaults to clipping to the rounded-corner rectangle bounds matching the <see cref="UIBlock2D"/>'s <see cref="UIBlock2D.CornerRadius">Corner Radius</see>.
    /// </remarks>
    [AddComponentMenu("Nova/Clip Mask")]
    [DisallowMultipleComponent]
    [ExecuteAlways]
    [HelpURL("https://novaui.io/manual/ClipMasks.html")]
    [RequireComponent(typeof(UIBlock))]
    public sealed class ClipMask : MonoBehaviour
    {
        #region Public
        /// <summary>
        /// The tint color applied to this <see cref="UIBlock"/> and its descendants.<br/>
        /// The tint is applied multiplicatively: <c>finalRenderedColor *= Tint</c>.<br/>
        /// Adjust <c>Tint.a</c> (alpha) to apply a fade. Set <c>Tint</c> to <c>Color.white</c> if no tint is desired.
        /// </summary>
        public Color Tint
        {
            get => info.Color;
            set
            {
                if (info.Color == value)
                {
                    return;
                }

                info.Color = value;
                InternalMethod_299();
            }
        }

        /// <summary>
        /// Enables or disables clipping. Can be used to make the <see cref="ClipMask"/> exclusively apply a <see cref="Tint">Tint</see>.
        /// </summary>
        /// <seealso cref="Tint"/>
        public bool Clip
        {
            get => info.Clip;
            set
            {
                if (info.Clip == value)
                {
                    return;
                }

                info.Clip = value;
                InternalMethod_299();
            }
        }

        /// <summary>
        /// The texture to use as a mask when <c><see cref="Clip">Clip</see> == true</c>. Clip shape defaults to a rectangle or a rounded-corner rectangle,
        /// depending on the <see cref="UIBlock"/> attached to <c>this.gameObject</c>, when <c>Mask == null</c>.
        /// </summary>
        /// <seealso cref="ClipMask"/>
        public Texture Mask
        {
            get => maskTexture;
            set
            {
                if (maskTexture == value)
                {
                    return;
                }
                maskTexture = value;
                InternalMethod_299();
            }
        }

        /// <summary>
        /// The <see cref="Nova.UIBlock"/> on <c>this.gameObject</c>.
        /// </summary>
        public UIBlock UIBlock
        {
            get
            {
                if (InternalField_3039 == null)
                {
                    InternalField_3039 = GetComponent<UIBlock>();
                }

                return InternalField_3039;
            }
        }
        #endregion

        #region Internal
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3039 = null;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_37 info = InternalType_37.InternalField_132;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Texture maskTexture = null;

        internal void InternalMethod_299()
        {
            if (!UIBlock.InternalProperty_25 || !enabled)
            {
                return;
            }

            info.InternalField_131 = maskTexture != null;

            InternalType_274.InternalProperty_190.InternalField_874.InternalMethod_1498(UIBlock.InternalProperty_29, UnsafeUtility.As<InternalType_37, InternalNamespace_0.InternalType_109>(ref info), maskTexture);
        }

        private void InternalMethod_300(InternalType_131 InternalParameter_216)
        {
            if (InternalType_274.InternalProperty_190 == null)
            {
                return;
            }

            InternalType_274.InternalProperty_190.InternalField_874.InternalMethod_1499(InternalParameter_216);
        }

        private void OnEnable()
        {
            UIBlock.InternalMethod_116();
            InternalMethod_299();
        }

        private void OnDisable()
        {
            InternalMethod_300(UIBlock.InternalProperty_29);

            if (NovaApplication.IsEditor)
            {
                InternalType_131 InternalVar_1 = UIBlock.InternalProperty_29;
                NovaApplication.EditorDelayCall += () =>
                {
                    if (this == null)
                    {
                        InternalMethod_300(InternalVar_1);
                    }
                };
            }
        }

        
        [Obfuscation]
        private void OnDidApplyAnimationProperties()
        {
            InternalMethod_299();
        }
        #endregion
    }
}

