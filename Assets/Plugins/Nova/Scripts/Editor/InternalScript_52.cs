// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22.InternalNamespace_23;
using System;
using System.Collections.Generic;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal abstract class InternalType_539<T86> : InternalType_540
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected List<T86> InternalField_2385 = null;

        protected virtual void OnEnable()
        {
            InternalField_2385 = serializedObject.targetObjects.InternalMethod_3256<T86>();
        }

        protected virtual void InternalMethod_2167()
        {
            serializedObject.Update();
        }

#if !NOVA_DEBUG
        [System.Reflection.Obfuscation]
        protected override bool ShouldHideOpenButton() => true;
#endif

    }

    internal abstract class InternalType_540 : UnityEditor.Editor
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2386 = "m_Script";

        public void InternalMethod_2168(params string[] InternalParameter_2482)
        {
            string[] InternalVar_1 = new string[InternalParameter_2482.Length + 1];
            Array.Copy(InternalParameter_2482, InternalVar_1, InternalParameter_2482.Length);

            InternalVar_1[InternalVar_1.Length - 1] = InternalField_2386;

            InternalMethod_2170(InternalVar_1);
        }

        public void InternalMethod_2169()
        {
            InternalMethod_2170(InternalField_2386);
        }

        public void InternalMethod_2170(params string[] InternalParameter_2483)
        {
            serializedObject.UpdateIfRequiredOrScript();

            UnityEditor.EditorGUI.BeginChangeCheck();
            DrawPropertiesExcluding(serializedObject, InternalParameter_2483);
            if (UnityEditor.EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

