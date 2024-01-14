// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(MinMax))]
    internal class InternalType_665 : InternalType_583<InternalType_599>
    {
        protected override void OnGUI(Rect position, GUIContent label)
        {
            EditorGUI.PrefixLabel(position, label);

            position.InternalMethod_3253();

            float InternalVar_1 = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = InternalType_573.InternalField_2550 * 3;

            position.InternalMethod_3247(out Rect InternalVar_2, out Rect InternalVar_3);
            int InternalVar_4 = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;
            InternalMethod_2381(InternalVar_2, InternalType_554.InternalField_2474, InternalField_2604.InternalProperty_539);
            InternalMethod_2381(InternalVar_3, InternalType_554.InternalField_2475, InternalField_2604.InternalProperty_525);
            EditorGUI.indentLevel = InternalVar_4;

            EditorGUIUtility.labelWidth = InternalVar_1;
        }

        private void InternalMethod_2381(Rect InternalParameter_2173, GUIContent InternalParameter_1907, SerializedProperty InternalParameter_1906)
        {
            EditorGUI.BeginProperty(InternalParameter_2173, InternalParameter_1907, InternalParameter_1906);

            float InternalVar_1 = InternalParameter_1906.floatValue;
            bool InternalVar_2 = !float.IsInfinity(InternalVar_1);

            InternalParameter_2173.InternalMethod_3249(InternalType_573.InternalField_2551, out Rect InternalVar_3, out Rect InternalVar_4);
            bool InternalVar_5 = EditorGUI.ToggleLeft(InternalVar_3, GUIContent.none, InternalVar_2);
            InternalParameter_2173.InternalMethod_3252(InternalParameter_2173.width);

            if (InternalVar_5 != InternalVar_2)
            {
                if (InternalVar_5)
                {
                    InternalParameter_1906.floatValue = 0f;
                }
                else
                {
                    InternalParameter_1906.floatValue = float.NegativeInfinity;
                }
            }

            EditorGUI.BeginDisabledGroup(!InternalVar_5);
            EditorGUI.BeginChangeCheck();
            float InternalVar_6 = EditorGUI.FloatField(InternalVar_4, InternalParameter_1907, InternalParameter_1906.floatValue);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_1906.floatValue = InternalVar_6;
            }
            EditorGUI.EndDisabledGroup();

            EditorGUI.EndProperty();
        }
    }
}