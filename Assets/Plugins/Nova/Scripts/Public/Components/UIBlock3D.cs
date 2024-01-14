// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A <see cref="UIBlock"/> with an adjustable, rounded-corner, rounded-edge cube mesh.
    /// </summary>
    [AddComponentMenu("Nova/UIBlock 3D")]
    [HelpURL("https://novaui.io/manual/UIBlock3D.html")]
    public sealed class UIBlock3D : UIBlock, InternalType_9
    {
        #region Public
        /// <summary>
        /// The primary body content color.
        /// </summary>
        public override Color Color
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_277;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_277 = value;
            }
        }

        /// <summary>
        /// The <see cref="Length"/> configuration used to calculate a corner radius, applies to all eight corners of the body's front and back faces (XY planes).
        /// </summary>
        /// <remarks>
        /// <see cref="CornerRadius">CornerRadius</see>.<see cref="Length.Percent">Percent</see> is relative to half 
        /// the minimum dimension (X or Y) of <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>float calculatedCornerRadius = CornerRadius.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value)</c>
        /// </remarks>
        public ref Length CornerRadius
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_278.InternalMethod_9();
        }

        /// <summary>
        /// The <see cref="Length"/> configuration used to calculate an edge radius, applies to all eight edges of the body's front and back faces (XY planes).
        /// </summary>
        /// <remarks>
        /// <see cref="EdgeRadius">EdgeRadius</see>.<see cref="Length.Percent">Percent</see> is relative to half 
        /// the minimum dimension (X, Y, or Z) of <see cref="UIBlock.CalculatedSize">CalculatedSize</see>. Mathematically speaking:<br/>
        /// <c>float unclampedEdgeRadius = EdgeRadius.Percent * 0.5f * Mathf.Min(CalculatedSize.X.Value, CalculatedSize.Y.Value, CalculatedSize.Z.Value)</c>.<br/><br/>
        /// When rendering, EdgeRadius will not exceed the calculated value of <see cref="CornerRadius"/>. Mathematically speaking:<br/>
        /// <c> float calculatedEdgeRadius = Mathf.Min(unclampedEdgeRadius, calculatedCornerRadius)</c>.
        /// </remarks>
        public ref Length EdgeRadius
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalField_279.InternalMethod_9();
        }
        #endregion

        #region Internal
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
        internal InternalType_10.Calculated InternalProperty_43 => InternalType_274.InternalProperty_190.InternalMethod_1694(this).InternalMethod_953<InternalNamespace_0.InternalType_82, InternalType_10>().InternalMethod_153(CalculatedSize.Value);

        /// <summary>
        /// Initialize values for 3D block
        /// </summary>
        private UIBlock3D() : base()
        {
            Layout = Layout.ThreeD;
            visibility = InternalType_36.InternalMethod_307(InternalType_11.InternalField_66);
            surface = Surface.InternalField_50;
        }
        #endregion
    }
}

