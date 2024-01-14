// Copyright (c) Supernova Technologies LLC
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(Length))]
    internal class InternalType_588 : InternalType_583<InternalType_594>
    {
        protected override void OnGUI(Rect position, GUIContent label)
        {
            GUIContent InternalVar_1 = EditorGUI.BeginProperty(position, label, InternalField_2604.InternalProperty_954);
            Rect InternalVar_2 = position;
            InternalVar_2.width = Mathf.Max(InternalType_573.InternalField_2560, InternalVar_2.width - InternalType_573.InternalField_2559) - InternalType_573.InternalField_2557;

            EditorGUI.BeginChangeCheck();
            float InternalVar_3 = InternalField_2604.InternalProperty_506;
            float InternalVar_4 = float.IsNaN(InternalVar_3) ? 0 : InternalField_2604.InternalProperty_508 == LengthType.Value ? InternalVar_3 : InternalVar_3 * 100;
            InternalVar_4 = EditorGUI.FloatField(InternalVar_2, InternalVar_1, InternalVar_4);
            InternalVar_3 = InternalVar_4 / (InternalField_2604.InternalProperty_508 == LengthType.Value ? 1 : 100);
            bool InternalVar_5 = EditorGUI.EndChangeCheck();

            EditorGUI.BeginChangeCheck();
            Rect InternalVar_6 = InternalVar_2;
            InternalVar_6.width = InternalType_573.InternalField_2559;
            InternalVar_6.x += InternalVar_2.width + InternalType_573.InternalField_2557;
            LengthType InternalVar_7 = InternalType_573.InternalMethod_2257(InternalVar_6, InternalField_2604.InternalProperty_508);
            bool InternalVar_8 = EditorGUI.EndChangeCheck();
            EditorGUI.EndProperty();

            if (InternalVar_8)
            {
                InternalField_2604.InternalProperty_508 = InternalVar_7;
            }

            if (InternalVar_5)
            {
                InternalField_2604.InternalProperty_506 = InternalVar_3;
            }
        }
    }
}

