// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_8;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System;
using System.Collections.Generic;
using UnityEngine;

using Math = Nova.InternalNamespace_0.InternalNamespace_5.InternalType_187;

namespace Nova
{
    internal interface InternalType_29 : InternalType_1, InternalType_4 { }

    /// <summary>
    /// Creates a virtualized, scrollable list of <see cref="ItemView"/> prefabs from a user-provided data source.
    /// </summary>
    [AddComponentMenu("Nova/List View")]
    [RequireComponent(typeof(UIBlock))]
    [HelpURL("https://novaui.io/manual/ListView.html")]
    public class ListView : MonoBehaviour, InternalType_29, ISerializationCallbackReceiver
    {
        #region Public
        /// <summary>
        /// Invoked when the list is scrolled beyond the last list element. Provides the distance between the edge of content and edge of the viewport.
        /// </summary>
        /// <remarks>This event will fire <i>every</i> frame the <see cref="ListView"/> is scrolled while in this state. This provides the most flexibility to the event subscribers, but it does mean this event can be a bit noisy.</remarks>
        public event Action<float> OnScrolledPastEnd = null;

        /// <summary>
        /// Invoked when the list is scrolled beyond the first list element. Provides the distance between the edge of content and edge of the viewport.
        /// </summary>
        /// <remarks>This event will fire <i>every</i> frame the <see cref="ListView"/> is scrolled while in this state. This provides the most flexibility to the event subscribers, but it does mean this event can be a bit noisy.</remarks>
        public event Action<float> OnScrolledPastStart = null;

        /// <summary>
        /// The distance a list item must be out of view before it's removed and added back into the list item pool.<br/>Can be used as a spatial buffer in the event the rendered size of a list item extends beyond its <see cref="UIBlock.LayoutSize"/>.
        /// </summary>
        public float OutOfViewDistance
        {
            get => outOfViewDistance;
            set => outOfViewDistance = value;
        }

        /// <summary>
        /// The size of the underlying data source. Will return <c>0</c> if the underlying data source is <c>null</c>.
        /// </summary>
        public int DataSourceItemCount => InternalProperty_55 == null || InternalProperty_55.InternalProperty_431 ? 0 : InternalProperty_55.InternalProperty_430;

        /// <summary>
        /// The highest index into the data source mapped to a list item that's currently loaded into view.
        /// </summary>
        public int MaxLoadedIndex => DataSourceItemCount == 0 ? -1 : Math.InternalMethod_883(InternalField_99, 0, DataSourceItemCount - 1);

        /// <summary>
        /// The lowest index into the data source mapped to a list item that's currently loaded into view.
        /// </summary>
        public int MinLoadedIndex => DataSourceItemCount == 0 ? -1 : Math.InternalMethod_883(InternalField_98, 0, DataSourceItemCount - 1);

        /// <summary>
        /// The parent <see cref="Nova.UIBlock"/> of all the list items. Attached to <c>this.gameObject</c>. 
        /// </summary>
        public UIBlock UIBlock
        {
            get
            {
                if (!NovaApplication.IsPlaying)
                {
                    return GetComponent<UIBlock>();
                }

                if (_uiBlock == null)
                {
                    _uiBlock = GetComponent<UIBlock>();
                }

                return _uiBlock;
            }
        }

        /// <summary>
        /// Retrieve the underlying data source, previously assigned via <see cref="SetDataSource{T}(IList{T})"/>.
        /// </summary>
        /// <remarks></remarks>
        /// <typeparam name="T">The list item type of the data source</typeparam>
        /// <returns>Returns <c>null</c> if the data source was never set or if the data source is not an instance of <see cref="IList{T}"/>. Otherwise returns the underlying data source.</returns>
        public IList<T> GetDataSource<T>()
        {
            return InternalProperty_55 == null ? null : InternalProperty_55.InternalMethod_2038<T>();
        }

        /// <summary>
        /// Set the underlying data source. This instructs the list to start creating a 1-to-1 mapping of objects in the data source to <see cref="ListView"/> list items.
        /// </summary>
        /// <remarks>
        /// Any desired <see cref="Data.OnBind{TData}"/> event handlers must be added via <see cref="AddDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/><br/> <b>before</b> this call to <see cref="SetDataSource{T}(IList{T})"/>.
        /// Otherwise the <see cref="ListView"/> won't know how to bind objects in the <paramref name="dataSource"/> to any of the list item prefab types.
        /// </remarks>
        /// <typeparam name="T">The type of list element stored in <paramref name="dataSource"/></typeparam>
        /// <param name="dataSource">The list of data objects to bind to this <see cref="ListView"/></param>
        /// 
        /// <example><code>
        /// using System;
        /// using System.Collections.Generic;
        /// using UnityEngine;
        /// 
        /// // In Editor, assign and configure on an <see cref="ItemView"/> at the root of a toggle list-item prefab
        /// [Serializable]
        /// public class ToggleVisuals : <see cref="ItemVisuals"/>
        /// {
        ///     // The visual to display a label string
        ///     public <see cref="TextBlock"/> Label;
        ///
        ///     // The visual to display toggle on/off state
        ///     public <see cref="UIBlock2D"/> IsOnIndicator;
        /// }
        /// 
        /// // The underlying data stored per toggle in a list of toggles
        /// [Serializable]
        /// public class ToggleData
        /// {
        ///     public string Label;
        ///     public bool IsOn;
        /// }
        /// 
        /// public class ListViewBinder : MonoBehaviour
        /// {
        ///      // Serialize and assign in the Editor
        ///      public <see cref="ListView"/> ListView = null;
        ///
        ///      // Serialize and assign in the Editor
        ///      public List&lt;ToggleData&gt; Toggles = null;
        ///      
        ///      // Color to display when a toggle is "on"
        ///      public Color ToggledOnColor = Color.blue;
        ///      // Color to display when a toggle is "off"
        ///      public Color ToggledOffColor = Color.grey;
        /// 
        ///      public void OnEnable()
        ///      {
        ///          // <see cref="ListView.AddDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
        ///          ListView.AddDataBinder&lt;ToggleData, ToggleVisuals&gt;(BindToggle);
        ///      }
        ///
        ///      // <see cref="Data.OnBind{TData}"/>
        ///      public void BindToggle(Data.OnBind&lt;ToggleData&gt; evt, ToggleVisuals fields, int index)
        ///      {
        ///          // Get the ToggleData off the Data.OnBind event
        ///          ToggleData toggleData = evt.UserData;
        ///
        ///          // Assign the ToggleVisuals.Label text to the underlying ToggleData.Label string
        ///          fields.Label.Text = toggleData.Label;
        ///
        ///          // Assign the ToggleVisuals.IsOnIndicator color to ToggledOnColor or ToggledOffColor, depending on the underlying ToggleData.IsOn bool
        ///          fields.IsOnIndicator.Color = toggleData.IsOn ? ToggledOnColor : ToggledOffColor;
        ///      }
        ///      
        ///      public void OnDisable()
        ///      {
        ///          // <see cref="ListView.RemoveDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
        ///          ListView.RemoveDataBinder&lt;ToggleData, ToggleVisuals&gt;(BindToggle);
        ///      }
        /// }
        /// </code></example>
        public void SetDataSource<T>(IList<T> dataSource)
        {
            InternalField_570 = true;

            InternalField_102.InternalMethod_2016(UIBlock.transform, listItemPrefabs);

            InternalMethod_219(InternalParameter_163: false);

            if (InternalProperty_55 != null)
            {
                InternalProperty_55.Dispose();
            }

            InternalProperty_55 = InternalType_516<T>.InternalMethod_2034(dataSource);

            if (dataSource != null && UIBlock.InternalProperty_25)
            {
                AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

                if (InternalVar_1.AutoSpace)
                {
                    Debug.LogWarning($"{nameof(AutoLayout)}.{nameof(AutoLayout.AutoSpace)} is not supported on {GetType().Name}s and will likely lead to issues when populating the {GetType().Name} with items if enabled.", this);
                }

                bool InternalVar_2 = InternalVar_1.Cross.Enabled && InternalVar_1.Cross.Axis != InternalVar_1.Axis;

                if (InternalVar_2)
                {
                    Debug.LogWarning($"{nameof(AutoLayout)}.{nameof(AutoLayout.Cross)} is not supported on {GetType().Name}s and will likely lead to issues populating the {GetType().Name} with items and while scrolling if enabled.", this);
                }

                InternalMethod_217();
            }

            InternalProperty_56.InternalMethod_42();

            InternalField_570 = false;
        }

        /// <summary>
        /// Scrolls the list content by the provided <paramref name="delta"/> along the <see cref="UIBlock"/>'s <see cref="AutoLayout"/>.<see cref="AutoLayout.Axis">Axis</see>
        /// </summary>
        /// <remarks>If <c><see cref="UIBlock"/>.gameObject.activeInHierarchy == <see langword="false"/></c>, this call won't do anything.</remarks>
        /// <param name="delta">Value is in <c><see cref="UIBlock"/>.transform</c> local space</param>
        public void Scroll(float delta)
        {
            if (!UIBlock.InternalProperty_25 || InternalProperty_55 == null || InternalProperty_55.InternalProperty_431)
            {
                return;
            }

            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            float InternalVar_3 = InternalProperty_56.InternalProperty_548[InternalVar_2] * 2;

            if (Mathf.Abs(delta) >= InternalVar_3)
            {
                delta = Math.InternalMethod_892(delta) * InternalVar_3;
            }

            InternalField_100.InternalMethod_51(delta);
        }

        /// <summary>
        /// Jumps the <see cref="ListView"/> to the item at the given index.
        /// </summary>
        /// <remarks>
        /// The final location of the specified item after the jump will be at to the edge of the view 
        /// in the direction which the <see cref="ListView"/> had to scroll to get to the item.<br/>
        /// E.g. If the <see cref="ListView"/> had to scroll <i>down</i> to get to the item in a vertically scrollable list,
        /// the item will be at the <i>bottom</i> of the view.
        /// </remarks>
        /// <param name="index">The index into the data source, set via <see cref="SetDataSource{T}(IList{T})"/>, of the object to bind into view and jump to</param>
        /// <exception cref="IndexOutOfRangeException">if <c><paramref name="index"/> &lt; 0 || <paramref name="index"/> &gt;= <see cref="DataSourceItemCount"/></c></exception>
        /// <exception cref="InvalidOperationException">if <c><see cref="UIBlock">UIBlock</see>.<see cref="UIBlock.AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> == <see cref="Axis"/>.<see cref="Axis.None">None</see></c></exception>
        /// <seealso cref="JumpToIndexPage(int)"/>
        /// <seealso cref="Scroller.ScrollToIndex(int, bool)"/>
        public void JumpToIndex(int index) => Scroll(JumpToIndexPage(index));

        /// <summary>
        /// Jumps the <see cref="ListView"/> to the virtualized page of the item at the given index
        /// </summary>
        /// <remarks>If <c><see cref="UIBlock"/>.gameObject.activeInHierarchy == <see langword="false"/></c>, this call won't do anything.</remarks>
        /// <example>
        /// <code>
        /// 
        /// // Bind element at index 100 and its surrounding elements to the ListView.
        /// float distanceOutOfView = listView.JumpToIndexPage(100); 
        /// 
        /// // move the element at index 100 into view
        /// listView.Scroll(distanceOutOfView);
        /// 
        /// </code>
        /// </example>
        /// 
        /// <param name="index">The index into the data source, set via <see cref="SetDataSource{T}(IList{T})"/>, of the object to bind into view and jump to</param>
        /// 
        /// <returns>
        /// The signed distance the list must be scrolled to make the jumped-to item maximally visible within the viewport.<br/><br/>
        /// Calling <see cref="JumpToIndexPage(int)"/> only guarantees to bind the element at the provided <paramref name="index"/> to<br/>
        /// the <see cref="ListView"/>, but it might be slightly out of view without a subsequent call to <see cref="Scroll(float)"/>.
        /// </returns>
        /// <exception cref="IndexOutOfRangeException">if <c><paramref name="index"/> &lt; 0 || <paramref name="index"/> &gt;= <see cref="DataSourceItemCount"/></c></exception>
        /// <exception cref="InvalidOperationException">if <c><see cref="UIBlock">UIBlock</see>.<see cref="UIBlock.AutoLayout">AutoLayout</see>.<see cref="AutoLayout.Axis">Axis</see> == <see cref="Axis"/>.<see cref="Axis.None">None</see></c></exception>
        /// <seealso cref="JumpToIndex(int)"/>
        /// <seealso cref="Scroller.ScrollToIndex(int, bool)"/>
        public float JumpToIndexPage(int index) => InternalMethod_2686(index, InternalParameter_2246: true);

        /// <summary>
        /// Attempts to retrieve the <see cref="ItemView"/> in view representing the object in the data source at the provided index, <paramref name="sourceIndex"/>.
        /// </summary>
        /// <param name="sourceIndex">The index of the object in the data source</param>
        /// <param name="listItem">The list item visual reprensenting the object at index <paramref name="sourceIndex"/></param>
        /// <returns><see langword="true"/> if a list item representing the object at index <paramref name="sourceIndex"/> is currently loaded into view. Otherwise returns <see langword="false"/>.</returns>
        /// <seealso cref="TryGetSourceIndex(ItemView, out int)"/>
        public bool TryGetItemView(int sourceIndex, out ItemView listItem)
        {
            return InternalMethod_2061(sourceIndex, out _, out listItem);
        }

        /// <summary>
        /// Attempts to retrieve the index into the data source, <paramref name="sourceIndex"/>, represented by the provided in-view <paramref name="listItem"/>.
        /// </summary>
        /// <param name="listItem">The list item visual reprensenting the object at index <paramref name="sourceIndex"/></param>
        /// <param name="sourceIndex">The index of the object in the data source</param>
        /// <returns><see langword="true"/> if <paramref name="listItem"/> is loaded into view. Otherwise returns <see langword="false"/>.</returns>
        /// <seealso cref="TryGetItemView(int, out ItemView)"/>
        public bool TryGetSourceIndex(ItemView listItem, out int sourceIndex)
        {
            if (listItem == null)
            {
                sourceIndex = -1;
                return false;
            }

            return InternalField_102.InternalMethod_2020(listItem.UIBlock.InternalProperty_29, out sourceIndex);
        }

        /// <summary>
        /// Transfers ownership of the <see cref="ItemView"/> representing the object at data source index <paramref name="sourceIndex"/> from the <see cref="ListView"/> to the caller, allowing the caller to manipulate the <paramref name="listItem"/> arbitrarily without fighting the <see cref="ListView"/> binding/prefab pooling system.
        /// </summary>
        /// <remarks>
        /// If the detach succeeds, the <paramref name="listItem"/>'s parent will be set to <paramref name="newParent"/>.<br/><br/>
        /// Because the now detached item is no longer a child of the <see cref="ListView"/>, the gesture handlers registered
        /// on the <see cref="ListView"/> will not fire for the detached item anymore. To continue receiving the same events while the item is detached,
        /// subscribe to them on the detached <see cref="ItemView.UIBlock"/> directly (or its new parent) via <see cref="UIBlock.AddGestureHandler{TGesture}(UIEventHandler{TGesture}, bool)"/> 
        /// and then use <see cref="UIBlock.RemoveGestureHandler{TGesture}(UIEventHandler{TGesture})"/> before <see cref="TryReattach(ItemView)"/> to avoid having multiple gesture handlers simultaneously. 
        /// </remarks>
        /// <param name="sourceIndex">The index of the object in the data source</param>
        /// <param name="listItem">The list item visual reprensenting the object at index <paramref name="sourceIndex"/></param>
        /// <param name="newParent">The transform to set as the new parent of <paramref name="listItem"/></param>
        /// <returns><see langword="true"/> if <paramref name="listItem"/> is loaded into view and gets detached succesfully. Otherwise returns <see langword="false"/>.</returns>
        /// <seealso cref="TryDetach(ItemView, Transform)"/>
        /// <seealso cref="TryReattach(ItemView)"/>
        public bool TryDetach(int sourceIndex, out ItemView listItem, Transform newParent = null)
        {
            if (!TryGetItemView(sourceIndex, out listItem))
            {
                return false;
            }

            return TryDetach(listItem, newParent);
        }

        /// <summary>
        /// Transfers ownership of the detached <paramref name="listItem"/> from the <see cref="ListView"/> to the caller, allowing the caller to manipulate the <paramref name="listItem"/> arbitrarily without fighting the <see cref="ListView"/> binding/prefab pooling system.
        /// </summary>
        /// <remarks>
        /// If the detach succeeds, the <paramref name="listItem"/>'s parent will be set to <paramref name="newParent"/>.<br/><br/>
        /// Because the now detached item is no longer a child of the <see cref="ListView"/>, the gesture handlers registered
        /// on the <see cref="ListView"/> will not fire for the detached item anymore. To continue receiving the same events while the item is detached,
        /// subscribe to them on the detached <see cref="ItemView.UIBlock"/> directly (or its new parent) via <see cref="UIBlock.AddGestureHandler{TGesture}(UIEventHandler{TGesture}, bool)"/> 
        /// and then use <see cref="UIBlock.RemoveGestureHandler{TGesture}(UIEventHandler{TGesture})"/> before <see cref="TryReattach(ItemView)"/> to avoid having multiple gesture handlers simultaneously. 
        /// </remarks>
        /// <param name="listItem">The list item visual reprensenting the item</param>
        /// <param name="newParent">The transform to set as the new parent of <paramref name="listItem"/></param>
        /// <returns><see langword="true"/> if <paramref name="listItem"/> is loaded into view and gets detached succesfully. Otherwise returns <see langword="false"/>.</returns>
        /// <seealso cref="TryDetach(int, out ItemView, Transform)"/>
        /// <seealso cref="TryReattach(ItemView)"/>
        public bool TryDetach(ItemView listItem, Transform newParent = null)
        {
            if (listItem == null ||
                !InternalField_102.InternalMethod_2020(listItem.UIBlock.InternalProperty_29, out int InternalVar_1) ||
                !InternalField_102.InternalMethod_2024(listItem, newParent))
            {
                return false;
            }

            InternalField_2335.Remove(InternalVar_1);
            InternalField_105.Add(InternalVar_1);
            InternalField_100.InternalMethod_58(listItem.UIBlock);
            return true;
        }

        /// <summary>
        /// If a list item was previously detached from the <see cref="ListView"/> (via <see cref="TryDetach(ItemView, Transform)"/>),
        /// this is a way to transfer ownership of <paramref name="listItem"/> back to the <see cref="ListView"/>.
        /// </summary>
        /// <remarks>
        /// The returned object is simply returned to the list item prefab pool for reuse, <i>not</i> inserted into view directly.
        /// </remarks>
        /// <param name="listItem">The list item to re-attach, previously detached via <see cref="TryDetach(ItemView, Transform)"/></param>
        /// <returns><see langword="true"/> if <paramref name="listItem"/> was previously detached from this <see cref="ListView"/> and can be attached/pooled. Otherwise returns <see langword="false"/>.</returns>
        /// <seealso cref="TryDetach(int, out ItemView, Transform)"/>
        /// <seealso cref="TryDetach(ItemView, Transform)"/>
        public bool TryReattach(ItemView listItem)
        {
            return InternalField_102.InternalMethod_2023(listItem);
        }

        /// <summary>
        /// Reprocesses the object at index <paramref name="sourceIndex"/> in the data source, invoking any 
        /// necessary <see cref="PrefabProviderCallback{int}"/> callbacks, added via<br/> 
        /// <see cref="AddPrefabProvider{TData}(PrefabProviderCallback{int})"/>, and triggering a <see cref="Data.OnBind{TData}"/> event 
        /// to refresh the list item content. 
        /// </summary>
        /// <remarks>Unlike <see cref="Refresh"/>, <see cref="Rebind(int)"/> does not load new items if the rebind causes new content
        /// to become visible. If your call to <see cref="Rebind(int)"/> modifies the size of the target item, potentially requiring new items
        /// to be loaded, call <see cref="Relayout"/> after <see cref="Rebind(int)"/> or use <see cref="Refresh"/> instead.</remarks>
        /// <param name="sourceIndex">The index of the object in the data source to rebind to the <see cref="ListView"/></param>
        public void Rebind(int sourceIndex)
        {
            if (!UIBlock.InternalProperty_25 || InternalProperty_55 == null || InternalProperty_55.InternalProperty_431)
            {
                return;
            }

            if (sourceIndex < InternalField_98 || sourceIndex > InternalField_99)
            {
                return;
            }

            if (!InternalField_105.Contains(sourceIndex))
            {
                bool InternalVar_3 = InternalMethod_2061(sourceIndex, out InternalType_131 InternalVar_1, out ItemView InternalVar_2);
                if (!InternalVar_3 && !InternalVar_1.InternalProperty_192)
                {
                    return;
                }

                if (InternalVar_3 && InternalField_102.InternalMethod_2021(sourceIndex, InternalVar_2, InternalProperty_55.InternalMethod_2036(sourceIndex), out Type InternalVar_4))
                {
                    InternalType_515<int>.InternalMethod_2032(InternalVar_4).InternalMethod_2042(InternalVar_2, InternalProperty_55, sourceIndex);
                    return;
                }

                InternalMethod_233(sourceIndex, InternalParameter_178: true);
            }

            if (InternalMethod_2059(sourceIndex, out ItemView InternalVar_5))
            {
                int InternalVar_6 = -1;

                int InternalVar_7 = InternalVar_5.transform.GetSiblingIndex();

                for (int InternalVar_8 = sourceIndex - 1; InternalVar_8 >= InternalField_98; --InternalVar_8)
                {
                    if (TryGetItemView(InternalVar_8, out ItemView InternalVar_9))
                    {
                        InternalVar_6 = InternalVar_9.transform.GetSiblingIndex() + 1;
                        break;
                    }
                }

                if (InternalVar_6 < 0)
                {
                    for (int InternalVar_8 = sourceIndex + 1; InternalVar_8 <= InternalField_99; ++InternalVar_8)
                    {
                        if (TryGetItemView(InternalVar_8, out ItemView InternalVar_9))
                        {
                            InternalVar_6 = InternalVar_9.transform.GetSiblingIndex();
                            break;
                        }
                    }
                }

                InternalVar_6 = InternalVar_6 < 0 ? 0 : InternalVar_7 < InternalVar_6 ? InternalVar_6 - 1 : InternalVar_6;

                if (InternalVar_7 != InternalVar_6)
                {
                    InternalVar_5.transform.SetSiblingIndex(InternalVar_6);
                }
            }
        }

        /// <summary>
        /// Synchronizes the items in view with the content of the underlying data source, previously assigned via <see cref="SetDataSource{T}(IList{T})"/>.<br/>
        /// Calls <see cref="Rebind(int)"/> for in-view elements, handles changes to the number of items in the data source, and will call <see cref="Relayout"/> to ensure the view is filled. 
        /// </summary>
        public void Refresh()
        {
            if (!UIBlock.InternalProperty_25)
            {
                return;
            }

            if (InternalProperty_55 == null || InternalProperty_55.InternalProperty_431)
            {
                if (InternalField_2335.Count > 0)
                {
                    InternalMethod_219(InternalParameter_163: true);
                }

                return;
            }

            bool InternalVar_1 = false;

            while (InternalField_99 >= DataSourceItemCount && InternalField_99 >= InternalField_98)
            {
                if (InternalField_99 % InternalProperty_52 == 0)
                {
                    InternalMethod_2060(InternalParameter_2701: false);
                }
                else
                {
                    InternalMethod_231();
                }

                InternalVar_1 = true;
            }

            bool InternalVar_2 = InternalField_99 < InternalField_98;

            if (InternalVar_2)
            {
                InternalField_98 = InternalVar_1 ? DataSourceItemCount : 0;
                InternalField_99 = InternalField_98 - 1;

                InternalMethod_218(InternalParameter_162: !InternalVar_1);
                JumpToIndex(InternalVar_1 ? InternalField_99 : InternalField_98);
            }
            else
            {
                for (int InternalVar_3 = MinLoadedIndex; InternalVar_3 <= MaxLoadedIndex; ++InternalVar_3)
                {
                    Rebind(InternalVar_3);

                    if (!InternalMethod_2061(InternalVar_3, out InternalType_131 InternalVar_4, out ItemView InternalVar_5))
                    {
                        continue;
                    }

                    InternalVar_5.UIBlock.InternalMethod_106();
                }
            }

            if (InternalVar_1)
            {
                InternalProperty_56.InternalMethod_42();
            }

            Relayout();
        }

        /// <summary>
        /// The <see cref="ListView"/> will pull more content into view and page content out of view as it's scrolled, but it doesn't automatically check for external<br/>
        /// events causing its child list items to change in size. This utility provides a way to manually re-fill the list view or page out extraneous list items.
        /// </summary>
        public void Relayout()
        {
            UIBlock.CalculateLayout();

            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return;
            }

            float InternalVar_3 = 0;

            if (InternalProperty_56.InternalProperty_1 <= InternalProperty_56.InternalProperty_549[InternalVar_2] && DataSourceItemCount > 0)
            {
                int InternalVar_4 = TryGetItemView(0, out _) ? DataSourceItemCount - 1 : 0;

                InternalVar_3 = InternalMethod_2686(InternalVar_4, InternalParameter_2246: false);
            }
            else
            {
                while ((InternalField_99 + 1) % InternalProperty_52 != 0 &&
                       InternalField_99 < DataSourceItemCount - 1)
                {
                    InternalMethod_229(InternalParameter_175: false);
                }

                bool InternalVar_4 = !InternalProperty_56.InternalMethod_45(1);
                bool InternalVar_5 = !InternalProperty_56.InternalMethod_45(-1);

                float InternalVar_6 = UIBlock.InternalProperty_19[InternalVar_2];
                float InternalVar_7 = UIBlock.InternalProperty_18[InternalVar_2];
                float InternalVar_8 = UIBlock.PaddedSize[InternalVar_2];
                float InternalVar_9 = UIBlock.CalculatedPadding.Offset[InternalVar_2];

                float InternalVar_10 = InternalVar_7 * 0.5f;
                float InternalVar_11 = InternalVar_6 - InternalVar_10;
                float InternalVar_12 = InternalVar_6 + InternalVar_10;
                float InternalVar_13 = InternalVar_8 * 0.5f;
                float InternalVar_14 = InternalVar_9 - InternalVar_13;
                float InternalVar_15 = InternalVar_9 + InternalVar_13;

                if (InternalVar_4 && InternalVar_12 < InternalVar_15)
                {
                    InternalVar_3 = InternalVar_15 - InternalVar_12;
                }
                else if (InternalVar_5 && InternalVar_11 > InternalVar_14)
                {
                    InternalVar_3 = InternalVar_14 - InternalVar_11;
                }
            }

            Scroll(InternalVar_3);
        }

        /// <summary>
        /// Register a <see cref="PrefabProviderCallback{TKey}"/> for a particular data type in the data source, <typeparamref name="TData"/>.
        /// </summary>
        /// <remarks>Allows the caller to manually provide the prefab to use for a given object in the data source. Useful for when the<br/> caller wants to
        /// bind multiple list item prefab types to a single data type in the data source, <typeparamref name="TData"/>, or if the caller<br/> 
        /// wants to bypass the serialized set of list item prefabs.
        /// </remarks>
        /// <typeparam name="TData">The the list element type of the data source (or a derived type)</typeparam>
        /// <param name="prefabProvider">The callback that will be invoked before loading a list item for data source element type <typeparamref name="TData"/></param>
        /// <exception cref="ArgumentNullException">If <paramref name="prefabProvider"/> is <c>null</c>.</exception>
        public void AddPrefabProvider<TData>(PrefabProviderCallback<int> prefabProvider)
        {
            if (prefabProvider == null)
            {
                throw new ArgumentNullException(nameof(prefabProvider));
            }

            InternalField_102.InternalMethod_2029<TData>(prefabProvider);
        }

        /// <summary>
        /// Unregister a <see cref="PrefabProviderCallback{TKey}"/> that was previously registered via <see cref="AddPrefabProvider{TData}(PrefabProviderCallback{int})"/>
        /// </summary>
        /// <typeparam name="TData">The the list element type of the data source (or a derived type)</typeparam>
        public void RemovePrefabProvider<TData>() => InternalField_102.InternalMethod_2028<TData>();

        /// <summary>
        /// Subscribe to an indexed <see cref="Data.OnUnbind{TData}"/> event on this <see cref="ListView"/>'s set of list items
        /// </summary>
        /// <remarks><typeparamref name="TData"/> should match or be derived from the underlying data source element type, the type parameter passed into <see cref="SetDataSource{T}(IList{T})"/>.</remarks>
        /// <typeparam name="TData">The data type to unbind from the corresponding <typeparamref name="TVisuals"/> type</typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback invoked when the event fires</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        public void AddDataUnbinder<TData, TVisuals>(UIEventHandler<Data.OnUnbind<TData>, TVisuals, int> eventHandler) where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalField_102.InternalMethod_2031<TVisuals, TData>();

            InternalMethod_2678(eventHandler);
        }

        /// <summary>
        /// Unsubscribe from an indexed <see cref="Data.OnUnbind{TData}"/> event previously subscribed to via <see cref="ListView.AddDataUnbinder{TData, TVisuals}(UIEventHandler{Data.OnUnbind{TData}, TVisuals, int})"/>
        /// </summary>
        /// <remarks><typeparamref name="TData"/> should match or be derived from the underlying data source element type, the type parameter passed into <see cref="SetDataSource{T}(IList{T})"/>.</remarks>
        /// <typeparam name="TData">The data type to bind to the corresponding <typeparamref name="TVisuals"/> type</typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback to remove from the subscription list</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        public void RemoveDataUnbinder<TData, TVisuals>(UIEventHandler<Data.OnUnbind<TData>, TVisuals, int> eventHandler) where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalField_102.InternalMethod_2030<TVisuals, TData>();

            InternalMethod_2677(eventHandler);
        }

        /// <summary>
        /// Subscribe to an indexed <see cref="Data.OnBind{TData}"/> event on this <see cref="ListView"/>'s set of list items
        /// </summary>
        /// <remarks><typeparamref name="TData"/> should match or be derived from the underlying data source element type, the type parameter passed into <see cref="SetDataSource{T}(IList{T})"/>.</remarks>
        /// <typeparam name="TData">The data type to bind to the corresponding <typeparamref name="TVisuals"/> type</typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback invoked when the event fires</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        public void AddDataBinder<TData, TVisuals>(UIEventHandler<Data.OnBind<TData>, TVisuals, int> eventHandler) where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalField_102.InternalMethod_2031<TVisuals, TData>();

            InternalMethod_2678(eventHandler);
        }

        /// <summary>
        /// Unsubscribe from an indexed <see cref="Data.OnBind{TData}"/> event previously subscribed to via <see cref="ListView.AddDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
        /// </summary>
        /// <remarks><typeparamref name="TData"/> should match or be derived from the underlying data source element type, the type parameter passed into <see cref="SetDataSource{T}(IList{T})"/>.</remarks>
        /// <typeparam name="TData">The data type to bind to the corresponding <typeparamref name="TVisuals"/> type</typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback to remove from the subscription list</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        public void RemoveDataBinder<TData, TVisuals>(UIEventHandler<Data.OnBind<TData>, TVisuals, int> eventHandler) where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalField_102.InternalMethod_2030<TVisuals, TData>();

            InternalMethod_2677(eventHandler);
        }

        /// <summary>
        /// Subscribe to an indexed <see cref="IGestureEvent"/> event on this <see cref="ListView"/>'s set of list items
        /// </summary>
        /// <typeparam name="TEvent">The type of gesture event to handle for list items of type <typeparamref name="TVisuals"/></typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback invoked when the event fires</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        public void AddGestureHandler<TEvent, TVisuals>(UIEventHandler<TEvent, TVisuals, int> eventHandler) where TEvent : struct, IGestureEvent where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalMethod_2678(eventHandler);
        }

        /// <summary>
        /// Unsubscribe from a gesture event previously subscribed to via <see cref="ListView.AddGestureHandler{TEvent, TVisuals}(UIEventHandler{TEvent, TVisuals, int})"/>
        /// </summary>
        /// <typeparam name="TEvent">The type of gesture event to handle for list items of type <typeparamref name="TVisuals"/></typeparam>
        /// <typeparam name="TVisuals">The type of <see cref="ItemVisuals"/>, configured on a list item prefab, to target.</typeparam>
        /// <param name="eventHandler">The callback to remove from the subscription list</param>
        /// <exception cref="ArgumentNullException">If <paramref name="eventHandler"/> is <c>null</c>.</exception>
        /// <seealso cref="Gesture.OnClick"/>
        /// <seealso cref="Gesture.OnPress"/>
        /// <seealso cref="Gesture.OnRelease"/>
        /// <seealso cref="Gesture.OnHover"/>
        /// <seealso cref="Gesture.OnUnhover"/>
        /// <seealso cref="Gesture.OnScroll"/>
        /// <seealso cref="Gesture.OnMove"/>
        /// <seealso cref="Gesture.OnDrag"/>
        /// <seealso cref="Gesture.OnCancel"/>
        public void RemoveGestureHandler<TEvent, TVisuals>(UIEventHandler<TEvent, TVisuals, int> eventHandler) where TEvent : struct, IGestureEvent where TVisuals : ItemVisuals
        {
            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            InternalMethod_2677(eventHandler);
        }
        #endregion

        #region Internal
        [SerializeField]
        [Tooltip("The prefabs to use when binding items in the data source.")]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<ItemView> listItemPrefabs = null;

        [SerializeField]
        [Tooltip("The distance a list item must be out of view before it's removed and added back into the list item pool.\nCan be used as a spatial buffer in the event the rendered size of a list item extends beyond its layout size.")]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float outOfViewDistance;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected virtual int InternalProperty_52 => 1;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalType_1.InternalProperty_1081 => InternalProperty_52;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected int InternalField_98 = 0;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected int InternalField_99 = -1;
        [SerializeField, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock _uiBlock = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected UIBlock InternalProperty_53 => _uiBlock;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalType_1.InternalProperty_1
        {
            get
            {
                if (UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_1) &&
                    InternalField_99 - InternalField_98 + 1 == DataSourceItemCount)
                {
                    return InternalField_100.InternalProperty_10[InternalVar_1];
                }

                return InternalMethod_222(DataSourceItemCount);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalType_1.InternalProperty_2
        {
            get
            {
                float InternalVar_1 = InternalProperty_56.InternalProperty_1;

                if (UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_2))
                {
                    InternalVar_1 -= InternalProperty_56.InternalProperty_549[InternalVar_2];
                }

                return Mathf.Max(InternalVar_1, 0);
            }
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_2 InternalField_100 = new InternalType_2();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_2 InternalProperty_54 => InternalField_100;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_190 InternalField_101 = default;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_515<int> InternalField_102 = new InternalType_515<int>();

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_570 = false;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<MulticastDelegate, MulticastDelegate> InternalField_103 = new Dictionary<MulticastDelegate, MulticastDelegate>();

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Dictionary<int, (ItemView Item, Type UserDataType, InternalType_131 ID)> InternalField_2335 = new Dictionary<int, (ItemView Item, Type UserDataType, InternalType_131 ID)>();

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private HashSet<int> InternalField_105 = new HashSet<int>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]

        [field: NonSerialized, HideInInspector]
        private protected InternalType_518 InternalProperty_55 { get; private set; }

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlockActivator InternalField_106 = null;
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_107 = false;
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_82 = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_1.InternalProperty_549 => UIBlock.PaddedSize;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_1.InternalProperty_548
        {
            get
            {
                Vector3 InternalVar_1 = Vector3.zero;

                if (UIBlock.InternalMethod_79().Axis.TryGetIndex(out int InternalVar_2))
                {
                    InternalVar_1[InternalVar_2] = 2 * OutOfViewDistance;
                }

                return UIBlock.CalculatedSize.Value + InternalVar_1;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_1 InternalProperty_56 => this;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalType_1.InternalProperty_3
        {
            get
            {
                AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

                if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
                {
                    return 0;
                }

                float InternalVar_3 = InternalVar_1.InternalProperty_13;

                int InternalVar_4 = Mathf.Clamp(InternalField_98, 0, DataSourceItemCount - 1);
                int InternalVar_5 = DataSourceItemCount - Mathf.Clamp(InternalField_99, 0, DataSourceItemCount - 1) - 1;
                float InternalVar_6 = InternalField_98 > 0 ? UIBlock.CalculatedSpacing.Value : 0;
                float InternalVar_7 = InternalField_99 < DataSourceItemCount - 1 ? UIBlock.CalculatedSpacing.Value : 0;
                float InternalVar_8 = -InternalVar_3 * (InternalMethod_222(InternalVar_4) + InternalVar_6);
                float InternalVar_9 = InternalVar_3 * (InternalMethod_222(InternalVar_5) + InternalVar_7);
                float InternalVar_10 = InternalField_100.InternalProperty_11[InternalVar_2];

                return InternalVar_10 - UIBlock.CalculatedPadding.Offset[InternalVar_2] + 0.5f * (InternalVar_8 + InternalVar_9);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        float InternalType_1.InternalProperty_4 => InternalMethod_221();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_1.InternalProperty_5 => InternalField_100.InternalProperty_10;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_1.InternalProperty_6 => InternalField_100.InternalProperty_11;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalType_1.InternalProperty_0 => DataSourceItemCount;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_521<InternalType_131> InternalType_1.InternalProperty_9 => InternalMethod_2062();

        private protected virtual InternalType_521<InternalType_131> InternalMethod_2062()
        {
            return ((InternalType_146)UIBlock).InternalProperty_214.InternalMethod_2043();
        }

        private void InternalMethod_217()
        {
            ref AutoLayout InternalVar_1 = ref UIBlock.AutoLayout;

            InternalVar_1.Offset = 0;

            InternalField_100.InternalMethod_60(InternalProperty_56, UIBlock, UIBlock.InternalProperty_29);

            if (InternalProperty_55 == null)
            {
                return;
            }

            InternalField_98 = 0;
            InternalField_99 = -1;

            if (!InternalField_82 && InternalNamespace_0.InternalType_24.InternalProperty_945.InternalMethod_554(InternalNamespace_0.InternalType_116.InternalField_2332) && UIBlock.ChildCount != 0)
            {
                string InternalVar_2 = name;
                InternalVar_2 = string.IsNullOrWhiteSpace(InternalVar_2) ? "GameObject" : InternalVar_2;

                Debug.LogWarning($"{InternalVar_2}'s {nameof(ListView)} has {nameof(Nova.UIBlock)} children before being initialized. Manually adding {nameof(Nova.UIBlock)} children to a {nameof(ListView)} is unsupported and will cause issues, as a {nameof(ListView)} must have full control over its children. {InternalType_178.InternalField_484}", this);
            }

            InternalField_82 = true;

            InternalMethod_218(InternalParameter_162: true);

            InternalField_100.InternalMethod_50();

            if (InternalVar_1.Alignment != 0)
            {
                JumpToIndex(0);
            }
        }

        private void InternalMethod_218(bool InternalParameter_162)
        {
            UIBlock InternalVar_1 = UIBlock;

            InternalVar_1.CalculateLayout();

            ref AutoLayout InternalVar_2 = ref InternalVar_1.AutoLayout;

            if (!InternalVar_2.Enabled)
            {
                Debug.LogError($"Auto Layout is disabled on the {GetType().FullName}, {InternalVar_1.name}.", InternalVar_1);
                return;
            }

            int InternalVar_3 = InternalVar_2.Axis.Index();

            bool InternalVar_4 = UIBlock.AutoSize[InternalVar_3] == AutoSize.Shrink;

            float InternalVar_5;

            if (InternalVar_4)
            {
                MinMax InternalVar_6 = UIBlock.SizeMinMax[InternalVar_3];

                InternalVar_5 = InternalVar_6.Max + 2 * OutOfViewDistance;
            }
            else
            {
                InternalVar_5 = InternalProperty_56.InternalProperty_548[InternalVar_3];
            }

            float InternalVar_7 = 0;

            while (InternalVar_7 <= InternalVar_5)
            {
                InternalType_66 InternalVar_8 = InternalProperty_56.InternalMethod_43(InternalParameter_36: InternalParameter_162, InternalVar_5 - InternalVar_7);

                if (InternalVar_8 == null)
                {
                    break;
                }

                float InternalVar_9 = InternalVar_8.InternalProperty_150[InternalVar_3];

                InternalVar_5 = Mathf.Max(InternalProperty_56.InternalProperty_548[InternalVar_3], InternalVar_5);
                InternalVar_7 += InternalVar_9 + UIBlock.CalculatedSpacing.Value;
            }
        }

        private void InternalMethod_219(bool InternalParameter_163 = true, bool InternalParameter_164 = false)
        {
            while (InternalField_2335.Count > 0)
            {
                InternalMethod_2060(InternalParameter_2701: false);
            }

            if (InternalParameter_163)
            {
                InternalProperty_56.InternalMethod_42();
            }

            InternalField_98 = 0;
            InternalField_99 = -1;

            UIBlock.AutoLayout.Offset = 0;

            if (InternalParameter_164)
            {
                InternalField_100.Dispose();
                InternalField_102.InternalMethod_2017();
                InternalMethod_220();
            }
        }

        private float InternalMethod_2686(int InternalParameter_2247, bool InternalParameter_2246)
        {
            if (!UIBlock.InternalProperty_25 || InternalProperty_55 == null || InternalProperty_55.InternalProperty_431)
            {
                return 0;
            }

            if (InternalParameter_2247 < 0 || InternalParameter_2247 >= InternalProperty_55.InternalProperty_430)
            {
                throw new IndexOutOfRangeException($"Expected: [0, {InternalProperty_55.InternalProperty_430}). Actual: {InternalParameter_2247}.");
            }

            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                throw new InvalidOperationException($"{UIBlock.name}'s Auto Layout axis is unassigned.");
            }

            bool InternalVar_3 = TryGetItemView(InternalParameter_2247, out _);
            bool InternalVar_4 = InternalParameter_2247 < InternalField_98;

            if (!InternalVar_3)
            {
                InternalMethod_219(InternalParameter_163: false);

                int InternalVar_5 = InternalParameter_2247 % InternalProperty_52;

                if (InternalVar_4)
                {
                    InternalField_98 = Mathf.Max(InternalParameter_2247 - InternalVar_5 + InternalProperty_52, 0);
                    InternalField_99 = InternalField_98 - 1;
                }
                else
                {
                    InternalField_99 = Mathf.Min(InternalParameter_2247 - InternalVar_5 + InternalProperty_52 - 1, InternalProperty_55.InternalProperty_430 - 1);
                    InternalField_98 = InternalField_99 + 1;
                }

                InternalMethod_218(InternalParameter_162: InternalVar_4);
                InternalProperty_56.InternalMethod_43(InternalParameter_36: false, Mathf.Max(0, UIBlock.CalculatedSize.Value[InternalVar_2] - UIBlock.InternalProperty_18[InternalVar_2]));
            }

            float InternalVar_6 = 0;

            if (InternalMethod_919(InternalParameter_2247, out InternalType_5 InternalVar_7))
            {
                float InternalVar_8 = InternalVar_7.InternalProperty_144[InternalVar_2].InternalField_153;

                if (InternalVar_8 == 0)
                {
                    InternalVar_7.InternalMethod_442();
                    InternalVar_8 = InternalVar_7.InternalProperty_144[InternalVar_2].InternalField_153;
                }

                if (!InternalVar_3 && InternalVar_4 != InternalVar_1.InternalProperty_15)
                {
                    UIBlock.AutoLayout.Offset -= InternalVar_8 + UIBlock.CalculatedSpacing.Value;
                }

                InternalProperty_56.InternalMethod_42();
                UIBlock.CalculateLayout();

                InternalVar_6 = InternalType_182.InternalMethod_3654(InternalVar_7, InternalVar_2, InternalVar_1.Alignment);
            }

            if (InternalParameter_2246)
            {
                InternalField_100.InternalMethod_50();
            }

            return Math.InternalMethod_882(InternalVar_6);
        }

        private bool InternalMethod_2061(int InternalParameter_2721, out InternalType_131 InternalParameter_2720, out ItemView InternalParameter_2702)
        {
            if (!InternalField_2335.TryGetValue(InternalParameter_2721, out var InternalVar_1))
            {
                InternalParameter_2720 = InternalType_131.InternalField_415;
                InternalParameter_2702 = null;
                return false;
            }

            InternalParameter_2720 = InternalVar_1.ID;
            InternalParameter_2702 = InternalVar_1.Item;
            return InternalParameter_2702 != null;
        }

        private protected virtual void InternalMethod_220() { }

        private float InternalMethod_221()
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out int InternalVar_2))
            {
                return 0;
            }

            float InternalVar_3 = InternalProperty_56.InternalProperty_3;
            return InternalType_182.InternalMethod_858(InternalVar_3, InternalProperty_56.InternalProperty_1, InternalProperty_56.InternalProperty_549[InternalVar_2], UIBlock.CalculatedPadding.Offset[InternalVar_2], InternalVar_1.Alignment);
        }

        private float InternalMethod_222(int InternalParameter_165)
        {
            AutoLayout InternalVar_1 = UIBlock.InternalMethod_79();

            if (!InternalVar_1.Axis.TryGetIndex(out _) || InternalParameter_165 <= 0)
            {
                return 0;
            }

            float InternalVar_2 = Mathf.Ceil((float)InternalParameter_165 / InternalProperty_52);

            return (InternalVar_2 * InternalField_101.InternalProperty_242) + ((InternalVar_2 - 1) * UIBlock.CalculatedSpacing.Value);
        }

        private static void InternalMethod_2685<TEvent, TTarget>(ListView InternalParameter_2245, TEvent InternalParameter_2244, TTarget InternalParameter_2243, UIEventHandler<TEvent, TTarget, int> InternalParameter_2242) where TEvent : struct, IEvent where TTarget : ItemVisuals
        {
            try
            {
                bool InternalVar_1 = false;
                UIBlock InternalVar_2 = InternalParameter_2244.Target;

                if (!InternalParameter_2245.InternalField_102.InternalMethod_2020(InternalVar_2.InternalProperty_29, out int InternalVar_3))
                {
                    if (InternalVar_2.transform == InternalParameter_2245.transform)
                    {
                        return;
                    }

                    if (!InternalVar_2.transform.IsChildOf(InternalParameter_2245.transform))
                    {
                        goto NotFound;
                    }

                    while (InternalVar_2 != InternalParameter_2245.UIBlock.gameObject)
                    {
                        InternalVar_2 = InternalVar_2.Parent;

                        if (InternalParameter_2245.InternalField_102.InternalMethod_2020(InternalVar_2.InternalProperty_29, out InternalVar_3))
                        {
                            InternalVar_1 = true;
                            break;
                        }
                    }

                    NotFound:
                    if (!InternalVar_1)
                    {
                        return;
                    }
                }

                InternalParameter_2242?.Invoke(InternalParameter_2244, InternalParameter_2243, InternalVar_3);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        private protected virtual void InternalMethod_224() { }

        void InternalType_1.InternalMethod_42()
        {
            InternalField_102.InternalMethod_2022();

            InternalMethod_224();
        }

        bool InternalType_1.InternalMethod_2317(bool InternalParameter_2723)
        {
            bool InternalVar_1 = !InternalParameter_2723;
            InternalParameter_2723 &= InternalField_98 >= 0;

            if (!InternalParameter_2723 && !InternalVar_1)
            {
                return false;
            }

            InternalMethod_2060(InternalParameter_2701: InternalParameter_2723);

            return true;
        }

        bool InternalType_1.InternalMethod_867(int sourceIndex, out InternalType_5 InternalParameter_170)
        {
            InternalParameter_170 = null;

            if (InternalMethod_2061(sourceIndex, out _, out ItemView InternalVar_1))
            {
                InternalParameter_170 = InternalVar_1.UIBlock;
                return true;
            }

            return false;
        }

        bool InternalType_1.InternalMethod_868(InternalType_5 listItem, out int sourceIndex)
        {
            if (listItem == null)
            {
                sourceIndex = -1;
                return false;
            }

            return InternalField_102.InternalMethod_2020(listItem.InternalProperty_195, out sourceIndex);
        }

        InternalType_66 InternalType_1.InternalMethod_43(bool InternalParameter_36, float InternalParameter_37)
        {
            if (InternalProperty_55 == null)
            {
                return null;
            }

            if (!InternalParameter_36 && InternalField_98 == 0 && OnScrolledPastStart != null)
            {
                try
                {
                    OnScrolledPastStart.Invoke(InternalParameter_37);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }
            else if (InternalParameter_36 && InternalField_99 == InternalProperty_55.InternalProperty_430 - 1 && OnScrolledPastEnd != null)
            {
                try
                {
                    OnScrolledPastEnd.Invoke(InternalParameter_37);
                }
                catch (Exception e)
                {
                    Debug.LogException(e);
                }
            }

            bool InternalVar_1 = !InternalParameter_36 && InternalField_98 > 0;
            bool InternalVar_2 = InternalParameter_36 && InternalField_99 < InternalProperty_55.InternalProperty_430 - 1;

            if (!InternalVar_1 && !InternalVar_2)
            {
                return null;
            }

            InternalType_66 InternalVar_3 = InternalMethod_1858(InternalParameter_2057: InternalVar_1);

            if (InternalVar_3 != null)
            {
                float InternalVar_4 = InternalVar_3.InternalProperty_144[UIBlock.InternalMethod_79().Axis.Index()].InternalField_153;

                if (InternalField_101.InternalField_553 == 0)
                {
                    InternalField_101 = new InternalType_190(InternalVar_4, 0.1f);
                }
                else
                {
                    InternalField_101.InternalMethod_957(InternalVar_4);
                }
            }

            return InternalVar_3;
        }

        bool InternalType_1.InternalMethod_881(int InternalParameter_752, out InternalType_5 InternalParameter_767) => InternalMethod_919(InternalParameter_752, out InternalParameter_767);


        private protected virtual bool InternalMethod_919(int InternalParameter_855, out InternalType_5 InternalParameter_2352)
        {
            InternalParameter_2352 = null;
            if (!TryGetItemView(InternalParameter_855, out ItemView InternalVar_1))
            {
                return false;
            }

            InternalParameter_2352 = InternalVar_1.UIBlock;

            return true;
        }

        private protected virtual void InternalMethod_2060(bool InternalParameter_2701)
        {
            if (InternalParameter_2701)
            {
                InternalMethod_230();
            }
            else
            {
                InternalMethod_231();
            }
        }

        private protected virtual InternalType_66 InternalMethod_1858(bool InternalParameter_2057)
        {
            return InternalParameter_2057 ? InternalMethod_228(InternalParameter_174: true) : InternalMethod_229(InternalParameter_175: true);
        }

        private protected InternalType_66 InternalMethod_228(bool InternalParameter_174)
        {
            InternalField_98--;

            if (!InternalMethod_2059(InternalField_98, out ItemView InternalVar_1))
            {
                InternalField_98++;

                return null;
            }

            InternalVar_1.UIBlock.InternalMethod_105();

            if (InternalParameter_174)
            {
                InternalVar_1.UIBlock.CalculateLayout();
            }

            return InternalVar_1.UIBlock;
        }

        private protected InternalType_66 InternalMethod_229(bool InternalParameter_175)
        {
            InternalField_99++;
            if (!InternalMethod_2059(InternalField_99, out ItemView InternalVar_1))
            {
                InternalField_99--;
                return null;
            }

            InternalVar_1.UIBlock.InternalMethod_106();

            if (InternalParameter_175)
            {
                InternalVar_1.UIBlock.CalculateLayout();
            }

            return InternalVar_1.UIBlock;
        }

        private protected void InternalMethod_230()
        {
            InternalMethod_233(InternalField_98);
            InternalField_98 = Mathf.Min(InternalProperty_55.InternalProperty_430 - 1, InternalField_98 + 1);
        }

        private protected void InternalMethod_231()
        {
            InternalMethod_233(InternalField_99);
            InternalField_99 = Mathf.Max(-1, InternalField_99 - 1);
        }

        private bool InternalMethod_2059(int InternalParameter_2700, out ItemView InternalParameter_2699)
        {
            if (InternalParameter_2700 < 0 || InternalParameter_2700 >= InternalProperty_55.InternalProperty_430)
            {
                throw new IndexOutOfRangeException($"Index out of range. Expected [0, {InternalProperty_55.InternalProperty_430}) but received {InternalParameter_2700}.");
            }

            Type InternalVar_1 = InternalProperty_55.InternalMethod_2036(InternalParameter_2700);
            InternalType_736 InternalVar_3 = InternalField_102.InternalMethod_3350(InternalParameter_2700, InternalVar_1, out InternalParameter_2699, out Type InternalVar_2);

            if (InternalParameter_2699 == null)
            {
                if (InternalVar_3 == InternalType_736.InternalField_3364)
                {
                    string InternalVar_4 = $"Unable to find a corresponding prefab type for data object of type {InternalVar_1.Name}.";
                    string InternalVar_5 = InternalField_570 ? $" Make sure any desired databind handlers are registered before calling {nameof(SetDataSource)}." : string.Empty;
                    Debug.LogError($"{InternalVar_4}{InternalVar_5}", this);
                }

                return false;
            }

            if (InternalParameter_2699.transform.parent != UIBlock.transform)
            {
                InternalParameter_2699.transform.SetParent(UIBlock.transform, false);
            }

            InternalField_105.Remove(InternalParameter_2700);
            InternalField_2335[InternalParameter_2700] = (InternalParameter_2699, InternalVar_2, InternalParameter_2699.UIBlock.InternalProperty_29);

            InternalType_515<int>.InternalMethod_2032(InternalVar_2).InternalMethod_2042(InternalParameter_2699, InternalProperty_55, InternalParameter_2700);

            InternalField_100.InternalMethod_59(InternalParameter_2699.UIBlock.InternalProperty_29);


            return true;
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2334 = false;
        private void InternalMethod_233(int InternalParameter_177, bool InternalParameter_178 = false)
        {
            bool InternalVar_3 = InternalMethod_2061(InternalParameter_177, out InternalType_131 InternalVar_1, out ItemView InternalVar_2);

            if (!InternalVar_3 && !InternalVar_1.InternalProperty_192)
            {
                if (!InternalField_105.Remove(InternalParameter_177))
                {
                    Debug.LogError($"Not tracking list item for index {InternalParameter_177}. Current range [{MinLoadedIndex}, {MaxLoadedIndex}]. Use ListView.{nameof(TryDetach)}() to manually remove an item from the List View.");
                }

                return;
            }

            Type InternalVar_4 = null;
            if (InternalField_2335.TryGetValue(InternalParameter_177, out var InternalVar_5))
            {
                InternalVar_4 = InternalVar_5.UserDataType;
                InternalField_2335.Remove(InternalParameter_177);
            }

            InternalField_100.InternalMethod_2315(InternalVar_1);

            if (InternalVar_3)
            {
                Type InternalVar_6 = InternalParameter_177 < DataSourceItemCount ? InternalField_102.InternalMethod_2018(InternalVar_2, InternalProperty_55.InternalMethod_2036(InternalParameter_177)) : InternalVar_4;
                InternalType_515<int>.InternalMethod_2032(InternalVar_6).InternalMethod_2041(InternalVar_2, InternalProperty_55, InternalParameter_177);
                InternalField_102.InternalMethod_2026(InternalVar_2, InternalParameter_177);
            }
            else
            {
                InternalField_102.InternalMethod_2025(InternalVar_1);

                if (!InternalField_2334 && InternalNamespace_0.InternalType_24.InternalProperty_945.InternalMethod_554(InternalNamespace_0.InternalType_116.InternalField_2333))
                {
                    InternalField_2334 = true;
                    Debug.LogWarning($"ListView item was destroyed without being detached first. This is unsupported and may cause issues. {InternalType_178.InternalField_484}", this);
                }
            }


            if (InternalParameter_178)
            {
                InternalField_102.InternalMethod_2022();
            }
        }

        bool InternalType_1.InternalMethod_45(float InternalParameter_39)
        {
            if (InternalProperty_55 == null || InternalProperty_55.InternalProperty_431)
            {
                return false;
            }

            bool InternalVar_1 = UIBlock.InternalMethod_79().InternalProperty_13 == InternalParameter_39;
            return InternalVar_1 ? InternalField_99 < InternalProperty_55.InternalProperty_430 - 1 : InternalField_98 > 0;
        }

        private void InternalMethod_234()
        {
            if (this == null)
            {
                return;
            }

            InternalMethod_219(InternalParameter_164: true);

            NovaApplication.EditorBeforeAssemblyReload -= InternalMethod_234;
        }

        void InternalType_4.InternalMethod_119()
        {
            if (!NovaApplication.InPlayer(this))
            {
                return;
            }

            if (NovaApplication.IsEditor)
            {
                NovaApplication.EditorBeforeAssemblyReload -= InternalMethod_234;
                NovaApplication.EditorBeforeAssemblyReload += InternalMethod_234;
            }

            InternalField_100.InternalMethod_60(InternalProperty_56, UIBlock, UIBlock.InternalProperty_29);

            InternalMethod_239();

            InternalMethod_235();
        }

        void InternalType_4.InternalMethod_120()
        {
            if (!NovaApplication.InPlayer(this))
            {
                return;
            }

            InternalField_100.Dispose();

            InternalMethod_236();
        }

        private protected virtual void InternalMethod_235() { }
        private protected virtual void InternalMethod_236() { }
        private protected virtual void InternalMethod_237() { }

        internal int InternalMethod_238(int InternalParameter_179) => InternalField_98 + InternalParameter_179;
        private protected virtual void OnDestroy()
        {
            if (InternalField_106 != null)
            {
                InternalField_106.InternalMethod_304(this);
            }

            InternalMethod_220();
        }

        private void Awake()
        {
            InternalMethod_239();
        }

        private void InternalMethod_239()
        {
            if (InternalField_107)
            {
                return;
            }

            if (TryGetComponent(out InternalField_106))
            {
                InternalField_106.InternalMethod_303(this);
            }

            InternalMethod_237();

            InternalField_107 = true;
        }

        private void InternalMethod_2678<TEvent, TVisuals>(UIEventHandler<TEvent, TVisuals, int> InternalParameter_2241) where TEvent : struct, IEvent where TVisuals : ItemVisuals
        {
            if (InternalParameter_2241 == null)
            {
                return;
            }

            if (InternalField_103.TryGetValue(InternalParameter_2241, out var InternalVar_1))
            {
                Debug.LogError($"Provided event handler is already registered with the {GetType().Name}, {name}.", this);
                return;
            }

            UIEventHandler<TEvent, TVisuals> InternalVar_2 = (evt, target) => InternalMethod_2685(this, evt, target, InternalParameter_2241);

            InternalField_103[InternalParameter_2241] = InternalVar_2;

            UIBlock.InternalMethod_3270(InternalVar_2);
        }

        private void InternalMethod_2677<TEvent, TVisuals>(UIEventHandler<TEvent, TVisuals, int> InternalParameter_2240) where TEvent : struct, IEvent where TVisuals : ItemVisuals
        {
            if (InternalParameter_2240 == null)
            {
                return;
            }

            if (!InternalField_103.TryGetValue(InternalParameter_2240, out var InternalVar_1))
            {
                return;
            }

            InternalField_103.Remove(InternalParameter_2240);

            if (!(InternalVar_1 is UIEventHandler<TEvent, TVisuals> typedHandler))
            {
                Debug.Log($"Event handler type mismatch. Provided handler is of type {InternalParameter_2240.GetType()}, but the caller specified the handler would be of type {typeof(UIEventHandler<TEvent, TVisuals, int>)}.");
                return;
            }

            UIBlock.InternalMethod_3269(typedHandler);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize() => InternalMethod_2409();

        private protected void InternalMethod_2409()
        {
            if (!NovaApplication.IsPlaying && _uiBlock != null)
            {
                _uiBlock = null;
            }
        }

        /// <summary>
        /// Prevent users from inheriting
        /// </summary>
        internal ListView() { }
        #endregion
    }
}
