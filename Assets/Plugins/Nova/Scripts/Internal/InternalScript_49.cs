// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_8;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Nova
{
    internal interface InternalType_1
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalProperty_0 { get; }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalProperty_1 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalProperty_2 { get; }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalProperty_3 { get; }
        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalProperty_4 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalProperty_5 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalProperty_6 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalProperty_1081 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalProperty_549 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalProperty_548 { get; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float OutOfViewDistance { get; }

        void Scroll(float delta);
        void JumpToIndex(int index);
        float JumpToIndexPage(int index);
        void InternalMethod_42();
        InternalType_66 InternalMethod_43(bool InternalParameter_36, float InternalParameter_37);
        bool InternalMethod_2317(bool InternalParameter_2723);
        bool InternalMethod_45(float InternalParameter_39);
        bool InternalMethod_867(int InternalParameter_171, out InternalType_5 InternalParameter_170);
        bool InternalMethod_868(InternalType_5 InternalParameter_764, out int InternalParameter_751);
        bool InternalMethod_881(int InternalParameter_752, out InternalType_5 InternalParameter_767);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_521<InternalType_131> InternalProperty_9 { get; }
    }

    internal class InternalType_2 : System.IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_1 InternalField_15 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_16 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_17 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_18 = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_218 InternalField_19;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private unsafe static InternalType_735<InternalType_175> InternalField_20;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private NovaHashMap<InternalType_131, InternalType_217> InternalField_21;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private HashSet<InternalType_131> InternalField_22 = new HashSet<InternalType_131>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private HashSet<InternalType_131> InternalField_23 = new HashSet<InternalType_131>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_10 => (float3)InternalField_24.InternalField_26;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_11 { get; private set; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_3 InternalField_24 = default;

        public void InternalMethod_50()
        {
            _ = InternalMethod_52(0, ref InternalField_24);
        }

        public void InternalMethod_51(float InternalParameter_40)
        {
            if (!InternalMethod_52(InternalParameter_40, ref InternalField_24))
            {
                return;
            }

            InternalField_18 = true;

            InternalField_16.AutoLayout.Offset = InternalMethod_53(ref InternalField_24);

            InternalField_18 = false;
        }

        private bool InternalMethod_52(float InternalParameter_41, ref InternalType_3 InternalParameter_42)
        {
            if (!InternalField_17)
            {
                Debug.LogError("Attempting to scroll before processor is initialized.");
                return false;
            }

            AutoLayout InternalVar_1 = InternalField_16.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return false;
            }

            float InternalVar_3 = InternalField_16.InternalProperty_18[InternalVar_2];
            float InternalVar_4 = InternalField_16.InternalProperty_19[InternalVar_2];

            float InternalVar_5 = InternalField_16.InternalProperty_18[InternalVar_2] - (float)InternalField_24.InternalField_26[InternalVar_2];
            float InternalVar_6 = InternalField_16.InternalProperty_19[InternalVar_2] - InternalProperty_11[InternalVar_2];

            int InternalVar_7 = (int)math.sign(InternalParameter_41);

            if (InternalVar_7 == 0)
            {
                float InternalVar_8 = InternalField_16.CalculatedSize.Value[InternalVar_2];
                if (InternalVar_3 <= InternalVar_8)
                {
                    InternalVar_7 = InternalVar_4 == 0 ? -1 : (int)math.sign(InternalVar_4);
                }
                else 
                {
                    InternalVar_7 = (int)math.sign(InternalType_187.InternalMethod_882(InternalVar_6 - 0.5f * InternalVar_5));
                }
            }

            InternalParameter_42 = new InternalType_3(ref InternalVar_1, InternalField_16.InternalProperty_18, InternalParameter_41, InternalField_16.CalculatedSpacing.Value, InternalVar_7, InternalVar_2);
            InternalProperty_11 = InternalField_16.InternalProperty_19;

            if (InternalField_18 || InternalVar_7 == 0)
            {
                return false;
            }

            InternalField_19.InternalField_571 = InternalField_15.OutOfViewDistance;
            InternalField_19.InternalField_575 = InternalParameter_41;
            InternalField_19.InternalField_573 = InternalVar_2;
            InternalField_19.InternalField_574 = InternalVar_7;
            InternalField_19.InternalField_3362 = InternalVar_1.Alignment;

            unsafe
            {
                InternalField_20.InternalField_3352.Invoke(UnsafeUtility.AddressOf(ref InternalField_19));
            }

            return true;
        }

        private float InternalMethod_53(ref InternalType_3 InternalParameter_43)
        {
            InternalMethod_56(ref InternalParameter_43);

            return InternalMethod_54(ref InternalParameter_43);
        }

        private float InternalMethod_54(ref InternalType_3 InternalParameter_44)
        {
            InternalField_15.InternalMethod_42();

            double InternalVar_1 = InternalParameter_44.InternalField_26[InternalParameter_44.InternalField_27];
            double InternalVar_2 = InternalParameter_44.InternalField_25;
            double InternalVar_3 = InternalField_15.InternalProperty_549[InternalParameter_44.InternalField_27];
            double InternalVar_4 = InternalField_16.CalculatedPadding.Offset[InternalParameter_44.InternalField_27];
            int InternalVar_5 = InternalField_16.InternalMethod_79().Alignment;

            double InternalVar_6 = InternalType_182.InternalMethod_855(InternalVar_2, InternalVar_1, InternalVar_3, InternalVar_4, InternalVar_5);

            Vector3 InternalVar_7 = Vector3.zero;
            InternalVar_7[InternalParameter_44.InternalField_27] = (float)InternalVar_6;

            InternalProperty_11 = InternalVar_7;

            return (float)InternalType_182.InternalMethod_856(InternalVar_6, InternalVar_1, InternalVar_3, InternalVar_4, InternalVar_5);
        }

        private bool InternalMethod_55(ref InternalType_3 InternalParameter_45, Vector3 InternalParameter_46)
        {
            if (!InternalField_15.InternalMethod_2317(InternalParameter_2723: InternalParameter_45.InternalField_35))
            {
                return false;
            }

            InternalParameter_45.InternalMethod_61(-InternalParameter_46);

            return true;
        }

        private void InternalMethod_56(ref InternalType_3 InternalParameter_47)
        {
            int InternalVar_1 = 0;

            InternalField_23.Clear();
            InternalType_521<InternalType_131> InternalVar_2 = InternalField_15.InternalProperty_9;
            int InternalVar_3 = InternalVar_2.InternalProperty_433;

            int InternalVar_4 = InternalParameter_47.InternalField_35 ? 0 : InternalVar_2.InternalProperty_433 - 1;
            for (int InternalVar_5 = InternalVar_4; InternalVar_5 >= 0 && InternalVar_5 < InternalVar_2.InternalProperty_433; InternalVar_5 += InternalParameter_47.InternalField_32)
            {
                InternalType_131 InternalVar_6 = InternalVar_2[InternalVar_5];

                if (!InternalField_23.Add(InternalVar_6))
                {
                    continue;
                }

                if (!InternalField_21.TryGetValue(InternalVar_6, out InternalType_217 InternalVar_7))
                {
                    InternalField_22.Remove(InternalVar_6);
                    continue;
                }

                InternalVar_1++;

                switch (InternalVar_7.InternalField_564)
                {
                    case InternalType_216.InternalField_562:
                        if (InternalField_15.InternalMethod_45(InternalParameter_47.InternalField_33 > 0 ? -1 : 1))
                        {
                            InternalField_22.Remove(InternalVar_6);
                            InternalMethod_55(ref InternalParameter_47, InternalVar_7.InternalField_563);
                        }
                        break;
                    case InternalType_216.InternalField_560:
                        if (InternalField_15.InternalMethod_45(InternalParameter_47.InternalField_33 > 0 ? -1 : 1))
                        {
                            InternalField_22.Remove(InternalVar_6);
                        }
                        break;
                    case InternalType_216.InternalField_561:
                        bool InternalVar_8 = InternalVar_1 == InternalVar_3;

                        if (InternalField_22.Add(InternalVar_6) || InternalVar_8)
                        {
                            InternalMethod_57(ref InternalParameter_47, InternalParameter_49: InternalVar_8);
                        }
                        break;
                }
            }

            while (InternalMethod_57(ref InternalParameter_47, InternalParameter_49: false)) ;

            if (InternalParameter_47.InternalField_31 == 0)
            {
                InternalParameter_47.InternalMethod_65();
                while (InternalMethod_57(ref InternalParameter_47, InternalParameter_49: false)) ;
            }
        }

        private bool InternalMethod_57(ref InternalType_3 InternalParameter_48, bool InternalParameter_49)
        {
            if (!InternalParameter_48.InternalMethod_62(InternalField_15.InternalProperty_548, out double InternalVar_1) && !InternalParameter_49)
            {
                return false;
            }

            InternalType_66 InternalVar_2 = InternalField_15.InternalMethod_43(InternalParameter_36: InternalParameter_48.InternalField_35, (float)InternalVar_1);

            if (InternalVar_2 == null)
            {
                return false;
            }

            InternalParameter_48.InternalMethod_61(InternalVar_2.InternalProperty_150);

            return true;
        }

        public void InternalMethod_58(InternalType_66 InternalParameter_50)
        {
            if (InternalField_18)
            {
                return;
            }

            InternalType_145 InternalVar_1 = InternalType_253.InternalProperty_190.InternalMethod_1158(InternalParameter_50.InternalProperty_195);

            if (InternalVar_1 == null || InternalVar_1.InternalProperty_203)
            {
                return;
            }

            InternalMethod_2315(InternalParameter_50.InternalProperty_195);
        }

        public void InternalMethod_2315(InternalType_131 InternalParameter_2722)
        {
            InternalField_22.Remove(InternalParameter_2722);
        }

        public void InternalMethod_59(InternalType_131 InternalParameter_51)
        {
            if (InternalField_18)
            {
                return;
            }

            InternalType_145 InternalVar_1 = InternalType_253.InternalProperty_190.InternalMethod_1158(InternalParameter_51);

            if (InternalVar_1 == null || InternalVar_1.InternalProperty_203)
            {
                return;
            }

            InternalField_22.Add(InternalParameter_51);
        }

        public void InternalMethod_60(InternalType_1 InternalParameter_52, UIBlock InternalParameter_53, InternalType_131 InternalParameter_54)
        {
            if (InternalField_17)
            {
                return;
            }

            this.InternalField_15 = InternalParameter_52;
            this.InternalField_16 = InternalParameter_53;

            InternalField_21 = new NovaHashMap<InternalType_131, InternalType_217>(16, Allocator.Persistent);

            InternalType_253 InternalVar_1 = InternalType_253.InternalProperty_190;
            InternalType_457 InternalVar_2 = InternalType_457.InternalProperty_190;

            InternalField_19 = new InternalType_218()
            {
                InternalField_565 = InternalField_21,

                InternalField_566 = InternalVar_2.InternalField_1843,

                InternalField_568 = InternalVar_2.InternalField_1857,
                InternalField_567 = InternalVar_2.InternalField_1844,

                InternalField_569 = InternalVar_1.InternalProperty_261,

                InternalField_572 = InternalParameter_54,
            };

            if (InternalField_20.InternalField_3352 == null)
            {
                unsafe
                {
                    InternalField_20 = new InternalType_735<InternalType_175>(InternalType_218.InternalMethod_1045);
                }
            }

            InternalField_17 = true;
        }

        public void Dispose()
        {
            if (!InternalField_17)
            {
                return;
            }

            InternalField_15 = null;

            InternalField_21.Dispose();

            InternalField_22.Clear();
            InternalField_23.Clear();

            InternalField_17 = false;
        }

        private struct InternalType_3
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public double InternalField_25;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public double3 InternalField_26;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_27;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_28;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly double InternalField_29;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_30;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public double InternalField_31;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public int InternalField_32;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public int InternalField_33;

            
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                        public bool InternalField_34;

            
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                        public bool InternalField_35;

            public void InternalMethod_61(Vector3 InternalParameter_55)
            {
                float InternalVar_1 = InternalParameter_55[InternalField_27];
                float InternalVar_2 = InternalType_187.InternalMethod_892(InternalVar_1);

                InternalMethod_63(InternalVar_1 + InternalVar_2 * (float)InternalField_29, InternalVar_2);
            }

            public bool InternalMethod_62(Vector3 InternalParameter_56, out double InternalParameter_57)
            {
                float InternalVar_1 = InternalParameter_56[InternalField_27];
                float InternalVar_2 = (float)InternalField_26[InternalField_27];

                float InternalVar_3 = InternalType_182.InternalMethod_857((float)InternalField_25, InternalVar_2, InternalVar_1, 0, InternalField_30);

                if (InternalField_33 < 0)
                {
                    float InternalVar_4 = InternalVar_1 * 0.5f;
                    float InternalVar_5 = InternalVar_3 + InternalVar_2 * 0.5f;
                    InternalParameter_57 = InternalVar_4 - InternalVar_5;
                }
                else
                {
                    float InternalVar_4 = InternalVar_1 * -0.5f;
                    float InternalVar_5 = InternalVar_3 - InternalVar_2 * 0.5f;
                    InternalParameter_57 = InternalVar_5 - InternalVar_4;
                }

                return InternalType_187.InternalMethod_893(InternalParameter_57) > 0;
            }

            private void InternalMethod_63(float InternalParameter_58, float InternalParameter_59)
            {
                InternalField_26[InternalField_27] += InternalParameter_58;

                if (InternalField_30 == 0)
                {
                    InternalField_25 -= InternalParameter_58 * InternalParameter_59 * 0.5f * InternalField_33;
                }
                else if ((InternalParameter_59 < 0 && InternalField_34) ||
                         (InternalParameter_59 > 0 && !InternalField_34))
                {
                    InternalField_25 -= InternalParameter_58;
                }
            }

            public InternalType_3(ref AutoLayout InternalParameter_60, Vector3 InternalParameter_61, float InternalParameter_62, float InternalParameter_63, int InternalParameter_64, int InternalParameter_65)
            {
                InternalField_27 = InternalParameter_65;
                InternalField_28 = InternalParameter_60.InternalProperty_12;
                InternalField_31 = InternalParameter_62;
                InternalField_26 = (float3)InternalParameter_61;
                InternalField_29 = InternalParameter_63;
                InternalField_30 = InternalParameter_60.Alignment;

                InternalField_25 = InternalParameter_60.Offset + InternalParameter_60.InternalProperty_14 * InternalField_31;

                InternalField_33 = InternalParameter_64;

                InternalField_34 = InternalParameter_60.InternalProperty_14 != InternalField_33;

                InternalField_35 = InternalParameter_60.InternalProperty_13 != InternalField_33;
                InternalField_32 = InternalField_35 ? 1 : -1;
            }

            public void InternalMethod_65()
            {
                InternalField_35 = !InternalField_35;
                InternalField_31 = -InternalField_31;
                InternalField_33 = -InternalField_33;
                InternalField_34 = !InternalField_34;
                InternalField_32 = -InternalField_32;
            }
        }
    }
}
