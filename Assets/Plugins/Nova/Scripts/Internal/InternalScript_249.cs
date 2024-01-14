// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.InternalNamespace_0
{
    internal class InternalType_118 : ScriptableObject
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_100 InternalField_384 = null;

        private void Awake()
        {
            hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSaveInEditor | HideFlags.HideInInspector;
        }

        private void OnEnable()
        {
            if (InternalField_384 == null)
            {
                return;
            }

            InternalField_384.InternalMethod_531();
        }

        private void OnDestroy()
        {
            if (InternalField_384 != null)
            {
                InternalField_384.Dispose();
            }
        }
    }
}
