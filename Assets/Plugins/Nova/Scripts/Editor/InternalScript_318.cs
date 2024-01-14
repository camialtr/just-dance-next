// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomPropertyDrawer(typeof(NavNode))]
    internal class InternalType_749 : InternalType_583<InternalType_751>
    {
        protected override float InternalMethod_2353(GUIContent InternalParameter_2767)
        {
            if (!InternalField_2604.InternalProperty_954.isExpanded)
            {
                return EditorGUIUtility.singleLineHeight;
            }

            int InternalVar_1 = 5;
            float InternalVar_2 = InternalType_720.InternalField_3298;

            InternalVar_2 += InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1113);
            InternalVar_2 += Mathf.Max(InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1107), InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1109));
            InternalVar_2 += InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1111);

            if (InternalType_534.InternalProperty_1088)
            {
                InternalVar_1++;
                InternalVar_2 += Mathf.Max(InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1117), InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1115));
            }

            return InternalVar_2 + (InternalVar_1 * InternalType_573.InternalField_2557);
        }

        protected override void OnGUI(Rect position, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, InternalField_2604.InternalProperty_954);

            InternalField_2604.InternalProperty_954.isExpanded = EditorGUI.Foldout(position, InternalField_2604.InternalProperty_954.isExpanded, label);

            if (!InternalField_2604.InternalProperty_954.isExpanded)
            {
                return;
            }

            position.InternalMethod_3251();

            Rect InternalVar_1 = position;
            InternalVar_1.height = InternalMethod_2353(label) - (InternalType_720.InternalField_3298 + InternalType_573.InternalField_2557);

            EditorGUI.HelpBox(InternalVar_1, string.Empty, MessageType.None);

            position.y += InternalType_573.InternalField_2557;
            position.xMin += InternalType_573.InternalField_2557;
            position.xMax -= InternalType_573.InternalField_2557;

            InternalMethod_3440(position);

            position.height = InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1113);

            Rect InternalVar_2 = position.InternalMethod_3441(position.width * 0.5f);
            EditorGUI.PropertyField(InternalVar_2, InternalField_2604.InternalProperty_1114);

            position.InternalMethod_3444(position.height + InternalType_573.InternalField_2557);
            position.height = Mathf.Max(InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1107), InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1109));

            position.InternalMethod_3247(out Rect InternalVar_3, out Rect InternalVar_4);
            EditorGUI.PropertyField(InternalVar_3, InternalField_2604.InternalProperty_1108);
            EditorGUI.PropertyField(InternalVar_4, InternalField_2604.InternalProperty_1110);

            position.InternalMethod_3444(position.height + InternalType_573.InternalField_2557);
            position.height = InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1111);

            InternalVar_2 = position.InternalMethod_3441(position.width * 0.5f);
            EditorGUI.PropertyField(InternalVar_2, InternalField_2604.InternalProperty_1112);

            if (InternalType_534.InternalProperty_1088)
            {
                position.InternalMethod_3444(position.height + InternalType_573.InternalField_2557);
                position.height = Mathf.Max(InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1117), InternalType_748.InternalMethod_3439(InternalField_2604.InternalProperty_1115));

                position.InternalMethod_3247(out InternalVar_3, out InternalVar_4);
                EditorGUI.PropertyField(InternalVar_3, InternalField_2604.InternalProperty_1118);
                EditorGUI.PropertyField(InternalVar_4, InternalField_2604.InternalProperty_1116);
            }


            EditorGUI.EndFoldoutHeaderGroup();

            EditorGUI.EndProperty();
        }

        private void InternalMethod_3440(Rect InternalParameter_3221)
        {
            float InternalVar_1 = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 2 * InternalType_573.InternalField_2550;

            float InternalVar_2 = 2 * InternalType_573.InternalField_2550;
            Rect InternalVar_3 = InternalParameter_3221.InternalMethod_3442(InternalVar_2, InternalType_720.InternalField_3298);
            InternalType_534.InternalProperty_1088 = GUI.Toggle(InternalVar_3, InternalType_534.InternalProperty_1088, InternalType_554.InternalType_747.InternalProperty_1091, InternalType_573.InternalType_574.InternalProperty_480);
            EditorGUIUtility.labelWidth = InternalVar_1;
        }
    }
}
