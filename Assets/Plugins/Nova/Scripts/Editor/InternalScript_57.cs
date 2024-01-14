// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_10;
using UnityEditor;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal static class InternalType_578
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly float InternalField_2598 = EditorStyles.label.CalcSize(InternalType_554.InternalType_555.InternalField_2482).x + InternalType_573.InternalField_2557;

        public static void InternalMethod_2342(InternalType_613 InternalParameter_2755)
        {
            using InternalType_553 InternalVar_1 = InternalType_573.InternalMethod_2229("General");

            if (!InternalVar_1)
            {
                return;
            }

            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            float InternalVar_2 = InternalType_573.InternalProperty_472;

            InternalType_573.InternalProperty_472 = InternalField_2598;

            InternalType_573.InternalMethod_2245(InternalType_554.InternalType_555.InternalField_2477, InternalParameter_2755.InternalProperty_681, NovaSettings.LogFlags);

            InternalType_573.InternalProperty_472 = InternalVar_2;

            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        public static void InternalMethod_2343(InternalType_613 InternalParameter_2756)
        {
            using InternalType_553 InternalVar_1 = InternalType_573.InternalMethod_2229("Rendering");

            if (!InternalVar_1)
            {
                return;
            }


            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            InternalType_573.InternalType_575.InternalMethod_2308();

            float InternalVar_2 = InternalType_573.InternalProperty_472;

            InternalType_573.InternalProperty_472 = InternalField_2598;

            InternalType_573.InternalMethod_2235(InternalType_554.InternalType_555.InternalField_382, InternalParameter_2756.InternalProperty_425);
            InternalType_573.InternalMethod_2235(InternalType_554.InternalType_555.InternalField_2479, InternalParameter_2756.InternalProperty_687);
            InternalType_573.InternalMethod_2233(InternalType_554.InternalType_555.InternalField_2480, InternalParameter_2756.InternalProperty_689, 1f, 3f);

            InternalType_573.InternalMethod_2239(InternalType_554.InternalType_555.InternalField_2482, InternalParameter_2756.InternalProperty_691, 0, 20);
            InternalType_573.InternalMethod_2239(InternalType_554.InternalType_555.InternalField_2483, InternalParameter_2756.InternalProperty_693, 0, 20);

            InternalType_573.InternalMethod_2246(InternalType_554.InternalType_555.InternalField_379, InternalParameter_2756.InternalProperty_423, NovaSettings.PackedImageCopyMode);

            if (InternalType_333.InternalProperty_1033)
            {
                InternalType_573.InternalMethod_3336(InternalType_554.InternalType_567.InternalField_3355);
            }

            EditorGUI.BeginDisabledGroup(InternalType_333.InternalProperty_1033);

            InternalType_573.InternalMethod_2225(InternalType_554.InternalType_555.InternalField_2484);

            EditorGUI.indentLevel++;
            InternalType_573.InternalMethod_2245(InternalType_554.InternalType_555.InternalField_1099, InternalParameter_2756.InternalProperty_716, NovaSettings.UIBlock2DLightingModels);
            InternalType_573.InternalMethod_2245(InternalType_554.InternalType_555.InternalField_1097, InternalParameter_2756.InternalProperty_694, NovaSettings.TextBlockLightingModels);
            InternalType_573.InternalMethod_2245(InternalType_554.InternalType_555.InternalField_1098, InternalParameter_2756.InternalProperty_421, NovaSettings.UIBlock3DLightingModels);
            EditorGUI.indentLevel--;

            EditorGUI.EndDisabledGroup();

            InternalType_573.InternalProperty_472 = InternalVar_2;
            InternalType_573.InternalType_575.InternalMethod_2310();

            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        public static void InternalMethod_216(InternalType_613 InternalParameter_117)
        {
            using InternalType_553 InternalVar_1 = InternalType_573.InternalMethod_2229("Input");

            if (!InternalVar_1)
            {
                return;
            }

            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            InternalType_573.InternalType_575.InternalMethod_2308();

            float InternalVar_2 = InternalType_573.InternalProperty_472;
            InternalType_573.InternalProperty_472 = InternalField_2598;


            InternalType_573.InternalMethod_2239(InternalType_554.InternalType_555.InternalField_372, InternalParameter_117.InternalProperty_246, 0, 5);

            InternalType_573.InternalProperty_472 = InternalVar_2;
            InternalType_573.InternalType_575.InternalMethod_2310();

            InternalType_573.InternalType_575.InternalMethod_2307();

        }

        public static void InternalMethod_863(SerializedObject InternalParameter_805)
        {
            using InternalType_553 InternalVar_1 = InternalType_573.InternalMethod_2229("Editor");

            if (!InternalVar_1)
            {
                return;
            }

            float InternalVar_2 = InternalType_573.InternalProperty_472;

            InternalType_573.InternalProperty_472 = InternalField_2598;

            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            EditorGUI.BeginChangeCheck();
            bool InternalVar_3 = EditorGUILayout.Toggle(InternalType_554.InternalType_555.InternalField_2485, InternalType_534.InternalProperty_685);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_685 = InternalVar_3;
            }

            InternalType_573.InternalType_575.InternalMethod_2307();

            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            EditorGUI.BeginChangeCheck();
            bool InternalVar_4 = EditorGUILayout.Toggle(InternalType_554.InternalType_555.InternalField_1013, InternalType_534.InternalProperty_720);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_720 = InternalVar_4;
            }

            InternalType_573.InternalType_575.InternalMethod_2307();

            EditorGUILayout.Space();

            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(InternalType_573.InternalType_575.InternalField_2593);

            InternalType_573.InternalType_575.InternalMethod_2308();

            EditorGUILayout.LabelField("Controls", EditorStyles.boldLabel);
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.ButtonPrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.TogglePrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.SliderPrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.DropdownPrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.TextFieldPrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.ScrollViewPrefab)));
            EditorGUILayout.ObjectField(InternalParameter_805.FindProperty(nameof(NovaSettings.UIRootPrefab)));

            InternalType_573.InternalType_575.InternalMethod_2310();

            InternalType_573.InternalType_575.InternalMethod_2307();

            InternalType_573.InternalProperty_472 = InternalVar_2;
        }
    }
}

