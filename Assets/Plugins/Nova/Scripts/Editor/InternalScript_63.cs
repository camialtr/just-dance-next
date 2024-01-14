// Copyright (c) Supernova Technologies LLC
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal static class InternalType_791
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly GUIContent InternalField_558 = EditorGUIUtility.TrTextContent("\u2014", "Mixed Values");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly Vector2 InternalField_559 = new Vector2(230, 315);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static SerializedProperty InternalField_556 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_581 InternalField_555 = null;

        public static void InternalMethod_211(Rect InternalParameter_161, SerializedProperty InternalParameter_2641, GUIContent InternalParameter_2639)
        {
            InternalParameter_2639 = EditorGUI.BeginProperty(InternalParameter_161, InternalParameter_2639, InternalParameter_2641);
            InternalType_791.InternalField_556 = InternalParameter_2641;

            bool InternalVar_1 = EditorGUI.showMixedValue;
            bool InternalVar_2 = InternalMethod_2470(InternalParameter_2641);

            if (InternalVar_2)
            {
                EditorGUI.PrefixLabel(InternalParameter_161, InternalParameter_2639);
            }

            EditorGUI.showMixedValue = InternalVar_2;
            InternalMethod_2965(InternalParameter_161, InternalParameter_2639);
            EditorGUI.showMixedValue = InternalVar_1;

            if (!InternalVar_2)
            {
                EditorGUI.PropertyField(InternalParameter_161, InternalParameter_2641, includeChildren: true);
            }

            EditorGUI.EndProperty();
        }

        private static void InternalMethod_2965(Rect InternalParameter_21, GUIContent InternalParameter_13)
        {
            Rect InternalVar_1 = InternalParameter_21;

            float InternalVar_2 = Mathf.Max(EditorStyles.boldLabel.CalcSize(InternalParameter_13).x, InternalType_573.InternalProperty_472);

            InternalVar_1.x += InternalVar_2 + InternalType_573.InternalField_2557;
            InternalVar_1.width = InternalParameter_21.width - InternalVar_2 - InternalType_573.InternalField_2557;
            InternalVar_1.height = EditorGUIUtility.singleLineHeight;

            using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
            {
                Type InternalVar_3 = InternalMethod_21(InternalField_556.managedReferenceFullTypename); ;


                bool InternalVar_4 = InternalVar_3 != null;
                string InternalVar_5 = InternalVar_4 ? InternalVar_3.Name : "None (Unassigned)";
                string InternalVar_6 = InternalVar_4 ? InternalVar_3.Assembly.FullName : "Null";

                string InternalVar_7 = ObjectNames.NicifyVariableName(InternalVar_5.Substring(InternalVar_5.LastIndexOf(".") + 1));

                if (InternalVar_3 != null)
                {
                    TypeMenuNameAttribute InternalVar_8 = InternalVar_3.GetCustomAttribute<TypeMenuNameAttribute>();

                    if (InternalVar_8 != null && !string.IsNullOrWhiteSpace(InternalVar_8.DisplayName))
                    {
                        InternalVar_7 = InternalVar_8.DisplayName;
                    }
                }

                GUIContent InternalVar_9 = EditorGUI.showMixedValue ? InternalField_558 : new GUIContent(InternalVar_7, InternalVar_5 + " (" + InternalVar_6 + ")");

                bool InternalVar_10 = GUI.Button(InternalVar_1, InternalVar_9, EditorStyles.popup);

                if (!InternalVar_10)
                {
                    return;
                }

                if (InternalField_555 == null)
                {
                    Type InternalVar_11 = InternalMethod_21(InternalField_556.managedReferenceFieldTypename);
                    if (InternalVar_11 == null)
                    {
                        Debug.LogError($"SerializeReference type, [{InternalField_556.managedReferenceFieldTypename}], not found.");
                        return;
                    }

                    InternalField_555 = new InternalType_581(InternalVar_11, "Visuals");
                    InternalField_555.InternalEvent_6 += InternalMethod_2430;
                }

                InternalField_555.InternalProperty_1168 = InternalField_559;
                InternalField_555.Show(InternalVar_1);
            }
        }

        private static void InternalMethod_2430(Type InternalParameter_2640)
        {
            if (InternalParameter_2640 == null)
            {
                InternalField_556.managedReferenceValue = null;
                InternalField_556.serializedObject.ApplyModifiedProperties();
                return;
            }

            UnityEngine.Object[] InternalVar_1 = InternalField_556.serializedObject.targetObjects;

            if (InternalVar_1 == null || InternalVar_1.Length == 0)
            {
                InternalVar_1 = new UnityEngine.Object[1] { InternalField_556.serializedObject.targetObject };
            }

            foreach (UnityEngine.Object InternalVar_2 in InternalVar_1)
            {
                SerializedObject InternalVar_3 = new SerializedObject(InternalVar_2);
                SerializedProperty InternalVar_4 = InternalVar_3.FindProperty(InternalField_556.propertyPath);

                if (InternalMethod_21(InternalVar_4.managedReferenceFullTypename) != InternalParameter_2640)
                {
                    InternalVar_4.managedReferenceValue = Activator.CreateInstance(InternalParameter_2640);
                    InternalVar_4.serializedObject.ApplyModifiedProperties();
                }
            }
        }

        public static Type InternalMethod_21(string InternalParameter_20)
        {
            (string InternalVar_1, string InternalVar_2) = InternalMethod_13(InternalParameter_20);

            return Type.GetType($"{InternalVar_2}, {InternalVar_1}");
        }

        public static (string AssemblyName, string ClassName) InternalMethod_13(string InternalParameter_12)
        {
            if (string.IsNullOrEmpty(InternalParameter_12))
            {
                return ("", "");
            }

            string[] InternalVar_1 = InternalParameter_12.Split(char.Parse(" "));
            string InternalVar_2 = InternalVar_1[1];
            string InternalVar_3 = InternalVar_1[0];
            return (InternalVar_3, InternalVar_2);
        }

        public static bool InternalMethod_2470(SerializedProperty InternalParameter_11)
        {
            UnityEngine.Object[] InternalVar_1 = InternalParameter_11.serializedObject.targetObjects;

            if (InternalVar_1 == null || InternalVar_1.Length < 2)
            {
                return false;
            }

            string InternalVar_2 = InternalParameter_11.managedReferenceFullTypename;

            foreach (UnityEngine.Object InternalVar_3 in InternalVar_1)
            {
                SerializedObject InternalVar_4 = new SerializedObject(InternalVar_3);
                SerializedProperty InternalVar_5 = InternalVar_4.FindProperty(InternalParameter_11.propertyPath);

                if (InternalVar_2 != InternalVar_5.managedReferenceFullTypename)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
