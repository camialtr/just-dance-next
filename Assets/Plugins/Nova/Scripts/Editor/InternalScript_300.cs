// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    
    internal static class InternalType_44
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static int InternalField_411 = -1;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static UIBlock[] InternalField_142 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Dictionary<UIBlock, Vector3> InternalField_141 = new Dictionary<UIBlock, Vector3>();

        [InitializeOnLoadMethod]
        private static void InternalMethod_1839()
        {
            InternalField_411 = -1;
            InternalField_142 = null;
            InternalField_141.Clear();

            Selection.selectionChanged -= InternalMethod_3318;
            Selection.selectionChanged += InternalMethod_3318;

            InternalType_64.InternalEvent_11 -= InternalMethod_3320;
            InternalType_64.InternalEvent_11 += InternalMethod_3320;

            InternalType_64.InternalEvent_1 -= InternalMethod_3319;
            InternalType_64.InternalEvent_1 += InternalMethod_3319;

            InternalMethod_3318();
        }

        private static void InternalMethod_3319()
        {
            if (InternalField_142 == null || !InternalType_457.InternalProperty_190.InternalProperty_408)
            {
                return;
            }

            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_142.Length; ++InternalVar_1)
            {
                UIBlock InternalVar_2 = InternalField_142[InternalVar_1];
                InternalType_67 InternalVar_3 = InternalVar_2;

                InternalType_133 InternalVar_4 = InternalVar_3.InternalProperty_196;

                if (!InternalVar_4.InternalProperty_194 || !InternalType_457.InternalProperty_190.InternalField_1859[InternalVar_4])
                {
                    continue;
                }

                Vector3 InternalVar_5 = InternalField_141[InternalVar_2];

                Vector3 InternalVar_6 = InternalType_448.InternalMethod_1747(InternalVar_4, ref InternalType_457.InternalProperty_190.InternalField_1841).InternalProperty_361.InternalProperty_115;

                if (InternalVar_6 != InternalVar_5)
                {
                    SerializedObject InternalVar_7 = new SerializedObject(InternalVar_2);
                    InternalType_595 InternalVar_8 = new InternalType_595() { InternalProperty_954 = InternalVar_7.FindProperty("layout.Position") };
                    InternalVar_8.InternalProperty_510.InternalProperty_506 = InternalVar_6.x;
                    InternalVar_8.InternalProperty_512.InternalProperty_506 = InternalVar_6.y;
                    InternalVar_8.InternalProperty_514.InternalProperty_506 = InternalVar_6.z;
                    InternalVar_7.ApplyModifiedProperties();
                }
            }
        }

        private static void InternalMethod_3320()
        {
            int InternalVar_1 = Undo.GetCurrentGroup();

            if (InternalField_411 == InternalVar_1)
            {
                return;
            }

            InternalField_411 = InternalVar_1;

            foreach (UIBlock InternalVar_2 in InternalField_142)
            {
                InternalField_141[InternalVar_2] = InternalVar_2.Position.Raw;
            }
        }

        private static void InternalMethod_3318()
        {
            InternalField_142 = Selection.GetFiltered<UIBlock>(SelectionMode.TopLevel).Where(x => x.gameObject.activeInHierarchy && PrefabUtility.IsAnyPrefabInstanceRoot(x.gameObject)).ToArray();
            InternalField_141.Clear();
        }

        
        public static void InternalMethod_3261(UIBlock InternalParameter_1313)
        {
            Vector3 InternalVar_1 = InternalParameter_1313.transform.localPosition;
            Vector3 InternalVar_2 = InternalParameter_1313.InternalMethod_1035();
            bool InternalVar_3 = InternalVar_1 != InternalVar_2;

            if (InternalVar_3)
            {
                Vector3 InternalVar_4 = InternalMethod_3206(InternalParameter_1313);

                InternalType_5 InternalVar_5 = InternalParameter_1313.InternalMethod_3592();
                Vector3 InternalVar_6 = InternalVar_5 != null ? (Vector3)InternalVar_5.InternalProperty_146.InternalProperty_139 : Vector3.zero;

                Vector3 InternalVar_7 = InternalType_182.InternalMethod_852(InternalVar_1, InternalParameter_1313.LayoutSize, InternalParameter_1313.CalculatedMargin.Offset, InternalVar_4, InternalVar_6, (Vector3)InternalParameter_1313.Alignment);
                InternalParameter_1313.Position.Raw = Length3.InternalMethod_2424(InternalVar_7, InternalParameter_1313.Position, InternalParameter_1313.PositionMinMax, InternalVar_4);
            }

            if (InternalVar_3 || InternalType_457.InternalProperty_190.InternalProperty_408)
            {



                SerializedObject InternalVar_4 = new SerializedObject(InternalParameter_1313);
                InternalType_600 InternalVar_5 = new InternalType_600() { InternalProperty_954 = InternalVar_4.FindProperty("layout") };
                InternalType_595 InternalVar_6 = InternalVar_5.InternalProperty_552;

                Vector3 InternalVar_7 = InternalParameter_1313.Position.Raw;
                InternalVar_6.InternalProperty_510.InternalProperty_506 = InternalVar_7.x;
                InternalVar_6.InternalProperty_512.InternalProperty_506 = InternalVar_7.y;
                InternalVar_6.InternalProperty_514.InternalProperty_506 = InternalVar_7.z;

                InternalVar_4.ApplyModifiedProperties();
            }
        }

        public static bool InternalMethod_3259(Transform InternalParameter_2317) => InternalType_457.InternalProperty_190.InternalProperty_206.InternalMethod_1960(InternalParameter_2317);

        
        public static Vector3 InternalMethod_3206(UIBlock InternalParameter_2318)
        {
            InternalType_5 InternalVar_1 = InternalParameter_2318.InternalMethod_3592();
            bool InternalVar_2 = InternalVar_1 != null;

            if (!InternalVar_2)
            {
                return Vector3.zero;
            }

            return InternalVar_1.InternalProperty_148;
        }
    }
}
