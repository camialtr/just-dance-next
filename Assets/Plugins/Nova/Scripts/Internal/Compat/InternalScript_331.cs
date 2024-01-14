// Copyright (c) Supernova Technologies LLC
namespace Nova.Compat
{
    internal class UnityVersionUtils
    {
        public enum UnityVersion
        {
            V2020 = 0,
            V2021 = 1,
            V2022 = 2,
        };

        public abstract class Impl
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public abstract UnityVersion Version { get; }

            
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public abstract bool NewTMP { get; }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Impl Instance = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool Is2022OrNewer => Instance != null && (int)Instance.Version >= (int)UnityVersion.V2022;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool NewTMP => Instance != null && Instance.NewTMP;
    }
}

