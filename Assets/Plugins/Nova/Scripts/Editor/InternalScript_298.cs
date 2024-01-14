// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_17.InternalNamespace_22;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal abstract class InternalType_191<T79> : InternalType_539<T79> where T79 : GestureRecognizer
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static GUIContent InternalField_3448 = EditorGUIUtility.TrTextContent("Navigate");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<T79> InternalField_2219 = new List<T79>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3344 = 89;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_3449 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_3450 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_3451 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_3452 = null;

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalField_3450 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3527);
            InternalField_3449 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3530);
            InternalField_3451 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3528);
            InternalField_3452 = serializedObject.FindProperty(InternalType_646.InternalType_691.InternalField_3529);

            if (Application.IsPlaying(target))
            {
                Undo.undoRedoPerformed += InternalMethod_1220;
            }
        }

        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_1220;
        }

        protected virtual void InternalMethod_1220()
        {
            InternalMethod_1193();
            serializedObject.ApplyModifiedProperties();
            InternalMethod_1183();
        }

        protected void InternalMethod_3433()
        {
            EditorGUILayout.LabelField(InternalField_3448, EditorStyles.boldLabel);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(InternalField_3450, InternalType_554.InternalType_743.InternalField_3458);
            if (EditorGUI.EndChangeCheck() && Application.isPlaying)
            {
                InternalMethod_1220();
            }

            bool InternalVar_1 = !InternalField_3450.boolValue;

            EditorGUI.BeginDisabledGroup(InternalVar_1);
            InternalMethod_3434();
            EditorGUI.EndDisabledGroup();

            if (InternalVar_1)
            {
                return;
            }

            EditorGUILayout.PropertyField(InternalField_3452, InternalType_554.InternalType_743.InternalField_3461);

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField(InternalField_3451, InternalType_554.InternalType_743.InternalField_3460);
            if (EditorGUI.EndChangeCheck() && Application.isPlaying)
            {
                InternalMethod_1220();
            }

            EditorGUILayout.PropertyField(InternalField_3449, InternalType_554.InternalType_743.InternalField_3459);
        }

        private void InternalMethod_3434()
        {
            EditorGUI.BeginChangeCheck();

            Rect InternalVar_1 = GUILayoutUtility.GetLastRect();

            InternalVar_1 = InternalVar_1.InternalMethod_3442(2 * InternalType_573.InternalField_2550, InternalType_720.InternalField_3298);
            Rect InternalVar_2 = InternalVar_1;
            InternalVar_2.x -= InternalVar_2.width;

            bool InternalVar_3 = InternalType_534.InternalProperty_1089;
            GUIContent InternalVar_4 = InternalType_554.InternalType_743.InternalMethod_3436(InternalVar_3);
            InternalType_534.InternalProperty_1089 = GUI.Toggle(InternalVar_2, InternalVar_3, InternalVar_4, InternalType_573.InternalType_574.InternalProperty_478);

            EditorGUI.BeginDisabledGroup(!InternalType_534.InternalProperty_1089);
            bool InternalVar_5 = InternalType_534.InternalProperty_1090;
            GUIContent InternalVar_6 = InternalType_554.InternalType_743.InternalMethod_3435(InternalVar_5);
            InternalType_534.InternalProperty_1090 = GUI.Toggle(InternalVar_1, InternalVar_5, InternalVar_6, InternalType_573.InternalType_574.InternalProperty_481);
            EditorGUI.EndDisabledGroup();

            if (EditorGUI.EndChangeCheck())
            {
                SceneView.RepaintAll();
            }
        }

        
        private void InternalMethod_1193()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            InternalField_2219.Clear();

            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                T79 InternalVar_2 = InternalField_2385[InternalVar_1];
                if (!InternalVar_2.isActiveAndEnabled)
                {
                    continue;
                }

                Undo.RecordObject(InternalVar_2, "Inspector");

                InternalVar_2.enabled = false;
                InternalField_2219.Add(InternalVar_2);
            }
        }

        
        private void InternalMethod_1183()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2219.Count; ++InternalVar_1)
            {
                T79 InternalVar_2 = InternalField_2219[InternalVar_1];
                InternalVar_2.enabled = true;
            }
        }
    }
}
