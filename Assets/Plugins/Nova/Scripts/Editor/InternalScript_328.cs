// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(CrossLayout))]
    internal class InternalType_778 : InternalType_583<InternalType_780>
    {
        protected override float InternalMethod_2353(GUIContent InternalParameter_2767)
        {
            if (!InternalField_2604.InternalProperty_954.isExpanded)
            {
                return EditorGUI.GetPropertyHeight(InternalField_2604.InternalProperty_954, InternalParameter_2767, false);
            }

            return 9f * InternalType_720.InternalField_3298;
        }

        protected override void OnGUI(Rect position, GUIContent label)
        {
           InternalField_2604.InternalProperty_954.isExpanded = EditorGUI.Foldout(position, InternalField_2604.InternalProperty_954.isExpanded, label, true);

            if (!InternalField_2604.InternalProperty_954.isExpanded)
            {
                EditorGUI.EndFoldoutHeaderGroup();
                return;
            }

            position.InternalMethod_3251();

            using (new EditorGUI.IndentLevelScope(1))
            {
                EditorGUI.BeginChangeCheck();

                bool InternalVar_1 = EditorGUI.Toggle(position, InternalType_554.InternalType_557.InternalField_2086, InternalField_2604.InternalProperty_1172.boolValue);

                if (EditorGUI.EndChangeCheck())
                {
                    if (InternalVar_1)
                    {
                        InternalField_2604.InternalProperty_1171 = Axis.X;
                    }
                    else
                    {
                        InternalField_2604.InternalProperty_1171 = Axis.None;
                    }
                }

                position.InternalMethod_3251();

                EditorGUI.BeginDisabledGroup(!InternalVar_1);
                float InternalVar_2 = (position.width - EditorGUIUtility.labelWidth) / 3f;
                EditorGUI.PrefixLabel(position, InternalType_554.InternalType_557.InternalField_2491);
                Rect InternalVar_3 = new Rect(position.x + InternalType_573.InternalProperty_472, position.y, position.width - InternalType_573.InternalProperty_472, position.height);
                EditorGUI.BeginChangeCheck();
                EditorGUI.BeginProperty(InternalVar_3, GUIContent.none, InternalField_2604.InternalProperty_1172);
                int InternalVar_4 = InternalField_2604.InternalProperty_1171.Index();
                InternalVar_4 = InternalVar_4 >= 0 ? InternalVar_4 : 0;
                int InternalVar_5 = InternalType_573.InternalMethod_1887(InternalVar_3, InternalVar_4, InternalType_554.InternalField_2463, InternalVar_2);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalField_2604.InternalProperty_1171 = AxisIndex.GetAxis(InternalVar_5);
                }
                EditorGUI.EndDisabledGroup();

                position.InternalMethod_3251();

                EditorGUI.PrefixLabel(position, InternalType_554.InternalType_557.InternalField_2492);

                Rect InternalVar_6 = new Rect(position.x + InternalType_573.InternalProperty_472, position.y, position.width - InternalType_573.InternalProperty_472, position.height);
                EditorGUI.BeginChangeCheck();
                EditorGUI.BeginProperty(InternalVar_6, GUIContent.none, InternalField_2604.InternalProperty_1182);
                int InternalVar_7 = InternalType_573.InternalMethod_1887(InternalVar_6, InternalField_2604.InternalProperty_1181 + 1, InternalType_554.InternalProperty_464[InternalVar_4], InternalVar_2);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalField_2604.InternalProperty_1181 = InternalVar_7 - 1;
                }

                position.InternalMethod_3251();
                EditorGUI.PrefixLabel(position, InternalType_554.InternalType_557.InternalField_2493);

                float InternalVar_8 = (position.width - EditorGUIUtility.labelWidth) / 2f;

                Rect InternalVar_9 = new Rect(position.x + InternalType_573.InternalProperty_472, position.y, position.width - InternalType_573.InternalProperty_472, position.height);
                EditorGUI.BeginChangeCheck();
                EditorGUI.BeginProperty(InternalVar_9, GUIContent.none, InternalField_2604.InternalProperty_1180);
                int InternalVar_10 = InternalType_573.InternalMethod_1887(InternalVar_9, InternalField_2604.InternalProperty_1179 ? 1 : 0, InternalType_554.InternalProperty_465[InternalVar_4], InternalVar_8);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalField_2604.InternalProperty_1179 = InternalVar_10 == 1;
                }

                position.InternalMethod_3251();

                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1178);
                position.InternalMethod_3251();
                EditorGUI.BeginDisabledGroup(InternalField_2604.InternalProperty_1177);
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1174);
                EditorGUI.EndDisabledGroup();
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1176);
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1184);
            }

            EditorGUI.EndFoldoutHeaderGroup();
        }
    }
}