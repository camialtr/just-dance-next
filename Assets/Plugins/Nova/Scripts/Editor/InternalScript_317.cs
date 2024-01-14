// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(NavLink))]
    internal class InternalType_748 : InternalType_583<InternalType_750>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3479 = InternalType_573.InternalField_2557 * 2;

        public static float InternalMethod_3439(InternalType_750 InternalParameter_3220)
        {
            int InternalVar_1 = InternalParameter_3220.InternalProperty_1092 == NavLinkType.Manual ? 4 : 3;
            return (InternalVar_1 * InternalType_720.InternalField_3298) + InternalField_3479 + InternalType_573.InternalField_2557;
        }

        protected override float InternalMethod_2353(GUIContent InternalParameter_2767) => InternalMethod_3439(InternalField_2604);

        protected override void OnGUI(Rect position, GUIContent label)
        {
            label = EditorGUI.BeginProperty(position, label, InternalField_2604.InternalProperty_954);

            Rect InternalVar_1 = position;
            InternalVar_1.height = InternalMethod_2353(label);

            EditorGUI.HelpBox(InternalVar_1, string.Empty, MessageType.None);

            position.y += InternalType_573.InternalField_2557;

            Rect InternalVar_2 = position.InternalMethod_3441(EditorStyles.label.CalcSize(label).x);
            EditorGUI.LabelField(InternalVar_2, label);
            InternalType_573.InternalType_574.InternalMethod_3438(position, InternalParameter_3219: true);

            position.InternalMethod_3251();
            Rect InternalVar_3 = position;
            InternalVar_3.height = InternalVar_1.height - (InternalType_720.InternalField_3298 + InternalType_573.InternalField_2557);
            InternalType_573.InternalType_574.InternalMethod_2290(InternalVar_3, InternalType_573.InternalType_574.InternalProperty_474);

            position.y += InternalType_573.InternalField_2557;
            position.xMin += InternalField_3479;
            position.xMax -= InternalField_3479;

            float InternalVar_4 = EditorGUIUtility.labelWidth;
            float InternalVar_5 = EditorStyles.label.CalcSize(InternalType_554.InternalType_746.InternalField_3475).x + InternalType_573.InternalField_2557;

            EditorGUIUtility.labelWidth = InternalVar_5;
            EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1093, InternalType_554.InternalType_746.InternalField_3473);

            if (InternalField_2604.InternalProperty_1092 == NavLinkType.Manual)
            {
                position.InternalMethod_3251();
                Rect InternalVar_6 = position;

                bool InternalVar_7 = !InternalField_2604.InternalProperty_1097.hasMultipleDifferentValues && InternalField_2604.InternalProperty_1096 != null && !InternalField_2604.InternalProperty_1096.Navigable;

                if (InternalVar_7)
                {   
                    InternalVar_6.width = EditorStyles.label.CalcSize(InternalType_554.InternalType_746.InternalField_3474).x;
                    
                    Rect InternalVar_8 = InternalVar_6;
                    InternalVar_8.x = InternalVar_8.xMax;
                    InternalVar_8.width = InternalType_573.InternalField_2551;

                    EditorGUIUtility.labelWidth = InternalType_573.InternalField_2551;
                    EditorGUI.LabelField(InternalVar_8, InternalType_554.InternalType_746.InternalField_3476);
                }

                EditorGUIUtility.labelWidth = InternalVar_6.width;
                EditorGUI.LabelField(InternalVar_6, InternalType_554.InternalType_746.InternalField_3474);

                EditorGUIUtility.labelWidth = 0;
                Rect InternalVar_9 = position;
                InternalVar_9.xMin += InternalVar_5 + InternalType_573.InternalField_2557;
                EditorGUI.PropertyField(InternalVar_9, InternalField_2604.InternalProperty_1097, GUIContent.none);

                EditorGUIUtility.labelWidth = InternalVar_5;
            }

            position.InternalMethod_3251();
            EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_1095, InternalType_554.InternalType_746.InternalField_3475);

            EditorGUIUtility.labelWidth = InternalVar_4;

            EditorGUI.EndProperty();
        }
    }
}
