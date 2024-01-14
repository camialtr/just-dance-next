// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal class InternalType_767 : EditorWindow
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_3646 = "Thank you for choosing Nova!\n\nIf you're new to Nova," +
                                              " we recommend diving in to the scenes under Nova\\Sample\\UIControls " +
                                              "to get started.\n\nIf you're looking for even more complete example projects, " +
                                              "such as a settings menu, inventory system, XR handtracking, etc., then we recommend checking out" +
                                              " our GitHub page, where the full source for those projects is readily available to download!" +
                                              "\n\nIf you'd prefer something more instructive, we have several step-by-step " +
                                              "video tutorials for you on our YouTube channel, and our documentation is chock-full of videos, code snippets," +
                                              " and everything else you might need to become a true Nova expert!\n\nGot a feature request, have a question, or found a bug? Get " +
                                              "in touch with us via email and/or start a new discussion with the Nova Community on GitHub!";

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_3647 = "Enjoying Nova? Mind leaving us a ";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_3648 = "review?";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_3649 = "Nova FAQ";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3650 = 36;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3651 = 18;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3652 = 0.75f;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static float InternalProperty_1161 => InternalType_554.InternalField_3642.image.width;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static float InternalProperty_1162 => InternalType_554.InternalField_3642.image.height;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static RectOffset InternalProperty_1163 => new RectOffset(18, 4, 4, 0);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Rect InternalProperty_1164
        {
            get
            {
                Vector2 InternalVar_1 = new Vector2(InternalProperty_1163.horizontal, InternalProperty_1163.vertical);
                Vector2 InternalVar_2 = 0.5f * new Vector2(InternalProperty_1161, InternalProperty_1161) + InternalVar_1;
                Vector2 InternalVar_3 = EditorGUIUtility.GetMainWindowPosition().center;

                return new Rect(InternalVar_3 - (0.5f * InternalVar_2), InternalVar_2);
            }
        }

        [InitializeOnLoadMethod]
        private static void InternalMethod_3669()
        {
            EditorApplication.delayCall += InternalMethod_3670;
        }

        private static void InternalMethod_3670()
        {
            if (InternalType_534.InternalProperty_1157)
            {
                return;
            }

            InternalMethod_3671();
        }

        public static void InternalMethod_3671()
        {
            InternalMethod_3675().Show();
        }

        private void OnEnable()
        {
            InternalType_534.InternalProperty_1157 = true;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector2 InternalField_3653 = Vector2.zero;

        private void OnGUI()
        {
            float InternalVar_1 = Mathf.Min(position.size.y, InternalProperty_1161) / 3f;
            float InternalVar_2 = Mathf.Min(position.size.x, InternalVar_1 * InternalProperty_1161 / InternalProperty_1162);

            Rect InternalVar_3 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Height(InternalVar_1));
            InternalVar_3 = InternalVar_3.InternalMethod_3441(InternalVar_2);

            EditorGUI.LabelField(InternalVar_3, InternalType_554.InternalField_3642);

            InternalType_573.InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());

            EditorGUILayout.Space(InternalField_3651);

            InternalMethod_3673(InternalVar_3.width * InternalField_3652);

            EditorGUILayout.Space(InternalField_3651);

            InternalMethod_3672();

            InternalMethod_3674();
        }

        private void InternalMethod_3672()
        {
            Rect InternalVar_1 = GUILayoutUtility.GetLastRect();
            InternalVar_1.y -= InternalType_573.InternalField_2557;

            InternalType_573.InternalType_574.InternalMethod_3438(InternalVar_1);

            float InternalVar_2 = (position.size.y * 0.5f) - (InternalField_3650 + InternalField_3651);

            Rect InternalVar_3 = InternalVar_1.InternalMethod_3441(position.size.x);
            InternalVar_3.y = InternalVar_1.yMax;
            InternalVar_3.height = InternalVar_2 + InternalType_573.InternalField_2557;
            InternalType_573.InternalType_574.InternalMethod_2290(InternalVar_3, InternalType_573.InternalType_574.InternalProperty_474);

            InternalField_3653 = EditorGUILayout.BeginScrollView(InternalField_3653, GUILayout.Height(InternalVar_2));
            EditorGUILayout.LabelField(InternalField_3646, InternalType_573.InternalType_574.InternalProperty_1159);
            EditorGUILayout.EndScrollView();

            InternalType_573.InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
        }

        private void InternalMethod_3673(float InternalParameter_3467)
        {
            float InternalVar_1 = EditorGUIUtility.labelWidth;
            float InternalVar_2 = EditorGUIUtility.fieldWidth;

            GUIStyle InternalVar_3 = InternalType_573.InternalType_574.InternalProperty_1160;

            Vector2 InternalVar_4 = InternalVar_3.CalcSize(EditorGUIUtility.TrTempContent("UI Playground"));
            float InternalVar_5 = InternalVar_4.x;
            float InternalVar_6 = InternalVar_3.CalcSize(EditorGUIUtility.TrTempContent("Discover")).x;
            float InternalVar_7 = InternalVar_3.CalcSize(EditorGUIUtility.TrTempContent("Manual")).x;
            float InternalVar_8 = InternalVar_3.CalcSize(EditorGUIUtility.TrTempContent("Community")).x;
            
            EditorGUIUtility.labelWidth = Mathf.Max(InternalVar_5, InternalVar_6, InternalVar_7, InternalVar_8);
            EditorGUIUtility.fieldWidth = 0;

            float InternalVar_9 = InternalVar_5 + InternalVar_6 + InternalVar_7 + InternalVar_8;

            float InternalVar_10 = Mathf.Max((InternalParameter_3467 - InternalVar_9) / 3, InternalType_573.InternalField_2557);

            Rect InternalVar_11 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Height(InternalVar_4.y));
            InternalVar_11 = InternalVar_11.InternalMethod_3441(InternalParameter_3467);

            Rect InternalVar_12 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Height(InternalVar_4.y));
            InternalVar_12 = InternalVar_12.InternalMethod_3441(InternalParameter_3467);

            Rect InternalVar_13 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Height(InternalVar_4.y));
            InternalVar_13 = InternalVar_13.InternalMethod_3441(InternalParameter_3467);

            EditorGUI.LabelField(InternalVar_11, "Experiment", InternalVar_3);
            
            if (InternalType_573.InternalMethod_3660(InternalVar_12, "UI Controls"))
            {
                InternalMethod_3676("UIControls");
            }

            if (InternalType_573.InternalMethod_3660(InternalVar_13, "UI Playground"))
            {
                InternalMethod_3676("UIPlayground");
            }

            InternalVar_11.xMin += InternalVar_5 + InternalVar_10;
            InternalVar_12.xMin += InternalVar_5 + InternalVar_10;
            InternalVar_13.xMin += InternalVar_5 + InternalVar_10;

            EditorGUI.LabelField(InternalVar_11, "Discover", InternalVar_3);
            InternalType_573.InternalMethod_3659(InternalVar_12, "Examples", "https://novaui.io/samples/");
            InternalType_573.InternalMethod_3659(InternalVar_13, "YouTube", "https://www.youtube.com/@NovaUI");

            InternalVar_11.xMin += InternalVar_6 + InternalVar_10;
            InternalVar_12.xMin += InternalVar_6 + InternalVar_10;
            InternalVar_13.xMin += InternalVar_6 + InternalVar_10;

            EditorGUI.LabelField(InternalVar_11, "Learn", InternalVar_3);
            InternalType_573.InternalMethod_3659(InternalVar_12, "Manual", "https://novaui.io/manual/");
            InternalType_573.InternalMethod_3659(InternalVar_13, "API", "https://novaui.io/api/");

            InternalVar_11.xMin += InternalVar_7 + InternalVar_10;
            InternalVar_12.xMin += InternalVar_7 + InternalVar_10;
            InternalVar_13.xMin += InternalVar_7 + InternalVar_10;

            EditorGUI.LabelField(InternalVar_11, "Contact", InternalVar_3);
            InternalType_573.InternalMethod_3659(InternalVar_12, "Community", "https://github.com/NovaUI-Unity/Feedback/discussions");
            InternalType_573.InternalMethod_3659(InternalVar_13, "Email", "mailto:contact@novaui.io");

            EditorGUIUtility.labelWidth = InternalVar_1;
            EditorGUIUtility.fieldWidth = InternalVar_2;
        }

        private void InternalMethod_3674()
        {
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Height(InternalField_3650));

            float InternalVar_2 = EditorStyles.label.CalcSize(EditorGUIUtility.TrTempContent(InternalField_3647)).x;
            float InternalVar_3 = EditorStyles.linkLabel.CalcSize(EditorGUIUtility.TrTempContent(InternalField_3648)).x;

            InternalVar_1 = InternalVar_1.InternalMethod_3677(new Vector2(InternalVar_2 + InternalVar_3, EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing));

            float InternalVar_4 = EditorGUIUtility.labelWidth;

            EditorGUIUtility.labelWidth = InternalVar_2;
            EditorGUI.LabelField(InternalVar_1, InternalField_3647);
            EditorGUIUtility.labelWidth = InternalVar_4;

            InternalVar_1.xMin += InternalVar_2;
            InternalType_573.InternalMethod_3659(InternalVar_1, InternalField_3648, "https://u3d.as/2Sge", InternalParameter_3460: false);
        }

        private static InternalType_767 InternalMethod_3675()
        {
            InternalType_767 InternalVar_1 = GetWindow<InternalType_767>(InternalField_3649);

            if (InternalVar_1 == null)
            {
                InternalVar_1 = CreateWindow<InternalType_767>(InternalField_3649);
            }

            InternalVar_1.position = InternalProperty_1164;

            return InternalVar_1;
        }

        private static void InternalMethod_3676(string InternalParameter_3468)
        { 
            string[] InternalVar_1 = AssetDatabase.FindAssets($"{InternalParameter_3468} t:scene");

            foreach (string InternalVar_2 in InternalVar_1)
            {
                string InternalVar_3 = AssetDatabase.GUIDToAssetPath(InternalVar_2);

                if (InternalVar_3.Contains("Nova"))
                {
                    SceneAsset InternalVar_4 = AssetDatabase.LoadAssetAtPath<SceneAsset>(InternalVar_3);
                    AssetDatabase.OpenAsset(InternalVar_4);
                    break;
                }
            }
        }
    }
}
