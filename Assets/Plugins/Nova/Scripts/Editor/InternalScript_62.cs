// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(Length3))]
    internal class InternalType_587 : InternalType_583<InternalType_595>
    {
        protected override void OnGUI(Rect position, GUIContent label)
        {
            EditorGUI.LabelField(position, label);

            position.InternalMethod_3253();

            position.InternalMethod_3248(out Rect InternalVar_1, out Rect InternalVar_2, out Rect InternalVar_3);
            float InternalVar_4 = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = InternalType_573.InternalField_2550;
            EditorGUI.PropertyField(InternalVar_1, InternalField_2604.InternalProperty_511);
            EditorGUI.PropertyField(InternalVar_2, InternalField_2604.InternalProperty_513);
            EditorGUI.PropertyField(InternalVar_3, InternalField_2604.InternalProperty_515);
            EditorGUIUtility.labelWidth = InternalVar_4;
        }
    }
}