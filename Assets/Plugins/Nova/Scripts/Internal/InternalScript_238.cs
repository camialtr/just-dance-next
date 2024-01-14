// Copyright (c) Supernova Technologies LLC
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using UnityEngine;

namespace Nova
{
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct InternalType_8
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Color Color;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Length CornerRadius;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public RadialFill RadialFill;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public RadialGradient Gradient;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Border Border;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Shadow Shadow;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_39 Image;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool SoftenEdges;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool FillEnabled;

        internal Calculated InternalMethod_148(Vector2 InternalParameter_89)
        {
            return new Calculated(this, InternalParameter_89);
        }

        [Obfuscation]
        internal readonly struct Calculated
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length.Calculated CornerRadius;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Border.Calculated Border;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly RadialGradient.Calculated Gradient;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Shadow.Calculated Shadow;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly RadialFill.Calculated RadialFill;

            internal Calculated(InternalType_8 data, Vector2 relativeTo)
            {
                float InternalVar_1 = math.cmin(relativeTo) * 0.5f;

                var InternalVar_2 = new InternalNamespace_0.InternalType_45.InternalType_47(data.CornerRadius.InternalMethod_1(), InternalNamespace_0.InternalType_45.InternalType_46.InternalField_151, InternalVar_1);
                CornerRadius = InternalVar_2.InternalMethod_18();

                Border = data.Border.InternalMethod_146(InternalVar_1);
                Gradient = data.Gradient.InternalMethod_145(relativeTo);
                Shadow = data.Shadow.InternalMethod_147(relativeTo);
                RadialFill = data.RadialFill.InternalMethod_2153(relativeTo);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly InternalType_8 InternalField_61 = new InternalType_8()
        {
            Color = Color.grey,
            CornerRadius = Length.Zero,
            RadialFill = RadialFill.InternalField_3393,
            Border = Border.InternalField_58,
            Shadow = Shadow.InternalField_59,
            Gradient = RadialGradient.InternalField_57,
            Image = InternalType_39.InternalField_136,
            SoftenEdges = true,
            FillEnabled = true,
        };
    }
}