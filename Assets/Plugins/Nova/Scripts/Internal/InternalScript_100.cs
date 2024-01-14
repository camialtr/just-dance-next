// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_4;
using System;
using System.Collections.Generic;

namespace Nova.InternalNamespace_16
{
    internal struct InternalType_529<T66> where T66 : IEvent
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public T66 InternalField_2354;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_524.InternalType_525 InternalField_2355;

        public InternalType_529(ref T66 InternalParameter_2422, InternalType_524.InternalType_525 InternalParameter_2423)
        {
            InternalField_2354 = InternalParameter_2422;
            InternalField_2355 = InternalParameter_2423;
        }
    }

    
    internal class InternalType_524
    {
        
        internal class InternalType_525
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public int InternalProperty_440 => InternalField_2349 == null ? 0 : InternalField_2349.Count;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private InternalType_153<InternalType_523> InternalField_2349 = null;

            public void InternalMethod_2091(InternalType_523 InternalParameter_2405)
            {
                if (InternalField_2349 == null)
                {
                    InternalField_2349 = InternalType_156<InternalType_153<InternalType_523>, InternalType_523>.InternalMethod_740();
                }

                InternalField_2349.Add(InternalParameter_2405);
            }

            public void InternalMethod_2092(InternalType_523 InternalParameter_2406)
            {
                InternalField_2349.Remove(InternalParameter_2406);
            }

            public void InternalMethod_1459(InternalType_273 InternalParameter_112, Type InternalParameter_111, InternalType_159<Type, InternalType_157<InternalType_273>> InternalParameter_110, InternalType_157<Type> InternalParameter_109, InternalType_153<Type> InternalParameter_108)
            {
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2349.Count; ++InternalVar_1)
                {
                    InternalType_523 InternalVar_2 = InternalField_2349[InternalVar_1];

                    if (!InternalVar_2.InternalMethod_1635(InternalParameter_112, InternalParameter_111, out InternalType_273 InternalVar_3) || InternalVar_3 == null)
                    {
                        continue;
                    }

                    Type InternalVar_4 = InternalVar_2.InternalProperty_439;
                    Type InternalVar_5 = InternalVar_3.GetType();

                    do
                    {
                        InternalMethod_1384(InternalParameter_110, InternalParameter_109, InternalVar_5, InternalVar_3);

                        if (InternalVar_5.Equals(InternalVar_4) ||
                            InternalParameter_108.Contains(InternalVar_5))
                        {
                            break;
                        }

                        InternalVar_5 = InternalVar_5.BaseType;

                    } while (InternalVar_5 != null && InternalVar_4.IsAssignableFrom(InternalVar_5));
                }
            }

            private void InternalMethod_1384(InternalType_159<Type, InternalType_157<InternalType_273>> InternalParameter_107, InternalType_157<Type> InternalParameter_71, Type InternalParameter_70, InternalType_273 InternalParameter_69)
            {
                if (!InternalParameter_107.TryGetValue(InternalParameter_70, out InternalType_157<InternalType_273> InternalVar_1))
                {
                    InternalVar_1 = InternalType_155<InternalType_273>.InternalMethod_740();
                    InternalParameter_107.Add(InternalParameter_70, InternalVar_1);
                }

                if (InternalVar_1.Count == 0)
                {
                    InternalParameter_71.Add(InternalParameter_70);
                }

                InternalVar_1.Add(InternalParameter_69);
            }
        }

        private class InternalType_526<T64> : InternalType_527 where T64 : class, InternalType_273
        {
            public override void InternalMethod_1383<TEvent>(MulticastDelegate action, ref TEvent InternalParameter_3095, InternalType_273 InternalParameter_3096)
            {
                try
                {
                    switch (action)
                    {
                        case UIEventHandler<TEvent, T64> callback:
                            callback.Invoke(InternalParameter_3095, (T64)InternalParameter_3096);
                            break;
                    }
                }
                catch (Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
            }
        }

        private abstract class InternalType_527
        {
            public abstract void InternalMethod_1383<TEvent>(MulticastDelegate InternalParameter_68, ref TEvent InternalParameter_3095, InternalType_273 InternalParameter_3096) where TEvent : struct, IEvent;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Dictionary<Type, InternalType_527> InternalField_2342 = new Dictionary<Type, InternalType_527>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static HashSet<int> InternalField_89 = new HashSet<int>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const int InternalField_206 = 0;

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static int InternalField_208 = 1;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_152<MulticastDelegate>, InternalType_527> InternalField_2343 = new Dictionary<InternalType_152<MulticastDelegate>, InternalType_527>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<Type, int> InternalField_2344 = new Dictionary<Type, int>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<Type, List<InternalType_152<MulticastDelegate>>> InternalField_2345 = new Dictionary<Type, List<InternalType_152<MulticastDelegate>>>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_152<MulticastDelegate>, Type> InternalField_2346 = new Dictionary<InternalType_152<MulticastDelegate>, Type>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<MulticastDelegate, InternalType_152<MulticastDelegate>> InternalField_2347 = new Dictionary<MulticastDelegate, InternalType_152<MulticastDelegate>>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_152<MulticastDelegate>, MulticastDelegate> InternalField_2348 = new Dictionary<InternalType_152<MulticastDelegate>, MulticastDelegate>();

        public static int InternalMethod_3250()
        {
            return InternalField_208++;
        }

        public static void InternalMethod_3262<TEvent>(ref TEvent InternalParameter_1307) where TEvent : struct, IEvent
        {
            InternalField_89.Remove(InternalParameter_1307.ID);
        }

        public bool InternalMethod_2081<TEvent>(Type InternalParameter_2391 = null) where TEvent : struct, IEvent
        {
            if (!InternalField_2345.TryGetValue(typeof(TEvent), out List<InternalType_152<MulticastDelegate>> InternalVar_1) || InternalVar_1 == null)
            {
                return false;
            }

            if (InternalParameter_2391 == null)
            {
                return InternalVar_1.Count > 0;
            }

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Count; ++InternalVar_2)
            {
                if (InternalField_2346[InternalVar_1[InternalVar_2]].IsAssignableFrom(InternalParameter_2391))
                {
                    return true;
                }
            }

            return false;
        }

        public void InternalMethod_1464<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_114) where TEvent : struct, IEvent where TTarget : class, InternalType_273
        {
            Type InternalVar_1 = typeof(TEvent);
            Type InternalVar_2 = typeof(TTarget);

            if (InternalVar_2.IsInterface)
            {
                throw new ArgumentException($"Provided target type, {InternalVar_2.Name}, is an interface, but event target types must be a class type.");
            }

            if (!InternalField_2345.TryGetValue(InternalVar_1, out var InternalVar_3))
            {
                InternalVar_3 = new List<InternalType_152<MulticastDelegate>>();
                InternalField_2345[InternalVar_1] = InternalVar_3;
            }

            if (!InternalField_2342.TryGetValue(InternalVar_2, out InternalType_527 InternalVar_4))
            {
                InternalVar_4 = new InternalType_526<TTarget>();
                InternalField_2342[InternalVar_2] = InternalVar_4;
            }

            if (!InternalField_2344.ContainsKey(InternalVar_2))
            {
                InternalField_2344[InternalVar_2] = 0;
            }

            InternalField_2344[InternalVar_2]++;

            InternalType_152<MulticastDelegate> InternalVar_5 = InternalType_152<MulticastDelegate>.InternalMethod_716();

            InternalVar_3.Add(InternalVar_5);
            InternalField_2343[InternalVar_5] = InternalVar_4;
            InternalField_2346[InternalVar_5] = InternalVar_2;
            InternalField_2347[InternalParameter_114] = InternalVar_5;
            InternalField_2348[InternalVar_5] = InternalParameter_114;
        }

        public void InternalMethod_1461<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_113) where TEvent : struct, IEvent where TTarget : class, InternalType_273
        {
            Type InternalVar_1 = typeof(TEvent);
            Type InternalVar_2 = typeof(TTarget);

            if (!InternalField_2347.TryGetValue(InternalParameter_113, out InternalType_152<MulticastDelegate> InternalVar_3))
            {
                return;
            }

            if (!InternalField_2345.TryGetValue(InternalVar_1, out var InternalVar_4))
            {
                return;
            }

            bool InternalVar_5 = InternalVar_4.Remove(InternalVar_3);
            InternalField_2343.Remove(InternalVar_3);
            InternalField_2346.Remove(InternalVar_3);
            InternalField_2347.Remove(InternalParameter_113);
            InternalField_2348.Remove(InternalVar_3);

            if (InternalVar_5 && InternalField_2344.ContainsKey(InternalVar_2))
            {
                InternalField_2344[InternalVar_2]--;

                if (InternalField_2344[InternalVar_2] == 0)
                {
                    InternalField_2344.Remove(InternalVar_2);
                }
            }
        }

        private struct InternalType_528<T65> where T65 : struct, IEvent
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public InternalType_527 InternalField_2350;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public MulticastDelegate InternalField_2351;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public T65 InternalField_2352;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public InternalType_273 InternalField_2353;

            public void InternalMethod_2096()
            {
                InternalField_2350.InternalMethod_1383(InternalField_2351, ref InternalField_2352, InternalField_2353);
            }

            public InternalType_528(InternalType_527 InternalParameter_3097, MulticastDelegate InternalParameter_3098, ref T65 InternalParameter_3099, InternalType_273 InternalParameter_3100)
            {
                InternalField_2350 = InternalParameter_3097;
                InternalField_2351 = InternalParameter_3098;
                InternalField_2352 = InternalParameter_3099;
                InternalField_2353 = InternalParameter_3100;
            }
        }

        public void InternalMethod_3257<TEvent>(InternalType_157<InternalType_529<TEvent>> InternalParameter_1312, out bool InternalParameter_1303) where TEvent : struct, IEvent
        {
            InternalType_157<InternalType_528<TEvent>> InternalVar_1 = null;
            InternalMethod_2085(InternalParameter_1312, out InternalVar_1);
            InternalMethod_3258(InternalVar_1, out InternalParameter_1303);
        }

        private void InternalMethod_2085<TEvent>(InternalType_157<InternalType_529<TEvent>> InternalParameter_2395, out InternalType_157<InternalType_528<TEvent>> InternalParameter_2396) where TEvent : struct, IEvent
        {
            InternalParameter_2396 = null;

            InternalType_153<Type> InternalVar_1 = InternalType_156<InternalType_153<Type>, Type>.InternalMethod_740();
            if (!InternalMethod_2087<TEvent>(ref InternalVar_1, out List<InternalType_152<MulticastDelegate>> InternalVar_2))
            {
                InternalType_156<InternalType_153<Type>, Type>.InternalMethod_741(InternalVar_1);
                return;
            }

            Type InternalVar_3 = typeof(TEvent);

            InternalType_157<InternalType_273> InternalVar_4 = InternalType_155<InternalType_273>.InternalMethod_740();
            InternalParameter_2396 = InternalType_155<InternalType_528<TEvent>>.InternalMethod_740();

            for (int InternalVar_5 = 0; InternalVar_5 < InternalParameter_2395.Count; ++InternalVar_5)
            {
                InternalType_529<TEvent> InternalVar_6 = InternalParameter_2395[InternalVar_5];
                TEvent InternalVar_7 = InternalVar_6.InternalField_2354;
                InternalType_525 InternalVar_8 = InternalVar_6.InternalField_2355;

                if (InternalVar_7.Target == null || InternalVar_7.Receiver == null)
                {
                    continue;
                }

                InternalType_159<Type, InternalType_157<InternalType_273>> InternalVar_9 = InternalType_158<Type, InternalType_157<InternalType_273>>.InternalMethod_740();
                InternalType_157<Type> InternalVar_10 = InternalType_155<Type>.InternalMethod_740();

                InternalVar_8.InternalMethod_1459(InternalVar_7.Receiver, InternalVar_3, InternalVar_9, InternalVar_10, InternalVar_1);

                for (int InternalVar_11 = 0; InternalVar_11 < InternalVar_2.Count; ++InternalVar_11)
                {
                    int InternalVar_12 = InternalVar_4.Count;

                    InternalType_152<MulticastDelegate> InternalVar_13 = InternalVar_2[InternalVar_11];

                    if (!InternalMethod_2088(InternalVar_9, InternalField_2346[InternalVar_13], ref InternalVar_4))
                    {
                        continue;
                    }

                    InternalType_527 InternalVar_14 = InternalField_2343[InternalVar_13];

                    for (int InternalVar_15 = InternalVar_12; InternalVar_15 < InternalVar_4.Count; ++InternalVar_15)
                    {
                        InternalParameter_2396.Add(new InternalType_528<TEvent>(InternalVar_14, InternalField_2348[InternalVar_13], ref InternalVar_7, InternalVar_4[InternalVar_15]));
                    }
                }

                InternalMethod_2089(InternalVar_9, InternalVar_10);
            }

            InternalType_155<InternalType_273>.InternalMethod_741(InternalVar_4);
            InternalType_156<InternalType_153<Type>, Type>.InternalMethod_741(InternalVar_1);
        }

        private void InternalMethod_3258<TEvent>(InternalType_157<InternalType_528<TEvent>> InternalParameter_1315, out bool InternalParameter_1314) where TEvent : struct, IEvent
        {
            InternalParameter_1314 = false;

            if (InternalParameter_1315 == null)
            {
                return;
            }

            int InternalVar_1 = InternalParameter_1315.Count;
            int InternalVar_2 = InternalVar_1 > 0 ? InternalParameter_1315[0].InternalField_2352.ID : InternalField_206;

            if (InternalVar_2 != InternalField_206)
            {
                InternalField_89.Add(InternalVar_2);
            }

            for (int InternalVar_3 = 0; InternalVar_3 < InternalVar_1; ++InternalVar_3)
            {
                InternalParameter_1315[InternalVar_3].InternalMethod_2096();
            }

            if (InternalVar_2 != InternalField_206)
            {
                InternalParameter_1314 = !InternalField_89.Remove(InternalVar_2);
            }

            InternalType_155<InternalType_528<TEvent>>.InternalMethod_741(InternalParameter_1315);
        }

        private bool InternalMethod_2087<TEvent>(ref InternalType_153<Type> InternalParameter_2398, out List<InternalType_152<MulticastDelegate>> InternalParameter_2399)
        {
            Type InternalVar_1 = typeof(TEvent);

            if (!InternalField_2345.TryGetValue(InternalVar_1, out InternalParameter_2399))
            {
                return false;
            }

            int InternalVar_2 = InternalParameter_2399.Count;
            for (int InternalVar_3 = 0; InternalVar_3 < InternalVar_2; ++InternalVar_3)
            {
                InternalParameter_2398.Add(InternalField_2346[InternalParameter_2399[InternalVar_3]]);
            }

            return InternalVar_2 > 0;
        }

        private static bool InternalMethod_2088(Dictionary<Type, InternalType_157<InternalType_273>> InternalParameter_2400, Type InternalParameter_2401, ref InternalType_157<InternalType_273> InternalParameter_2402)
        {
            int InternalVar_1 = InternalParameter_2402.Count;

            if (InternalParameter_2400.TryGetValue(InternalParameter_2401, out InternalType_157<InternalType_273> InternalVar_2))
            {
                InternalParameter_2402.AddRange(InternalVar_2);
                return InternalParameter_2402.Count > InternalVar_1;
            }

            return false;
        }

        private static void InternalMethod_2089(InternalType_159<Type, InternalType_157<InternalType_273>> InternalParameter_2403, InternalType_157<Type> InternalParameter_2404)
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_2404.Count; ++InternalVar_1)
            {
                InternalType_155<InternalType_273>.InternalMethod_741(InternalParameter_2403[InternalParameter_2404[InternalVar_1]]);
            }

            InternalType_158<Type, InternalType_157<InternalType_273>>.InternalMethod_741(InternalParameter_2403);
            InternalType_155<Type>.InternalMethod_741(InternalParameter_2404);
        }
    }
}