// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    internal class InternalType_537 : InternalType_136<InternalType_537>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_429.InternalType_430<InternalType_444> InternalField_2376;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_433<InternalType_445, InternalType_434, InternalType_444> InternalField_2377;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_428> InternalField_2378 = new List<InternalType_428>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_735<InternalType_175> InternalField_2379;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                private static InternalType_5 InternalField_2380 = null;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                private static InternalType_428 InternalField_2381;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                private static double InternalField_2382 = float.MinValue;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const double InternalField_2383 = 10;

        
        public static void InternalMethod_2149()
        {
            if (InternalMethod_2163())
            {
                InternalMethod_2157(Event.current.mousePosition, InternalParameter_2466: true, InternalParameter_2467: true);
            }
            else
            {
                UnityEditor.Selection.activeGameObject = UnityEditor.HandleUtility.PickGameObject(Event.current.mousePosition, out int _);
            }
        }

        
        internal static bool InternalMethod_843(Ray InternalParameter_690, List<InternalType_427> InternalParameter_1051, Camera InternalParameter_1050, NovaHashMap<InternalType_131, bool> InternalParameter_1003, int InternalParameter_1002 = int.MaxValue)
        {
            InternalMethod_1041(InternalParameter_690, InternalParameter_1050, ref InternalParameter_1003, ref InternalField_2376);
            InternalMethod_2155(ref InternalField_2376.InternalField_1656, InternalParameter_1051, InternalParameter_1002);
            return InternalParameter_1051.Count > 0;
        }

        
        public static bool InternalMethod_2151(Ray InternalParameter_2451, List<InternalType_428> InternalParameter_2452, int InternalParameter_2453 = InternalType_429.InternalField_1645)
        {
            InternalType_429.InternalProperty_200.InternalMethod_1687(InternalParameter_2451, InternalParameter_2452, float.PositiveInfinity, InternalMethod_2154, InternalParameter_2453);
            return InternalParameter_2452.Count > 0;
        }

        public static bool InternalMethod_2152(Ray InternalParameter_2454, out InternalType_428 InternalParameter_2455)
        {
            return InternalType_429.InternalProperty_200.InternalMethod_1688(InternalParameter_2454, out InternalParameter_2455, InternalMethod_2154);
        }

        private static void InternalMethod_1041(Ray InternalParameter_1001, Camera InternalParameter_1000, ref NovaHashMap<InternalType_131, bool> InternalParameter_999, ref InternalType_429.InternalType_430<InternalType_444> InternalParameter_996)
        {
            float4x4 InternalVar_1 = InternalParameter_1000.projectionMatrix * InternalParameter_1000.transform.worldToLocalMatrix;

            {
                InternalField_2377.InternalField_1665.InternalField_1749 = InternalVar_1;
                InternalField_2377.InternalField_1665.InternalField_1748 = InternalParameter_1001;
                InternalField_2377.InternalField_1665.InternalField_1747 = InternalParameter_999;

                InternalField_2377.InternalField_1667 = InternalParameter_996.InternalField_1656;
                InternalField_2377.InternalField_1666 = InternalParameter_996.InternalField_1657;

                unsafe
                {
                    InternalField_2379.InternalField_3352.Invoke(UnsafeUtility.AddressOf(ref InternalField_2377));
                }
            }
        }

        private static bool InternalMethod_2154(InternalType_5 InternalParameter_2460) => InternalParameter_2460.InternalProperty_203 ? false : SceneViewUtils.IsSelectableInSceneView(InternalParameter_2460.InternalProperty_202.gameObject);

        
        private static void InternalMethod_2155(ref NativeList<InternalType_444> InternalParameter_2461, List<InternalType_427> InternalParameter_2462, int InternalParameter_2463 = int.MaxValue)
        {
            InternalParameter_2462.Clear();

            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_2461.Length && InternalVar_1 < InternalParameter_2463; ++InternalVar_1)
            {
                InternalType_444 InternalVar_2 = InternalParameter_2461[InternalVar_1];
                if (!InternalType_253.InternalProperty_190.InternalField_413.TryGetValue(InternalVar_2.InternalField_1732, out InternalType_145 InternalVar_3))
                {
                    continue;
                }

                if (InternalVar_3.InternalProperty_203)
                {
                    continue;
                }

                UIBlock InternalVar_4 = InternalVar_3 as UIBlock;

                if (!SceneViewUtils.IsVisibleInSceneView(InternalVar_4.gameObject))
                {
                    continue;
                }

                InternalParameter_2462.Add(new InternalType_427()
                {
                    InternalField_1638 = InternalVar_4,
                    InternalField_1640 = InternalVar_2.InternalField_1729,
                    InternalField_1641 = InternalVar_2.InternalField_1726,
                    InternalField_1639 = new Bounds(InternalVar_2.InternalField_1730, InternalVar_2.InternalField_1731),
                });
            }
        }

        private static void InternalMethod_2156(UnityEditor.SceneView InternalParameter_2464)
        {
            Event InternalVar_1 = Event.current;

            bool InternalVar_2 = true;

            if (!InternalMethod_2158(InternalParameter_2464, InternalVar_1) || !InternalMethod_2159(InternalVar_1))
            {
                if (UnityEditor.EditorApplication.timeSinceStartup - InternalField_2382 > InternalField_2383)
                {
                    InternalField_2381 = default;
                }
                InternalVar_2 = false;
            }

            if (InternalVar_2)
            {
                InternalMethod_2157(InternalVar_1.mousePosition, InternalParameter_2466: InternalVar_1.type == EventType.MouseDown);
                InternalMethod_2164(InternalVar_1);
            }

            if (InternalField_2380 == null && UnityEditor.Selection.activeGameObject == null)
            {
                InternalField_2381 = default;
            }
        }

        public static void InternalMethod_2157(Vector2 InternalParameter_2465, bool InternalParameter_2466, bool InternalParameter_2467 = false)
        {
            using (new UnityEditor.Handles.DrawingScope(Matrix4x4.identity))
            {
                Ray InternalVar_1 = UnityEditor.HandleUtility.GUIPointToWorldRay(InternalParameter_2465);

                if (InternalMethod_2151(InternalVar_1, InternalField_2378))
                {
                    int InternalVar_2 = 0;

                    if (!InternalMethod_2163())
                    {
                        InternalVar_2 = InternalField_2378.IndexOf(InternalField_2381) + 1;

                        if (InternalVar_2 >= InternalField_2378.Count)
                        {
                            InternalField_2381 = default(InternalType_428);
                            return;
                        }
                    }

                    InternalMethod_2162(InternalVar_1, InternalField_2378[InternalVar_2], InternalParameter_2466);

                    if (InternalParameter_2467 && InternalParameter_2466)
                    {
                        InternalMethod_2162(InternalVar_1, InternalField_2378[InternalVar_2], !InternalParameter_2466);
                    }
                }
                else
                {
                    InternalField_2381 = default(InternalType_428);
                }
            }
        }

        private static bool InternalMethod_2158(UnityEditor.SceneView InternalParameter_2468, Event InternalParameter_2469)
        {
            return InternalParameter_2468 != null && InternalParameter_2468.camera != null && InternalParameter_2469 != null;
        }

        private static bool InternalMethod_2159(Event InternalParameter_2470)
        {
            if (InternalParameter_2470.button != 0 || InternalParameter_2470.clickCount == 0)
            {
                return false;
            }

            if (InternalParameter_2470.type == EventType.Repaint || InternalParameter_2470.type == EventType.Layout)
            {
                return false;
            }

            bool InternalVar_1 = InternalParameter_2470.type == EventType.MouseDown && GUIUtility.hotControl != 0;
            bool InternalVar_2 = (InternalParameter_2470.type == EventType.MouseUp || (InternalParameter_2470.type == EventType.Used && GUIUtility.hotControl == 0));

            if (InternalVar_1 || InternalVar_2)
            {
                return true;
            }

            return false;
        }

        public static GameObject InternalMethod_2160(Camera InternalParameter_2471, int InternalParameter_2472, Vector2 InternalParameter_2473, GameObject[] InternalParameter_2474, GameObject[] InternalParameter_2475, out int InternalParameter_2476)
        {
            InternalMethod_2151(InternalParameter_2471.ScreenPointToRay(InternalParameter_2473), InternalField_2378, InternalParameter_2472);

            IEnumerable<GameObject> InternalVar_1 = InternalField_2378.Select(x => x.InternalProperty_343);

            int InternalVar_2 = 0;

            if (InternalParameter_2475 != null && InternalParameter_2475.Where(x => x != null).FirstOrDefault() != null)
            {
                InternalVar_1 = InternalVar_1.Intersect(InternalParameter_2475);
            }

            if (InternalParameter_2474 != null && InternalParameter_2474.Where(x => x != null).FirstOrDefault() != null)
            {
                InternalVar_1 = InternalVar_1.Except(InternalParameter_2474);
            }
            else if (InternalField_2378.Count > 1)
            {
                GameObject[] InternalVar_3 = UnityEditor.Selection.gameObjects;

                if (InternalVar_3 != null)
                {
                    if (InternalVar_3.Length == 1)
                    {
                        List<GameObject> InternalVar_4 = InternalVar_1.ToList();

                        if (InternalVar_4.Count > 0)
                        {
                            InternalVar_2 = (InternalVar_4.IndexOf(InternalVar_3[0]) + 1) % InternalVar_4.Count;
                        }
                    }
                    else
                    {
                        InternalVar_1 = InternalVar_1.Except(InternalVar_3);
                    }
                }
            }

            InternalParameter_2476 = 0;

            return InternalVar_1.ElementAtOrDefault(InternalVar_2);
        }


        private static bool InternalMethod_2161(out GameObject InternalParameter_2477)
        {
            InternalParameter_2477 = UnityEditor.HandleUtility.PickGameObject(Event.current.mousePosition, out int InternalVar_1);

            return InternalParameter_2477 != null;
        }

        private static void InternalMethod_2162(Ray InternalParameter_2478, InternalType_428 InternalParameter_2479, bool InternalParameter_2480)
        {
            if (InternalMethod_2161(out GameObject InternalVar_1) && InternalVar_1.GetComponent<UIBlock>() == null)
            {
                bool InternalVar_3 = UnityEditor.HandleUtility.FindNearestVertex(Event.current.mousePosition, new Transform[] { InternalVar_1.transform }, out Vector3 InternalVar_2);
                Vector3 InternalVar_4 = InternalVar_3 ? InternalVar_2 : InternalVar_1.transform.position;
                float InternalVar_5 = Vector3.Distance(InternalVar_4, InternalParameter_2478.origin);
                float InternalVar_6 = Vector3.Distance(InternalParameter_2479.InternalField_1643, InternalParameter_2478.origin);

                if (InternalVar_5 < InternalVar_6)
                {
                    InternalField_2380 = null;
                    return;
                }
            }

            if (InternalParameter_2480)
            {
                InternalField_2380 = InternalParameter_2479.InternalField_1642;
                return;
            }

            if (InternalParameter_2479.InternalField_1642 != InternalField_2380)
            {
                InternalField_2380 = null;
                return;
            }

            bool InternalVar_7 = false;

            bool InternalVar_8 = UnityEditor.EditorGUI.actionKey; 

            if (InternalVar_8)
            {
                InternalVar_7 = UnityEditor.Selection.Contains(InternalParameter_2479.InternalProperty_343);
            }

            bool InternalVar_9 = Event.current.shift || (InternalVar_8 && !InternalVar_7);
            bool InternalVar_10 = InternalVar_8 && InternalVar_7;

            if (InternalVar_9)
            {
                Object[] InternalVar_11 = UnityEditor.Selection.objects;
                Object[] InternalVar_12 = new Object[InternalVar_11.Length + 1];
                System.Array.Copy(InternalVar_11, InternalVar_12, InternalVar_11.Length);
                InternalVar_12[InternalVar_11.Length] = InternalParameter_2479.InternalProperty_343;

                UnityEditor.Selection.objects = InternalVar_12;
            }
            else if (InternalVar_10)
            {
                Object[] InternalVar_11 = UnityEditor.Selection.objects;
                Object[] InternalVar_12 = new Object[InternalVar_11.Length - 1];
                int InternalVar_13 = System.Array.IndexOf(InternalVar_11, InternalParameter_2479.InternalProperty_343);

                System.Array.Copy(InternalVar_11, InternalVar_12, InternalVar_13);
                System.Array.Copy(InternalVar_11, InternalVar_13 + 1, InternalVar_12, InternalVar_13, InternalVar_11.Length - InternalVar_13 - 1);

                UnityEditor.Selection.objects = InternalVar_12;
            }
            else
            {
                UnityEditor.Selection.activeGameObject = InternalParameter_2479.InternalProperty_343;
            }

            InternalField_2381 = InternalParameter_2479;

            InternalField_2380 = null;

            InternalField_2382 = UnityEditor.EditorApplication.timeSinceStartup;
        }

        public static bool InternalMethod_2163()
        {
            return Event.current.shift || UnityEditor.EditorGUI.actionKey;
        }

        private static void InternalMethod_2164(Event InternalParameter_2481)
        {
            if (InternalParameter_2481.type != EventType.Used)
            {
                return;
            }

            UnityEditor.EditorGUIUtility.hotControl = 0;
        }

        protected override void InternalMethod_656()
        {
            unsafe
            {
                InternalField_2379 = new InternalType_735<InternalType_175>(InternalType_433<InternalType_445, InternalType_434, InternalType_444>.InternalMethod_1703);
            }

            InternalType_253 InternalVar_1 = InternalType_253.InternalProperty_190;
            InternalType_457 InternalVar_2 = InternalType_457.InternalProperty_190;

            InternalField_2376.InternalMethod_702();

            InternalField_2377 = new InternalType_433<InternalType_445, InternalType_434, InternalType_444>()
            {
                InternalField_1670 = InternalVar_1.InternalProperty_263,
                InternalField_1671 = InternalVar_1.InternalProperty_264,
                InternalField_1669 = InternalVar_1.InternalProperty_260,

                InternalField_1668 = InternalVar_2.InternalField_1861,

                InternalField_1665 = new InternalType_445()
                {
                    InternalField_1735 = InternalVar_2.InternalField_1843,
                    InternalField_1736 = InternalVar_2.InternalField_1854,
                    InternalField_1737 = InternalVar_2.InternalField_1855,
                    InternalField_1738 = InternalVar_2.InternalField_430,
                    InternalField_1739 = InternalVar_2.InternalField_431,
                    InternalField_1743 = InternalVar_2.InternalField_1857,
                    InternalField_1744 = InternalVar_2.InternalField_1856,
                    InternalField_1745 = InternalVar_2.InternalField_1858,
                    InternalField_1746 = InternalVar_2.InternalField_1844,

                    InternalField_1740 = InternalVar_1.InternalProperty_263,
                    InternalField_1741 = InternalVar_1.InternalProperty_264,
                    InternalField_1742 = InternalVar_1.InternalProperty_265.InternalField_594,
                }
            };

            UnityEditor.HandleUtility.pickGameObjectCustomPasses += InternalMethod_2160;
            UnityEditor.SceneView.duringSceneGui += InternalMethod_2156;
        }

        protected override void InternalMethod_657()
        {
            InternalField_2376.Dispose();

            UnityEditor.HandleUtility.pickGameObjectCustomPasses -= InternalMethod_2160;
            UnityEditor.SceneView.duringSceneGui -= InternalMethod_2156;
            UnityEditor.EditorGUIUtility.hotControl = 0;
        }
    }
}
