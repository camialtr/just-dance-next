// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova.InternalNamespace_0.InternalNamespace_8
{
    internal enum InternalType_736
    {
        InternalField_3363,
        InternalField_3364,
        InternalField_3365
    }

    internal class InternalType_515<T76>
    {
        #region 
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                private static Dictionary<Type, InternalType_519> InternalField_2328 = new Dictionary<Type, InternalType_519>()
        {
            {typeof(object), new InternalType_520<object>() }
        };

        internal static InternalType_519 InternalMethod_2032(Type InternalParameter_2354)
        {
            if (InternalField_2328.TryGetValue(InternalParameter_2354, out InternalType_519 InternalVar_1))
            {
                return InternalVar_1;
            }

            return InternalField_2328[typeof(object)];
        }
        #endregion

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                        private Transform InternalField_2327 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<ItemView> InternalField_2326 = new List<ItemView>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<ItemView, Stack<ItemView>> InternalField_2325 = new Dictionary<ItemView, Stack<ItemView>>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_131, (ItemView Prefab, T76 Key)> InternalField_2324 = new Dictionary<InternalType_131, (ItemView Prefab, T76 Key)>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_153<ItemView> InternalField_2323 = new InternalType_153<ItemView>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_131, T76> InternalField_2322 = new Dictionary<InternalType_131, T76>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<Type> InternalField_2321 = new List<Type>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<Type, MulticastDelegate> InternalField_2320 = new Dictionary<Type, MulticastDelegate>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<Type, List<Type>> InternalField_2319 = new Dictionary<Type, List<Type>>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<int, ItemView> InternalField_2318 = new Dictionary<int, ItemView>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2317 = false;

        public void InternalMethod_2031<TPrefab, TData>()
        {
            Type InternalVar_1 = typeof(TPrefab);

            if (!InternalField_2319.TryGetValue(InternalVar_1, out List<Type> InternalVar_2))
            {
                InternalVar_2 = new List<Type>();
                InternalField_2319[InternalVar_1] = InternalVar_2;
            }

            Type InternalVar_3 = typeof(TData);
            if (!InternalVar_2.Contains(InternalVar_3))
            {
                InternalVar_2.Add(InternalVar_3);

                if (!InternalField_2328.ContainsKey(InternalVar_3))
                {
                    InternalField_2328.Add(InternalVar_3, new InternalType_520<TData>());
                }
            }
        }

        public void InternalMethod_2030<TPrefab, TData>()
        {
            Type InternalVar_1 = typeof(TPrefab);

            if (!InternalField_2319.TryGetValue(InternalVar_1, out List<Type> InternalVar_2))
            {
                return;
            }

            InternalVar_2.Remove(typeof(TData));
        }

        public void InternalMethod_2029<TData>(PrefabProviderCallback<T76> InternalParameter_2353)
        {
            Type InternalVar_1 = typeof(TData);

            if (InternalField_2320.ContainsKey(InternalVar_1))
            {
                Debug.LogError($"A different Prefab Provider for the given data type [{typeof(TData)}] is already registered.");
                return;
            }

            InternalField_2320.Add(InternalVar_1, InternalParameter_2353);
            InternalField_2321.Add(InternalVar_1);
        }

        
        public void InternalMethod_2028<TData>()
        {
            Type InternalVar_1 = typeof(TData);

            if (!InternalField_2320.ContainsKey(InternalVar_1))
            {
                return;
            }

            InternalField_2320.Remove(InternalVar_1);
            InternalField_2321.Remove(InternalVar_1);
        }

        public InternalType_736 InternalMethod_3350(T76 InternalParameter_2227, Type InternalParameter_2228, out ItemView InternalParameter_2237, out Type InternalParameter_2238)
        {
            InternalParameter_2237 = null;
            ItemView InternalVar_1 = InternalMethod_2019(InternalParameter_2227, InternalParameter_2228, out InternalParameter_2238);

            if (InternalVar_1 == null)
            {
                return InternalType_736.InternalField_3364;
            }

            if (!InternalField_2325.TryGetValue(InternalVar_1, out Stack<ItemView> InternalVar_2))
            {
                InternalVar_2 = new Stack<ItemView>();
                InternalField_2325[InternalVar_1] = InternalVar_2;
            }

            while (InternalParameter_2237 == null && InternalVar_2.Count > 0)
            {
                InternalParameter_2237 = InternalVar_2.Pop();
            }

            if (InternalParameter_2237 == null)
            {
                try
                {
                    InternalParameter_2237 = ItemView.Instantiate(InternalVar_1, InternalField_2327);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Instantiating prefab {InternalVar_1.name} failed with: {e}", InternalField_2327);
                    return InternalType_736.InternalField_3365;
                }
            }
            else
            {
                InternalField_2323.Remove(InternalParameter_2237);
                InternalField_2322.Remove(InternalParameter_2237.UIBlock.InternalProperty_29);
            }

            InternalField_2324.Add(InternalParameter_2237.UIBlock.InternalProperty_29, (InternalVar_1, InternalParameter_2227));

            if (!InternalParameter_2237.gameObject.activeSelf)
            {
                try
                {
                    InternalParameter_2237.gameObject.SetActive(true);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Activating prefab failed with: {e}", InternalField_2327);
                }
            }

            return InternalType_736.InternalField_3363;
        }

        public void InternalMethod_2026(ItemView InternalParameter_2349, T76 InternalParameter_2348)
        {
            if (InternalParameter_2349 == null)
            {
                return;
            }

            if (!InternalField_2324.TryGetValue(InternalParameter_2349.UIBlock.InternalProperty_29, out var InternalVar_1))
            {
                try
                {
                    GameObject.Destroy(InternalParameter_2349.gameObject);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
                return;
            }

            InternalField_2324.Remove(InternalParameter_2349.UIBlock.InternalProperty_29);

            Stack<ItemView> InternalVar_2 = InternalField_2325[InternalVar_1.Prefab];
            InternalField_2323.Add(InternalParameter_2349);
            InternalField_2322.Add(InternalParameter_2349.UIBlock.InternalProperty_29, InternalParameter_2348);
            InternalVar_2.Push(InternalParameter_2349);
        }

        
        public void InternalMethod_2025(InternalType_131 InternalParameter_2347)
        {
            InternalField_2324.Remove(InternalParameter_2347);
        }

        public bool InternalMethod_2024(ItemView InternalParameter_2346, Transform InternalParameter_2345)
        {
            if (InternalParameter_2346 == null)
            {
                return false;
            }

            if (!InternalField_2324.TryGetValue(InternalParameter_2346.UIBlock.InternalProperty_29, out var InternalVar_1))
            {
                return false;
            }
            InternalField_2324.Remove(InternalParameter_2346.UIBlock.InternalProperty_29);

            if (InternalParameter_2346.transform.parent == InternalField_2327)
            {
                try
                {
                    InternalParameter_2346.transform.parent = InternalParameter_2345;
                }
                catch (Exception e)
                {
                    Debug.LogError($"Reparenting detached item failed with: {e}");
                }
            }

            InternalField_2318.Add(InternalParameter_2346.GetInstanceID(), InternalVar_1.Prefab);
            return true;
        }

        public bool InternalMethod_2023(ItemView InternalParameter_2344)
        {
            if (InternalParameter_2344 == null || !InternalField_2318.TryGetValue(InternalParameter_2344.GetInstanceID(), out ItemView InternalVar_1))
            {
                return false;
            }

            if (!InternalField_2325.TryGetValue(InternalVar_1, out Stack<ItemView> InternalVar_2))
            {
                return false;
            }

            if (InternalParameter_2344.gameObject.activeSelf)
            {
                try
                {
                    InternalParameter_2344.gameObject.SetActive(false);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            if (InternalParameter_2344.transform.parent != InternalField_2327)
            {
                try
                {
                    InternalParameter_2344.transform.parent = InternalField_2327;
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            InternalVar_2.Push(InternalParameter_2344);
            InternalField_2318.Remove(InternalParameter_2344.GetInstanceID());

            return true;
        }

        public void InternalMethod_2022()
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2323.Count; ++InternalVar_1)
            {
                ItemView InternalVar_2 = InternalField_2323[InternalVar_1];

                if (InternalVar_2 == null)
                {
                    continue;
                }

                if (InternalVar_2.gameObject.activeSelf)
                {
                    try
                    {
                        InternalVar_2.gameObject.SetActive(false);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }

            InternalField_2323.Clear();
            InternalField_2322.Clear();
        }

        public bool InternalMethod_2021(T76 InternalParameter_2343, ItemView InternalParameter_2342, Type InternalParameter_2341, out Type InternalParameter_2340)
        {
            ItemView InternalVar_1 = InternalMethod_2019(InternalParameter_2343, InternalParameter_2341, out InternalParameter_2340);

            if (!InternalField_2324.TryGetValue(InternalParameter_2342.UIBlock.InternalProperty_29, out var InternalVar_2))
            {
                return false;
            }

            return InternalVar_2.Prefab == InternalVar_1;
        }

        public bool InternalMethod_2020(InternalType_131 InternalParameter_2339, out T76 InternalParameter_2338)
        {
            if (InternalField_2324.TryGetValue(InternalParameter_2339, out var InternalVar_1))
            {
                InternalParameter_2338 = InternalVar_1.Key;
                return true;
            }

            return InternalField_2322.TryGetValue(InternalParameter_2339, out InternalParameter_2338);
        }

        private ItemView InternalMethod_2019(T76 InternalParameter_2337, Type InternalParameter_2336, out Type InternalParameter_2335)
        {
            ItemView InternalVar_1 = null;

            for (int InternalVar_2 = 0; InternalVar_2 < InternalField_2321.Count; ++InternalVar_2)
            {
                if (!InternalField_2321[InternalVar_2].IsAssignableFrom(InternalParameter_2336))
                {
                    continue;
                }

                if (!InternalField_2320.TryGetValue(InternalParameter_2336, out MulticastDelegate InternalVar_3) ||
                    !(InternalVar_3 is PrefabProviderCallback<T76> prefabProvider))
                {
                    continue;
                }

                try
                {
                    if (!prefabProvider.Invoke(InternalParameter_2337, out InternalVar_1))
                    {
                        continue;
                    }
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Prefab provider failed with: {ex}");
                    continue;
                }

                if (InternalVar_1 == null)
                {
                    string InternalVar_4 = InternalParameter_2336 == null ? "Null" : InternalParameter_2336.Name;
                    Debug.LogWarning($"Prefab Provider returned \"true\" but prefab object was null. Falling back to default prefab for type {InternalVar_4}.");
                    continue;
                }

                InternalParameter_2335 = InternalParameter_2336;
                return InternalVar_1;
            }

            InternalParameter_2335 = typeof(object);

            for (int InternalVar_2 = 0; InternalVar_2 < InternalField_2326.Count; ++InternalVar_2)
            {
                ItemView InternalVar_3 = InternalField_2326[InternalVar_2];

                if (InternalVar_3 == null)
                {
                    continue;
                }

                if (!InternalVar_3.InternalProperty_947)
                {
                    Debug.LogError($"The {nameof(ItemView)}.{nameof(ItemView.Visuals)} property must be non-null in order to work correctly.", InternalField_2327);
                    continue;
                }

                Type InternalVar_4 = InternalVar_3.InternalProperty_948;
                if (!InternalField_2319.TryGetValue(InternalVar_4, out List<Type> InternalVar_5))
                {
                    continue;
                }

                for (int InternalVar_6 = 0; InternalVar_6 < InternalVar_5.Count; ++InternalVar_6)
                {
                    Type InternalVar_7 = InternalVar_5[InternalVar_6];

                    if (InternalVar_7.IsAssignableFrom(InternalParameter_2336) &&
                        InternalParameter_2335.IsAssignableFrom(InternalVar_7))
                    {
                        InternalParameter_2335 = InternalVar_7;
                        InternalVar_1 = InternalField_2326[InternalVar_2];
                    }
                }
            }

            return InternalVar_1;
        }

        public Type InternalMethod_2018(ItemView InternalParameter_2334, Type InternalParameter_2333)
        {
            Type InternalVar_1 = typeof(object);
            Type InternalVar_2 = InternalParameter_2334.InternalProperty_948;

            if (InternalField_2319.TryGetValue(InternalVar_2, out List<Type> InternalVar_3))
            {
                for (int InternalVar_4 = 0; InternalVar_4 < InternalVar_3.Count; ++InternalVar_4)
                {
                    Type InternalVar_5 = InternalVar_3[InternalVar_4];

                    if (InternalVar_5.IsAssignableFrom(InternalParameter_2333) &&
                        InternalVar_1.IsAssignableFrom(InternalVar_5))
                    {
                        InternalVar_1 = InternalVar_5;
                    }
                }
            }

            return InternalVar_1;
        }

        public void InternalMethod_2017()
        {
            foreach (var InternalVar_1 in InternalField_2325)
            {
                Stack<ItemView> InternalVar_2 = InternalVar_1.Value;

                if (InternalVar_2 == null)
                {
                    continue;
                }

                while (InternalVar_2.Count > 0)
                {
                    try
                    {
                        GameObject.Destroy(InternalVar_2.Pop().gameObject);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }
            }

            InternalField_2325.Clear();
            InternalField_2318.Clear();
        }

        public void InternalMethod_2016(Transform InternalParameter_2332, List<ItemView> InternalParameter_2331)
        {
            if (InternalField_2317)
            {
                return;
            }

            InternalField_2327 = InternalParameter_2332;

            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_2331.Count; ++InternalVar_1)
            {
                ItemView InternalVar_2 = InternalParameter_2331[InternalVar_1];

                if (InternalVar_2 == null)
                {
                    continue;
                }

                if (!InternalVar_2.InternalProperty_947)
                {
                    Debug.LogError($"[{InternalVar_2.name}] The {nameof(ItemView)}.{nameof(ItemView.Visuals)} property must be non-null in order to work correctly.", InternalVar_2);
                    continue;
                }

                if (InternalField_2326.Contains(InternalVar_2))
                {
                    continue;
                }

                InternalField_2326.Add(InternalVar_2);
                InternalField_2325.Add(InternalVar_2, new Stack<ItemView>());
            }

            InternalField_2317 = true;
        }
    }
}
