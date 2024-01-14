// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Unity.Mathematics;
using UnityEngine;

namespace Nova
{
    internal struct InternalType_726
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_1 InternalField_3035;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3032;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3031;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_3030;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private AutoLayout InternalField_2996;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2803;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2992;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2989;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2986;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_2981;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_2980;

        public void InternalMethod_2963(UIBlock InternalParameter_2377, InternalType_1 InternalParameter_2356, UIBlock InternalParameter_2355)
        {
            this.InternalField_3032 = InternalParameter_2377;
            this.InternalField_3035 = InternalParameter_2356;
            this.InternalField_3031 = InternalParameter_2355;

            InternalField_2996 = default;
            InternalField_2803 = 0;
            InternalField_2992 = 0;
            InternalField_2989 = 0;
            InternalField_2986 = 0;
            InternalField_3030 = 0;

            InternalMethod_2960();
        }

        public void InternalMethod_2960()
        {
            if (InternalField_3031 == null || InternalField_3032 == null)
            {
                return;
            }

            AutoLayout InternalVar_1 = InternalField_3032.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            bool InternalVar_3 = (InternalField_3035 as MonoBehaviour) != null && InternalField_3035.InternalProperty_0 > 0;

            float InternalVar_4 = InternalField_3032.CalculatedSize[InternalVar_2].Value;
            float InternalVar_5 = InternalField_3032.PaddedSize[InternalVar_2];
            float InternalVar_6 = InternalVar_3 ? InternalField_3035.InternalProperty_5[InternalVar_2] : InternalField_3032.InternalProperty_18[InternalVar_2];
            float InternalVar_7 = InternalVar_3 ? InternalField_3035.InternalProperty_1 : InternalVar_6;
            float InternalVar_8 = InternalField_3032.InternalProperty_19[InternalVar_2] - InternalField_3032.CalculatedPadding.Offset[InternalVar_2];
            float InternalVar_9 = InternalVar_3 ? -InternalField_3035.InternalProperty_3 : -InternalVar_8;
            float InternalVar_10 = InternalField_3031.CalculatedPosition[InternalVar_2].Percent;
            int InternalVar_11 = InternalVar_3 ? InternalField_3035.InternalProperty_0 : InternalField_3032.InternalProperty_84;

            bool InternalVar_12 = !InternalType_187.InternalMethod_922(InternalField_3030, InternalVar_9);
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2981, InternalVar_10);
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2992, InternalVar_6);
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2989, InternalVar_7);
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2986, InternalVar_8);
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2803, InternalVar_5);
            InternalVar_12 |= AutoLayout.InternalMethod_72(ref InternalField_2996).InternalMethod_422(ref AutoLayout.InternalMethod_72(ref InternalVar_1));
            InternalVar_12 |= !InternalType_187.InternalMethod_922(InternalField_2980, InternalVar_11);

            if (!InternalVar_12)
            {
                return;
            }

            float InternalVar_13 = 0;
            float InternalVar_14 = 0;

            if (!InternalVar_3 || 
                !InternalField_3035.InternalMethod_45(1) || 
                !InternalField_3035.InternalMethod_45(-1))
            {
                float InternalVar_15 = InternalVar_7 * 0.5f;
                float InternalVar_16 = InternalVar_9 - InternalVar_15;
                float InternalVar_17 = InternalVar_9 + InternalVar_15;

                InternalVar_14 = InternalVar_7 > InternalVar_5 ? InternalVar_17 - InternalVar_5 * 0.5f : InternalVar_1.Offset * -InternalVar_1.InternalProperty_14;
                float InternalVar_18 = InternalVar_7 > InternalVar_5 ? (-InternalVar_5 * 0.5f) - InternalVar_16 : InternalVar_1.Offset * InternalVar_1.InternalProperty_14;

                InternalVar_13 = math.min(InternalVar_14, math.min(InternalVar_18, 0));
            }

            Length InternalVar_19 = InternalField_3031.Size[InternalVar_2];

            float InternalVar_20 = math.max(InternalVar_7, InternalVar_4);
            float InternalVar_21 = (InternalVar_4 + InternalVar_13) / InternalVar_20;
            InternalVar_19.Percent = math.clamp(InternalVar_21, 0, 1 - math.max(InternalField_3031.CalculatedMargin[InternalVar_2].Sum().Percent, 0));
            InternalField_3031.Size[InternalVar_2] = InternalVar_19;

            UIBlock InternalVar_22 = InternalField_3031.Parent;
            float InternalVar_23 = InternalVar_22 == null ? InternalVar_5 : InternalVar_22.PaddedSize[InternalVar_2];
            InternalVar_21 = InternalField_3031.SizeMinMax[InternalVar_2].Clamp(InternalVar_19.Percent * InternalVar_23) / InternalVar_23;

            if (!InternalType_457.InternalProperty_190.InternalMethod_1852(InternalField_3031))
            {
                InternalField_3031.CalculateLayout();
            }

            float InternalVar_24 = InternalVar_21 + math.min(InternalField_3031.CalculatedMargin[InternalVar_2].Sum().Percent, 0);

            Length InternalVar_25 = InternalField_3031.Position[InternalVar_2];

            float InternalVar_26 = 1 - InternalVar_24;
            float InternalVar_27 = 0.5f * InternalVar_26;

            float InternalVar_28 = InternalVar_7 >= InternalVar_5 ? InternalVar_26 * InternalVar_9 / (InternalVar_7 - InternalVar_5) : InternalVar_14 / InternalVar_5;
            float InternalVar_29 = math.clamp(InternalVar_28, -InternalVar_27, InternalVar_27);

            InternalVar_25.Percent = InternalType_182.InternalMethod_858(InternalVar_29, InternalVar_24, 1, 0, InternalField_3031.Alignment[InternalVar_2]);

            InternalField_3031.Position[InternalVar_2] = InternalVar_25;

            InternalField_2996 = InternalVar_1;
            InternalField_2803 = InternalVar_5;
            InternalField_2992 = InternalVar_6;
            InternalField_2989 = InternalVar_7;
            InternalField_2986 = InternalVar_8;
            InternalField_3030 = InternalVar_9;
            InternalField_2981 = InternalVar_25.Percent;
            InternalField_2980 = InternalVar_11;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_938
        {
            get
            {
                int InternalVar_1 = (InternalField_3035 as MonoBehaviour) == null || InternalField_3035.InternalProperty_0 == 0 ? InternalField_3032.InternalProperty_84 : InternalField_3035.InternalProperty_0;


                if (InternalVar_1 != InternalField_2980)
                {
                    return true;
                }

                if (!InternalField_3032.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_2))
                {
                    return false;
                }

                if (InternalField_2992 != InternalField_3032.InternalProperty_18[InternalVar_2])
                {
                    return true;
                }

                if (InternalField_2986 != InternalField_3032.InternalProperty_19[InternalVar_2])
                {
                    return true;
                }

                return false;
            }
        }

    }
}
