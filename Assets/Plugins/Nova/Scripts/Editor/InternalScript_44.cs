// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System;
using Unity.Collections.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(SortGroup))]
    [CanEditMultipleObjects]
    internal class InternalType_546 : InternalType_539<SortGroup>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_633 InternalField_2424 = new InternalType_633();

        protected override void OnEnable()
        {
            base.OnEnable();
            InternalField_2424.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_673.InternalField_3040);

            Undo.undoRedoPerformed += InternalMethod_2182;
        }

        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_2182;
        }

        private void InternalMethod_2182()
        {
            InternalMethod_2183();
        }

        
        private bool InternalMethod_1326(SortGroup InternalParameter_1754, out InternalType_40 InternalParameter_1751)
        {
            InternalParameter_1751 = default;
            if (InternalType_268.InternalField_406 == null)
            {
                return false;
            }

            InternalType_131 InternalVar_1 = InternalParameter_1754.UIBlock.InternalProperty_29;
            if (!InternalVar_1.InternalProperty_192)
            {
                return false;
            }

            if (!InternalType_268.InternalField_406.InternalField_3378.TryGetValue(InternalVar_1, out InternalType_408 InternalVar_2) ||
                InternalVar_2.InternalField_1555 == InternalVar_1 ||
                !InternalType_274.InternalProperty_190.InternalField_869.InternalField_3381.TryGetValue(InternalVar_2.InternalField_1555, out _))
            {
                return false;
            }

            if (InternalType_274.InternalProperty_190.InternalField_869.InternalField_1188.TryGetValue(InternalVar_2.InternalField_1555, out InternalNamespace_0.InternalType_101 InternalVar_3))
            {
                InternalParameter_1751 = UnsafeUtility.As<InternalNamespace_0.InternalType_101, InternalType_40>(ref InternalVar_3);
            }
            else
            {
                InternalParameter_1751 = new InternalType_40()
                {
                    SortingOrder = 0,
                    RenderQueue = InternalType_776.InternalField_3710,
                    RenderOverOpaqueGeometry = true,
                };
            }

            return true;
        }

        private bool InternalMethod_3001(out InternalType_40 InternalParameter_1750)
        {
            InternalParameter_1750 = default;
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                if (InternalMethod_1326(InternalField_2385[InternalVar_1], out InternalParameter_1750))
                {
                    return true;
                }
            }

            return false;
        }

        public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();
            InternalType_573.InternalMethod_2238(InternalType_554.InternalType_565.InternalField_2512, InternalField_2424.InternalProperty_783, Int16.MinValue, Int16.MaxValue);

            bool InternalVar_2 = InternalMethod_3001(out InternalType_40 InternalVar_1);
            if (InternalVar_2)
            {
                EditorGUI.BeginDisabledGroup(true);

                Rect InternalVar_3 = InternalType_573.InternalType_575.InternalMethod_2302(InternalType_573.InternalType_575.InternalProperty_501);
                GUIContent InternalVar_4 = EditorGUI.BeginProperty(InternalVar_3, InternalType_554.InternalType_565.InternalField_1429, InternalField_2424.InternalProperty_785);
                EditorGUI.IntField(InternalVar_3, InternalVar_4, InternalVar_1.RenderQueue);
                EditorGUI.EndProperty();

                Rect InternalVar_5 = InternalType_573.InternalType_575.InternalMethod_2302();
                GUIContent InternalVar_6 = EditorGUI.BeginProperty(InternalVar_5, InternalType_554.InternalType_565.InternalField_1428, InternalField_2424.InternalProperty_251);
                EditorGUI.Toggle(InternalVar_5, InternalVar_6, InternalVar_1.RenderOverOpaqueGeometry);

                EditorGUI.EndDisabledGroup();
            }
            else
            {
                InternalType_573.InternalMethod_2238(InternalType_554.InternalType_565.InternalField_2513, InternalField_2424.InternalProperty_785, 0, 5000);
                InternalType_573.InternalMethod_2235(InternalType_554.InternalType_565.InternalField_207, InternalField_2424.InternalProperty_251);
            }

            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2183();
            }
        }

        private void InternalMethod_2183()
        {
            serializedObject.ApplyModifiedProperties();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                InternalField_2385[InternalVar_1].InternalMethod_301();
            }
        }
    }
}

