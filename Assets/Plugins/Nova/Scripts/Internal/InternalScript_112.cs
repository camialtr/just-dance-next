// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_4;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova.InternalNamespace_0
{
    internal class InternalType_759<T104> : InternalType_74 where T104 : MonoBehaviour, InternalType_5
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private T104 InternalField_3557;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_754 InternalField_3558 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_75 InternalField_3559 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<uint, InternalType_152<InternalType_94>> InternalField_3560 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_153<uint> InternalField_3561 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<uint, InternalType_78> InternalField_3562 = null;

        public event InternalType_14.InternalType_12 InternalEvent_2 = null;
        public event InternalType_14.InternalType_23 InternalEvent_3 = null;
        public event InternalType_14.InternalType_25 InternalEvent_4 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_74.InternalProperty_1152
        {
            get
            {
                InternalType_754 InternalVar_1 = ((InternalType_74)this).InternalProperty_1150;

                return InternalVar_1 != null && InternalVar_1.InternalProperty_1154;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_74.InternalProperty_1151
        {
            get
            {
                InternalType_754 InternalVar_1 = ((InternalType_74)this).InternalProperty_1150;

                return InternalVar_1 != null && InternalVar_1.InternalProperty_1155;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_754 InternalType_74.InternalProperty_1150 => InternalField_3558 == null || !InternalField_3558.InternalProperty_1153 ? null : InternalField_3558;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_75 InternalType_74.InternalProperty_1149 => InternalField_3559;

        void InternalType_74.InternalMethod_3548(InternalType_75 InternalParameter_3232)
        {
            InternalField_3559 = InternalParameter_3232;
        }

        void InternalType_74.InternalMethod_3549()
        {
            InternalField_3559 = null;
        }

        void InternalType_74.InternalMethod_3551(InternalType_754 InternalParameter_3233)
        {
            InternalField_3558 = InternalParameter_3233;
        }

        void InternalType_74.InternalMethod_3552()
        {
            InternalField_3558 = null;
        }

        void InternalType_74.InternalMethod_467(InternalType_78 InternalParameter_327)
        {
            if (InternalField_3560 == null || InternalField_3562 == null)
            {
                return;
            }

            InternalType_14.InternalType_13 InternalVar_1 = InternalType_14.InternalMethod_191(InternalField_3557, InternalParameter_327);

            if (!InternalField_3560.TryGetValue(InternalParameter_327.InternalField_257, out InternalType_152<InternalType_94> InternalVar_2) || !InternalVar_2.InternalProperty_220)
            {
                InternalEvent_4?.Invoke(ref InternalVar_1);

                return;
            }

            InternalType_169<InternalType_94>.InternalMethod_821(InternalVar_2);

            if (InternalField_3562.Remove(InternalParameter_327.InternalField_257))
            {
                InternalField_3561.Remove(InternalParameter_327.InternalField_257);
            }

            InternalField_3560.Remove(InternalParameter_327.InternalField_257);

            InternalEvent_4?.Invoke(ref InternalVar_1);
        }

        void InternalType_74.InternalMethod_468()
        {
            if (InternalField_3562 == null)
            {
                return;
            }

            InternalType_521<uint> InternalVar_1 = InternalField_3561.InternalProperty_221;

            while (InternalVar_1.InternalProperty_433 > 0)
            {
                uint InternalVar_2 = InternalVar_1[InternalVar_1.InternalProperty_433 - 1];

                ((InternalType_74)this).InternalMethod_467(InternalField_3562[InternalVar_2]);
            }
        }

        bool InternalType_74.InternalMethod_463<TInput>()
        {

            Type InternalVar_1 = typeof(TInput);

            if (InternalVar_1 == typeof(bool))
            {
                return InternalEvent_2 != null;
            }

            if (InternalVar_1 == typeof(InternalType_755<Vector3>))
            {
                return InternalEvent_3 != null;
            }

            return false;
        }

        void InternalType_74.InternalMethod_466<TInput>(InternalType_78 InternalParameter_325, InternalType_76<TInput>? InternalParameter_326)
        {
            if (InternalField_3560 == null)
            {
                InternalField_3560 = new Dictionary<uint, InternalType_152<InternalType_94>>(1);
                InternalField_3562 = new Dictionary<uint, InternalType_78>(1);
                InternalField_3561 = new InternalType_153<uint>(1);
            }

            InternalType_76<TInput>? InternalVar_1 = null;

            uint InternalVar_2 = InternalParameter_325.InternalField_257;

            if (InternalField_3560.TryGetValue(InternalVar_2, out InternalType_152<InternalType_94> InternalVar_3) && InternalVar_3.InternalProperty_220)
            {
                if (InternalType_169<InternalType_94>.InternalType_171<InternalType_76<TInput>>.InternalMethod_826(InternalVar_3, out InternalType_76<TInput> InternalVar_4))
                {
                    if (InternalParameter_326.Value == InternalVar_4)
                    {
                        return;
                    }

                    InternalVar_1 = InternalVar_4;

                    InternalType_169<InternalType_94>.InternalType_171<InternalType_76<TInput>>.InternalMethod_824(InternalVar_3);
                }
                else
                {
                    InternalType_169<InternalType_94>.InternalMethod_821(InternalVar_3);
                }
            }
            else if (!InternalParameter_326.HasValue)
            {
                return;
            }

            if (InternalParameter_326.HasValue)
            {
                InternalField_3560[InternalVar_2] = InternalType_169<InternalType_94>.InternalType_171<InternalType_76<TInput>>.InternalMethod_823(InternalParameter_326.Value);
                InternalField_3561.Add(InternalVar_2);
                InternalField_3562[InternalVar_2] = InternalParameter_325;
            }
            else
            {
                InternalField_3562.Remove(InternalVar_2);
                InternalField_3561.Remove(InternalVar_2);
                InternalField_3560[InternalVar_2] = InternalType_152<InternalType_94>.InternalField_441;
            }


            Type InternalVar_5 = typeof(TInput);

            if (InternalVar_5 == typeof(bool))
            {
                InternalType_76<bool>? InternalVar_6 = null;
                InternalType_76<bool>? InternalVar_7 = null;

                if (InternalVar_1.HasValue)
                {
                    _ = InternalVar_1.Value.InternalMethod_474(out InternalVar_6);
                }

                if (InternalParameter_326.HasValue)
                {
                    _ = InternalParameter_326.Value.InternalMethod_474(out InternalVar_7);
                }

                InternalType_14.InternalType_16<bool> InternalVar_8 = InternalType_14.InternalMethod_188(InternalField_3557, InternalVar_6, InternalVar_7, InternalParameter_325);
                InternalEvent_2?.Invoke(ref InternalVar_8);

                return;
            }

            if (InternalVar_5 == typeof(InternalType_755<Vector3>))
            {
                InternalType_76<InternalType_755<Vector3>>? InternalVar_6 = null;
                InternalType_76<InternalType_755<Vector3>>? InternalVar_7 = null;

                if (InternalVar_1.HasValue)
                {
                    _ = InternalVar_1.Value.InternalMethod_474(out InternalVar_6);
                }

                if (InternalParameter_326.HasValue)
                {
                    _ = InternalParameter_326.Value.InternalMethod_474(out InternalVar_7);
                }

                InternalType_14.InternalType_16<InternalType_755<Vector3>> InternalVar_8 = InternalType_14.InternalMethod_188(InternalField_3557, InternalVar_6, InternalVar_7, InternalParameter_325);
                InternalEvent_3?.Invoke(ref InternalVar_8);

                return;
            }
        }

        InternalType_76<TInput>? InternalType_74.InternalMethod_464<TInput>(uint contextID)
        {
            if (InternalField_3560 != null && InternalField_3560.TryGetValue(contextID, out InternalType_152<InternalType_94> InternalVar_1) && InternalVar_1.InternalProperty_220)
            {
                return InternalType_169<InternalType_94>.InternalType_171<InternalType_76<TInput>>.InternalMethod_825(InternalVar_1);
            }

            return null;
        }

        bool InternalType_74.InternalMethod_465(uint InternalParameter_323, out InternalType_78 InternalParameter_324)
        {
            if (InternalField_3562 == null)
            {
                InternalParameter_324 = default;
                return false;
            }

            return InternalField_3562.TryGetValue(InternalParameter_323, out InternalParameter_324);
        }

        public InternalType_759(T104 InternalParameter_3336)
        {
            this.InternalField_3557 = InternalParameter_3336;
        }
    }
}
