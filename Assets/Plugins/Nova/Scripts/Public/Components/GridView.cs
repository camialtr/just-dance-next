// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A callback to configure a <see cref="GridSlice"/>, <see cref="GridSlice2D"/> or <see cref="GridSlice3D"/> before it's inserted into the grid view.
    /// </summary>
    /// <param name="sliceIndex">The virtual index of the slice along the <paramref name="primaryAxis"/></param>
    /// <param name="gridView">The <see cref="GridView"/> requesting the grid slice.</param>
    /// <param name="gridSlice">The grid slice of type <typeparamref name="T"/> to configure. This slice will then be inserted into the grid.</param>
    /// <typeparam name="T">
    /// The type of grid slice the provider will configure:
    /// <list type="bullet">
    /// <item><description><see cref="GridSlice"/></description></item>
    /// <item><description><see cref="GridSlice2D"/></description></item>
    /// <item><description><see cref="GridSlice3D"/></description></item>
    /// </list>
    /// </typeparam>
    /// <seealso cref="GridView.SetSliceProvider(GridSliceProviderCallback{GridSlice})"/>
    /// <seealso cref="GridView.SetSliceProvider(GridSliceProviderCallback{GridSlice2D})"/>
    /// <seealso cref="GridView.SetSliceProvider(GridSliceProviderCallback{GridSlice3D})"/>
    public delegate void GridSliceProviderCallback<T>(int sliceIndex, GridView gridView, ref T gridSlice);

    /// <summary>
    /// A <see cref="ListView"/> whose list items can be arranged in a 2D layout.
    /// </summary>
    /// <remarks>
    /// Percent-based <see cref="Layout"/> properties on <see cref="UIBlock"/>s parented directly to a 
    /// <see cref="GridView"/> are calculated relative to their "virtual" parent <see cref="GridSlice"/>, 
    /// not the <see cref="GridView"/> itself.
    /// </remarks>
    [AddComponentMenu("Nova/Grid View")]
    [HelpURL("https://novaui.io/manual/GridView.html")]
    public sealed class GridView : ListView, ISerializationCallbackReceiver
    {
        #region Public
        /// <summary>
        /// The lowest slice index currently loaded into the grid view.
        /// </summary>
        public int MinLoadedSliceIndex => InternalProperty_48.InternalMethod_254(MinLoadedIndex);

        /// <summary>
        /// The highest slice index currently loaded into the grid view.
        /// </summary>
        public int MaxLoadedSliceIndex => InternalProperty_48.InternalMethod_254(MaxLoadedIndex);

        /// <summary>
        /// The number of elements to position along the <see cref="CrossAxis"/>.
        /// </summary>
        /// <seealso cref="CrossAxis"/>
        public int CrossAxisItemCount
        {
            get
            {
                return crossAxisItemCount;
            }
            set
            {
                int InternalVar_1 = Mathf.Max(1, value);
                if (InternalVar_1 == crossAxisItemCount)
                {
                    return;
                }

                crossAxisItemCount = InternalVar_1;

                if (!UIBlock.InternalProperty_25)
                {
                    return;
                }

                InternalMethod_411();
            }
        }

        /// <summary>
        /// The scrolling axis to position elements in the grid. Assigned implicitly from the <see cref="AutoLayout.Axis"/> configured on the <see cref="ListView.UIBlock"/>.
        /// </summary>
        /// <seealso cref="CrossAxis"/>
        public Axis PrimaryAxis
        {
            get
            {
                return UIBlock.InternalMethod_79().Axis;
            }
            set
            {
                UIBlock.AutoLayout.Axis = value;
            }
        }

        /// <summary>
        /// The non-scrolling axis along which <see cref="GridSlice"/>'s will position items.
        /// </summary>
        /// <example>If the <see cref="PrimaryAxis"/> is set to Y, the <see cref="CrossAxis"/> is commonly set to X.</example>
        /// <seealso cref="CrossAxisItemCount"/>
        /// <seealso cref="PrimaryAxis"/>
        public Axis CrossAxis
        {
            get => crossAxis;
            set
            {
                if (crossAxis == value)
                {
                    return;
                }

                crossAxis = value;

                InternalType_521<InternalType_34> InternalVar_1 = InternalProperty_50;

                for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.InternalProperty_433; ++InternalVar_2)
                {
                    InternalType_33 InternalVar_3 = InternalVar_1[InternalVar_2] as InternalType_33;
                    InternalVar_3.InternalProperty_64.Axis = crossAxis;
                }
            }
        }

        /// <summary>
        /// Assigns the given <see cref="GridSliceProviderCallback{T}"/> as the sole handler for any grid slice requests. As a <see cref="GridView"/> is scrolled, new list items will 
        /// be pulled into view, and <see cref="CrossAxisItemCount"/> list items will be visually parented to the returned <see cref="GridSlice"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <remarks>
        /// A <see cref="GridView"/> can only have a single <see cref="GridSliceProviderCallback{T}"/> at a given time, so assigning a value here will remove any existing slice providers.
        /// </remarks>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice2D})"/>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice3D})"/>
        public void SetSliceProvider(GridSliceProviderCallback<GridSlice> provider) => InternalMethod_196<GridSlice>(provider);

        /// <summary>
        /// Assigns the given <see cref="GridSliceProviderCallback{T}"/> as the sole handler for any grid slice requests. As a <see cref="GridView"/> is scrolled, new list items will 
        /// be pulled into view, and <see cref="CrossAxisItemCount"/> list items will be visually parented to the returned <see cref="GridSlice2D"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <remarks>
        /// A <see cref="GridView"/> can only have a single <see cref="GridSliceProviderCallback{T}"/> at a given time, so assigning a value here will remove any existing slice providers.
        /// </remarks>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice})"/>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice3D})"/>
        public void SetSliceProvider(GridSliceProviderCallback<GridSlice2D> provider) => InternalMethod_196<GridSlice2D>(provider);

        /// <summary>
        /// Assigns the given <see cref="GridSliceProviderCallback{T}"/> as the sole handler for any grid slice requests. As a <see cref="GridView"/> is scrolled, new list items will 
        /// be pulled into view, and <see cref="CrossAxisItemCount"/> list items will be visually parented to the returned <see cref="GridSlice3D"/>.
        /// </summary>
        /// <param name="provider"></param>
        /// <remarks>
        /// A <see cref="GridView"/> can only have a single <see cref="GridSliceProviderCallback{T}"/> at a given time, so assigning a value here will remove any existing slice providers.
        /// </remarks>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice})"/>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice2D})"/>
        public void SetSliceProvider(GridSliceProviderCallback<GridSlice3D> provider) => InternalMethod_196<GridSlice3D>(provider);

        /// <summary>
        /// Clears any <see cref="GridSliceProviderCallback{T}"/> callback previously assigned via 
        /// <list type="bullet">
        /// <item><description><see cref="SetSliceProvider(GridSliceProviderCallback{GridSlice})"/></description></item>
        /// <item><description><see cref="SetSliceProvider(GridSliceProviderCallback{GridSlice2D})"/></description></item>
        /// <item><description><see cref="SetSliceProvider(GridSliceProviderCallback{GridSlice3D})"/></description></item>
        /// </list>
        /// </summary>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice})"/>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice2D})"/>
        /// <seealso cref="SetSliceProvider(GridSliceProviderCallback{GridSlice3D})"/>
        public void ClearSliceProvider()
        {
            InternalField_90 = null;
            InternalField_91 = typeof(GridSlice);
            InternalField_92 = typeof(InternalType_42);
        }

        /// <summary>
        /// Wraps the GridView's underlying data source in a <see cref="GridList{T}"/> to be indexable by a <see cref="GridIndex"/>,
        /// where <see cref="GridIndex.Row"/> is the index into the <see cref="PrimaryAxis"/> and <see cref="GridIndex.Column"/> is the index
        /// into the <see cref="CrossAxis"/>.
        /// </summary>
        /// <typeparam name="T">The type of <see cref="GridList{T}"/> to create. Must match the type parameter used when calling <see cref="ListView.SetDataSource{T}(IList{T})"/></typeparam>
        /// <returns>The GridView's underlying data source wrapped as a <see cref="GridList{T}"/></returns>
        /// <exception cref="ArgumentException">Thrown when <typeparamref name="T"/> doesn't match the type parameter used when calling <see cref="ListView.SetDataSource{T}(IList{T})"/></exception>
        /// <exception cref="ArgumentException">Thrown when <see cref="ListView.SetDataSource{T}(IList{T})"/> hasn't been called or was set to <c><see langword="null"/></c></exception>
        /// <seealso cref="ListView.SetDataSource{T}(IList{T})"/>
        public GridList<T> GetDataSourceAsGrid<T>()
        {
            IList<T> InternalVar_1 = GetDataSource<T>();

            if (InternalVar_1 == null)
            {
                if (InternalProperty_55 != null)
                {
                    throw new ArgumentException($"Requesting a {nameof(GridList<T>)} of type {typeof(T).Name}, but the {nameof(GridView)}'s data source is tracking elements of type {InternalProperty_55.InternalMethod_2039().Name}. The provided Type argument, {nameof(T)}, must match the underlying data source element type.");
                }

                throw new ArgumentException($"The {nameof(GridView)} has no underlying data source to wrap as a {typeof(GridList<T>)}. You must first call {nameof(SetDataSource)} before a {nameof(GridList<T>)} can be made from the {nameof(GridView)}.");
            }

            return GridList<T>.CreateWithColumns(InternalVar_1, CrossAxisItemCount);
        }

        /// <summary>
        /// Retrieves the <see cref="ItemView"/> representing the object in the data source at the provided <see cref="GridIndex"/> if it's paged into the <see cref="GridView"/>.
        /// </summary>
        /// <param name="index"> 
        /// The <see cref="GridIndex"/> of the object in the data source represented by the requested 
        /// <see cref="ItemView"/>, where <see cref="GridIndex.Row"/> is the  index into the <see cref="PrimaryAxis"/> 
        /// and <see cref="GridIndex.Column"/> is the index into the <see cref="CrossAxis"/>
        /// </param>
        /// <param name="gridItem"> The item in the GridView representing the data object in the data source at the provided <see cref="GridIndex"/>.</param>
        /// <returns>Returns <see langword="true"/> if the requested <see cref="ItemView"/> is found (paged into view), otherwise returns <see langword="false"/>.</returns>
        public bool TryGetGridItem(GridIndex index, out ItemView gridItem)
        {
            int InternalVar_1 = InternalProperty_48.InternalMethod_253(index);

            return TryGetItemView(InternalVar_1, out gridItem);
        }

        /// <summary>
        /// Invokes the configured grid slice provider, set via <see cref="SetSliceProvider"/>, for the grid<br/> 
        /// slice at the given index, <paramref name="sliceIndex"/>. Provides a way for the caller to reconfigure the visuals/layout of the requested grid slice.
        /// </summary>
        /// <remarks>
        /// If the grid slice provider has been cleared or was never set or if <paramref name="sliceIndex"/> is outside the range defined by [<see cref="MinLoadedSliceIndex"/>, <see cref="MaxLoadedSliceIndex"/>], this call won't do anything.
        /// </remarks>
        /// <param name="sliceIndex">The virtual index of the grid slice to update.</param>
        public void UpdateGridSlice(int sliceIndex)
        {
            if (InternalField_90 == null || sliceIndex < MinLoadedSliceIndex || sliceIndex > MaxLoadedSliceIndex)
            {
                return;
            }

            int InternalVar_1 = sliceIndex - MinLoadedSliceIndex;

            InternalType_33 InternalVar_2 = InternalProperty_50[InternalVar_1] as InternalType_33;

            InternalMethod_202(InternalVar_2, InternalField_90, sliceIndex, PrimaryAxis, CrossAxis);
        }
        #endregion

        #region Internal
        [SerializeField, InternalType_22]
        [Tooltip("The non-scrolling axis to position elements in the grid.\n\nE.g.\nIf the Primary Axis is set to Y, the Cross Axis is commonly set to X.")]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Axis crossAxis = Axis.X;
        [SerializeField, InternalType_22]
        [Min(1), Tooltip("The number of elements to position along the Cross Axis.\n\nE.g.\nIf the Cross Axis is set to X, this is the number of columns in the grid.")]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int crossAxisItemCount = 1;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private MulticastDelegate InternalField_90;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Type InternalField_91 = typeof(GridSlice);
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Type InternalField_92 = typeof(InternalType_42);
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_35 InternalField_93 = new InternalType_35();

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_35 InternalField_94 = new InternalType_35();
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_95 = 0;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_96 = 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected override int InternalProperty_52 => CrossAxisItemCount;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_32 InternalProperty_48 => InternalType_32.InternalMethod_258(InternalProperty_55.InternalProperty_430, CrossAxisItemCount);

        private protected override InternalType_521<InternalType_131> InternalMethod_2062()
        {
            return InternalProperty_51 == 0 ? base.InternalMethod_2062() : InternalProperty_49.InternalProperty_182;
        }

        private protected override bool InternalMethod_919(int InternalParameter_855, out InternalType_5 InternalParameter_2352)
        {
            InternalParameter_2352 = null;

            if (!TryGetItemView(InternalParameter_855, out ItemView InternalVar_1))
            {
                return false;
            }

            InternalParameter_2352 = InternalType_253.InternalProperty_190.InternalMethod_1158(InternalVar_1.UIBlock.InternalProperty_29) as InternalType_5;

            return InternalParameter_2352 != null;
        }

        private protected override void InternalMethod_2060(bool firstSibling)
        {
            if ((firstSibling && InternalProperty_50.InternalProperty_433 <= InternalField_95) ||
                (!firstSibling && InternalProperty_50.InternalProperty_433 <= InternalField_96))
            {
                base.InternalMethod_2060(firstSibling);

                return;
            }

            InternalType_33 InternalVar_1 = (firstSibling ? InternalProperty_50[InternalField_95++] : InternalProperty_50[InternalProperty_51 - (++InternalField_96)]) as InternalType_33;

            if (firstSibling)
            {
                for (int InternalVar_2 = 0; InternalVar_2 < crossAxisItemCount && InternalVar_1.InternalProperty_30 - InternalVar_2 > 0; ++InternalVar_2)
                {
                    if (InternalField_98 > InternalField_99)
                    {
                        break;
                    }

                    InternalMethod_230();
                }
            }
            else
            {
                for (int InternalVar_2 = 0; InternalVar_2 < crossAxisItemCount && InternalVar_1.InternalProperty_30 - InternalVar_2 > 0; ++InternalVar_2)
                {
                    if (InternalField_99 < InternalField_98)
                    {
                        break;
                    }

                    InternalMethod_231();
                }
            }

            InternalProperty_54.InternalMethod_58(InternalVar_1);

            InternalField_94.InternalMethod_295(InternalVar_1);
        }

        private protected override InternalType_66 InternalMethod_1858(bool InternalParameter_2057)
        {
            if (!InternalParameter_2057 && (InternalField_99 + 1) % InternalProperty_52 != 0)
            {
                InternalType_66 InternalVar_1 = InternalMethod_229(InternalParameter_175: false);

                if (InternalVar_1 != null && InternalMethod_919(InternalField_99, out InternalType_5 InternalVar_2))
                {
                    InternalVar_2.InternalMethod_442();
                }

                return null;
            }

            InternalType_33 InternalVar_3 = InternalMethod_201(InternalParameter_2057);

            int InternalVar_4 = 0;

            if (InternalParameter_2057)
            {
                for (int InternalVar_5 = 0; InternalVar_5 < crossAxisItemCount; ++InternalVar_5)
                {
                    InternalType_66 InternalVar_6 = InternalMethod_228(InternalParameter_174: false);

                    InternalVar_4 += (InternalVar_6 as MonoBehaviour) != null ? 1 : 0;

                    if (InternalField_98 == 0)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (int InternalVar_5 = 0; InternalVar_5 < crossAxisItemCount; ++InternalVar_5)
                {
                    InternalType_66 InternalVar_6 = InternalMethod_229(InternalParameter_175: false);

                    InternalVar_4 += (InternalVar_6 as MonoBehaviour) != null ? 1 : 0;

                    if (InternalField_99 == InternalProperty_55.InternalProperty_430 - 1)
                    {
                        break;
                    }
                }
            }

            if (InternalVar_4 == 0)
            {
                InternalField_94.InternalMethod_295(InternalVar_3);

                return null;
            }

            InternalVar_3.InternalMethod_442();

            InternalProperty_54.InternalMethod_59(InternalVar_3.InternalProperty_83);

            return InternalVar_3;
        }

        private protected override void InternalMethod_224()
        {
            while (InternalField_94.InternalMethod_296(out InternalType_33 InternalVar_1))
            {
                InternalVar_1.InternalProperty_269 = false;
                InternalMethod_208(InternalVar_1);
                InternalVar_1.Dispose();
                InternalField_93.InternalMethod_295(InternalVar_1);
            }

            InternalField_95 = 0;
            InternalField_96 = 0;
        }

        private void InternalMethod_196<TSlice>(MulticastDelegate InternalParameter_142) where TSlice : struct
        {
            if (InternalParameter_142 == null)
            {
                ClearSliceProvider();
                return;
            }

            InternalField_91 = typeof(TSlice);
            InternalField_92 = InternalMethod_200<TSlice>();
            InternalField_90 = InternalParameter_142;
        }

        private protected override void InternalMethod_220()
        {
            InternalField_93.Dispose();
        }

        private protected override void OnDestroy()
        {
            base.OnDestroy();

            if (virtualBlockSerializer != null)
            {
                Destroy(virtualBlockSerializer);
                virtualBlockSerializer = null;
            }
        }

        private protected override void InternalMethod_235()
        {
            InternalProperty_49.InternalMethod_540();

            if (NovaApplication.InPlayer(this))
            {
                InternalMethod_411(InternalParameter_173: true);
            }
        }

        private protected override void InternalMethod_236()
        {
            InternalProperty_49.InternalMethod_539();
        }

        private static void InternalMethod_197(InternalType_33 InternalParameter_143, GridSlice InternalParameter_144)
        {
            InternalParameter_143.InternalProperty_269 = false;
            InternalParameter_143.InternalProperty_63 = InternalParameter_144.Layout;
            InternalParameter_143.InternalProperty_64 = InternalParameter_144.AutoLayout;
        }

        private static void InternalMethod_198(InternalType_33 InternalParameter_145, GridSlice2D InternalParameter_146)
        {
            InternalType_42 InternalVar_1 = InternalParameter_145 as InternalType_42;

            InternalVar_1.InternalProperty_269 = true;
            InternalVar_1.InternalProperty_95 = InternalParameter_146.Color;
            InternalVar_1.InternalProperty_90 = InternalParameter_146.Gradient;
            InternalVar_1.InternalProperty_93 = InternalParameter_146.Surface;
            InternalVar_1.InternalProperty_94 = InternalParameter_146.CornerRadius;
            InternalVar_1.InternalProperty_91 = InternalParameter_146.Border;
            InternalVar_1.InternalProperty_92 = InternalParameter_146.Shadow;
            InternalVar_1.InternalProperty_63 = InternalParameter_146.Layout;
            InternalVar_1.InternalProperty_64 = InternalParameter_146.AutoLayout;
        }

        private static void InternalMethod_199(InternalType_33 InternalParameter_147, GridSlice3D InternalParameter_148)
        {
            InternalType_43 InternalVar_1 = InternalParameter_147 as InternalType_43;

            InternalVar_1.InternalProperty_269 = true;
            InternalVar_1.InternalProperty_96 = InternalParameter_148.Color;
            InternalVar_1.InternalProperty_97 = InternalParameter_148.Surface;
            InternalVar_1.InternalProperty_98 = InternalParameter_148.CornerRadius;
            InternalVar_1.InternalProperty_99 = InternalParameter_148.EdgeRadius;
            InternalVar_1.InternalProperty_63 = InternalParameter_148.Layout;
            InternalVar_1.InternalProperty_64 = InternalParameter_148.AutoLayout;
        }

        private static Type InternalMethod_200<TSlice>() where TSlice : struct
        {
            if (typeof(TSlice) == typeof(GridSlice3D))
            {
                return typeof(InternalType_43);
            }

            return typeof(InternalType_42);
        }

        private InternalType_33 InternalMethod_201(bool InternalParameter_149)
        {
            int InternalVar_1 = InternalParameter_149 ? InternalField_98 - 1 : InternalField_99 + 1;
            int InternalVar_2 = InternalProperty_48.InternalMethod_254(InternalVar_1);

            if (InternalField_94.InternalMethod_297(InternalField_92, out InternalType_33 InternalVar_3))
            {
                int InternalVar_4 = InternalVar_3.InternalProperty_209;
                int InternalVar_5 = InternalParameter_149 ? 0 : InternalProperty_51 - InternalField_94.InternalMethod_298(InternalField_92) - 1;

                if (InternalParameter_149)
                {
                    InternalField_96 = Mathf.Max(InternalField_96 - 1, 0);
                }
                else
                {
                    InternalField_95 = Mathf.Max(InternalField_95 - 1, 0);
                }

                if (InternalVar_4 != InternalVar_5)
                {
                    InternalMethod_207(InternalVar_3, InternalVar_5);
                }
            }
            else
            {
                InternalVar_3 = InternalField_93.InternalMethod_294(InternalField_92);

                InternalVar_3.InternalMethod_287();
                InternalMethod_206(InternalVar_3, crossAxisItemCount, InternalParameter_157: InternalParameter_149);
                InternalVar_3.InternalMethod_279();
            }

            InternalMethod_202(InternalVar_3, InternalField_90, InternalVar_2, UIBlock.InternalMethod_79().Axis, crossAxis);

            return InternalVar_3;
        }

        private void InternalMethod_202(InternalType_33 InternalParameter_150, MulticastDelegate InternalParameter_151, int InternalParameter_152, Axis InternalParameter_153, Axis InternalParameter_154)
        {
            if (InternalField_91 == typeof(GridSlice2D))
            {
                GridSlice2D InternalVar_1 = new GridSlice2D(InternalParameter_153, InternalParameter_154);

                if (InternalParameter_151 != null)
                {
                    try
                    {
                        GridSliceProviderCallback<GridSlice2D> InternalVar_2 = (GridSliceProviderCallback<GridSlice2D>)InternalParameter_151;

                        InternalVar_2.Invoke(InternalParameter_152, this, ref InternalVar_1);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                InternalMethod_198(InternalParameter_150, InternalVar_1);
            }
            else if (InternalField_91 == typeof(GridSlice3D))
            {
                GridSlice3D InternalVar_1 = new GridSlice3D(InternalParameter_153, InternalParameter_154);

                if (InternalParameter_151 != null)
                {
                    try
                    {
                        GridSliceProviderCallback<GridSlice3D> InternalVar_2 = (GridSliceProviderCallback<GridSlice3D>)InternalParameter_151;
                        InternalVar_2.Invoke(InternalParameter_152, this, ref InternalVar_1);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                InternalMethod_199(InternalParameter_150, InternalVar_1);
            }
            else
            {
                GridSlice InternalVar_1 = new GridSlice(InternalParameter_153, InternalParameter_154);

                if (InternalParameter_151 != null)
                {
                    try
                    {
                        GridSliceProviderCallback<GridSlice> InternalVar_2 = (GridSliceProviderCallback<GridSlice>)InternalParameter_151;
                        InternalVar_2.Invoke(InternalParameter_152, this, ref InternalVar_1);
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                    }
                }

                InternalMethod_197(InternalParameter_150, InternalVar_1);
            }
        }

        internal void InternalMethod_411(bool InternalParameter_173 = false)
        {
            if (MinLoadedIndex < 0)
            {
                return;
            }

            if (InternalParameter_173)
            {
                for (int InternalVar_1 = 0; InternalVar_1 < transform.childCount; ++InternalVar_1)
                {
                    Transform InternalVar_2 = transform.GetChild(InternalVar_1);

                    if (!InternalVar_2.gameObject.activeSelf)
                    {
                        continue;
                    }

                    if (!InternalVar_2.TryGetComponent(out UIBlock InternalVar_3))
                    {
                        continue;    
                    }
                    
                    ((InternalType_4)InternalVar_3).InternalMethod_119();
                } 
            }

            while (MinLoadedIndex % crossAxisItemCount != 0)
            {
                InternalMethod_228(InternalParameter_174: false);
            }
            
            int InternalVar_4 = UIBlock.InternalProperty_84 * crossAxisItemCount;

            int InternalVar_5 = DataSourceItemCount % crossAxisItemCount;

            if (InternalVar_5 != 0 && MaxLoadedIndex == DataSourceItemCount - 1)
            {
                InternalVar_4 -= crossAxisItemCount - InternalVar_5;
            }

            if (InternalVar_4 == UIBlock.ChildCount)
            {
                return;
            }

            if (InternalVar_4 > UIBlock.ChildCount)
            {
                int InternalVar_6 = UIBlock.InternalProperty_84 - Mathf.FloorToInt(UIBlock.ChildCount / (float)crossAxisItemCount);

                for (int InternalVar_7 = 0; InternalVar_7 < InternalVar_6 && InternalProperty_51 > InternalField_96; ++InternalVar_7)
                {
                    InternalType_33 InternalVar_8 = InternalProperty_50[InternalProperty_51 - (++InternalField_96)] as InternalType_33;

                    InternalProperty_54.InternalMethod_58(InternalVar_8);

                    InternalField_94.InternalMethod_295(InternalVar_8);
                }

                InternalVar_6 = UIBlock.ChildCount - ((UIBlock.InternalProperty_84 - InternalVar_6) * crossAxisItemCount);

                for (int InternalVar_7 = 0; InternalVar_7 < InternalVar_6; ++InternalVar_7)
                {
                    InternalMethod_231();
                }
            }
            else
            {
                bool InternalVar_6 = UIBlock.ChildCount % crossAxisItemCount != 0;
                int InternalVar_7 = InternalVar_6 ? crossAxisItemCount - (UIBlock.ChildCount % crossAxisItemCount) : 0;

                for (int InternalVar_8 = 0; InternalVar_8 < InternalVar_7 && InternalField_99 < DataSourceItemCount - 1; ++InternalVar_8)
                {
                    InternalMethod_229(InternalParameter_175: false);
                }

                InternalVar_7 = Mathf.CeilToInt(UIBlock.ChildCount / (float)crossAxisItemCount) - UIBlock.InternalProperty_84;

                for (int InternalVar_8 = 0; InternalVar_8 < InternalVar_7; ++InternalVar_8)
                {
                    InternalType_33 InternalVar_9 = InternalMethod_201(InternalParameter_149: true);

                    InternalVar_9.InternalMethod_442();

                    InternalProperty_54.InternalMethod_59(InternalVar_9.InternalProperty_83);
                }
            }

            InternalProperty_56.InternalMethod_42();

            InternalMethod_412();

            Relayout();
        }

        #region 
        [SerializeField, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_118 virtualBlockSerializer = null;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_100 InternalField_97 = InternalType_100.InternalField_312;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_100 InternalProperty_49
        {
            get
            {
                if (virtualBlockSerializer == null && InternalField_97.InternalProperty_180)
                {
                    virtualBlockSerializer = ScriptableObject.CreateInstance<InternalType_118>();
                    virtualBlockSerializer.InternalField_384 = InternalField_97;
                }

                if (virtualBlockSerializer == null)
                {
                    return InternalType_100.InternalField_312;
                }

                return virtualBlockSerializer.InternalField_384;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_521<InternalType_34> InternalProperty_50 => InternalProperty_49.InternalProperty_183;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalProperty_51 => InternalProperty_50.InternalProperty_433;

        private void InternalMethod_206(InternalType_34 InternalParameter_155, int InternalParameter_156, bool InternalParameter_157)
        {
            if (!InternalProperty_49.InternalProperty_180)
            {
                virtualBlockSerializer = ScriptableObject.CreateInstance<InternalType_118>();
                InternalField_97 = new InternalType_100(UIBlock);
                virtualBlockSerializer.InternalField_384 = InternalField_97;
            }

            InternalProperty_49.InternalMethod_536(InternalParameter_155, InternalParameter_156, InternalParameter_157);
        }

        private void InternalMethod_207(InternalType_34 InternalParameter_158, int InternalParameter_159) => InternalProperty_49.InternalMethod_537(InternalParameter_158, InternalParameter_159);
        private void InternalMethod_208(InternalType_34 InternalParameter_160) => InternalProperty_49.InternalMethod_538(InternalParameter_160);

        private void InternalMethod_412() => InternalProperty_49.InternalMethod_3740(CrossAxisItemCount);

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }
        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            InternalMethod_2409();

            if (!NovaApplication.IsPlaying ||
                virtualBlockSerializer == null ||
                virtualBlockSerializer.InternalField_384 == InternalField_97 ||
                !virtualBlockSerializer.InternalField_384.InternalProperty_180 ||
                (InternalProperty_53 != null && virtualBlockSerializer.InternalField_384.InternalProperty_181.InternalProperty_29 == InternalProperty_53.InternalProperty_29))
            {
                return;
            }

            InternalField_97 = InternalType_100.InternalMethod_541(virtualBlockSerializer.InternalField_384.InternalProperty_181.InternalProperty_29, InternalProperty_53);
            virtualBlockSerializer = null;
        }
        #endregion

        #endregion
    }
}
