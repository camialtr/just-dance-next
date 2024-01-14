// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(ImageAdjustment))]
    internal class InternalType_585 : InternalType_583<InternalType_609>
    {
        protected override float InternalMethod_2353(GUIContent InternalParameter_2767)
        {
            if (InternalField_2606)
            {
                if (InternalField_2604.InternalProperty_655 == ImageScaleMode.Manual)
                {
                    return 4f * InternalType_720.InternalField_3298;
                }
                else
                {
                    return 2f * InternalType_720.InternalField_3298;
                }
            }
            else
            {
                return EditorGUI.GetPropertyHeight(InternalField_2604.InternalProperty_954, InternalParameter_2767, false);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2606 = true;
        protected override void OnGUI(Rect position, GUIContent label)
        {
            InternalField_2606 = EditorGUI.Foldout(position, InternalField_2606, label, true);

            if (!InternalField_2606)
            {
                EditorGUI.EndFoldoutHeaderGroup();
                return;
            }

            position.InternalMethod_3251();

            EditorGUI.indentLevel++;

            EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_656);

            if (InternalField_2604.InternalProperty_655 == ImageScaleMode.Manual)
            {
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_652);
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_654);
            }

            EditorGUI.indentLevel--;

            EditorGUI.EndFoldoutHeaderGroup();
        }
    }
}