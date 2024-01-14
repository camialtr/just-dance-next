// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_1;
using Nova.InternalNamespace_0.InternalNamespace_4;

namespace Nova
{
    internal static class InternalType_725
    {
        private class InternalType_495<T77> : InternalType_120.InternalType_122 where T77 : struct, IAnimationWithEvents
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static InternalType_495<T77> InternalField_2979 = new InternalType_495<T77>();

            public void InternalMethod_593(InternalType_125 InternalParameter_484)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_484, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.OnCanceled();
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_484, InternalVar_1);
                }
            }

            public void InternalMethod_590(InternalType_125 InternalParameter_481)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_481, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.Complete();
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_481, InternalVar_1);
                }
            }

            public void InternalMethod_589(InternalType_125 InternalParameter_480)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_480, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.End();
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_480, InternalVar_1);
                }
            }

            public void InternalMethod_591(InternalType_125 InternalParameter_482)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_482, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.OnPaused();
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_482, InternalVar_1);
                }
            }

            public void InternalMethod_592(InternalType_125 InternalParameter_483)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_483, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.OnResumed();
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_483, InternalVar_1);
                }
            }

            public void InternalMethod_588(InternalType_125 InternalParameter_478, int iterations)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_478, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.Begin(iterations);
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_478, InternalVar_1);
                }
            }

            public void InternalMethod_594(InternalType_125 InternalParameter_485, float InternalParameter_486)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_826(InternalParameter_485, out T77 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.Update(InternalParameter_486);
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_827(InternalParameter_485, InternalVar_1);
                }
            }

            public void InternalMethod_595(InternalType_125 InternalParameter_487)
            {
                InternalType_169<InternalType_125>.InternalType_171<T77>.InternalMethod_824(InternalParameter_487);
            }
        }

        private class InternalType_494<T78> : InternalType_120.InternalType_123 where T78 : struct, IAnimation
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static InternalType_494<T78> InternalField_2978 = new InternalType_494<T78>();

            public void InternalMethod_594(InternalType_125 InternalParameter_485, float InternalParameter_486)
            {
                if (!InternalType_169<InternalType_125>.InternalType_171<T78>.InternalMethod_826(InternalParameter_485, out T78 InternalVar_1))
                {
                    return;
                }

                try
                {
                    InternalVar_1.Update(InternalParameter_486);
                }
                catch (System.Exception e)
                {
                    UnityEngine.Debug.LogException(e);
                }
                finally
                {
                    InternalType_169<InternalType_125>.InternalType_171<T78>.InternalMethod_827(InternalParameter_485, InternalVar_1);
                }
            }

            public void InternalMethod_595(InternalType_125 InternalParameter_487)
            {
                InternalType_169<InternalType_125>.InternalType_171<T78>.InternalMethod_824(InternalParameter_487);
            }
        }

        public static InternalType_125 InternalMethod_2950<T>(ref T InternalParameter_2316, float InternalParameter_2315, int InternalParameter_2314) where T : struct, IAnimationWithEvents => InternalType_120.InternalField_406.InternalMethod_2721(ref InternalParameter_2316, InternalParameter_2315, InternalParameter_2314, InternalType_495<T>.InternalField_2979);
        public static InternalType_125 InternalMethod_2949<T>(ref T InternalParameter_2287, float InternalParameter_2286, int InternalParameter_2285) where T : struct, IAnimation => InternalType_120.InternalField_406.InternalMethod_2721<T>(ref InternalParameter_2287, InternalParameter_2286, InternalParameter_2285, InternalType_494<T>.InternalField_2978);

        public static InternalType_125 InternalMethod_2734<T>(InternalType_125 InternalParameter_2284, ref T InternalParameter_2283, float InternalParameter_2282, int InternalParameter_2267) where T : struct, IAnimationWithEvents => InternalType_120.InternalField_406.InternalMethod_2720(InternalParameter_2284, ref InternalParameter_2283, InternalParameter_2282, InternalParameter_2267, InternalType_495<T>.InternalField_2979);
        public static InternalType_125 InternalMethod_2733<T>(InternalType_125 InternalParameter_2266, ref T InternalParameter_2265, float InternalParameter_2264, int InternalParameter_2263) where T : struct, IAnimation => InternalType_120.InternalField_406.InternalMethod_2720(InternalParameter_2266, ref InternalParameter_2265, InternalParameter_2264, InternalParameter_2263, InternalType_494<T>.InternalField_2978);

        public static InternalType_125 InternalMethod_2728<T>(InternalType_125 InternalParameter_2262, ref T InternalParameter_2261) where T : struct, IAnimationWithEvents => InternalType_120.InternalField_406.InternalMethod_2718(InternalParameter_2262, ref InternalParameter_2261, InternalType_495<T>.InternalField_2979);
        public static InternalType_125 InternalMethod_2702<T>(InternalType_125 InternalParameter_2260, ref T InternalParameter_2259) where T : struct, IAnimation => InternalType_120.InternalField_406.InternalMethod_2718(InternalParameter_2260, ref InternalParameter_2259, InternalType_494<T>.InternalField_2978);

        public static InternalType_125 InternalMethod_2701<T>(InternalType_125 InternalParameter_2258, ref T InternalParameter_2257, float InternalParameter_2256, int InternalParameter_2255) where T : struct, IAnimationWithEvents => InternalType_120.InternalField_406.InternalMethod_2719(InternalParameter_2258, ref InternalParameter_2257, InternalParameter_2256, InternalParameter_2255, InternalType_495<T>.InternalField_2979);
        public static InternalType_125 InternalMethod_2700<T>(InternalType_125 InternalParameter_2254, ref T InternalParameter_2253, float InternalParameter_2252, int InternalParameter_2251) where T : struct, IAnimation => InternalType_120.InternalField_406.InternalMethod_2719(InternalParameter_2254, ref InternalParameter_2253, InternalParameter_2252, InternalParameter_2251, InternalType_494<T>.InternalField_2978);
    }
}
