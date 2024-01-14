// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(GridView)), CanEditMultipleObjects]
    internal class InternalType_541 : InternalType_542
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected override string[] InternalProperty_456 { get; } = new string[] { "m_Script", InternalType_646.InternalType_668.InternalField_3026, InternalType_646.InternalType_668.InternalField_3027 };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_2387 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_2388 = null;

        private void OnEnable()
        {
            InternalField_2387 = serializedObject.FindProperty(InternalType_646.InternalType_668.InternalField_3026);
            InternalField_2388 = serializedObject.FindProperty(InternalType_646.InternalType_668.InternalField_3027);
        }

        protected override void InternalMethod_2174()
        {
            EditorGUILayout.LabelField("Grid", EditorStyles.boldLabel);

            if (serializedObject.targetObjects.Length == 1)
            {
                EditorGUI.BeginDisabledGroup(true);
                GridView InternalVar_1 = target as GridView;
                EditorGUILayout.EnumPopup(new GUIContent("Primary Axis", "The Primary Axis is the scrollable axis and is implicitly assigned via the attached UIBlock's AutoLayout.Axis property"), InternalVar_1.UIBlock.AutoLayout.Axis);
                EditorGUI.EndDisabledGroup();
            }

            EditorGUILayout.PropertyField(InternalField_2387);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(InternalField_2388);
            if (EditorGUI.EndChangeCheck() && Application.isPlaying)
            {
                InternalField_2388.serializedObject.ApplyModifiedProperties();

                foreach (Object InternalVar_1 in targets)
                {
                    GridView InternalVar_2 = InternalVar_1 as GridView;
                    if (!Application.IsPlaying(InternalVar_2) || !InternalVar_2.gameObject.activeInHierarchy)
                    {
                        continue;
                    }

                    InternalVar_2.InternalMethod_411();
                }
            }

            EditorGUILayout.Space();
        }
    }
}
