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
    internal class InternalType_43 : InternalType_33, InternalType_9
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_10 visuals = InternalType_10.InternalField_62;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_82 InternalType_256<InternalNamespace_0.InternalType_82>.InternalProperty_270
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalType_10, InternalNamespace_0.InternalType_82>(ref visuals);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Color InternalProperty_96
        {
            get
            {
                return ref InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_277;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Surface InternalProperty_97
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_73, Surface>(ref InternalType_274.InternalProperty_190.InternalMethod_1266(this));
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Length InternalProperty_98
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45, Length>(ref InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_278);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Length InternalProperty_99
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45, Length>(ref InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_279);
            }
        }

        internal override InternalType_34 InternalMethod_293()
        {
            InternalType_43 InternalVar_1 = new InternalType_43();

            if (InternalProperty_82.InternalProperty_197)
            {
                InternalVar_1.InternalMethod_291(InternalProperty_83);
            }
            else
            {
                InternalMethod_280(InternalVar_1);
                InternalVar_1.visuals = visuals;
            }

            return InternalVar_1;
        }

        public InternalType_43() : base()
        {
            InternalProperty_63 = Layout.ThreeD;
            InternalProperty_64 = AutoLayout.Horizontal;

            InternalType_36 InternalVar_1 = InternalType_36.InternalMethod_307(InternalType_11.InternalField_66);
            ((InternalType_255)this).InternalProperty_267 = UnsafeUtility.As<InternalType_36, InternalNamespace_0.InternalType_71>(ref InternalVar_1);
            InternalProperty_97 = Surface.InternalField_50;
        }
    }
}
