// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Lighting models (as a mask) to include in builds.
    /// </summary>
    /// <seealso cref="NovaSettings.UIBlock2DLightingModels"/>
    /// <seealso cref="NovaSettings.UIBlock3DLightingModels"/>
    /// <seealso cref="NovaSettings.TextBlockLightingModels"/>
    [Flags]
    public enum LightingModelBuildFlag : int
    {
        /// <summary>
        /// Don't include any shaders.
        /// </summary>
        None = InternalNamespace_0.InternalType_105.InternalField_328,
        /// <summary>
        /// Include <see cref="LightingModel.Unlit"/> shaders.
        /// </summary>
        Unlit = InternalNamespace_0.InternalType_105.InternalField_2253,
        /// <summary>
        /// Include shaders for the <see cref="LightingModel.Lambert"/> lighting model.
        /// </summary>
        Lambert = InternalNamespace_0.InternalType_105.InternalField_329,
        /// <summary>
        /// Include shaders for the <see cref="LightingModel.BlinnPhong"/> lighting model.
        /// </summary>
        BlinnPhong = InternalNamespace_0.InternalType_105.InternalField_330,
        /// <summary>
        /// Include shaders for the <see cref="LightingModel.Standard"/> lighting model.
        /// </summary>
        Standard = InternalNamespace_0.InternalType_105.InternalField_331,
        /// <summary>
        /// Include shaders for the <see cref="LightingModel.StandardSpecular"/> lighting model.
        /// </summary>
        StandardSpecular = InternalNamespace_0.InternalType_105.InternalField_332,
    }

    /// <summary>
    /// Certain, older versions of the Nvidia OpenGL driver for certain graphics cards crash
    /// when trying to copy a texture to a texture array when the texture is compressed with a 
    /// block-based format and has a mip-map with dimensions which are not a multiple of the block size.
    /// This enum configures how to copy such textures.
    /// </summary>
    public enum PackedImageCopyMode : int
    {
        /// <summary>
        /// Copy the texture without checking if all mip levels are multiples of block size.
        /// </summary>
        Blind = InternalNamespace_0.InternalType_499.InternalField_2481,
        /// <summary>
        /// Skip copying mip-levels when the dimensions are not a multiple of block size. You should only use this
        /// if you encounter issues.
        /// </summary>
        Skip = InternalNamespace_0.InternalType_499.InternalField_2478,
    }

    /// <summary>
    /// Warnings which can be disabled or enabled.
    /// </summary>
    /// <seealso cref="NovaSettings.LogFlags"/>
    [Flags]
    public enum LogFlags : int
    {
        /// <summary>
        /// Don't log any warnings.
        /// </summary>
        None = InternalNamespace_0.InternalType_116.InternalField_378,
        /// <summary>
        /// Log whenever an issue is encountered that prevents <see cref="ImagePackMode.Packed"/> images from working 
        /// (which will causes all images to fallback to <see cref="ImagePackMode.Unpacked"/>).
        /// </summary>
        PackedImageFailure = InternalNamespace_0.InternalType_116.InternalField_2767,
        /// <summary>
        /// Log when an unsupported TMP shader is used (which will cause the <see cref="TextBlock"/> to fallback to 
        /// <c>Mobile/Distance Field</c>).
        /// </summary>
        UnsupportedTextShader = InternalNamespace_0.InternalType_116.InternalField_380,
        /// <summary>
        /// Log when a <see cref="UIBlock"/> uses a <see cref="LightingModel"/> which has not been marked 
        /// to be included in builds via <see cref="NovaSettings.UIBlock2DLightingModels"/>, 
        /// <see cref="NovaSettings.UIBlock3DLightingModels"/>, or <see cref="NovaSettings.TextBlockLightingModels"/> 
        /// (depending on <see cref="UIBlock"/> type).
        /// </summary>
        LightingModelNotIncludedInBuild = InternalNamespace_0.InternalType_116.InternalField_381,
        /// <summary>
        /// Log when a child of a <see cref="ListView"/> is destroyed out from under it.
        /// </summary>
        ListViewItemDestroyed = InternalNamespace_0.InternalType_116.InternalField_2333,
        /// <summary>
        /// Log when <see cref="ListView"/> has children under it that it is not tracking.
        /// </summary>
        ListViewUntrackedItemsUnderRoot = InternalNamespace_0.InternalType_116.InternalField_2332,
    }

    
    [StructLayoutAttribute(LayoutKind.Sequential)]
    [Serializable]
    internal struct InternalType_41
    {
        #region 
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LogFlags LogFlags;
        #endregion

        #region 
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool PackedImagesEnabled;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public PackedImageCopyMode PackedImageCopyMode;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool SuperSampleText;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float EdgeSoftenWidth;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int UIBlock3DCornerDivisions;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int UIBlock3DEdgeDivisions;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LightingModelBuildFlag UIBlock2DLightingModels;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LightingModelBuildFlag TextBlockLightingModels;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LightingModelBuildFlag UIBlock3DLightingModels;
        #endregion

        #region 
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int ClickFrameDeltaThreshold;
        #endregion


        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly InternalType_41 InternalField_140 = new InternalType_41()
        {
            LogFlags = (LogFlags)(-1),
            PackedImagesEnabled = true,
            PackedImageCopyMode = PackedImageCopyMode.Blind,
            SuperSampleText = false,
            EdgeSoftenWidth = 1f,
            UIBlock3DCornerDivisions = 8,
            UIBlock3DEdgeDivisions = 8,
            UIBlock2DLightingModels = LightingModelBuildFlag.Unlit,
            TextBlockLightingModels = LightingModelBuildFlag.Unlit,
            UIBlock3DLightingModels = LightingModelBuildFlag.Lambert,
            ClickFrameDeltaThreshold = 1,
        };
    }
}
