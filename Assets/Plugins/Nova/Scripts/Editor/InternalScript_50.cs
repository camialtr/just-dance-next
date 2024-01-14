// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0.InternalNamespace_10;
using System;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    
    internal class InternalType_532 : AssetPostprocessor, IActiveBuildTargetChanged
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int callbackOrder => 0;

        public void OnActiveBuildTargetChanged(BuildTarget previousTarget, BuildTarget newTarget)
        {
            if (!InternalNamespace_0.InternalType_24.InternalProperty_1040 || !InternalNamespace_0.InternalType_24.InternalProperty_1045)
            {
                return;
            }

            InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_1390();
        }

        [System.Reflection.Obfuscation]
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (InternalType_268.InternalField_406 == null)
            {
                return;
            }

            bool InternalVar_1 = false;
            bool InternalVar_2 = false;
            for (int InternalVar_3 = 0; InternalVar_3 < importedAssets.Length; InternalVar_3++)
            {
                string InternalVar_4 = importedAssets[InternalVar_3];

                Type InternalVar_5 = AssetDatabase.GetMainAssetTypeAtPath(InternalVar_4);
                if (InternalVar_5 == null || !InternalVar_5.IsSubclassOf(typeof(Texture)))
                {
                    continue;
                }

                var InternalVar_6 = AssetDatabase.LoadAssetAtPath<Texture>(importedAssets[InternalVar_3]);
                InternalVar_1 = true;
                if (InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_22(InternalVar_6))
                {
                    InternalVar_2 = true;
                }

                if (AssetDatabase.LoadAssetAtPath<Sprite>(InternalVar_4) == null)
                {
                    continue;
                }

                var InternalVar_7 = AssetDatabase.LoadAllAssetsAtPath(InternalVar_4);

                if (InternalType_274.InternalProperty_190.InternalField_876.InternalMethod_23(InternalVar_6, InternalVar_7))
                {
                    InternalVar_2 = true;
                }
            }

            if (InternalVar_2)
            {
                InternalType_268.InternalField_406.InternalMethod_2107();
                NovaApplication.QueueEditorPlayerLoop();
            }
            else if (InternalVar_1)
            {
                InternalType_268.InternalField_406.InternalProperty_283 = true;
                NovaApplication.QueueEditorPlayerLoop();
            }
        }
    }
}

