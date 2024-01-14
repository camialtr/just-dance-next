// Copyright (c) Supernova Technologies LLC
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    [Obfuscation]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct CalculatedLayout
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Length3.Calculated Size;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Length3.Calculated Position;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LengthBounds.Calculated Padding;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public LengthBounds.Calculated Margin;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 PaddedSize => Size.Value - Padding.Size;
    }
}
