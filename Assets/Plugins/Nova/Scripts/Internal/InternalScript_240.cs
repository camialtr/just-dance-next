// Copyright (c) Supernova Technologies LLC
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    internal struct InternalType_10 : IEquatable<InternalType_10>
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Color Color;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Length CornerRadius;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Length EdgeRadius;

        public static bool operator ==(InternalType_10 InternalParameter_90, InternalType_10 InternalParameter_91)
        {
            return
                InternalParameter_90.Color.Equals(InternalParameter_91.Color) &&
                InternalParameter_90.CornerRadius.Equals(InternalParameter_91.CornerRadius) &&
                InternalParameter_90.EdgeRadius.Equals(InternalParameter_91.EdgeRadius);
        }
        public static bool operator !=(InternalType_10 InternalParameter_92, InternalType_10 InternalParameter_93) => !(InternalParameter_93 == InternalParameter_92);

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Color.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + CornerRadius.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + EdgeRadius.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is InternalType_10 asType)
            {
                return this == asType;
            }

            return false;
        }

        public bool Equals(InternalType_10 other) => this == other;

        internal Calculated InternalMethod_153(Vector3 InternalParameter_94)
        {
            return new Calculated(ref CornerRadius, ref EdgeRadius, ref InternalParameter_94);
        }

        [Obfuscation]
        internal readonly struct Calculated
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length.Calculated CornerRadius;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length.Calculated EdgeRadius;

            public Calculated(ref Length cornerRadius, ref Length edgeRadius, ref Vector3 size)
            {
                float InternalVar_1 = 0.5f * Mathf.Min(size.x, size.y);
                var InternalVar_2 = new InternalNamespace_0.InternalType_45.InternalType_47(cornerRadius.InternalMethod_1(), new InternalNamespace_0.InternalType_45.InternalType_46()
                {
                    InternalField_148 = 0f,
                    InternalField_149 = InternalVar_1
                }, InternalVar_1);
                CornerRadius = InternalVar_2.InternalMethod_18();

                float InternalVar_3 = Mathf.Min(CornerRadius.Value, 0.5f * size.z);
                var InternalVar_4 = new InternalNamespace_0.InternalType_45.InternalType_47(edgeRadius.InternalMethod_1(), new InternalNamespace_0.InternalType_45.InternalType_46()
                {
                    InternalField_148 = 0f,
                    InternalField_149 = InternalVar_3
                }, InternalVar_3);
                EdgeRadius = InternalVar_4.InternalMethod_18();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly InternalType_10 InternalField_62 = new InternalType_10()
        {
            Color = Color.grey,
            CornerRadius = Length.Zero,
            EdgeRadius = Length.Zero,
        };
    }
}