using UnityEditor;
using UnityEngine;

namespace NovaSamples.Editor
{
    [CustomPropertyDrawer(typeof(ShowIfAttribute))]
    public class ShowIfPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => ShouldShow(property, attribute as ShowIfAttribute) ? base.GetPropertyHeight(property, label) : 0;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!ShouldShow(property, attribute as ShowIfAttribute))
            {
                // Don't show the field if false
                return;
            }

            // Show the field
            EditorGUI.PropertyField(position, property, label);
        }

        private static bool ShouldShow(SerializedProperty property, ShowIfAttribute showIf)
        {
            SerializedProperty fieldToCheck;

            try
            {
                fieldToCheck = property.serializedObject.FindProperty(showIf.compareToFieldName);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);

                // Don't hide things if something's broken
                return true;
            }

            switch (showIf.visibleValue)
            {
                case bool boolValue:
                    return boolValue == fieldToCheck.boolValue;
                case float floatValue:
                    return floatValue == fieldToCheck.floatValue;
                case int intValue:
                    return intValue == fieldToCheck.intValue;
                case string stringValue:
                    return stringValue == fieldToCheck.stringValue;
                case System.Enum enumValue:
                    return enumValue.GetHashCode() == fieldToCheck.intValue;
                default:
                    Debug.LogError("Not a supported ShowIf comparison type. Only string, bool, float, int, and enum types are currently supported.", property.serializedObject.targetObject);
                    return true;
            }
        }
    }
}
