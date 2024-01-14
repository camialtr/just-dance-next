// Copyright (c) Supernova Technologies LLC
using UnityEngine.Rendering;

namespace Nova.InternalNamespace_0.InternalNamespace_5
{
    internal static class InternalType_776
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const int InternalField_3710 =
#if HIGH_DEF_RENDER_PIPELINE
            3050;
#else
            (int)RenderQueue.Overlay;
#endif
    }
}
