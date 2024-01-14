// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal abstract class InternalType_583<T87> : PropertyDrawer where T87 : class, InternalType_645, new()
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected T87 InternalField_2604 = new T87();

        protected abstract void OnGUI(Rect position, GUIContent label);

        protected virtual float InternalMethod_2353(GUIContent InternalParameter_2767)
        {
            return -1f;
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            InternalField_2604 = new T87() { InternalProperty_954 = property };

            float InternalVar_1 = InternalMethod_2353(label);
            if (InternalVar_1 != -1f)
            {
                return InternalVar_1;
            }
            else
            {
                return base.GetPropertyHeight(property, label);
            }
        }

        public sealed override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            InternalField_2604 = new T87() { InternalProperty_954 = property };

            EditorGUI.BeginChangeCheck();
            position.height = EditorGUIUtility.singleLineHeight;
            OnGUI(position, label);

            if (EditorGUI.EndChangeCheck())
            {
                property.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}
