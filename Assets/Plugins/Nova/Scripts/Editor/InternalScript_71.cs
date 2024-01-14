// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_20;
using System.Collections.Generic;
using UnityEditor;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17
{
    internal class InternalType_536 : SettingsProvider
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_613 InternalField_2373 = new InternalType_613();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SerializedObject InternalField_2374 = null;

        public override void OnGUI(string searchContext)
        {
            if (InternalField_2374 == null || InternalField_2373.InternalProperty_954 == null)
            {
                InternalField_2374 = new SerializedObject(NovaSettings.InternalProperty_89);
                InternalField_2373.InternalProperty_954 = InternalField_2374.FindProperty(InternalType_646.InternalType_685.InternalField_3085);
            }

            InternalField_2374.UpdateIfRequiredOrScript();

            InternalType_553.InternalField_2450 = true;
            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_2342(InternalField_2373);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2146(false);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_2343(InternalField_2373);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2146(true);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_216(InternalField_2373);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2146(false);
            }

            EditorGUI.BeginChangeCheck();
            InternalType_578.InternalMethod_863(InternalField_2374);
            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2146(false);
            }

            InternalType_553.InternalField_2450 = false;
        }

        private void InternalMethod_2146(bool InternalParameter_2442)
        {
            InternalField_2374.ApplyModifiedProperties();
            if (InternalParameter_2442)
            {
                NovaSettings.InternalProperty_89.InternalMethod_1972(true, false);
            }
        }

        public InternalType_536(string InternalParameter_2443, SettingsScope InternalParameter_2444, IEnumerable<string> InternalParameter_2445 = null) : base(InternalParameter_2443, InternalParameter_2444, InternalParameter_2445)
        {
        }

        [SettingsProvider]
        private static SettingsProvider InternalMethod_2148()
        {
            InternalType_536 InternalVar_1 = new InternalType_536("Project/Nova", SettingsScope.Project, SettingsProvider.GetSearchKeywordsFromGUIContentProperties<InternalType_554.InternalType_555>());
            return InternalVar_1;
        }
    }
}

