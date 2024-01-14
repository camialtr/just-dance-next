// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// An abstract base class for custom components to synchronize a set of properties based on their transform hierarchy
    /// </summary>
    [ExecuteAlways, DisallowMultipleComponent, RequireComponent(typeof(UIBlockActivator))]
    public abstract class CoreBlock : MonoBehaviour, InternalType_146, ISerializationCallbackReceiver
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_145.InternalProperty_207 => InternalProperty_26 == null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_145.InternalProperty_208 => InternalProperty_28;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        int InternalType_145.InternalProperty_209 => transform.GetSiblingIndex();

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_38 = false;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_39 = true;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_146.InternalProperty_213 { get => InternalField_38; set => InternalField_38 = value; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_146.InternalProperty_212 { get => InternalField_39; set => InternalField_39 = value; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_145 InternalType_145.InternalProperty_211 => InternalType_253.InternalProperty_190.InternalMethod_1157(InternalProperty_29);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_145 InternalType_145.InternalProperty_210 => InternalProperty_27.InternalProperty_210;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal bool InternalProperty_25 => InternalField_48;


        [NonSerialized, HideInInspector]
[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private CoreBlock InternalField_40 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private CoreBlock InternalProperty_26
        {
            get
            {
                return InternalField_40;
            }
            set
            {
                if (!InternalProperty_27.InternalProperty_151 || value == InternalField_40)
                {
                    return;
                }

                if (InternalField_40 != null && InternalField_40.InternalProperty_27.InternalProperty_197 && value == null)
                {
                    bool InternalVar_1 = InternalField_40.InternalProperty_27.InternalProperty_213;

                    InternalProperty_27.InternalMethod_561();

                    if (InternalProperty_31 && !InternalVar_1)
                    {
                        InternalField_40.InternalProperty_27.InternalProperty_213 = false;
                    }
                }

                InternalField_40 = value;

                if (InternalField_40 != null)
                {
                    bool InternalVar_1 = InternalField_40.InternalProperty_27.InternalProperty_213;

                    InternalProperty_27.InternalMethod_562();

                    if (InternalField_46 && !InternalVar_1)
                    {
                        InternalField_40.InternalProperty_27.InternalProperty_213 = false;
                    }
                }

                InternalMethod_115();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_146 InternalType_146.InternalProperty_210
        {
            get
            {
                return InternalProperty_26;
            }
            set
            {
                InternalProperty_26 = value as CoreBlock;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_146 InternalProperty_27
        {
            get
            {
                InternalMethod_110();
                return this;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected abstract bool InternalProperty_28 { get; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_68.InternalProperty_151 => InternalField_48;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_68.InternalProperty_152 => gameObject.activeInHierarchy;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_68.InternalProperty_153 => gameObject.activeSelf;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_68.InternalProperty_154 => InternalProperty_31;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Transform InternalType_141.InternalProperty_202 => transform;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_141.InternalProperty_203 => false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_141.InternalProperty_204 => NovaApplication.IsEditor ? transform.childCount > 0 || transform.parent != null : true;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_131 InternalField_41 = InternalType_131.InternalField_415;
        [SerializeField, HideInInspector, InternalType_22]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_131 sourceID = InternalType_131.InternalField_415;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_131 InternalType_134.InternalProperty_195 => InternalProperty_29;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_131 InternalProperty_29
        {
            get
            {
                if (!InternalField_41.InternalProperty_192)
                {
                    InternalField_41 = InternalType_131.InternalMethod_630();
                }

                return InternalField_41;
            }
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_133 InternalField_42 = InternalType_133.InternalField_418;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_133 InternalType_134.InternalProperty_196 => InternalField_42;
        void InternalType_134.InternalMethod_642(InternalType_133 InternalParameter_525) => InternalField_42 = InternalParameter_525;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        bool InternalType_134.InternalProperty_197
        {
            get
            {
                return InternalField_42.InternalProperty_194;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        string InternalType_135.InternalProperty_198 => name;


        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal int InternalProperty_84 => InternalType_253.InternalProperty_190.InternalMethod_3745(InternalProperty_29);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected bool InternalProperty_31 => InternalField_47;

        private protected abstract void InternalMethod_102();
        internal void InternalMethod_103() => OnTransformParentChanged();
        internal void InternalMethod_104() => OnTransformChildrenChanged();

        private void OnTransformParentChanged()
        {
            if (!InternalProperty_25)
            {
                return;
            }

            if (transform.parent != null &&
                transform.parent.TryGetComponent(out CoreBlock InternalVar_1) &&
                InternalVar_1.InternalMethod_556())
            {
                InternalProperty_26 = InternalVar_1;
            }
            else
            {
                InternalProperty_26 = null;
            }

            if (NovaApplication.IsEditor)
            {
                InternalMethod_102();
            }
        }

        private void OnTransformChildrenChanged()
        {
            if (!InternalProperty_25)
            {
                return;
            }

            InternalProperty_27.InternalMethod_560();

            if (NovaApplication.IsEditor)
            {
                InternalMethod_102();
            }
        }

        internal void InternalMethod_105()
        {
            InternalProperty_27.InternalMethod_558();
            transform.SetAsFirstSibling();
        }

        internal void InternalMethod_106()
        {
            Transform InternalVar_1 = transform.parent;
            InternalProperty_27.InternalMethod_559(InternalVar_1 == null ? 0 : InternalVar_1.childCount - 1);
            transform.SetAsLastSibling();
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_131> InternalField_43 = new List<InternalType_131>(0);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        List<InternalType_131> InternalType_146.InternalProperty_214 => InternalField_43;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_146> InternalField_44 = new List<InternalType_146>(0);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        List<InternalType_146> InternalType_146.InternalProperty_215 => InternalField_44;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_521<InternalType_131> InternalProperty_32
        {
            get
            {
                return InternalField_43.InternalMethod_2043();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal InternalType_521<InternalType_146> InternalProperty_33
        {
            get
            {
                return InternalField_44.InternalMethod_2043();
            }
        }

        internal InternalType_146 InternalMethod_109(int InternalParameter_76)
        {
            InternalType_521<InternalType_146> InternalVar_1 = InternalProperty_33;

            if (InternalParameter_76 < 0 || InternalParameter_76 >= InternalVar_1.InternalProperty_433)
            {
                throw new ArgumentOutOfRangeException("index", $"Expected: [0, {InternalVar_1.InternalProperty_433}) Received: {InternalParameter_76}");
            }

            return InternalVar_1[InternalParameter_76];
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected bool InternalField_45 = false;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_46 = false;
        private protected void InternalMethod_110()
        {
            if (InternalField_46 || InternalField_45)
            {
                return;
            }

            if (!InternalField_48)
            {
                return;
            }

            InternalField_46 = true;

            if (InternalField_3315 == null && TryGetComponent(out InternalField_3315))
            {
                InternalField_3315.InternalMethod_303(this);
            }

            if (NovaApplication.IsEditor)
            {
                if (NovaApplication.InPlayer(this))
                {
                    sourceID = InternalProperty_29;
                }
            }
            else
            {
                sourceID = InternalProperty_29;
            }

            InternalField_39 = true;
            InternalField_38 = false;

            OnTransformParentChanged();

            InternalProperty_27.InternalMethod_564();

            InternalField_45 = true;
            InternalField_46 = false;
        }

        void InternalType_134.InternalMethod_644() => InternalMethod_111();
        void InternalType_134.InternalMethod_645() => InternalMethod_112();
        private protected abstract void InternalMethod_111();
        private protected abstract void InternalMethod_112();
        internal abstract void InternalMethod_113();
        internal abstract void InternalMethod_114(InternalType_131 InternalParameter_77);
        private protected abstract void InternalMethod_115();

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_47 = false;
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_48 = false;
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlockActivator InternalField_3315 = null;

        internal void InternalMethod_116()
        {
            InternalProperty_27.InternalMethod_557();
        }

        private void Awake()
        {
            if (TryGetComponent(out InternalField_3315))
            {
                InternalField_3315.InternalMethod_303(this);
            }
        }

        private protected virtual void OnDestroy()
        {
            ((InternalType_4)this).InternalMethod_120();

            if (InternalField_3315 != null)
            {
                InternalField_3315.InternalMethod_304(this);
            }
        }

        private protected abstract void InternalMethod_117();
        private protected abstract void InternalMethod_118();

        void InternalType_4.InternalMethod_119()
        {
            if (InternalField_48)
            {
                return;
            }

            InternalField_48 = true;

            InternalMethod_110();

            InternalMethod_117();
        }

        void InternalType_4.InternalMethod_120()
        {
            if (!InternalField_48)
            {
                return;
            }

            InternalField_47 = true;

            InternalMethod_113();
            sourceID = InternalType_131.InternalField_415;

            InternalMethod_118();

            InternalProperty_27.InternalMethod_563();

            InternalField_47 = false;
            InternalField_48 = false;
            InternalField_45 = false;
            InternalField_46 = false;
        }

        /// <summary>
        /// Prevent users from inheriting
        /// </summary>
        internal CoreBlock() { }

        #region 
        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            if (!NovaApplication.IsPlaying)
            {
                if (sourceID.InternalProperty_192)
                {
                    sourceID = InternalType_131.InternalField_415;
                }
                return;
            }

            if (sourceID.InternalProperty_192 && sourceID != InternalProperty_29)
            {
                InternalMethod_114(sourceID);

                sourceID = InternalType_131.InternalField_415;
            }
        }
        #endregion
    }
}
