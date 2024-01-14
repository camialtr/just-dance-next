// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0;
using System;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Access point for Nova settings.
    /// </summary>
    [ExcludeFromPreset]
    public sealed class NovaSettings : ScriptableObject, InternalType_26
    {
        internal static event Action InternalEvent_0;

        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_41 settings = InternalType_41.InternalField_140;

        #region 
        event Action InternalType_26.InternalEvent_7
        {
            add
            {
                InternalEvent_0 += value;
            }
            remove
            {
                InternalEvent_0 -= value;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalType_26.InternalProperty_226 => EdgeSoftenWidth;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalType_26.InternalProperty_943 => UIBlock3DEdgeDivisions;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalType_26.InternalProperty_944 => UIBlock3DCornerDivisions;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_26.InternalProperty_946 => PackedImagesEnabled;
        #endregion

        #region 
        /// <summary>
        /// Enables or disables specific warnings that may be logged by Nova.
        /// </summary>
        public static LogFlags LogFlags
        {
            get => InternalProperty_89.settings.LogFlags;
            set
            {
                InternalProperty_89.settings.LogFlags = value;
                InternalProperty_89.InternalMethod_1972(false);
            }
        }

        /// <summary>
        /// Can be used to globally disable <see cref="ImagePackMode.Packed">Packed</see> images.
        /// </summary>
        /// <seealso cref="ImagePackMode"/>
        public static bool PackedImagesEnabled
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.PackedImagesEnabled;
            set
            {
                if (InternalProperty_89.settings.PackedImagesEnabled == value)
                {
                    return;
                }
                InternalProperty_89.settings.PackedImagesEnabled = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// How to copy <see cref="ImagePackMode.Packed">Packed</see> images. See <see cref="Nova.PackedImageCopyMode"/> for more info.
        /// </summary>
        public static PackedImageCopyMode PackedImageCopyMode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.PackedImageCopyMode;
            set
            {
                if (InternalProperty_89.settings.PackedImageCopyMode == value)
                {
                    return;
                }
                InternalProperty_89.settings.PackedImageCopyMode = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// Enables/disables super sampling of text, which can drastically reduce "shimmering" artifacts on text on certain platforms (such as VR).
        /// </summary>
        public static bool SuperSampleText
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.SuperSampleText;
            set
            {
                if (InternalProperty_89.settings.SuperSampleText == value)
                {
                    return;
                }
                InternalProperty_89.settings.SuperSampleText = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The width (in pixels) of the anti-aliasing (edge softening) performed at <see cref="UIBlock2D"/> and <see cref="ClipMask"/> boundaries.
        /// Edge softening can also be disabled per-<see cref="UIBlock2D"/> using <see cref="UIBlock2D.SoftenEdges"/>.
        /// </summary>
        public static float EdgeSoftenWidth
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.EdgeSoftenWidth;
            set
            {
                if (InternalProperty_89.settings.EdgeSoftenWidth == value)
                {
                    return;
                }
                InternalProperty_89.settings.EdgeSoftenWidth = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The number of divisions on the <see cref="UIBlock3D"/> mesh when applying the <see cref="UIBlock3D.CornerRadius"/> property.
        /// A larger value leads to a higher quality mesh, but the mesh will contain more vertices.
        /// </summary>
        public static int UIBlock3DCornerDivisions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.UIBlock3DCornerDivisions;
            set
            {
                if (InternalProperty_89.settings.UIBlock3DCornerDivisions == value)
                {
                    return;
                }
                InternalProperty_89.settings.UIBlock3DCornerDivisions = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The number of divisions on the <see cref="UIBlock3D"/> mesh when applying the <see cref="UIBlock3D.EdgeRadius"/> property.
        /// A larger value leads to a higher quality mesh, but the mesh will contain more vertices.
        /// </summary>
        public static int UIBlock3DEdgeDivisions
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalProperty_89.settings.UIBlock3DEdgeDivisions;
            set
            {
                if (InternalProperty_89.settings.UIBlock3DEdgeDivisions == value)
                {
                    return;
                }
                InternalProperty_89.settings.UIBlock3DEdgeDivisions = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The lighting models to include in builds for <see cref="UIBlock2D"/>. If a lighting model is not included in a build but a <see cref="UIBlock"/> 
        /// tries to use it, the block will fall back to <see cref="LightingModel.Unlit"/>.
        /// </summary>
        public static LightingModelBuildFlag UIBlock2DLightingModels
        {
            get => InternalProperty_89.settings.UIBlock2DLightingModels;
            set
            {
                InternalProperty_89.settings.UIBlock2DLightingModels = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The lighting models to include in builds for <see cref="UIBlock3D"/>. If a lighting model is not included in a build but a <see cref="UIBlock"/> 
        /// tries to use it, the block will fall back to <see cref="LightingModel.Unlit"/>.
        /// </summary>
        public static LightingModelBuildFlag UIBlock3DLightingModels
        {
            get => InternalProperty_89.settings.UIBlock3DLightingModels;
            set
            {
                InternalProperty_89.settings.UIBlock3DLightingModels = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }

        /// <summary>
        /// The lighting models to include in builds for <see cref="TextBlock"/>. If a lighting model is not included in a build but a <see cref="UIBlock"/> 
        /// tries to use it, the block will fall back to <see cref="LightingModel.Unlit"/>.
        /// </summary>
        public static LightingModelBuildFlag TextBlockLightingModels
        {
            get => InternalProperty_89.settings.TextBlockLightingModels;
            set
            {
                InternalProperty_89.settings.TextBlockLightingModels = value;
                InternalProperty_89.InternalMethod_1972(true);
            }
        }
        #endregion

        #region 
        /// <summary>
        /// The Nova button control prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock ButtonPrefab = null;
        /// <summary>
        /// The Nova toggle control prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock TogglePrefab = null;
        /// <summary>
        /// The Nova slider control prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock SliderPrefab = null;
        /// <summary>
        /// The Nova dropdown control prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock DropdownPrefab = null;
        /// <summary>
        /// The Nova text field prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock TextFieldPrefab = null;
        /// <summary>
        /// The Nova scroll view prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock ScrollViewPrefab = null;
        /// <summary>
        /// The Nova UI root prefab to instantiate in editor from the GameObject menu (and right-click in hierarchy window).
        /// </summary>
        public UIBlock UIRootPrefab = null;
        #endregion

        internal void InternalMethod_1972(bool InternalParameter_1470, bool InternalParameter_1331 = true)
        {
            InternalNamespace_0.InternalType_24.InternalProperty_945 = UnsafeUtility.As<InternalType_41, InternalNamespace_0.InternalType_115>(ref InternalField_139.settings);

            if (InternalParameter_1470)
            {
                InternalEvent_0?.Invoke();
            }

            if (InternalParameter_1331)
            {
                NovaApplication.MarkDirty(this);
            }
        }

        #region 
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static bool InternalProperty_88 => InternalField_139 == null ? InternalMethod_315() : true;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static NovaSettings InternalField_139 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static NovaSettings InternalProperty_89
        {
            get
            {
                if (InternalField_139 == null && !InternalMethod_315())
                {
                    throw new Exception("Failed to load Nova settings. Please ensure Nova was imported correctly.");
                }
                return InternalField_139;
            }
        }

        private static bool InternalMethod_315()
        {
            NovaSettings[] InternalVar_1 = Resources.FindObjectsOfTypeAll<NovaSettings>();
            if (InternalVar_1.Length != 0)
            {
                InternalField_139 = InternalVar_1[0];
            }
            else
            {
                InternalField_139 = Resources.Load<NovaSettings>("NovaSettings");
            }

            if (InternalField_139 != null)
            {
                InternalField_139.InternalMethod_1972(true);
            }

            return InternalField_139 != null;
        }
        #endregion
    }
}

