// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_17.InternalNamespace_21;
using Nova.InternalNamespace_25;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditorInternal;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CanEditMultipleObjects]
    internal abstract class InternalType_547<T68> : InternalType_539<T68>
        where T68 : UIBlock
    {
        protected abstract void InternalMethod_2184(T68 InternalParameter_2485);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected SerializedProperty InternalField_2425 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_600 InternalField_2426 = new InternalType_600();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_603 InternalField_2427 = new InternalType_603();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_611 InternalField_2428 = new InternalType_611();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_610 InternalField_2429 = new InternalType_610();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected T68 InternalProperty_683 => serializedObject.isEditingMultipleObjects ? null : target as T68;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_1559 = 0;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_1156 = 0;

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalMethod_860();

            InternalField_2425 = serializedObject.FindProperty(InternalType_646.InternalType_657.InternalField_2988);

            T68 InternalVar_1 = target as T68;
            if (InternalMethod_2188(InternalVar_1, InternalField_2425))
            {
                InternalNamespace_0.InternalNamespace_12.InternalType_457.InternalMethod_1860();
                InternalVar_1.CalculateLayout();
            }

            InternalField_2428.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_657.InternalField_3327);
            InternalField_2429.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_657.InternalField_2987);
            InternalField_2426.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_657.InternalField_2984);
            InternalField_2427.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_657.InternalField_2985);

            Undo.undoRedoPerformed += InternalMethod_2185;

            InternalField_1559 = 0;
            InternalField_1156 = 0;
        }


        private void OnDisable()
        {
            Undo.undoRedoPerformed -= InternalMethod_2185;
        }

        private void InternalMethod_2185()
        {
            InternalMethod_2189(InternalParameter_2493: true);
        }

        public override void OnInspectorGUI()
        {
            T68 InternalVar_1 = target as T68;

            int InternalVar_2 = EditorUtility.GetDirtyCount(InternalVar_1);
            int InternalVar_3 = EditorUtility.GetDirtyCount(InternalVar_1.gameObject);

            if (InternalField_1559 != InternalVar_2 || InternalField_1156 != InternalVar_3)
            {
                if (!Application.IsPlaying(target))
                {
                    InternalMethod_2189(InternalParameter_2493: true);
                }

                InternalField_1559 = InternalVar_2;
                InternalField_1156 = InternalVar_3;
            }

            if (!InternalEditorUtility.GetIsInspectorExpanded(target))
            {
                return;
            }

            InternalMethod_2167();

            InternalType_573.InternalField_263 = !serializedObject.isEditingMultipleObjects;

            EditorGUI.BeginChangeCheck();

            InternalMethod_2186(InternalVar_1, InternalField_2425);

            InternalMethod_2184(InternalVar_1);

            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2189();
                InternalType_180.InternalMethod_849();
            }

            InternalField_1559 = EditorUtility.GetDirtyCount(InternalVar_1);
            InternalField_1156 = EditorUtility.GetDirtyCount(InternalVar_1.gameObject);

        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<EditorTool> InternalField_3366 = new List<EditorTool>();

        
        private static List<EditorTool> InternalMethod_830(T68 InternalParameter_680)
        {
            InternalField_3366.Clear();

            InternalField_3366.Add(InternalType_713.InternalField_3369);
            InternalField_3366.Add(InternalType_710.InternalField_3368);
            if (InternalParameter_680 is UIBlock2D)
            {
                InternalField_3366.Add(InternalType_708.InternalField_3367);
            }
            return InternalField_3366;
        }

        private static void InternalMethod_2186(T68 InternalParameter_2486, SerializedProperty InternalParameter_2487)
        {
            using (InternalType_553 foldout = InternalType_573.InternalMethod_2229(InternalType_534.InternalField_2357, InternalParameter_2528: "Tools"))
            {
                if (!foldout)
                {
                    return;
                }

                InternalType_573.InternalType_575.InternalMethod_2305();
                GUILayout.FlexibleSpace();
                EditorGUILayout.EditorToolbar(InternalMethod_830(InternalParameter_2486));

                Rect InternalVar_1 = GUILayoutUtility.GetLastRect();

                GUILayout.FlexibleSpace();

                bool InternalVar_2 = InternalType_573.InternalMethod_3332(InternalParameter_2486);

                if (InternalVar_1.height > 0)
                {
                    float InternalVar_3 = 2 * InternalType_573.InternalField_2550;
                    float InternalVar_4 = EditorGUIUtility.singleLineHeight;
                    float InternalVar_5 = InternalVar_1.y + (0.5f * (InternalVar_1.height - InternalVar_4));
                    float InternalVar_6 = (2 * InternalVar_1.x) + InternalVar_1.width - (1.75f * InternalVar_3);
                    Rect InternalVar_7 = new Rect(InternalVar_6, InternalVar_5, InternalVar_3, InternalVar_4);

                    EditorGUI.BeginChangeCheck();
                    InternalVar_2 = GUI.Toggle(InternalVar_7, InternalVar_2, InternalType_554.InternalType_556.InternalProperty_467, InternalType_573.InternalType_574.InternalProperty_480);
                    if (EditorGUI.EndChangeCheck())
                    {
                        if (InternalParameter_2486 is UIBlock3D)
                        {
                            InternalType_534.InternalProperty_1031 = InternalVar_2;
                        }
                        else
                        {
                            InternalType_534.InternalProperty_442 = InternalVar_2;
                        }
                    }
                }
                InternalType_573.InternalType_575.InternalMethod_2307();

                if (InternalMethod_2188(InternalParameter_2486, InternalParameter_2487))
                {
                    InternalMethod_2187(InternalParameter_2486, InternalParameter_2487, InternalVar_2);
                }
            }
        }

        private static void InternalMethod_2187(T68 InternalParameter_2488, SerializedProperty InternalParameter_2489, bool InternalParameter_2490)
        {
            if (!SceneViewUtils.IsInCurrentPrefabStage(InternalParameter_2488.gameObject))
            {
                if (InternalType_728.InternalMethod_3278(InternalParameter_2488.Size.Type == LengthType.Percent))
                {
                    EditorGUILayout.HelpBox(new GUIContent("Preview Size on root UI Blocks is only available in Prefab View.", EditorGUIUtility.IconContent("d_console.infoicon.sml").image), wide: true);
                }

                return;
            }

            InternalType_573.InternalMethod_2236();

            EditorGUI.BeginChangeCheck();

            ThreeD<bool> InternalVar_1 = InternalParameter_2488.Size.Type == LengthType.Value;

            if (InternalParameter_2490)
            {
                InternalType_573.InternalMethod_2240(InternalType_554.InternalType_556.InternalField_2488, InternalParameter_2489, InternalVar_1);
            }
            else
            {
                InternalType_573.InternalMethod_2241(InternalType_554.InternalType_556.InternalField_2488, InternalParameter_2489, InternalVar_1.XY);
            }

            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2489.vector3Value = Vector3.Max(InternalParameter_2489.vector3Value, Vector3.zero);
            }
        }

        private static bool InternalMethod_2188(T68 InternalParameter_2491, SerializedProperty InternalParameter_2492)
        {
            if (InternalParameter_2492.serializedObject.targetObjects != null &&
                InternalParameter_2492.serializedObject.targetObjects.Length > 1)
            {
                return false;
            }

            if (InternalParameter_2491.Parent != null || !SceneViewUtils.IsVisibleInSceneView(InternalParameter_2491.gameObject))
            {
                return false;
            }

            return true;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected List<MonoBehaviour> InternalField_2211 = new List<MonoBehaviour>();
        protected virtual void InternalMethod_860()
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; InternalVar_1++)
            {
                InternalField_2211.Clear();
                InternalField_2385[InternalVar_1].GetComponents(InternalField_2211);

                int InternalVar_2 = -1;
                int InternalVar_3 = -1;
                for (int InternalVar_4 = 0; InternalVar_4 < InternalField_2211.Count; ++InternalVar_4)
                {
                    if (InternalField_2211[InternalVar_4] is UIBlock)
                    {
                        InternalVar_2 = InternalVar_4;
                    }
                    else if (InternalField_2211[InternalVar_4] is UIBlockActivator)
                    {
                        InternalVar_3 = InternalVar_4;
                    }

                    if (InternalVar_2 >= 0 && InternalVar_3 >= 0)
                    {
                        break;
                    }
                }

                UIBlockActivator InternalVar_5 = InternalField_2211[InternalVar_3] as UIBlockActivator;
                InternalVar_5.hideFlags ^= HideFlags.NotEditable;

                while (InternalVar_3 >= InternalVar_2 && ComponentUtility.MoveComponentUp(InternalVar_5))
                {
                    InternalVar_3--;
                }

                InternalVar_5.hideFlags |= HideFlags.NotEditable;
            }
        }

        [Obfuscation]
        public bool HasFrameBounds()
        {
            T68 InternalVar_1 = target as T68;
            return InternalVar_1.gameObject.activeInHierarchy;
        }

        [Obfuscation]
        public Bounds OnGetFrameBounds()
        {
            T68 InternalVar_1 = target as T68;

            Bounds InternalVar_2 = new Bounds(InternalVar_1.transform.position, InternalVar_1.InternalMethod_3351(InternalParameter_678: false));

            for (int InternalVar_3 = 1; InternalVar_3 < InternalField_2385.Count; ++InternalVar_3)
            {
                InternalVar_2.Encapsulate(new Bounds(InternalField_2385[InternalVar_3].transform.position, InternalField_2385[InternalVar_3].InternalMethod_3351(InternalParameter_678: false)));
            }

            return InternalVar_2;
        }

        protected void InternalMethod_2189(bool InternalParameter_2493 = false)
        {
            T68 InternalVar_1 = target as T68;
            Vector3 InternalVar_2 = InternalVar_1.PreviewSize;

            serializedObject.ApplyModifiedProperties();
            for (int InternalVar_3 = 0; InternalVar_3 < InternalField_2385.Count; ++InternalVar_3)
            {
                InternalField_2385[InternalVar_3].InternalMethod_1856();
            }

            if (InternalMethod_2188(InternalVar_1, InternalField_2425))
            {
                if (InternalParameter_2493 || InternalVar_2 != InternalVar_1.PreviewSize)
                {
                    InternalNamespace_0.InternalNamespace_12.InternalType_457.InternalMethod_1860();
                }
            }
        }

        protected override void InternalMethod_2167()
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; ++InternalVar_1)
            {
                InternalField_2385[InternalVar_1].InternalMethod_113();
            }
            serializedObject.UpdateIfRequiredOrScript();
        }
    }
}

