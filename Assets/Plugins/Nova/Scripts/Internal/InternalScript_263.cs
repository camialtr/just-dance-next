// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_10;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    

    [Serializable]
    internal class InternalType_33 : InternalType_34, InternalType_5
    {
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Layout layout = Layout.TwoD;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private AutoLayout autoLayout = AutoLayout.Horizontal;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_36 visualBase = InternalType_36.InternalMethod_307(InternalType_11.InternalField_64);
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Surface surface = Surface.InternalField_49;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_74 InternalProperty_34 => null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_69 InternalType_67.InternalProperty_142 => ref UnsafeUtility.As<Layout, InternalNamespace_0.InternalType_69>(ref layout);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_70 InternalType_67.InternalProperty_143 => ref UnsafeUtility.As<AutoLayout, InternalNamespace_0.InternalType_70>(ref autoLayout);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_67.InternalProperty_87 
        {
            get
            {
                return Vector3.zero;
            }
            set 
            { 
            } 
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_53.InternalType_55 InternalType_67.InternalProperty_144 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1832;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_53.InternalType_55 InternalType_67.InternalProperty_145 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1833;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_56.InternalType_58 InternalType_67.InternalProperty_146 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1834;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref readonly InternalNamespace_0.InternalType_56.InternalType_58 InternalType_67.InternalProperty_147 => ref InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1835;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Layout InternalProperty_63
        {
            get
            {
                if (!InternalProperty_82.InternalProperty_196.InternalProperty_194)
                {
                    return ref layout;
                }

                unsafe
                {
                    return ref UnsafeUtility.AsRef<Layout>(InternalType_457.InternalProperty_190.InternalMethod_14(this).InternalField_1836);
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref AutoLayout InternalProperty_64
        {
            get
            {
                if (!InternalProperty_82.InternalProperty_196.InternalProperty_194)
                {
                    return ref autoLayout;
                }

                unsafe
                {
                    return ref UnsafeUtility.AsRef<AutoLayout>(InternalType_457.InternalProperty_190.InternalMethod_14(this).InternalField_1227);
                }
            }
        }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref readonly Length.Calculated InternalProperty_65
        {
            get
            {
                return ref UnsafeUtility.As<InternalNamespace_0.InternalType_45.InternalType_47, Length.Calculated>(ref InternalType_457.InternalProperty_190.InternalMethod_3753(this).InternalField_3739);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Length3 InternalProperty_66 => ref InternalProperty_63.Size;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref MinMax3 InternalProperty_67 => ref InternalProperty_63.SizeMinMax;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Length3 InternalProperty_68 => ref InternalProperty_63.Position;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref MinMax3 InternalProperty_69 => ref InternalProperty_63.PositionMinMax;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref LengthBounds InternalProperty_70 => ref InternalProperty_63.Padding;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref MinMaxBounds InternalProperty_71 => ref InternalProperty_63.PaddingMinMax;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref LengthBounds InternalProperty_72 => ref InternalProperty_63.Margin;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref MinMaxBounds InternalProperty_73 => ref InternalProperty_63.MarginMinMax;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref ThreeD<AutoSize> InternalProperty_74 => ref InternalProperty_63.AutoSize;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Axis InternalProperty_75 => ref InternalProperty_63.AspectRatioAxis;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref Alignment InternalProperty_76 => ref InternalProperty_63.Alignment;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public ref bool InternalProperty_77 => ref InternalProperty_63.RotateSize;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_148 => InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalProperty_403;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_78 => InternalProperty_82.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1847(this) : Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_79 => InternalProperty_82.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1848(this) : Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_80 => InternalProperty_82.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1849(this) : Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_81 => InternalProperty_82.InternalProperty_196.InternalProperty_194 ? (Vector3)InternalType_457.InternalProperty_190.InternalMethod_1850(this) : Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_149 => InternalType_457.InternalProperty_190.InternalMethod_1857(this).InternalField_1832.InternalProperty_124;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_150 => InternalProperty_149 + (Vector3)((InternalType_67)this).InternalProperty_147.InternalProperty_137;

        public void InternalMethod_442() => InternalType_64.InternalProperty_200.InternalMethod_427(InternalProperty_83);

        private protected override void InternalMethod_288()
        {
            InternalType_253.InternalProperty_190.InternalMethod_626(this);
            InternalType_457.InternalProperty_190.InternalMethod_626(this);
            InternalType_274.InternalProperty_190.InternalMethod_626(this);
        }

        private protected override void InternalMethod_289()
        {
            InternalType_274.InternalProperty_190.InternalMethod_627(this);
            InternalType_457.InternalProperty_190.InternalMethod_627(this);
            InternalType_253.InternalProperty_190.InternalMethod_627(this);
        }

        private protected override void InternalMethod_292() { }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_71 InternalType_255.InternalProperty_267
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<InternalType_36, InternalNamespace_0.InternalType_71>(ref visualBase);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_73 InternalType_255.InternalProperty_268
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref UnsafeUtility.As<Surface, InternalNamespace_0.InternalType_73>(ref surface);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_269
        {
            get
            {
                return visualBase.Visible;
            }
            set
            {
                visualBase.Visible = value;
                InternalType_274.InternalProperty_190.InternalMethod_3031(this);
            }
        }

        public void InternalMethod_279()
        {
            if (!InternalProperty_82.InternalProperty_197)
            {
                return;
            }

            InternalType_253.InternalProperty_190.InternalMethod_622(this);
            InternalType_457.InternalProperty_190.InternalMethod_622(this);
            InternalType_274.InternalProperty_190.InternalMethod_622(this);
        }

        internal override void InternalMethod_290()
        {
            InternalType_253.InternalProperty_190.InternalMethod_623(this);
            InternalType_457.InternalProperty_190.InternalMethod_623(this);
            InternalType_274.InternalProperty_190.InternalMethod_623(this);
        }

        private protected override void InternalMethod_291(InternalType_131 InternalParameter_209)
        {
            InternalType_253.InternalProperty_190.InternalMethod_624(InternalParameter_209, this);
            InternalType_457.InternalProperty_190.InternalMethod_624(InternalParameter_209, this);
            InternalType_274.InternalProperty_190.InternalMethod_624(InternalParameter_209, this);
        }

        internal override InternalType_34 InternalMethod_293()
        {
            InternalType_33 InternalVar_1 = new InternalType_33();

            if (InternalProperty_82.InternalProperty_197)
            {
                InternalVar_1.InternalMethod_291(InternalProperty_83);
                InternalVar_1.InternalProperty_269 = InternalProperty_269;
            }
            else
            {
                InternalMethod_280(InternalVar_1);
            }

            return InternalVar_1;
        }

        private protected void InternalMethod_280(InternalType_33 InternalParameter_207)
        {
            InternalParameter_207.layout = layout;
            InternalParameter_207.autoLayout = autoLayout;
            InternalParameter_207.surface = surface;
            InternalParameter_207.visualBase = visualBase;
            InternalParameter_207.InternalProperty_269 = InternalProperty_269;
        }
    }
}
