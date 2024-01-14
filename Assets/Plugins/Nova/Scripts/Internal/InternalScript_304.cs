// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using UnityEngine;

namespace Nova
{
    internal static class InternalType_21
    {
        public static void InternalMethod_2736(UIBlock InternalParameter_2113, Vector3 InternalParameter_2032)
        {
            InternalType_5 InternalVar_1 = InternalParameter_2113.InternalMethod_3592();
            bool InternalVar_2 = InternalVar_1 != null;

            Vector3 InternalVar_3 = InternalVar_2 ? InternalVar_1.InternalProperty_148 : Vector3.zero;
            Vector3 InternalVar_4 = InternalVar_2 ? (Vector3)InternalVar_1.InternalProperty_146.InternalProperty_139 : Vector3.zero;

            if (InternalVar_2 && InternalVar_1.InternalProperty_203)
            {
                InternalParameter_2032 -= InternalVar_1.InternalMethod_1035();
            }

            Vector3 InternalVar_5 = InternalType_182.InternalMethod_852(InternalParameter_2032, InternalParameter_2113.LayoutSize, InternalParameter_2113.CalculatedMargin.Offset, InternalVar_3, InternalVar_4, (Vector3)InternalParameter_2113.Alignment);

            InternalParameter_2113.Position.Raw = Length3.InternalMethod_2424(InternalVar_5, InternalParameter_2113.Position, InternalParameter_2113.PositionMinMax, InternalVar_3);
        }
    }
}
