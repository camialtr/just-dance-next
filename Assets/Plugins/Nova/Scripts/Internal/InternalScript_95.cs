// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_4;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova.InternalNamespace_16
{
    internal class InternalType_522 : InternalType_273, InternalType_523
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_524 InternalProperty_437 => InternalField_2338;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_524.InternalType_525 InternalProperty_438 => InternalField_2339;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int InternalProperty_1034 => InternalField_2339 == null ? 0 : InternalField_2339.InternalProperty_440;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Type InternalProperty_439 => typeof(InternalType_522);

        private struct InternalType_261 : IEquatable<InternalType_261>
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public bool InternalField_2230;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public MulticastDelegate InternalField_2229;

            public bool Equals(InternalType_261 other)
            {
                bool InternalVar_1 = EqualityComparer<MulticastDelegate>.Default.Equals(InternalField_2229, other.InternalField_2229);

                return InternalVar_1;
            }

            public override int GetHashCode()
            {
                return InternalField_2229 == null ? 0 : InternalField_2229.GetHashCode();
            }
        }

        private struct InternalType_245
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public InternalType_153<InternalType_261> InternalField_2228;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public int InternalField_2227;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public bool InternalProperty_721 => InternalField_2227 > 0;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_2232 = 0;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_273 InternalField_2337 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_524 InternalField_2338 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_524.InternalType_525 InternalField_2339 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<Type, InternalType_245> InternalField_2340 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly Dictionary<Type, MulticastDelegate> InternalField_2341 = new Dictionary<Type, MulticastDelegate>();

        public bool InternalMethod_2069<TEvent>() where TEvent : struct, IEvent => InternalField_2338 == null ? false : InternalField_2338.InternalMethod_2081<TEvent>();

        public void InternalMethod_1634<TEvent>(UIEventHandler<TEvent> InternalParameter_169, bool InternalParameter_168) where TEvent : struct, IEvent
        {
            if (InternalField_2338 == null)
            {
                InternalField_2338 = new InternalType_524();
            }

            if (InternalField_2340 == null)
            {
                InternalField_2340 = new Dictionary<Type, InternalType_245>();
            }

            Type InternalVar_1 = typeof(TEvent);

            if (!InternalField_2340.TryGetValue(InternalVar_1, out InternalType_245 InternalVar_2))
            {
                InternalVar_2 = new InternalType_245() { InternalField_2228 = InternalType_156<InternalType_153<InternalType_261>, InternalType_261>.InternalMethod_740() };
                InternalField_2340[InternalVar_1] = InternalVar_2;
            }
            else
            {
                InternalType_261 InternalVar_3 = new InternalType_261() { InternalField_2229 = InternalParameter_169, InternalField_2230 = InternalParameter_168 };
                int InternalVar_4 = InternalVar_2.InternalField_2228.InternalMethod_723(InternalVar_3);

                if (InternalVar_4 >= 0)
                {
                    bool InternalVar_5 = InternalVar_2.InternalField_2228[InternalVar_4].InternalField_2230;
                    if (InternalVar_5 == InternalParameter_168)
                    {
                        return;
                    }

                    if (InternalParameter_168)
                    {
                        InternalVar_2.InternalField_2227--;
                    }
                    else
                    {
                        InternalVar_2.InternalField_2227++;
                    }

                    InternalVar_2.InternalField_2228.InternalMethod_722(InternalVar_4);
                    InternalVar_2.InternalField_2228.Add(InternalVar_3);

                    InternalField_2340[InternalVar_1] = InternalVar_2;

                    return;
                }
            }

            if (InternalVar_2.InternalField_2228.Count == 0)
            {
                if (!InternalField_2341.TryGetValue(InternalVar_1, out MulticastDelegate InternalVar_3))
                {
                    InternalVar_3 = (UIEventHandler<TEvent, InternalType_522>)InternalMethod_2072;
                    InternalField_2341.Add(InternalVar_1, InternalVar_3);
                }

                InternalField_2338.InternalMethod_1464(InternalVar_3 as UIEventHandler<TEvent, InternalType_522>);
            }

            InternalVar_2.InternalField_2228.Add(new InternalType_261() { InternalField_2229 = InternalParameter_169, InternalField_2230 = InternalParameter_168 });

            if (!InternalParameter_168)
            {
                InternalVar_2.InternalField_2227++;
                InternalField_2340[InternalVar_1] = InternalVar_2;
            }
        }

        public void InternalMethod_1633<TEvent>(UIEventHandler<TEvent> InternalParameter_167) where TEvent : struct, IEvent
        {
            if (InternalField_2338 == null || InternalField_2340 == null)
            {
                return;
            }

            Type InternalVar_1 = typeof(TEvent);

            if (!InternalField_2340.TryGetValue(InternalVar_1, out InternalType_245 InternalVar_2))
            {
                return;
            }

            int InternalVar_3 = InternalVar_2.InternalField_2228.InternalMethod_723(new InternalType_261() { InternalField_2229 = InternalParameter_167, InternalField_2230 = false });

            if (InternalVar_3 < 0)
            {
                return;
            }

            if (!InternalVar_2.InternalField_2228[InternalVar_3].InternalField_2230)
            {
                InternalVar_2.InternalField_2227--;
            }

            InternalVar_2.InternalField_2228.InternalMethod_722(InternalVar_3);

            if (InternalVar_2.InternalField_2228.Count == 0)
            {
                InternalField_2340.Remove(InternalVar_1);

                InternalType_156<InternalType_153<InternalType_261>, InternalType_261>.InternalMethod_741(InternalVar_2.InternalField_2228);

                if (!InternalField_2341.TryGetValue(InternalVar_1, out MulticastDelegate InternalVar_4))
                {
                    return;
                }

                InternalField_2338.InternalMethod_1461(InternalVar_4 as UIEventHandler<TEvent, InternalType_522>);
            }
            else
            {
                InternalField_2340[InternalVar_1] = InternalVar_2;
            }
        }

        private static void InternalMethod_2072<TEvent>(TEvent InternalParameter_2379, InternalType_522 InternalParameter_2380) where TEvent : struct, IEvent
        {
            Type InternalVar_1 = typeof(TEvent);

            if (InternalParameter_2380.InternalField_2340 == null || !InternalParameter_2380.InternalField_2340.TryGetValue(InternalVar_1, out InternalType_245 InternalVar_2))
            {
                return;
            }

            InternalType_153<InternalType_261> InternalVar_3 = InternalVar_2.InternalField_2228;

            for (int InternalVar_4 = 0; InternalVar_4 < InternalVar_3.Count; ++InternalVar_4)
            {
                try
                {
                    InternalType_261 InternalVar_5 = InternalVar_3[InternalVar_4];

                    if (InternalVar_5.InternalField_2229 is UIEventHandler<TEvent> typedEvent && (!InternalVar_5.InternalField_2230 || (InternalParameter_2379.Receiver == InternalParameter_2380.InternalField_2337 as MonoBehaviour)))
                    {
                        typedEvent.Invoke(InternalParameter_2379);
                    }
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
        }

        public void InternalMethod_1632<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_166) where TEvent : struct, IEvent where TTarget : class, InternalType_273
        {
            if (InternalField_2338 == null)
            {
                InternalField_2338 = new InternalType_524();
            }

            InternalField_2338.InternalMethod_1464(InternalParameter_166);
        }

        public void InternalMethod_1623<TEvent, TTarget>(UIEventHandler<TEvent, TTarget> InternalParameter_116) where TEvent : struct, IEvent where TTarget : class, InternalType_273
        {
            if (InternalField_2338 == null)
            {
                return;
            }

            InternalField_2338.InternalMethod_1461(InternalParameter_116);
        }

        public void InternalMethod_2075(InternalType_523 InternalParameter_2383)
        {
            if (InternalField_2339 == null)
            {
                InternalField_2339 = new InternalType_524.InternalType_525();
            }

            InternalField_2339.InternalMethod_2091(InternalParameter_2383);
        }

        public void InternalMethod_2076(InternalType_523 InternalParameter_2384)
        {
            if (InternalField_2339 == null)
            {
                return;
            }

            InternalField_2339.InternalMethod_2092(InternalParameter_2384);
        }

        public static void InternalMethod_2077<TEvent>(UIBlock InternalParameter_2385, TEvent InternalParameter_2386, Type InternalParameter_2387 = null) where TEvent : struct, IEvent
        {
            InternalType_157<InternalType_529<TEvent>> InternalVar_1 = InternalType_155<InternalType_529<TEvent>>.InternalMethod_740();

            UIBlock InternalVar_2 = InternalParameter_2385;

            InternalParameter_2386.ID = InternalType_524.InternalMethod_3250();

            do
            {
                InternalType_522 InternalVar_3 = InternalVar_2.InternalProperty_24;
                InternalType_524 InternalVar_4 = InternalVar_3.InternalProperty_437;

                bool InternalVar_5 = InternalVar_3.InternalProperty_1034 > 0;
                bool InternalVar_6 = InternalVar_4 != null && InternalVar_4.InternalMethod_2081<TEvent>(InternalParameter_2387);

                if (InternalVar_5)
                {
                    InternalVar_1.Add(new InternalType_529<TEvent>(ref InternalParameter_2386, InternalVar_3.InternalProperty_438));
                }

                if (InternalVar_6)
                {
                    InternalVar_3.InternalMethod_1521();

                    if (!InternalVar_5) 
                    {
                        InternalVar_1.Add(new InternalType_529<TEvent>(ref InternalParameter_2386, InternalVar_3.InternalProperty_438));
                    }

                    InternalVar_4.InternalMethod_3257(InternalVar_1, out bool InternalVar_7);

                    InternalVar_3.InternalMethod_1496();

                    if (InternalVar_7)
                    {
                        break;
                    }
                }

                InternalVar_2 = InternalVar_2.Parent;
                InternalParameter_2386.Target = InternalVar_2;

            } while (InternalVar_2 != null);

            InternalType_155<InternalType_529<TEvent>>.InternalMethod_741(InternalVar_1);
        }

        public static void InternalMethod_2086<TEvent>(ref TEvent InternalParameter_1308) where TEvent : struct, IEvent
        {
            InternalType_524.InternalMethod_3262(ref InternalParameter_1308);
        }

        public bool InternalMethod_1635(InternalType_273 InternalParameter_437, Type InternalParameter_181, out InternalType_273 InternalParameter_180)
        {
            InternalParameter_180 = this;
            return InternalField_2340 != null && InternalField_2340.TryGetValue(InternalParameter_181, out InternalType_245 InternalVar_1) && (InternalVar_1.InternalProperty_721 || InternalField_2337 == InternalParameter_437);
        }

        private void InternalMethod_1521()
        {
            if (++InternalField_2232 == 1)
            {
                InternalMethod_2075(this);
            }
        }

        private void InternalMethod_1496()
        {
            if (--InternalField_2232 == 0)
            {
                InternalMethod_2076(this);
            }

            InternalField_2232 = InternalField_2232 < 0 ? 0 : InternalField_2232;
        }

        public InternalType_522(InternalType_273 InternalParameter_115)
        {
            this.InternalField_2337 = InternalParameter_115;
        }
    }
}
