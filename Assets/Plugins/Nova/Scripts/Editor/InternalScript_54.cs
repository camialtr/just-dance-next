// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using System;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal struct InternalType_553 : IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const int InternalField_2445 = 14;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const int InternalField_2446 = 36;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2447;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2448;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2449;

        private InternalType_553(bool InternalParameter_2494, bool InternalParameter_2495, bool InternalParameter_2496 = false)
        {
            this.InternalField_2447 = InternalParameter_2494;
            this.InternalField_2448 = InternalParameter_2495;
            this.InternalField_2449 = InternalParameter_2496;
        }

        public void Dispose()
        {
            if (InternalField_2448)
            {
                InternalType_573.InternalType_575.InternalMethod_2310();

                if (InternalField_2449)
                {
                    EditorGUI.EndDisabledGroup();
                }

                if (InternalField_2447)
                {

                    Rect InternalVar_1 = GUILayoutUtility.GetLastRect();
                    InternalVar_1.yMax -= 1;

                    InternalType_573.InternalType_574.InternalMethod_3438(InternalVar_1, InternalParameter_3218: false);
                }
            }
        }

        public static InternalType_553 InternalMethod_2206(bool InternalParameter_2497, string InternalParameter_2498, Action<Rect> InternalParameter_2499 = null)
        {
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();

            InternalParameter_2497 = InternalMethod_2209(InternalVar_1, 0, InternalParameter_2497, InternalParameter_2498, InternalParameter_2499);

            InternalType_573.InternalType_575.InternalMethod_2309(InternalParameter_2497 ? InternalType_573.InternalType_574.InternalProperty_475 : GUIStyle.none);

            return new InternalType_553(InternalParameter_2497, InternalParameter_2495: true);
        }

        public static InternalType_553 InternalMethod_2207(bool InternalParameter_2500, string InternalParameter_2501, SerializedProperty InternalParameter_2502, Action<Rect> InternalParameter_2503 = null)
        {
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();

            InternalParameter_2500 = InternalMethod_2209(InternalVar_1, InternalField_2446, InternalParameter_2500, InternalParameter_2501, InternalParameter_2503);

            Rect InternalVar_2 = GUILayoutUtility.GetLastRect();
            InternalVar_2.width = InternalType_573.InternalField_2551;
            InternalVar_2.x = InternalVar_1.xMax - InternalField_2446;

            GUIContent InternalVar_3 = EditorGUI.BeginProperty(InternalVar_2, GUIContent.none, InternalParameter_2502);
            EditorGUI.BeginChangeCheck();

            bool InternalVar_4 = EditorGUI.Toggle(InternalVar_2, InternalVar_3, InternalParameter_2502.boolValue);

            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2502.boolValue = InternalVar_4;
            }
            EditorGUI.EndProperty();

            InternalType_573.InternalType_575.InternalMethod_2309(InternalParameter_2500 ? InternalType_573.InternalType_574.InternalProperty_475 : GUIStyle.none);
            EditorGUI.BeginDisabledGroup(!InternalVar_4);

            return new InternalType_553(InternalParameter_2500, InternalParameter_2495: true, InternalParameter_2496: true);
        }

        public static bool InternalMethod_2208(Rect InternalParameter_2504, bool InternalParameter_2505)
        {
            Rect InternalVar_1 = InternalParameter_2504;
            InternalVar_1.x -= InternalField_2445;
            InternalVar_1.width = InternalField_2445;

            return GUI.Toggle(InternalVar_1, InternalParameter_2505, string.Empty, InternalType_573.InternalType_574.InternalProperty_484);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool InternalField_2450 = false; 

        private static bool InternalMethod_2209(Rect InternalParameter_2506, float InternalParameter_2507, bool InternalParameter_2508, string InternalParameter_2509, Action<Rect> InternalParameter_2510)
        {
            InternalParameter_2506.width -= 1;
            InternalParameter_2506.height += 1f;

            EventType InternalVar_1 = Event.current.type;

            Rect InternalVar_2 = InternalParameter_2506;
            InternalVar_2.width = InternalType_573.InternalField_2552;
            InternalVar_2.height = InternalType_573.InternalField_2552;
            InternalVar_2.x = InternalParameter_2506.width + 2;
            InternalVar_2.y += 0.5f;

            Rect InternalVar_3 = InternalVar_2;
            InternalVar_3.width += InternalParameter_2507;
            InternalVar_3.height = InternalParameter_2506.height;
            InternalVar_3.x -= InternalParameter_2507;

            bool InternalVar_4 = Event.current.type == EventType.Repaint;
            bool InternalVar_5 = InternalVar_3.Contains(Event.current.mousePosition) && !InternalVar_4;
            if (InternalVar_5)
            {
                Event.current.type = EventType.Used;
            }

            Color InternalVar_6 = GUI.backgroundColor;
            bool InternalVar_7 = InternalParameter_2506.Contains(Event.current.mousePosition);
            if (InternalVar_4)
            {
                InternalType_573.InternalType_574.InternalProperty_491.Draw(InternalParameter_2506, false, false, false, false);
                GUI.backgroundColor = InternalVar_7 ? Color.white : Color.clear;
            }

            InternalParameter_2508 = EditorGUI.BeginFoldoutHeaderGroup(InternalParameter_2506, InternalParameter_2508, InternalParameter_2509, InternalType_573.InternalType_574.InternalProperty_490);
            EditorGUI.EndFoldoutHeaderGroup();

            if (InternalVar_4)
            {
                GUI.backgroundColor = Color.white;
                if (!InternalVar_7)
                {
                    Rect InternalVar_8 = InternalParameter_2506;
                    InternalVar_8.width = InternalField_2445;
                    if (!InternalField_2450)
                    {
                        InternalVar_8.x -= InternalField_2445;
                    }
                    EditorStyles.foldout.Draw(InternalVar_8, false, false, InternalParameter_2508, false);
                }
                GUI.backgroundColor = InternalVar_6;
            }

            if (InternalVar_5)
            {
                Event.current.type = InternalVar_1;
            }

            if (InternalParameter_2510 != null)
            {
                if (GUI.Button(InternalVar_2, InternalType_573.InternalType_574.InternalProperty_487, InternalType_573.InternalType_574.InternalProperty_486))
                {
                    InternalParameter_2510.Invoke(InternalVar_2);
                }
            }

            InternalType_573.InternalType_574.InternalMethod_3438(InternalParameter_2506);

            return InternalParameter_2508;
        }

        public static InternalType_553 InternalMethod_2210(bool InternalParameter_2511, string InternalParameter_2512, GUIStyle InternalParameter_2513)
        {
            InternalParameter_2511 = EditorGUILayout.Foldout(InternalParameter_2511, InternalParameter_2512, true, InternalParameter_2513 == null ? EditorStyles.foldout : InternalParameter_2513);
            return new InternalType_553(InternalParameter_2511, InternalParameter_2495: false);
        }

        public static InternalType_553 InternalMethod_2211(bool InternalParameter_2514, string InternalParameter_2515, ref Rect InternalParameter_2516)
        {
            InternalParameter_2514 = EditorGUI.Foldout(InternalParameter_2516.InternalMethod_3254(), InternalParameter_2514, InternalParameter_2515, true);
            return new InternalType_553(InternalParameter_2514, InternalParameter_2495: false, InternalParameter_2496: false);
        }

        public static implicit operator bool(InternalType_553 InternalParameter_2517) => InternalParameter_2517.InternalField_2447;
    }
}
