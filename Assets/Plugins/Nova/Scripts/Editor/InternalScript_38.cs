// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(ItemView)), CanEditMultipleObjects]
    internal class InternalType_544 : InternalType_540
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedProperty InternalField_2214 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly MethodInfo InternalField_2087 = typeof(MonoScript).GetMethod("GetAssemblyName", BindingFlags.Instance | BindingFlags.NonPublic);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly MethodInfo InternalField_2080 = typeof(MonoScript).GetMethod("GetNamespace", BindingFlags.Instance | BindingFlags.NonPublic);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly GUIContent InternalField_2089 = EditorGUIUtility.TrTextContent("Edit Visuals Script", "Open the script where the selected \"Visuals\" type is defined.");

        private void OnEnable()
        {
            InternalField_2214 = serializedObject.FindProperty(InternalType_646.InternalType_669.InternalField_3332);
        }

        public override void OnInspectorGUI()
        {
            bool InternalVar_1 = InternalType_791.InternalMethod_2470(InternalField_2214);
            float InternalVar_2 = InternalVar_1 ? EditorGUIUtility.singleLineHeight : EditorGUI.GetPropertyHeight(InternalField_2214, includeChildren: true);
            Rect InternalVar_3 = EditorGUILayout.GetControlRect(GUILayout.Height(InternalVar_2));

            InternalType_791.InternalMethod_211(InternalVar_3, InternalField_2214, InternalType_554.InternalType_563.InternalField_715);

            serializedObject.ApplyModifiedProperties();

            if (InternalVar_1 || InternalField_2087 == null)
            {
                return;
            }

            System.Type InternalVar_4 = InternalType_791.InternalMethod_21(InternalField_2214.managedReferenceFullTypename);

            if (InternalVar_4 == null)
            {
                return;
            }

            EditorGUILayout.Space();

            if (GUILayout.Button(InternalField_2089))
            {
                InternalMethod_1886(InternalVar_4);
            }
        }

        private static async void InternalMethod_1886(System.Type InternalParameter_3442)
        {
            if (InternalParameter_3442 == null)
            {
                return;
            }

            string[] InternalVar_1 = AssetDatabase.FindAssets("t:script");

            string InternalVar_2 = InternalParameter_3442.Assembly.GetName().Name;

            bool InternalVar_3 = InternalParameter_3442.Namespace != null;
            string InternalVar_4 = InternalVar_3 ? InternalParameter_3442.Namespace : string.Empty;

            foreach (string InternalVar_5 in InternalVar_1)
            {
                string InternalVar_6 = AssetDatabase.GUIDToAssetPath(InternalVar_5);

                MonoScript InternalVar_7 = AssetDatabase.LoadAssetAtPath<MonoScript>(InternalVar_6);

                if (InternalVar_7 == null)
                {
                    continue;
                }

                string InternalVar_8 = InternalMethod_1890(InternalVar_7);

                if (string.IsNullOrWhiteSpace(InternalVar_8))
                {
                    continue;
                }

                if (InternalVar_3 && InternalVar_7.GetClass() != null)
                {
                    string InternalVar_9 = InternalMethod_1888(InternalVar_7);

                    if (InternalVar_4 != InternalVar_9)
                    {
                        continue;
                    }
                }

                string InternalVar_10 = InternalVar_8.Replace(".dll", string.Empty);

                if (InternalVar_2 != InternalVar_10)
                {
                    continue;
                }

                string InternalVar_11 = InternalVar_7.text;

                bool InternalVar_12 = await Task.Run(() =>
                {
                    return Regex.IsMatch(InternalVar_11, $"class[ ]+{InternalParameter_3442.Name}[ ]*:");
                });

                if (InternalVar_12)
                {
                    AssetDatabase.OpenAsset(InternalVar_7);
                    return;
                }
            }
        }

        private static string InternalMethod_1890(MonoScript InternalParameter_3441)
        {
            return InternalField_2087?.Invoke(InternalParameter_3441, null) as string;
        }

        private static string InternalMethod_1888(MonoScript InternalParameter_3440)
        {
            return InternalField_2080?.Invoke(InternalParameter_3440, null) as string;
        }
    }
}
