// Copyright (c) Supernova Technologies LLC
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(ItemVisuals), useForChildren: true)]
    internal class InternalType_102 : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, includeChildren: true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.PropertyField(position, property, label, includeChildren: true);
        }
    }
}
