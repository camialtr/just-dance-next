// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(ClipMask))]
    [CanEditMultipleObjects]
    internal class InternalType_538 : InternalType_539<ClipMask>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_631 InternalField_2384 = new InternalType_631();

        protected override void OnEnable()
        {
            base.OnEnable();
            InternalField_2384.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_672.InternalField_3037);
            Undo.undoRedoPerformed += InternalMethod_2165;
        }

        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_2165;
        }

        private void InternalMethod_2165()
        {
            InternalMethod_2166();
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            InternalType_573.InternalMethod_2231(InternalType_554.InternalType_564.InternalField_2509, InternalField_2384.InternalProperty_776, true);
            InternalType_573.InternalMethod_2235(InternalType_554.InternalType_564.InternalField_2510, InternalField_2384.InternalProperty_778);
            SerializedProperty InternalVar_1 = serializedObject.FindProperty(InternalType_646.InternalType_672.InternalField_3038);
            EditorGUILayout.ObjectField(InternalVar_1, InternalType_554.InternalType_564.InternalField_2511);

            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2166();
            }
        }

        private void InternalMethod_2166()
        {
            serializedObject.ApplyModifiedProperties();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                InternalField_2385[InternalVar_1].InternalMethod_299();
            }
            InternalType_180.InternalMethod_849();
        }
    }
}
