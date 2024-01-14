// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_10;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    
    [Serializable]
    internal class InternalType_42 : InternalType_33, InternalType_7
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_8 visuals = InternalType_8.InternalField_61;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_80 InternalType_256<InternalNamespace_0.InternalType_80>.InternalProperty_270
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalType_8, InternalNamespace_0.InternalType_80>(ref visuals);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref RadialGradient InternalProperty_90
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalNamespace_0.InternalType_108, RadialGradient>(ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_268);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Border InternalProperty_91
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalNamespace_0.InternalType_106, Border>(ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_269);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Shadow InternalProperty_92
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalNamespace_0.InternalType_107, Shadow>(ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_270);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Surface InternalProperty_93
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalNamespace_0.InternalType_73, Surface>(ref InternalType_274.InternalProperty_190.InternalMethod_1266(this));
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Length InternalProperty_94
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_267.InternalMethod_9();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Color InternalProperty_95
        {
            get
            {
                return InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_266;
            }
            set
            {
                InternalType_274.InternalProperty_190.InternalMethod_1695(this).InternalField_266 = value;
            }
        }

        internal override InternalType_34 InternalMethod_293()
        {
            InternalType_42 InternalVar_1 = new InternalType_42();

            if (InternalProperty_82.InternalProperty_197)
            {
                InternalVar_1.InternalMethod_291(InternalProperty_83);
                InternalVar_1.InternalProperty_269 = InternalProperty_269;
            }
            else
            {
                InternalMethod_280(InternalVar_1);
                InternalVar_1.visuals = visuals;
            }

            return InternalVar_1;
        }
    }
}