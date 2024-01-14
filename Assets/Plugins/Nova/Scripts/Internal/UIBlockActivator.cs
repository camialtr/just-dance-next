// Copyright (c) Supernova Technologies LLC

using Nova.Compat;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Nova
{
    
    [ExecuteAlways]
    [ExcludeFromPreset]
    [ExcludeFromObjectFactory]
    [DisallowMultipleComponent]
    [HideInInspector]
    [Obfuscation(ApplyToMembers = false)]
    [AddComponentMenu("")]
    internal class UIBlockActivator : MonoBehaviour
    {
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_4> InternalField_129 = new List<InternalType_4>();

        public void InternalMethod_303<T>(T InternalParameter_218) where T : MonoBehaviour, InternalType_4
        {
            if (!InternalField_129.Contains(InternalParameter_218))
            {
                InternalField_129.Add(InternalParameter_218);

                if (isActiveAndEnabled)
                {

                    InternalParameter_218.InternalMethod_119();
                }
            }
        }

        public void InternalMethod_304(InternalType_4 InternalParameter_219)
        {
            if (InternalField_129.Remove(InternalParameter_219))
            {
                if (isActiveAndEnabled)
                {

                    InternalParameter_219.InternalMethod_120();
                }

                if (InternalField_129.Count == 0)
                {
                    InternalMethod_306();
                }
            }
        }

        private void InternalMethod_305()
        {
            InternalType_4[] InternalVar_1 = GetComponents<InternalType_4>();

            InternalField_129.Clear();

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Length; ++InternalVar_2)
            {
                var InternalVar_3 = InternalVar_1[InternalVar_2];

                if (InternalVar_3 as MonoBehaviour != null)
                {
                    InternalField_129.Add(InternalVar_3);
                }
            }
        }

        protected void InternalMethod_306()
        {
            if (Application.isPlaying)
            {
                Destroy(this);
            }
            else if (NovaApplication.IsEditor)
            {
                GameObject InternalVar_1 = gameObject;

                NovaApplication.EditorDelayCall += () =>
                {
                    if (InternalVar_1 != null)
                    {
                        DestroyImmediate(this);
                    }
                };
            }
        }

        private void OnEnable()
        {
            if (NovaApplication.IsEditor)
            {
                OnValidate();
            }

            int InternalVar_1 = InternalField_129.Count;

            if (InternalVar_1 == 0)
            {
                InternalMethod_305();
                InternalVar_1 = InternalField_129.Count;
            }

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1; ++InternalVar_2)
            {
                InternalType_4 InternalVar_3 = InternalField_129[InternalVar_2];
                if (InternalVar_3 as MonoBehaviour != null)
                {
                    InternalVar_3.InternalMethod_119();
                }
            }
        }

        private void OnDisable()
        {
            int InternalVar_1 = InternalField_129.Count;

            for (int InternalVar_2 = InternalVar_1 - 1; InternalVar_2 >= 0; --InternalVar_2)
            {
                InternalType_4 InternalVar_3 = InternalField_129[InternalVar_2];
                if (InternalVar_3 as MonoBehaviour != null)
                {
                    InternalVar_3.InternalMethod_120();
                }
            }
        }

        
        private void OnValidate()
        {
            if (!NovaApplication.IsEditor)
            {
                return;
            }

            if ((hideFlags & HideFlags.NotEditable) == 0)
            {
                hideFlags |= HideFlags.NotEditable;
            }

            if ((hideFlags & HideFlags.HideInInspector) == 0)
            {
                hideFlags |= HideFlags.HideInInspector;
            }
        }
    }
}
