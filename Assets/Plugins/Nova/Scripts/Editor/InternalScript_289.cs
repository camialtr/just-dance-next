// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using Unity.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace Nova.InternalNamespace_17
{
    internal static class InternalType_731
    {
        private class InternalType_732
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public List<InternalType_131> InternalField_3307 = new List<InternalType_131>();
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public List<InternalType_131> InternalField_3308 = new List<InternalType_131>();

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public bool InternalProperty_1024 => InternalField_3307.Count == 0;

            public void InternalMethod_3300()
            {
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_3307.Count; InternalVar_1++)
                {
                    InternalType_274.InternalProperty_190.InternalField_862.InternalField_1283.InternalMethod_837(InternalField_3307[InternalVar_1]);
                }

                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_3308.Count; InternalVar_1++)
                {
                    InternalType_274.InternalProperty_190.InternalField_862.InternalField_1285.InternalMethod_837(InternalField_3308[InternalVar_1]);
                }
            }

            public void InternalMethod_3301()
            {
                InternalField_3307.Clear();
                InternalField_3308.Clear();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_732 InternalField_3305 = new InternalType_732();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_732 InternalField_3306 = new InternalType_732();

        public static void InternalMethod_3298()
        {
            if (InternalType_274.InternalProperty_190 == null)
            {
                return;
            }

            InternalField_3306.InternalMethod_3301();
            InternalType_274.InternalProperty_190.InternalField_863.InternalField_3302.Clear();
            if (!SceneVisibilityManager.instance.AreAnyDescendantsHidden(SceneManager.GetActiveScene())
#if UNITY_EDITOR
                && (!PrefabStageUtilsImpl.TryGetPrefabScene(out Scene prefabScene) || !SceneVisibilityManager.instance.AreAnyDescendantsHidden(prefabScene)))
#else
)
#endif
            {
                if (!InternalField_3305.InternalProperty_1024)
                {
                    InternalField_3305.InternalMethod_3300();
                    InternalField_3305.InternalMethod_3301();
                    InternalType_180.InternalMethod_849();
                }
                return;
            }

            ref NativeList<InternalType_222> InternalVar_1 = ref InternalType_253.InternalProperty_190.InternalProperty_263;
            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Length; InternalVar_2++)
            {
                ref InternalType_222 InternalVar_3 = ref InternalVar_1.ElementAt(InternalVar_2);

                if (!InternalType_253.InternalProperty_190.InternalField_413.TryGetValue(InternalVar_3.InternalField_585, out InternalType_145 InternalVar_4) ||
                    InternalVar_4.InternalProperty_202 == null ||
                    !SceneVisibilityManager.instance.IsHidden(InternalVar_4.InternalProperty_202.gameObject))
                {
                    continue;
                }

                InternalType_131 InternalVar_5 = InternalType_253.InternalProperty_190.InternalProperty_265.InternalField_594[InternalVar_2].InternalField_589;
                InternalField_3306.InternalField_3308.Add(InternalVar_3.InternalField_585);
                InternalField_3306.InternalField_3307.Add(InternalVar_5);
                InternalType_274.InternalProperty_190.InternalField_863.InternalField_3302.Add(InternalVar_3.InternalField_585, default);
            }

            if (!InternalField_3306.InternalProperty_1024)
            {
                InternalField_3306.InternalMethod_3300();

                if (!InternalField_3305.InternalProperty_1024)
                {
                    InternalField_3305.InternalMethod_3300();
                    InternalField_3305.InternalMethod_3301();
                }

                InternalType_180.InternalMethod_849();

                var InternalVar_2 = InternalField_3305;
                InternalField_3305 = InternalField_3306;
                InternalField_3306 = InternalVar_2;
            }
            else if (!InternalField_3305.InternalProperty_1024)
            {
                InternalField_3305.InternalMethod_3300();
                InternalField_3305.InternalMethod_3301();
                InternalType_180.InternalMethod_849();
            }
        }
    }
}

