// Copyright (c) Supernova Technologies LLC
using System;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

namespace Nova.Compat
{
    internal struct NovaHashMap<K,V> : IDisposable
        where K : unmanaged, IEquatable<K>
        where V : unmanaged
    {
        [NativeDisableContainerSafetyRestriction]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
#if COLLECTIONS_1_3_OR_NEWER
        private NativeParallelHashMap<K, V> map;
#else
        private NativeHashMap<K, V> map;
#endif

        public V this[K key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => map[key];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => map[key] = value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(K key, V val) => map.Add(key, val);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(K key) => map.ContainsKey(key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryAdd(K key, V value) => map.TryAdd(key, value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(K key, out V val) => map.TryGetValue(key, out val);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Remove(K key) => map.Remove(key);

        public void Clear() => map.Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NativeArray<V> GetValueArray(AllocatorManager.AllocatorHandle allocator) => map.GetValueArray(allocator);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public NativeArray<K> GetKeyArray(AllocatorManager.AllocatorHandle allocator) => map.GetKeyArray(allocator);

        public void Dispose()
        {
            map.Dispose();
        }

        public NovaHashMap(int capacity, AllocatorManager.AllocatorHandle allocator)
        {
#if COLLECTIONS_1_3_OR_NEWER
            map = new NativeParallelHashMap<K, V>(capacity, allocator);
#else
            map = new NativeHashMap<K, V>(capacity, allocator);
#endif
        }

        public void Init(int capacity = 0)
        {
#if COLLECTIONS_1_3_OR_NEWER
            map = new NativeParallelHashMap<K, V>(capacity, Allocator.Persistent);
#else
            map = new NativeHashMap<K, V>(capacity, Allocator.Persistent);
#endif
        }
    }
}

