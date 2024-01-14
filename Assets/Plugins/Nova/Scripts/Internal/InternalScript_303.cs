// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_10;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6
{
    internal static class InternalType_416
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void InternalMethod_1959(this TextBlock InternalParameter_1293)
        {
            if (InternalParameter_1293.TMP.overflowMode != TextOverflowModes.Ellipsis)
            {
                return;
            }

            bool2 InternalVar_1 = InternalParameter_1293.InternalProperty_35;
            if (!math.any(InternalVar_1))
            {
                return;
            }

            float2 InternalVar_2 = InternalType_670.InternalMethod_1955(InternalParameter_1293.CalculatedSize.XY.Value, InternalParameter_1293.SizeMinMax.InternalMethod_2990().InternalProperty_121.xy, InternalVar_1);
            if (!math.any(InternalType_187.InternalMethod_918(ref InternalVar_2)))
            {
                return;
            }

            Debug.LogWarning("Ellipsis overflow mode and shrinking to text size is causing a TextBlock to not render. Provide a MaxSize in the TextBlock's layout on the shrinking axes, or disable shrinking to prevent this situation.");
        }
    }
}
