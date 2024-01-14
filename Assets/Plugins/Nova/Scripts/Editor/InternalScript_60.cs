// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(Length2))]
    internal class InternalType_586 : InternalType_583<InternalType_593>
    {
        protected override void OnGUI(Rect position, GUIContent label)
        {
            EditorGUI.LabelField(position, label);

            position.InternalMethod_3253();


            position.InternalMethod_3247(out Rect InternalVar_1, out Rect InternalVar_2);
            float InternalVar_3 = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = InternalType_573.InternalField_2550;
            EditorGUI.PropertyField(InternalVar_1, InternalField_2604.InternalProperty_503);
            EditorGUI.PropertyField(InternalVar_2, InternalField_2604.InternalProperty_505);
            EditorGUIUtility.labelWidth = InternalVar_3;
        }
    }
}