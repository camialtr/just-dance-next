// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(ScreenSpace))]
    [CanEditMultipleObjects]
    internal class InternalType_488 : InternalType_539<ScreenSpace>
    {
        protected override void OnEnable()
        {
            base.OnEnable();
            Undo.undoRedoPerformed += InternalMethod_1327;
        }

        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_1327;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.ObjectField(serializedObject.FindProperty(InternalType_646.InternalType_714.InternalField_2375), typeof(Camera), InternalType_554.InternalType_65.InternalField_1433);
            var InternalVar_1 = serializedObject.FindProperty(InternalType_646.InternalType_714.InternalField_3371);
            InternalType_573.InternalMethod_2246(InternalType_554.InternalType_65.InternalField_1432, InternalVar_1, InternalField_2385[0].Mode);

            var InternalVar_2 = (ScreenSpace.FillMode)InternalVar_1.intValue;
            if (InternalVar_2 == ScreenSpace.FillMode.FixedWidth || InternalVar_2 == ScreenSpace.FillMode.FixedHeight)
            {
                InternalType_573.InternalMethod_2241(InternalType_554.InternalType_65.InternalField_143, serializedObject.FindProperty(InternalType_646.InternalType_714.InternalField_3370));
            }

            InternalType_573.InternalMethod_3004(InternalType_554.InternalType_65.InternalField_448, serializedObject.FindProperty(InternalType_646.InternalType_714.InternalField_3372), 0f, float.MaxValue);

            EditorGUILayout.PropertyField(serializedObject.FindProperty(InternalType_646.InternalType_714.InternalField_2265), InternalType_554.InternalType_65.InternalField_2268);

            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_1327();
            }
        }

        private void InternalMethod_1327()
        {
            serializedObject.ApplyModifiedProperties();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                InternalField_2385[InternalVar_1].InternalMethod_1618();
            }
        }
    }
}

