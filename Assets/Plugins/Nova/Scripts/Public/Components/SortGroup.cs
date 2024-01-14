// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System;
using System.Reflection;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Configures the rendered sorting order of a <see cref="Nova.UIBlock"/> hierarchy.
    /// </summary>
    /// <seealso cref="UIBlock2D.ZIndex"/>
    /// <seealso cref="TextBlock.ZIndex"/>
    [DisallowMultipleComponent]
    [ExecuteAlways]
    [AddComponentMenu("Nova/Sort Group")]
    [RequireComponent(typeof(UIBlock))]
    [HelpURL("https://novaui.io/manual/RenderOrder.html")]
    public sealed class SortGroup : MonoBehaviour
    {
        #region Public
        /// <summary>
        /// The sorting order of this <see cref="UIBlock"/> hierarchy. Hierarchies with a higher sorting order render on top of those with a lower sorting order.
        /// </summary>
        /// <remarks>
        /// The default value for hierarchies <i>without</i> a <see cref="SortGroup"/> component is <c>0</c>.
        /// </remarks>
        /// <seealso cref="UIBlock2D.ZIndex"/>
        /// <seealso cref="TextBlock.ZIndex"/>
        /// <seealso cref="RenderQueue"/>
        public int SortingOrder
        {
            get => info.SortingOrder;
            set
            {
                if (info.SortingOrder == value)
                {
                    return;
                }
                info.SortingOrder = value;
                InternalMethod_301();
            }
        }

        /// <summary>
        /// The render queue value to set on all (transparent) materials used to render this <see cref="UIBlock"/> hierarchy.
        /// </summary>
        /// <remarks>
        /// The default value for hierarchies <i>without</i> a <see cref="SortGroup"/> component is <c>3000</c>.
        /// </remarks>
        /// <seealso cref="UIBlock2D.ZIndex"/>
        /// <seealso cref="TextBlock.ZIndex"/>
        /// <seealso cref="SortingOrder"/>
        public int RenderQueue
        {
            get => info.RenderQueue;
            set
            {
                value = Mathf.Clamp(value, 0, InternalType_178.InternalField_474);
                if (info.RenderQueue == value)
                {
                    return;
                }

                info.RenderQueue = value;
                InternalMethod_301();
            }
        }

        /// <summary>
        /// Whether or not the content in the sort group should render over geometry rendered in the 
        /// opaque render queue. This is useful for rendering in screen space.
        /// </summary>
        public bool RenderOverOpaqueGeometry
        {
            get => info.RenderOverOpaqueGeometry;
            set
            {
                if (info.RenderOverOpaqueGeometry == value)
                {
                    return;
                }

                info.RenderOverOpaqueGeometry = value;
                InternalMethod_301();
            }
        }
        
        /// <summary>
        /// The <see cref="Nova.UIBlock"/> on <c>this.gameObject</c>.
        /// </summary>
        public UIBlock UIBlock
        {
            get
            {
                if (InternalField_3036 == null)
                {
                    InternalField_3036 = GetComponent<UIBlock>();
                }

                return InternalField_3036;
            }
        }
        #endregion

        #region Internal
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3036 = null;
        [SerializeField]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_40 info = InternalType_40.InternalField_137;

        internal void InternalMethod_301()
        {
            if (!UIBlock.InternalProperty_25 || !enabled)
            {
                return;
            }

            InternalType_274.InternalProperty_190.InternalMethod_1262(UIBlock.InternalProperty_29, UnsafeUtility.As<InternalType_40, InternalNamespace_0.InternalType_101>(ref info));
        }

        private void InternalMethod_302(InternalType_131 InternalParameter_217)
        {
            if (InternalType_274.InternalProperty_190 == null)
            {
                return;
            }

            InternalType_274.InternalProperty_190.InternalMethod_1261(InternalParameter_217);
        }

        private void OnEnable()
        {
            UIBlock.InternalMethod_116();

            InternalMethod_301();
        }

        private void OnDisable()
        {
            InternalMethod_302(UIBlock.InternalProperty_29);
            
            if (NovaApplication.IsEditor)
            {
                InternalType_131 InternalVar_1 = UIBlock.InternalProperty_29;
                NovaApplication.EditorDelayCall += () =>
                {
                    if (this == null)
                    {
                        InternalMethod_302(InternalVar_1);
                    }
                };
            }
        }

        
        [Obfuscation]
        private void OnDidApplyAnimationProperties()
        {
            InternalMethod_301();
        }
        #endregion
    }
}

