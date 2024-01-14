// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.Compat
{
    internal static class NovaApplication
    {
        public static event System.Action EditorDelayCall
        {
            add
            {
#if UNITY_EDITOR
                UnityEditor.EditorApplication.delayCall += () => value?.Invoke();
#endif
            }
            remove
            {
#if UNITY_EDITOR
                Debug.LogError("NovaApplication.DelayCall doesn't support unsubscribing because it wraps UnityEditor.EditorApplication.delayCall, which uses its own editor-only delegate type" +
                    " that isn't accessible in an Editor-agnostic dll. Currently not worth remapping events since we don't need that functionality at time of writing.");
#endif
            }
        }

        
        public static event System.Action EditorBeforeAssemblyReload = null;
        private static void HandleBeforeAssemblyReload()
        {
            EditorBeforeAssemblyReload?.Invoke();
        }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly bool IsEditor =
#if UNITY_EDITOR
            true;
#else
            false;
#endif

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const bool ConstIsEditor =
#if UNITY_EDITOR
            true;
#else
            false;
#endif

        public static void QueueEditorPlayerLoop()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.QueuePlayerLoopUpdate();
#endif
        }

        public static void MarkDirty(Object obj)
        {
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(obj);
#endif
        }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool IsPlaying { get; private set; } =
#if UNITY_EDITOR
            false;
#else
            true;
#endif

        
        public static bool InPlayer(Object obj)
        {
#if UNITY_EDITOR
            return Application.IsPlaying(obj);
#else
            return true;
#endif
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
        private static void Init()
        {
            IsPlaying = UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode;
            UnityEditor.EditorApplication.playModeStateChanged += HandlePlayModeStateChanged;
            UnityEditor.AssemblyReloadEvents.beforeAssemblyReload += HandleBeforeAssemblyReload;
        }

        private static void HandlePlayModeStateChanged(UnityEditor.PlayModeStateChange state)
        {
            IsPlaying = UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode;
        }
#endif
    }
}
