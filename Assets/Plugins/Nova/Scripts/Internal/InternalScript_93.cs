// Copyright (c) Supernova Technologies LLC
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;

namespace Nova
{
    internal static class InternalType_0
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref InternalNamespace_0.InternalType_45 InternalMethod_1(ref this Length InternalParameter_1)
        {
            return ref UnsafeUtility.As<Length, InternalNamespace_0.InternalType_45>(ref InternalParameter_1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref InternalNamespace_0.InternalType_48 InternalMethod_2(ref this Length2 InternalParameter_2)
        {
            return ref UnsafeUtility.As<Length2, InternalNamespace_0.InternalType_48>(ref InternalParameter_2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref InternalNamespace_0.InternalType_53.InternalType_54 InternalMethod_2990(ref this MinMax3 InternalParameter_2770)
        {
            return ref UnsafeUtility.As<MinMax3, InternalNamespace_0.InternalType_53.InternalType_54>(ref InternalParameter_2770);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref Length InternalMethod_9(ref this InternalNamespace_0.InternalType_45 InternalParameter_9)
        {
            return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45, Length>(ref InternalParameter_9);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly Length.Calculated InternalMethod_18(ref this InternalNamespace_0.InternalType_45.InternalType_47 InternalParameter_18)
        {
            return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45.InternalType_47, Length.Calculated>(ref InternalParameter_18);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref readonly Length2.Calculated InternalMethod_19(ref this InternalNamespace_0.InternalType_48.InternalType_50 InternalParameter_19)
        {
            return ref UnsafeUtility.As<InternalNamespace_0.InternalType_48.InternalType_50, Length2.Calculated>(ref InternalParameter_19);
        }
    }
}
