// Copyright (c) Supernova Technologies LLC
using UnityEngine;
using Nova.InternalNamespace_0.InternalNamespace_5;
#if UNITY_EDITOR
using UnityEngine.SceneManagement;
#if UNITY_2021_2_OR_NEWER
using UnityEditor.SceneManagement;
#else
using UnityEditor.Experimental.SceneManagement;
#endif
#endif

namespace Nova.Compat
{
    internal class PrefabStageUtilsImpl : PrefabStageUtils.Impl
    {
#if UNITY_EDITOR
        private PrefabStage currentPrefabStage = null;
        private static PrefabStageUtilsImpl instance = null;
#endif

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override bool IsInPrefabStage =>
#if UNITY_EDITOR
            currentPrefabStage != null;
#else
            false;
#endif

        public override bool TryGetCurrentStageRoot(out GameObject root)
        {
#if UNITY_EDITOR
            if (currentPrefabStage != null)
            {
                root = currentPrefabStage.prefabContentsRoot;
                return true;
            }
            else
            {
                root = null;
                return false;
            }
#else
            root = null;
            return false;
#endif
        }

        private PrefabStageUtilsImpl()
        {
#if UNITY_EDITOR
            PrefabStage.prefabStageOpened += HandlePrefabStageOpened;
            PrefabStage.prefabStageClosing += HandlePrefabStageClosed;
            currentPrefabStage = PrefabStageUtility.GetCurrentPrefabStage();
#endif
        }

#if UNITY_EDITOR
        private void HandlePrefabStageOpened(PrefabStage obj)
        {
            currentPrefabStage = obj;
        }

        private void HandlePrefabStageClosed(PrefabStage obj)
        {
            // We need to query the current prefab stage because if someone has recursed into 
            // several prefab stages, and then they exit one it goes back to the others without
            // firing an "open" event and we can't cache the previous prefab stages because if a domain
            // reload happens we'll lose the cache state
            currentPrefabStage = PrefabStageUtility.GetCurrentPrefabStage();
        }

        public static bool TryGetPrefabScene(out Scene scene)
        {
            if (instance == null || !instance.IsInPrefabStage)
            {
                scene = default;
                return false;
            }

            scene = instance.currentPrefabStage.scene;
            return true;
        }
#endif

        public static void Init()
        {
#if UNITY_EDITOR
            instance = new PrefabStageUtilsImpl();
            PrefabStageUtils.Instance = instance;
#endif
        }
    }
}
