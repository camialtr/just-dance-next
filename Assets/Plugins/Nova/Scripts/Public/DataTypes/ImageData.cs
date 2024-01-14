// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Specifies how the Nova Engine should store and attempt to batch a given texture.
    /// </summary>
    /// <seealso cref="UIBlock2D.ImagePackMode"/>
    /// <seealso cref="NovaSettings.PackedImagesEnabled"/>
    public enum ImagePackMode
    {
        /// <summary>
        /// Store the texture by itself. Useful if the underlying texture's content changes regularly (such as for a video player) or
        /// if <see cref="Packed"/> causes visual artifacts. An unpacked texture will be rendered in its own draw call.
        /// </summary>
        Unpacked = InternalNamespace_0.InternalType_695.InternalField_2939,
        /// <summary>
        /// Store the texture with other compatible textures (compatible being determined by texture format, mips, dimensions, etc.).<br/>
        /// Packed textures can be batched, potentially leading to <i>many</i> fewer draw calls than if all textures were <see cref="Unpacked"/>.
        /// </summary>
        Packed = InternalNamespace_0.InternalType_695.InternalField_2831,
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct InternalType_38 : IEquatable<InternalType_38>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_133;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_86
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalField_133 != -1;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly InternalType_38 InternalField_134 = new InternalType_38()
        {
            InternalField_133 = -1,
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InternalType_38(InternalNamespace_0.InternalType_103 InternalParameter_221) => new InternalType_38()
        {
            InternalField_133 = InternalParameter_221,
        };

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator InternalNamespace_0.InternalType_103(InternalType_38 InternalParameter_222) => InternalParameter_222.InternalField_133;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(InternalType_38 other) => InternalField_133 == other.InternalField_133;
    }

    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct InternalType_39
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ImageAdjustment Adjustment;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ImagePackMode Mode;
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_38 InternalField_135;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly InternalType_39 InternalField_136 = new InternalType_39()
        {
            Adjustment = ImageAdjustment.InternalField_60,
            InternalField_135 = InternalType_38.InternalField_134,
            Mode = ImagePackMode.Packed,
        };
    }
}