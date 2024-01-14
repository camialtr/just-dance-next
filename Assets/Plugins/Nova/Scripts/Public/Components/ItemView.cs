// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_16;
using System;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// An abstract base class to be inherited by all user-defined, data-bindable <see cref="ItemView"/>.<see cref="ItemView.Visuals">Visuals</see> types.
    /// </summary>
    /// <remarks>All classes which inherit from <see cref="ItemVisuals"/> can be targeted by the UIBlock event system.</remarks>
    /// <seealso cref="ItemView"/>
    /// <seealso cref="ListView"/>
    /// <seealso cref="GridView"/>
    /// <seealso cref="UIBlockExtensions.AddGestureHandler{TInteractionEvent, TTarget}(UIBlock, UIEventHandler{TInteractionEvent, TTarget}))"/>
    /// <seealso cref="UIBlockExtensions.RemoveGestureHandler{TInteractionEvent, TTarget}(UIBlock, UIEventHandler{TInteractionEvent, TTarget})"/>
    /// <seealso cref="ListView.AddDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
    /// <seealso cref="ListView.RemoveDataBinder{TData, TVisuals}(UIEventHandler{Data.OnBind{TData}, TVisuals, int})"/>
    /// <seealso cref="ListView.AddGestureHandler{TEvent, TVisuals}(UIEventHandler{TEvent, TVisuals, int})"/>
    /// <seealso cref="ListView.RemoveGestureHandler{TEvent, TVisuals}(UIEventHandler{TEvent, TVisuals, int})"/>
    [Serializable]
    public abstract class ItemVisuals : InternalType_273
    {
        /// <summary>
        /// The containing <see cref="ItemView"/>.
        /// </summary>
        [NonSerialized, HideInInspector]
        public ItemView View = null;
    }

    /// <summary>
    /// A callback to provide a list item prefab to the requesting <see cref="ListView"/> or <see cref="GridView"/> which will represent the object in the data source at the given index.
    /// </summary>
    /// <typeparam name="T">The index type of the underlying data source</typeparam>
    /// <param name="index">The index into the underlying data source of the object the provided prefab will represent</param>
    /// <param name="sourcePrefab">The source prefab (<i>not</i> an instance) for the <see cref="ListView"/> to clone or pull from the list item prefab pool</param>
    /// <returns>
    /// <see langword="true"/> if the caller wishes to use an instance of the provided source prefab<br/>
    /// <see langword="false"/> if the caller wishes to have the <see cref="ListView"/> attempt to use a fallback prefab option
    /// </returns>
    public delegate bool PrefabProviderCallback<T>(T index, out ItemView sourcePrefab);

    /// <summary>
    /// A UI Component which supports dynamic serialization of user-defined sets of visual fields (e.g. <see cref="Nova.UIBlock"/>s, any other <see cref="MonoBehaviour"/>s, etc.).
    /// The <see cref="ItemView"/> acts as a "middle man" when binding user-provided data types to a <see cref="ListView"/> or <see cref="GridView"/>
    /// </summary>
    [RequireComponent(typeof(UIBlock)), DisallowMultipleComponent]
    [HelpURL("https://novaui.io/manual/ItemView.html")]
    [AddComponentMenu("Nova/Item View")]
    public sealed class ItemView : MonoBehaviour, InternalType_523, InternalType_4
    {
        #region Public
        /// <summary>
        /// The set of visual fields configured in the Editor.
        /// </summary>
        public ItemVisuals Visuals
        {
            get
            {
                if (visuals != null)
                {
                    visuals.View = this;
                }

                return visuals;
            }
        }

        /// <summary>
        /// The <see cref="Nova.UIBlock"/> attached to <c>this.gameObject</c>.
        /// </summary>
        public UIBlock UIBlock
        {
            get
            {
                if (InternalField_73 == null)
                {
                    TryGetComponent(out InternalField_73);
                }

                return InternalField_73;
            }
        }

        /// <summary>
        /// Retrieve <see cref="Visuals"/> as type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to cast, must inherit from <see cref="ItemVisuals"/>.</typeparam>
        /// <param name="visuals"><see cref="Visuals"/> casted to type <typeparamref name="T"/>, if it can be casted.</param>
        /// <returns><see langword="false"/> if <see cref="Visuals"/> is not of type <typeparamref name="T"/>.</returns>
        public bool TryGetVisuals<T>(out T visuals) where T : ItemVisuals
        {
            visuals = Visuals as T;
            return visuals != null;
        }
        #endregion

        #region Internal
        [SerializeReference, SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private ItemVisuals visuals = default;

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlockActivator InternalField_71 = null;

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_72 = false;

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_73 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal Type InternalProperty_948 => InternalProperty_947 ? Visuals.GetType() : null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal bool InternalProperty_947 => Visuals != null;

        internal void InternalMethod_163<TData>(TData InternalParameter_105)
        {
            if (!InternalProperty_947)
            {
                return;
            }

            UIBlock.InternalMethod_91(Data.InternalMethod_159(this, InternalParameter_105), InternalProperty_948);
        }

        internal void InternalMethod_164<TData>(TData InternalParameter_106)
        {
            if (!InternalProperty_947)
            {
                return;
            }

            UIBlock.InternalMethod_91(Data.InternalMethod_160(this, InternalParameter_106), InternalProperty_948);
        }

        bool InternalType_523.InternalMethod_1635(InternalType_273 receiver, Type _, out InternalType_273 target)
        {
            target = Visuals;
            return true;
        }

        void InternalType_4.InternalMethod_119()
        {
            InternalMethod_165();
        }

        void InternalType_4.InternalMethod_120() { }

        private void Awake()
        {
            InternalMethod_165();
        }

        private void OnDestroy()
        {
            if (InternalField_71 != null)
            {
                InternalField_71.InternalMethod_304(this);
            }

            UIBlock.InternalMethod_90(this);
        }

        private void InternalMethod_165()
        {
            if (!NovaApplication.InPlayer(this))
            {
                return;
            }

            if (InternalField_72)
            {
                return;
            }

            if (TryGetComponent(out InternalField_71))
            {
                InternalField_71.InternalMethod_303(this);
            }

            UIBlock.InternalMethod_89(this);
            InternalField_72 = true;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Type InternalType_523.InternalProperty_439 => typeof(ItemVisuals);

        #endregion
    }
}
