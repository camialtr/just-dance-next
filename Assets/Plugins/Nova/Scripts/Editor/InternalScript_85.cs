// Copyright (c) Supernova Technologies LLC
using System;
using UnityEditor;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal struct InternalType_719 : IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_3297;

        public void Dispose()
        {
            if (InternalField_3297)
            {
                EditorGUI.showMixedValue = false;
            }
        }

        public static InternalType_719 InternalMethod_3246()
        {
            EditorGUI.showMixedValue = true;
            return new InternalType_719()
            {
                InternalField_3297 = true,
            };
        }
    }
}

