// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_1;
using Nova.InternalNamespace_0.InternalNamespace_10;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal static class InternalType_766
    {
        [UnityEditor.InitializeOnLoadMethod]
        private static void InternalMethod_3650()
        {
            UnityEditor.EditorApplication.playModeStateChanged += (state) =>
            {
                bool InternalVar_1 = state == UnityEditor.PlayModeStateChange.EnteredEditMode || state == UnityEditor.PlayModeStateChange.ExitingPlayMode;

                if (InternalVar_1 && InternalType_120.InternalField_406 != null)
                {
                    InternalType_120.InternalField_406.Dispose();
                }

                InternalType_274.InternalProperty_190.InternalMethod_3651();
            };
        }
    }
}

