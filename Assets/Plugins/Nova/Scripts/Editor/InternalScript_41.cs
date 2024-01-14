// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_25;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(Interactable)), CanEditMultipleObjects]
    internal class InternalType_543 : InternalType_191<Interactable>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static GUIContent InternalField_2390 = EditorGUIUtility.TrTextContent("Drag");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static GUIContent InternalField_2391 = EditorGUIUtility.TrTextContent("Click");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_3784 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_2215 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_2398 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_2399 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_2400 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        SerializedProperty InternalField_2401 = null;

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalField_3784 = serializedObject.FindProperty(InternalType_646.InternalType_692.InternalField_3787);

            InternalField_2215 = serializedObject.FindProperty(InternalType_646.InternalType_693.InternalField_3336);

            InternalField_2398 = serializedObject.FindProperty(InternalType_646.InternalType_692.InternalField_3166);

            InternalField_2399 = serializedObject.FindProperty(InternalType_646.InternalType_692.InternalField_3167);
            InternalField_2400 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3164);
            InternalField_2401 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3165);
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField(InternalField_2391, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(InternalField_2398, InternalType_554.InternalType_743.InternalField_3457);

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(InternalField_2390, EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();
            InternalType_573.InternalMethod_2234(InternalField_2399, InternalType_554.InternalType_744.InternalField_3466);
            if (EditorGUI.EndChangeCheck() && Application.isPlaying)
            {
                InternalMethod_1220();
            }

            if (InternalType_728.InternalMethod_3278(InternalField_2385[0].Draggable))
            {
                InternalType_573.InternalMethod_2233(InternalType_554.InternalType_743.InternalField_3455, InternalField_2400, 0, InternalField_3344);
                InternalType_573.InternalMethod_2233(InternalType_554.InternalType_743.InternalField_3456, InternalField_2401, 0, InternalField_3344);
            }

            EditorGUILayout.Separator();
            EditorGUILayout.Separator();
            EditorGUILayout.PropertyField(InternalField_3784, InternalType_554.InternalType_744.InternalField_3785);
            EditorGUILayout.PropertyField(InternalField_2215, InternalType_554.InternalType_743.InternalField_3454);

            EditorGUILayout.Separator();
            InternalMethod_3433();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
