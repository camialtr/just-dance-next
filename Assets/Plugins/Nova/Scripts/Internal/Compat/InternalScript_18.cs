// Copyright (c) Supernova Technologies LLC
using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Nova.Compat
{
    internal unsafe struct RawPtrArrayWrapper<T> : IDisposable where T : unmanaged
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public NativeArray<T> Array;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private AtomicSafetyHandle safetyHandle;
#endif

        public RawPtrArrayWrapper(T* ptr, int length)
        {
            Array = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<T>(ptr, length, Allocator.None);

#if ENABLE_UNITY_COLLECTIONS_CHECKS
            safetyHandle = AtomicSafetyHandle.Create();
            NativeArrayUnsafeUtility.SetAtomicSafetyHandle(ref Array, safetyHandle);
#endif
        }

        public void Dispose()
        {
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            AtomicSafetyHandle.Release(safetyHandle);
#endif
        }

        public static implicit operator NativeArray<T>(RawPtrArrayWrapper<T> handle) => handle.Array;
    }
}

