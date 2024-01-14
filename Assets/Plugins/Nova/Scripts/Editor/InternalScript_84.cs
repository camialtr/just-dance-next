// Copyright (c) Supernova Technologies LLC
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.Events;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal class InternalType_715 : BaseAnimValueNonAlloc<Bounds>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3276 = 0.01f;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Matrix4x4 InternalField_3277;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Matrix4x4 InternalField_3278;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Matrix4x4 InternalField_3279;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Matrix4x4 InternalProperty_1020
        {
            get
            {
                return InternalField_3278;
            }
            set
            {
                InternalField_3278 = value;
                InternalField_3279 = value.inverse;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float InternalProperty_1021 => lerpPosition;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalProperty_1022 => InternalProperty_1023.MultiplyPoint(start.center);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Matrix4x4 InternalProperty_1023 => InternalField_3279 * InternalField_3277;

        public InternalType_715(Bounds InternalParameter_2912, Matrix4x4 InternalParameter_2913, UnityAction InternalParameter_2914) : base(InternalParameter_2912, InternalParameter_2914)
        {
            InternalField_3277 = InternalParameter_2913;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public new bool isAnimating
        {
            get
            {
                Bounds InternalVar_1 = GetValue();

                if ((target.size - InternalVar_1.size).magnitude <= InternalField_3276 &&
                    (target.center - InternalVar_1.center).magnitude <= InternalField_3276)
                {
                    return false;
                }

                return base.isAnimating;
            }
        }

        protected override bool AreEqual(Bounds a, Bounds b)
        {
            return base.AreEqual(a, b) && InternalField_3278.Equals(InternalField_3277);
        }

        protected override Bounds GetValue()
        {
            Vector3 InternalVar_1 = Vector3.Lerp(InternalProperty_1022, target.center, lerpPosition);
            Vector3 InternalVar_2 = Vector3.Lerp(start.size, target.size, lerpPosition);

            return new Bounds(InternalVar_1, InternalVar_2);
        }

        public void Reset()
        {
            BeginAnimating(target, start);
        }
    }
}
