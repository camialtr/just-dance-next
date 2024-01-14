// Copyright (c) Supernova Technologies LLC
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [UnityEditor.CustomEditor(typeof(ListView)), UnityEditor.CanEditMultipleObjects]
    internal class InternalType_542 : UnityEditor.Editor
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected virtual string[] InternalProperty_456 { get; } = new string[] { "m_Script" };

        protected virtual void InternalMethod_2174() { }
        protected virtual void InternalMethod_2175() { }

        public override void OnInspectorGUI()
        {
            InternalMethod_831();
            InternalMethod_1881();

            serializedObject.UpdateIfRequiredOrScript();

            UnityEditor.EditorGUI.BeginChangeCheck();
            InternalMethod_2174();

            DrawPropertiesExcluding(serializedObject, InternalProperty_456);
            if (UnityEditor.EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        private void InternalMethod_831()
        {
            if (!(target is ListView listView && listView.TryGetComponent(out UIBlock InternalVar_1)))
            {
                return;
            }

            if (!InternalVar_1.AutoLayout.AutoSpace)
            {
                return;
            }

            string InternalVar_2 = target.GetType().Name;
            bool InternalVar_3 = EditorUtility.DisplayDialog($"\"Auto\" spacing cannot be used with {InternalVar_2}", "Would you like to disable auto spacing on this UIBlock?", "Yes", "No");

            if (!InternalVar_3)
            {
                return;
            }

            InternalVar_1.AutoLayout.AutoSpace = false;
        }

        private void InternalMethod_1881()
        {
            if (!(target is ListView listView && listView.TryGetComponent(out UIBlock InternalVar_1)))
            {
                return;
            }
            

            if (!InternalVar_1.AutoLayout.Cross.Enabled)
            {
                return;
            }

            string InternalVar_2 = target.GetType().Name;
            bool InternalVar_3 = EditorUtility.DisplayDialog($"\"Cross Axis\" cannot be used with {InternalVar_2}", "Would you like to disable the Auto Layout's cross axis on this UIBlock?", "Yes", "No");

            if (!InternalVar_3)
            {
                return;
            }

            InternalVar_1.AutoLayout.Cross.Axis = Axis.None;
        }
    }
}
