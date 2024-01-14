// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.Compat
{
    internal static class PrefabStageUtils
    {
        public abstract class Impl
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public abstract bool IsInPrefabStage { get; }

            public abstract bool TryGetCurrentStageRoot(out GameObject root);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Impl Instance = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool IsInPrefabStage => Instance != null ? Instance.IsInPrefabStage : false;

        public static bool TryGetCurrentStageRoot(out GameObject root)
        {
            if (Instance != null)
            {
                return Instance.TryGetCurrentStageRoot(out root);
            }
            else
            {
                root = null;
                return false;
            }
        }
    }
}
