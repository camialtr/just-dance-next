// Copyright (c) Supernova Technologies LLC
using Nova;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    internal class InternalType_399 : AssetPostprocessor
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static HashSet<string> InternalField_1435 = new HashSet<string>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_1438 = "Nova.ItemViewPrefabReload";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_1437 = "%";

        [InitializeOnLoadMethod]
        private static void InternalMethod_1615()
        {
            if (!EditorPrefs.HasKey(InternalField_1438))
            {
                return;
            }

            AssemblyReloadEvents.afterAssemblyReload += InternalMethod_1616;
        }

        private void OnPostprocessPrefab(GameObject gameObject)
        {
            if (gameObject == null || !EditorApplication.isCompiling || InternalField_1435.Contains(assetPath))
            {
                return;
            }

            ItemView[] InternalVar_1 = gameObject.GetComponentsInChildren<ItemView>(includeInactive: true);

            if (InternalVar_1.Any(x => PrefabUtility.GetNearestPrefabInstanceRoot(x) == null && x.Visuals == null))
            {
                InternalField_1435.Add(assetPath);
            }
        }

        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            if (InternalField_1435.Count == 0)
            {
                return;
            }

            AssemblyReloadEvents.beforeAssemblyReload -= InternalMethod_1614;
            AssemblyReloadEvents.beforeAssemblyReload += InternalMethod_1614;
        }

        private static void InternalMethod_1614()
        {
            string InternalVar_1 = string.Join(InternalField_1437, InternalField_1435);

            EditorPrefs.SetString(InternalField_1438, InternalVar_1);

            AssemblyReloadEvents.beforeAssemblyReload -= InternalMethod_1614;

            InternalField_1435.Clear();
        }

        private static void InternalMethod_1616()
        {
            string InternalVar_1 = EditorPrefs.GetString(InternalField_1438, string.Empty);

            if (!string.IsNullOrWhiteSpace(InternalVar_1))
            {
                string[] InternalVar_2 = InternalVar_1.Split(InternalField_1437.ToCharArray());

                foreach (string InternalVar_3 in InternalVar_2)
                {
                    AssetDatabase.ImportAsset(InternalVar_3);
                }
            }

            EditorPrefs.DeleteKey(InternalField_1438);

            AssemblyReloadEvents.afterAssemblyReload -= InternalMethod_1616;
        }
    }
}

