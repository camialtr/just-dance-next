// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.InternalNamespace_0.InternalNamespace_5
{
    internal class InternalType_221 : InternalType_271.InternalType_354
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override int InternalProperty_1046 =>
#if UNITY_2022_2_OR_NEWER
            QualitySettings.globalTextureMipmapLimit;
#else
            QualitySettings.masterTextureLimit;
#endif

        public static void InternalMethod_1983()
        {
            InternalType_271.InternalField_412 = new InternalType_221();
        }
    }
}
