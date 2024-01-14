// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17
{
    [CustomEditor(typeof(NovaSettings))]
    internal class InternalType_535 : InternalType_540
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_613 InternalField_2372 = new InternalType_613();

        private void OnEnable()
        {
            InternalField_2372.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_685.InternalField_3085);
            Undo.undoRedoPerformed += InternalMethod_2144;
        }

        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_2144;
        }

        private void InternalMethod_2144()
        {
            InternalMethod_2145(true);
            serializedObject.UpdateIfRequiredOrScript();
        }

        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_2342(InternalField_2372);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2145(false);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_2343(InternalField_2372);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2145(true);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_216(InternalField_2372);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2145(false);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_863(serializedObject);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2145(false);
            }
        }

        private void InternalMethod_2145(bool InternalParameter_2441)
        {
            serializedObject.ApplyModifiedProperties();
            if (InternalParameter_2441)
            {
                NovaSettings.InternalProperty_89.InternalMethod_1972(true, false);
            }
        }
    }
}
