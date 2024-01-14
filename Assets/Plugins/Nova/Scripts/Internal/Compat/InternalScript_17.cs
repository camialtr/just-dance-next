// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.Compat
{
    internal static class SceneViewUtils
    {
        public static bool IsInCurrentPrefabStage(GameObject gameObject)
        {
#if UNITY_EDITOR
            if (gameObject == null || !PrefabStageUtils.TryGetCurrentStageRoot(out GameObject root))
            {
                return false;
            }

            return gameObject.transform.IsChildOf(root.transform);
#else
return false;
#endif
        }

        public static bool IsInCurrentStage(GameObject gameObject)
        {
#if UNITY_EDITOR
            if (gameObject == null)
            {
                return false;
            }

            return UnityEditor.SceneManagement.StageUtility.GetStageHandle(gameObject) == UnityEditor.SceneManagement.StageUtility.GetCurrentStageHandle();
#else
return false;
#endif
        }

        public static bool IsSelectableInSceneView(GameObject gameObject)
        {
#if UNITY_EDITOR
            return IsVisibleInSceneView(gameObject) && !UnityEditor.SceneVisibilityManager.instance.IsPickingDisabled(gameObject);
#else
return false;
#endif
        }

        public static bool IsVisibleInSceneView(GameObject gameObject)
        {
#if UNITY_EDITOR
            return IsInCurrentStage(gameObject) && IsOnLayerRenderedBySceneCamera(gameObject) && !UnityEditor.SceneVisibilityManager.instance.IsHidden(gameObject) && gameObject.activeInHierarchy;
#else
return false;
#endif
        }

        public static bool IsOnLayerRenderedBySceneCamera(GameObject gameObject)
        {
#if UNITY_EDITOR
            UnityEditor.SceneManagement.Stage currentStage = UnityEditor.SceneManagement.StageUtility.GetCurrentStage();

            if (currentStage == null)
            {
                return false;
            }

            ulong cullingMask = currentStage.GetCombinedSceneCullingMaskForCamera();
            return (cullingMask & gameObject.sceneCullingMask) != 0;
#else
return false;
#endif
        }
    }
}
