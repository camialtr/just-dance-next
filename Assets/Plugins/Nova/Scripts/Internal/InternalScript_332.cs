// Copyright (c) Supernova Technologies LLC
using Nova.Compat;

namespace Nova.InternalNamespace_0.InternalNamespace_5
{
    internal class InternalType_794 : UnityVersionUtils.Impl
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override UnityVersionUtils.UnityVersion Version
        {
            get
            {
#if UNITY_2022_1_OR_NEWER
                return UnityVersionUtils.UnityVersion.V2022;
#elif UNITY_2021_1_OR_NEWER
                return UnityVersionUtils.UnityVersion.V2021;
#else
                return UnityVersionUtils.UnityVersion.V2020;
#endif
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override bool NewTMP =>
#if TMP_UV4
            true;
#else
            false;
#endif

        public static void InternalMethod_3820()
        {
            UnityVersionUtils.Instance = new InternalType_794();
        }
    }
}
