// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using System.Reflection;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEditorInternal;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal static class InternalType_573
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool InternalField_371 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool InternalField_263 = true;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool InternalProperty_682 => InternalField_371 && InternalField_263;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2550 = 10;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3636 = 12.5f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2551 = 15;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2552 = 15;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2553 = 45;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_2554 = 220;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_2555 = 250;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_2556 = 190;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2557 = 2;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2558 = 16;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2559 = 4 * InternalField_2550;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2560 = 3 * InternalField_2550;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_2561 = 504;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static bool InternalProperty_468 => InternalProperty_473 < InternalField_2561;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static float InternalProperty_469 => Mathf.Min(EditorGUIUtility.labelWidth, InternalProperty_473 - InternalField_2554) + InternalField_2557;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static float InternalProperty_471 => Mathf.Max(InternalProperty_473 * 0.575f, InternalField_2556);

        [ClutchShortcut("Nova/Length Type Swap", KeyCode.L, ShortcutModifiers.Action)]
        private static void InternalMethod_1933()
        {
            InternalField_371 = !InternalField_371;
            InternalEditorUtility.RepaintAllViews();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static float InternalProperty_472
        {
            get
            {
                return EditorGUIUtility.labelWidth;
            }
            set
            {
                EditorGUIUtility.labelWidth = value;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static float InternalProperty_473
        {
            get
            {
                return Mathf.Min(2.25f * EditorGUIUtility.labelWidth, EditorGUIUtility.currentViewWidth);
            }
        }

        public static bool InternalMethod_3332(UIBlock InternalParameter_1471) => InternalParameter_1471 is UIBlock3D ? InternalType_534.InternalProperty_1031 : InternalType_534.InternalProperty_442;

        public static class InternalType_574
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static ColorSpace InternalField_2562;

            [InitializeOnLoadMethod]
            private static void InternalMethod_2266()
            {
                AssemblyReloadEvents.beforeAssemblyReload += InternalMethod_2268;
                EditorApplication.playModeStateChanged += (_) => InternalMethod_2268();

                InternalField_2562 = PlayerSettings.colorSpace;
                InternalType_531.InternalEvent_5 += InternalMethod_2267;

                SceneView.beforeSceneGui += (SceneView sceneView) =>
                {
                    if (!InternalType_534.InternalProperty_720 || !sceneView.drawGizmos)
                    {
                        return;
                    }

                    Color InternalVar_1 = SceneView.selectedOutlineColor;
                    InternalVar_1.a = 1;

                    InternalProperty_719 = InternalType_117.InternalMethod_571("Scene/Selected Children Outline", InternalVar_1);
                };
            }


            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_719 { get; private set; }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2563 = new Color(1, 1, 1, 0.05f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2564 = new Color(0, 0, 0, 0.075f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2565 = new Color(0, 0, 0, 0.075f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2566 = new Color(1, 1, 1, 0.05f);

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static Dictionary<Color, Texture2D> InternalField_2567 = new Dictionary<Color, Texture2D>();

            private static void InternalMethod_2267()
            {
                if (PlayerSettings.colorSpace == InternalField_2562)
                {
                    return;
                }

                InternalField_2562 = PlayerSettings.colorSpace;
                InternalMethod_2268();
            }

            private static void InternalMethod_2268()
            {
                foreach (var InternalVar_1 in InternalField_2567)
                {
                    if (InternalVar_1.Value == null)
                    {
                        continue;
                    }

                    InternalType_179.InternalMethod_848(InternalVar_1.Value);
                }

                InternalField_2567.Clear();

                InternalProperty_491 = null;
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_474 => EditorGUIUtility.isProSkin ? InternalField_2563 : InternalField_2565;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2568 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_475
            {
                get
                {
                    if (InternalField_2568 == null || InternalField_2568.normal.background == null)
                    {
                        InternalField_2568 = new GUIStyle(InternalProperty_476);

                        InternalField_2568.overflow = new RectOffset(18, 4, 0, 0);
                        InternalField_2568.padding.left -= 18;
                        InternalField_2568.margin.left -= 18;
                        InternalField_2568.padding.top += 3;
                        InternalField_2568.padding.bottom += 3;
                    }

                    return InternalField_2568;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2569 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_476
            {
                get
                {
                    if (InternalField_2569 == null || InternalField_2569.normal.background == null)
                    {
                        InternalField_2569 = new GUIStyle();

                        InternalField_2569.normal = new GUIStyleState()
                        {
                            background = InternalMethod_2296(InternalProperty_474)
                        };
                    }

                    return InternalField_2569;
                }
            }


            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2570 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_477
            {
                get
                {
                    if (InternalField_2570 == null || InternalField_2570.normal.background == null)
                    {
                        InternalField_2570 = new GUIStyle(GUIStyle.none);
                        InternalField_2570.padding = EditorStyles.helpBox.padding;
                        InternalField_2570.margin = EditorStyles.helpBox.margin;
                        InternalField_2570.overflow = EditorStyles.helpBox.overflow;
                        InternalField_2570.padding.right += 2;
                        InternalField_2570.padding.bottom += 2;

                        InternalField_2570.border = new RectOffset(-1, 0, 0, -1);
                    }

                    return InternalField_2570;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2571 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_478
            {
                get
                {
                    if (InternalField_2571 == null)
                    {
                        InternalField_2571 = new GUIStyle(EditorStyles.miniButtonLeft);
                        InternalField_2571.fontSize = 10;
                        InternalField_2571.alignment = TextAnchor.MiddleCenter;
                    }
                    return InternalField_2571;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2572 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_479
            {
                get
                {
                    if (InternalField_2572 == null)
                    {
                        InternalField_2572 = new GUIStyle(GUI.skin.button)
                        {
                            fontSize = 8,
                            fontStyle = FontStyle.Bold
                        };
                    }

                    return InternalField_2572;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2573 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_480
            {
                get
                {
                    if (InternalField_2573 == null)
                    {
                        InternalField_2573 = new GUIStyle(EditorStyles.miniButtonMid);
                        InternalField_2573.fontSize = 10;
                        InternalField_2573.alignment = TextAnchor.MiddleCenter;
                    }
                    return InternalField_2573;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2574 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_481
            {
                get
                {
                    if (InternalField_2574 == null)
                    {
                        InternalField_2574 = new GUIStyle(EditorStyles.miniButtonRight);
                        InternalField_2574.fontSize = 10;
                        InternalField_2574.alignment = TextAnchor.MiddleCenter;
                    }
                    return InternalField_2574;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2575 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_482
            {
                get
                {
                    if (InternalField_2575 == null)
                    {
                        InternalField_2575 = new GUIStyle(EditorStyles.numberField);
                        InternalField_2575.fontStyle = FontStyle.Bold;
                        InternalField_2575.normal.textColor = InternalProperty_494;
                        InternalField_2575.active.textColor = InternalProperty_494;
                        InternalField_2575.hover.textColor = InternalProperty_494;
                        InternalField_2575.focused.textColor = InternalProperty_494;

                        InternalField_2575.onNormal.textColor = InternalProperty_494;
                        InternalField_2575.onActive.textColor = InternalProperty_494;
                        InternalField_2575.onHover.textColor = InternalProperty_494;
                        InternalField_2575.onFocused.textColor = InternalProperty_494;
                    }

                    return InternalField_2575;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2576 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_483
            {
                get
                {
                    if (InternalField_2576 == null)
                    {
                        InternalField_2576 = new GUIStyle(EditorStyles.numberField);
                        InternalField_2576.fontStyle = FontStyle.Bold;
                        InternalField_2576.normal.textColor = InternalProperty_495;
                        InternalField_2576.active.textColor = InternalProperty_495;
                        InternalField_2576.hover.textColor = InternalProperty_495;
                        InternalField_2576.focused.textColor = InternalProperty_495;

                        InternalField_2576.onNormal.textColor = InternalProperty_495;
                        InternalField_2576.onActive.textColor = InternalProperty_495;
                        InternalField_2576.onHover.textColor = InternalProperty_495;
                        InternalField_2576.onFocused.textColor = InternalProperty_495;
                    }

                    return InternalField_2576;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2577 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_484
            {
                get
                {
                    if (InternalField_2577 == null)
                    {
                        InternalField_2577 = new GUIStyle(EditorStyles.foldout);
                        InternalField_2577.alignment = TextAnchor.MiddleLeft;
                    }

                    return InternalField_2577;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2578 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_485
            {
                get
                {
                    if (InternalField_2578 == null)
                    {
                        InternalField_2578 = new GUIStyle(EditorStyles.numberField);
                        InternalField_2578.fontStyle = FontStyle.Bold;
                        InternalField_2578.normal.textColor = InternalProperty_496;
                        InternalField_2578.active.textColor = InternalProperty_496;
                        InternalField_2578.hover.textColor = InternalProperty_496;
                        InternalField_2578.focused.textColor = InternalProperty_496;

                        InternalField_2578.onNormal.textColor = InternalProperty_496;
                        InternalField_2578.onActive.textColor = InternalProperty_496;
                        InternalField_2578.onHover.textColor = InternalProperty_496;
                        InternalField_2578.onFocused.textColor = InternalProperty_496;
                    }

                    return InternalField_2578;
                }
            }


            
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_486 => "IconButton";
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIContent InternalProperty_487 => new GUIContent() { image = EditorStyles.foldoutHeaderIcon.normal.scaledBackgrounds[0] };

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_488 => "IN LockButton";
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_489 => "FloatFieldLinkButton";

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2579 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_490
            {
                get
                {
                    if (InternalField_2579 == null)
                    {
                        InternalField_2579 = new GUIStyle(EditorStyles.foldoutHeader);
                        InternalField_2579.margin = new RectOffset(-32, 0, 1, 2);
                    }
                    return InternalField_2579;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly Color InternalField_2580 = new Color(0.18f, 0.18f, 0.18f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly Color InternalField_2581 = new Color(0.65f, 0.65f, 0.65f);

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2582 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_491
            {
                get
                {
                    if (InternalField_2582 == null || InternalField_2582.normal == null || InternalField_2582.normal.background == null)
                    {
                        InternalField_2582 = new GUIStyle(GUIStyle.none);
                        InternalField_2582.overflow = new RectOffset(20, 8, 1, 1);
                        InternalField_2582.normal.background = InternalMethod_2296(EditorGUIUtility.isProSkin ? InternalField_2580 : InternalField_2581);
                    }
                    return InternalField_2582;
                }
                private set
                {
                    if (value != null)
                    {
                        Debug.LogWarning($"Invalid assingment of SectionHeaderBackground. Only can be set to null as a means of clearing.");

                        return;
                    }

                    InternalField_2582 = null;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle[] InternalField_2583 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle[] InternalProperty_492
            {
                get
                {
                    if (InternalField_2583 == null || InternalField_2583[0].normal.background == null)
                    {
                        InternalField_2583 = new GUIStyle[2];
                        Color InternalVar_1 = new Color(0, 0, 0, 0.2f);
                        Color InternalVar_2 = new Color(0, 0, 0, 0.1f);

                        InternalField_2583[0] = new GUIStyle()
                        {
                            normal = new GUIStyleState()
                            {
                                background = InternalMethod_2296(InternalVar_1),
                            }
                        };

                        InternalField_2583[1] = new GUIStyle()
                        {
                            normal = new GUIStyleState()
                            {
                                background = InternalMethod_2296(InternalVar_2),
                            }
                        };
                    }

                    return InternalField_2583;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_2584 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_493
            {
                get
                {
                    if (InternalField_2584 == null)
                    {
                        InternalField_2584 = new GUIStyle()
                        {
                            normal = new GUIStyleState()
                        };
                    }

                    return InternalField_2584;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_3643 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_1158
            {
                get
                {
                    if (InternalField_3643 == null)
                    {
                        InternalField_3643 = new GUIStyle(EditorStyles.linkLabel);
                        InternalField_3643.fontSize += 2;
                        InternalField_3643.hover = new GUIStyleState()
                        {
                            textColor = EditorStyles.label.normal.textColor
                        };
                    }

                    return InternalField_3643;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_3644 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_1159
            {
                get
                {
                    if (InternalField_3644 == null)
                    {
                        InternalField_3644 = new GUIStyle(EditorStyles.label);

                        InternalField_3644.fontSize += 2;
                        InternalField_3644.wordWrap = true;
                        InternalField_3644.padding = new RectOffset(36, 36, 18, 18);
                    }

                    return InternalField_3644;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUIStyle InternalField_3645 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIStyle InternalProperty_1160
            {
                get
                {
                    if (InternalField_3645 == null)
                    {
                        InternalField_3645 = new GUIStyle(EditorStyles.boldLabel);

                        InternalField_3645.fontSize += 2;
                    }

                    return InternalField_3645;
                }
            }

            public static void InternalMethod_2290(Rect InternalParameter_2665, Color InternalParameter_2666)
            {
                if (Event.current == null || Event.current.type != EventType.Repaint)
                {
                    return;
                }

                InternalProperty_493.normal.background = InternalMethod_2296(InternalParameter_2666);

                InternalProperty_493.Draw(InternalParameter_2665, false, false, false, false);
            }

            public static void InternalMethod_3438(Rect InternalParameter_3216, float InternalParameter_3217 = 1.5f, bool InternalParameter_3218 = true, bool InternalParameter_3219 = false)
            {
                if (Event.current.type != EventType.Repaint)
                {
                    return;
                }

                Rect InternalVar_1 = InternalParameter_3216;
                InternalVar_1.y = InternalVar_1.yMax;

                if (!InternalParameter_3219)
                {
                    InternalVar_1.x = 0;
                    InternalVar_1.width = EditorGUIUtility.currentViewWidth;
                }

                int InternalVar_2 = InternalParameter_3218 ? 0 : 1;
                int InternalVar_3 = InternalParameter_3218 ? 1 : 0;

                float InternalVar_4 = InternalParameter_3218 ? InternalParameter_3217 * (1 / 3f) : InternalParameter_3217 * (2 / 3f);
                float InternalVar_5 = InternalParameter_3218 ? InternalParameter_3217 * (2 / 3f) : InternalParameter_3217 * (1 / 3f);

                InternalVar_1.height = InternalVar_4;
                InternalProperty_492[InternalVar_2].Draw(InternalVar_1, false, false, false, false);
                InternalVar_1.y += InternalVar_4;
                InternalVar_1.height = InternalVar_5;
                InternalProperty_492[InternalVar_3].Draw(InternalVar_1, false, false, false, false);
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_494
            {
                get
                {
                    float InternalVar_1 = EditorGUIUtility.isProSkin ? 0.5f : 1f;
                    float InternalVar_2 = EditorGUIUtility.isProSkin ? 0.8f : 0.6f;

                    Color.RGBToHSV(Color.yellow, out float InternalVar_3, out float InternalVar_4, out float InternalVar_5);

                    return Color.HSVToRGB(InternalVar_3, InternalVar_1, InternalVar_2);
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_495
            {
                get
                {
                    const float InternalVar_1 = 0.6f;
                    float InternalVar_2 = EditorGUIUtility.isProSkin ? 1f : 0.8f;

                    Color.RGBToHSV(new Color(0.3f, 0.533f, 1), out float InternalVar_3, out float InternalVar_4, out float InternalVar_5);

                    return Color.HSVToRGB(InternalVar_3, InternalVar_1, InternalVar_2);
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_496
            {
                get
                {
                    const float InternalVar_1 = 0.7f;
                    float InternalVar_2 = EditorGUIUtility.isProSkin ? 0.9f : 0.7f;

                    Color.RGBToHSV(new Color(1, 0.3f, 0.533f), out float InternalVar_3, out float InternalVar_4, out float InternalVar_5);

                    return Color.HSVToRGB(InternalVar_3, InternalVar_1, InternalVar_2);
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static Color InternalProperty_497
            {
                get
                {
                    const float InternalVar_1 = 0.8f;
                    float InternalVar_2 = 0.7f;

                    Color.RGBToHSV(new Color(0.3f, 1, 0.533f), out float InternalVar_3, out float InternalVar_4, out float InternalVar_5);

                    return Color.HSVToRGB(InternalVar_3, InternalVar_1, InternalVar_2);
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2585 = new Color(0.8f, 0, 0.35f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2586 = new Color(0, 0.33f, 1);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2587 = new Color(0, .45f, 0.25f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2588 = new Color(0, 0.4f, 0.4f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2589 = new Color(0, 0.8f, 0.9f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2590 = new Color(0, 0.9f, 0.8f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2591 = new Color(0.6f, 0.4f, 0.9f);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly Color InternalField_2592 = new Color(1, 0.4f, 1);

            public static Texture2D InternalMethod_2296(Color InternalParameter_2670)
            {
                bool InternalVar_2 = !InternalField_2567.TryGetValue(InternalParameter_2670, out Texture2D InternalVar_1) || InternalVar_1 == null;

                if (InternalVar_2)
                {
                    InternalVar_1 = InternalMethod_2297(InternalParameter_2670);
                    InternalVar_1.name = $"NovaGUI.SolidTexture.{ColorUtility.ToHtmlStringRGBA(InternalParameter_2670)}";
                    InternalField_2567[InternalParameter_2670] = InternalVar_1;
                }

                return InternalVar_1;
            }

            private static Texture2D InternalMethod_2297(Color InternalParameter_2671)
            {
                Texture2D InternalVar_1 = new Texture2D(2, 2);

                for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.height; ++InternalVar_2)
                {
                    for (int InternalVar_3 = 0; InternalVar_3 < InternalVar_1.width; ++InternalVar_3)
                    {
                        InternalVar_1.SetPixel(InternalVar_3, InternalVar_2, InternalParameter_2671);
                    }
                }

                InternalVar_1.Apply();

                return InternalVar_1;
            }
        }

        public static class InternalType_575
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public const float InternalField_2593 = 1.125f;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static float InternalProperty_498 => InternalProperty_469 + InternalField_2557;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUILayoutOption InternalProperty_499
            {
                get
                {
                    return GUILayout.Width(InternalProperty_498);
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUILayoutOption InternalField_2594 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUILayoutOption InternalProperty_500
            {
                get
                {
                    if (InternalField_2594 == null)
                    {
                        InternalField_2594 = GUILayout.Width(InternalType_553.InternalField_2445);
                    }

                    return InternalField_2594;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static GUILayoutOption InternalField_2595 = null;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUILayoutOption InternalProperty_501
            {
                get
                {
                    if (InternalField_2595 == null)
                    {
                        InternalField_2595 = GUILayout.MinWidth(InternalField_2560);
                    }

                    return InternalField_2595;
                }
            }


            public static Rect InternalMethod_2302(params GUILayoutOption[] InternalParameter_2672)
            {
                Rect InternalVar_1 = InternalMethod_2303(InternalParameter_2673: false, EditorGUIUtility.singleLineHeight, InternalParameter_2672);
                return InternalVar_1;
            }

            public static Rect InternalMethod_2303(bool InternalParameter_2673, float InternalParameter_2674, params GUILayoutOption[] InternalParameter_2675)
            {
                if (Event.current.type == EventType.Used)
                {
                    return new Rect(Vector2.zero, Vector2.one);
                }

                Rect InternalVar_1 = EditorGUILayout.GetControlRect(InternalParameter_2673, InternalParameter_2674, InternalParameter_2675);

                return InternalVar_1;
            }

            public static void InternalMethod_2304(bool InternalParameter_2676, out Rect InternalParameter_2677, out Rect InternalParameter_2678, out Rect InternalParameter_2679)
            {
                Rect InternalVar_1 = InternalMethod_2302();

                float InternalVar_2 = InternalParameter_2676 ? 1f / 3f : 0.5f;
                float InternalVar_3 = InternalVar_1.width * InternalVar_2;

                InternalParameter_2677 = InternalVar_1;
                InternalParameter_2677.width = InternalVar_3;

                InternalParameter_2678 = InternalParameter_2677;
                InternalParameter_2678.x += InternalVar_3 + InternalField_2557;

                InternalParameter_2679 = default;

                if (InternalParameter_2676)
                {
                    InternalParameter_2679 = InternalParameter_2678;
                    InternalParameter_2679.x += InternalVar_3 + InternalField_2557;
                }
            }

            public static Rect InternalMethod_2305()
            {
                return EditorGUILayout.BeginHorizontal();
            }

            public static Rect InternalMethod_2306(GUIStyle InternalParameter_2680)
            {
                return EditorGUILayout.BeginHorizontal(InternalParameter_2680);
            }

            public static void InternalMethod_2307()
            {
                EditorGUILayout.EndHorizontal();
            }

            public static Rect InternalMethod_2308()
            {
                return EditorGUILayout.BeginVertical();
            }

            public static Rect InternalMethod_2309(GUIStyle InternalParameter_2681)
            {
                return EditorGUILayout.BeginVertical(InternalParameter_2681);
            }

            public static void InternalMethod_2310()
            {
                EditorGUILayout.EndVertical();
            }
        }

        public static class InternalType_117
        {
            public static Color InternalMethod_571(string InternalParameter_3103, Color InternalParameter_3104)
            {
                string[] InternalVar_1 = EditorPrefs.GetString(InternalParameter_3103, string.Empty).Split(';');

                if (InternalVar_1 != null &&
                    InternalVar_1.Length == 5 &&
                    float.TryParse(InternalVar_1[1], out float InternalVar_2) &&
                    float.TryParse(InternalVar_1[2], out float InternalVar_3) &&
                    float.TryParse(InternalVar_1[3], out float InternalVar_4))
                {
                    return new Color(InternalVar_2, InternalVar_3, InternalVar_4);
                }

                return InternalParameter_3104;
            }
        }

        public static void InternalMethod_3336(string InternalParameter_33)
        {
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Width(0), GUILayout.Height(0));

            InternalMethod_3639(InternalVar_1, InternalParameter_33);

            EditorGUILayout.Space(-3);
        }

        public static void InternalMethod_3639(Rect InternalParameter_3429, string InternalParameter_3428)
        {
            InternalParameter_3429.x -= InternalType_573.InternalField_2552;
            InternalParameter_3429.y += InternalType_573.InternalField_2557;
            InternalParameter_3429.width = InternalType_573.InternalField_2552;
            InternalParameter_3429.height = InternalType_573.InternalField_2552;

            EditorGUI.LabelField(InternalParameter_3429, new GUIContent(InternalType_554.InternalField_3354) { tooltip = InternalParameter_3428 });
        }

        public static void InternalMethod_3658(Rect InternalParameter_3453, GUIContent InternalParameter_3454, string InternalParameter_3455, bool InternalParameter_3456 = true)
        {
            if (InternalMethod_3661(InternalParameter_3453, InternalParameter_3454, InternalParameter_3456))
            {
                System.Diagnostics.Process.Start(InternalParameter_3455);
            }
        }

        public static void InternalMethod_3659(Rect InternalParameter_3457, string InternalParameter_3458, string InternalParameter_3459, bool InternalParameter_3460 = true)
        {
            InternalMethod_3658(InternalParameter_3457, EditorGUIUtility.TrTempContent(InternalParameter_3458), InternalParameter_3459, InternalParameter_3460);
        }

        public static bool InternalMethod_3660(Rect InternalParameter_3461, string InternalParameter_3462, bool InternalParameter_3463 = true)
        {
            return InternalMethod_3661(InternalParameter_3461, EditorGUIUtility.TrTempContent(InternalParameter_3462), InternalParameter_3463);
        }

        public static bool InternalMethod_3661(Rect InternalParameter_3464, GUIContent InternalParameter_3465, bool InternalParameter_3466 = true)
        {
            EditorGUIUtility.AddCursorRect(InternalParameter_3464, MouseCursor.Link);

            GUIStyle InternalVar_1 = InternalParameter_3466 ? InternalType_574.InternalProperty_1158 : EditorStyles.linkLabel;

            Vector2 InternalVar_2 = InternalVar_1.CalcSize(InternalParameter_3465);
            InternalParameter_3464.width = InternalVar_2.x;
            InternalParameter_3464.height = InternalVar_2.y;

            Handles.color = InternalVar_1.normal.textColor;
            Handles.DrawLine(new Vector3(InternalParameter_3464.xMin + (float)InternalVar_1.padding.left, InternalParameter_3464.yMax), new Vector3(InternalParameter_3464.xMax - (float)InternalVar_1.padding.right, InternalParameter_3464.yMax));
            Handles.color = Color.white;

            return GUI.Button(InternalParameter_3464, InternalParameter_3465, InternalVar_1);
        }

        public static void InternalMethod_2225(GUIContent InternalParameter_2519)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_499);
            EditorGUI.LabelField(InternalVar_1, InternalParameter_2519);
        }

        public static void InternalMethod_2226(GUIContent InternalParameter_2520, SerializedProperty InternalParameter_2521)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_499);
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2520, InternalParameter_2521);
            EditorGUI.LabelField(InternalVar_1, InternalVar_2);
            EditorGUI.EndProperty();
        }

        public static bool InternalMethod_2227(GUIContent InternalParameter_2522, bool InternalParameter_2523, SerializedProperty InternalParameter_2524)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_499);
            EditorGUI.BeginDisabledGroup(false);
            InternalParameter_2523 = InternalType_553.InternalMethod_2208(InternalVar_1, InternalParameter_2523);
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2522, InternalParameter_2524);
            EditorGUI.LabelField(InternalVar_1, InternalVar_2);
            EditorGUI.EndDisabledGroup();
            EditorGUI.EndProperty();

            return InternalParameter_2523;
        }

        public static bool InternalMethod_2228(bool InternalParameter_2525)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_500);
            EditorGUI.BeginDisabledGroup(false);
            InternalParameter_2525 = InternalType_553.InternalMethod_2208(InternalVar_1, InternalParameter_2525);
            EditorGUI.EndDisabledGroup();

            return InternalParameter_2525;
        }

        public static InternalType_553 InternalMethod_2229(string InternalParameter_2526, System.Action<Rect> InternalParameter_2527 = null, string InternalParameter_2528 = null)
        {
            string InternalVar_1 = InternalType_534.InternalMethod_1942(InternalParameter_2526);
            bool InternalVar_2 = EditorPrefs.GetBool(InternalVar_1, false);
            InternalType_553 InternalVar_3 = InternalType_553.InternalMethod_2206(InternalVar_2, string.IsNullOrEmpty(InternalParameter_2528) ? InternalParameter_2526 : InternalParameter_2528, InternalParameter_2527);

            if (InternalVar_3 != InternalVar_2)
            {
                EditorPrefs.SetBool(InternalVar_1, InternalVar_3);
            }
            return InternalVar_3;
        }

        public static InternalType_553 InternalMethod_2230(string InternalParameter_2529, SerializedProperty InternalParameter_2530)
        {
            string InternalVar_1 = InternalType_534.InternalMethod_1942(InternalParameter_2529);
            bool InternalVar_2 = EditorPrefs.GetBool(InternalVar_1, false);
            InternalType_553 InternalVar_3 = InternalType_553.InternalMethod_2207(InternalVar_2, InternalParameter_2529, InternalParameter_2530);

            if (InternalVar_3 != InternalVar_2)
            {
                EditorPrefs.SetBool(InternalVar_1, InternalVar_3);
            }
            return InternalVar_3;
        }

        public static void InternalMethod_2231(GUIContent InternalParameter_2531, SerializedProperty InternalParameter_2532, bool InternalParameter_2533 = true)
        {
            InternalMethod_2232(InternalType_575.InternalMethod_2302(), InternalParameter_2531, InternalParameter_2532, InternalParameter_2533);
        }

        public static void InternalMethod_2232(Rect InternalParameter_2534, GUIContent InternalParameter_2535, SerializedProperty InternalParameter_2536, bool InternalParameter_2537 = true)
        {
            GUIContent InternalVar_1 = EditorGUI.BeginProperty(InternalParameter_2534, InternalParameter_2535, InternalParameter_2536);

            EditorGUI.BeginChangeCheck();
            Color InternalVar_2 = InternalMethod_2250(InternalParameter_2534, InternalVar_1, InternalParameter_2536.colorValue, InternalParameter_2536.hasMultipleDifferentValues, InternalParameter_2537);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2536.colorValue = InternalVar_2;
            }

            EditorGUI.EndProperty();
        }

        public static Color InternalMethod_2250(Rect InternalParameter_3427, GUIContent InternalParameter_2207, Color InternalParameter_3444, bool InternalParameter_3445, bool InternalParameter_3446 = true)
        {
            float InternalVar_1 = InternalProperty_472;

            Rect InternalVar_2 = InternalParameter_3427;

            float InternalVar_3 = InternalParameter_3445 ? -InternalField_2557 : EditorStyles.label.CalcSize(InternalType_554.InternalField_3627).x;

            if (!string.IsNullOrWhiteSpace(InternalParameter_2207.text))
            {
                InternalVar_2.width = InternalProperty_472 - InternalVar_3;
                InternalParameter_3427.xMin = InternalVar_2.xMax;
            }

            EditorGUI.LabelField(InternalVar_2, InternalParameter_2207);

            Rect InternalVar_4 = InternalParameter_3427;
            InternalVar_4.width = 0;

            Rect InternalVar_5 = InternalParameter_3427;

            if (!InternalParameter_3445)
            {   
                InternalProperty_472 = InternalVar_3;
                InternalVar_4.width = 2 * InternalField_3636 + EditorStyles.numberField.padding.horizontal + InternalVar_3;
                InternalVar_5.xMin = InternalVar_4.xMax - InternalField_2557;
            }

            EditorGUI.BeginDisabledGroup(InternalParameter_3445);
            InternalParameter_3444.a = Mathf.Clamp01(EditorGUI.IntField(InternalVar_4, InternalParameter_3445 ? GUIContent.none : InternalType_554.InternalField_3627, Mathf.RoundToInt(100 * InternalParameter_3444.a)) / 100f);
            EditorGUI.EndDisabledGroup();

            bool InternalVar_6 = EditorGUI.showMixedValue;

            EditorGUI.showMixedValue = InternalParameter_3445;

            InternalParameter_3444 = EditorGUI.ColorField(InternalVar_5, GUIContent.none, InternalParameter_3444, showEyedropper: true, showAlpha: InternalParameter_3446, hdr: false);

            EditorGUI.showMixedValue = InternalVar_6;

            InternalProperty_472 = InternalVar_1;

            return InternalParameter_3444;
        }

        public static void InternalMethod_2233(GUIContent InternalParameter_2538, SerializedProperty InternalParameter_2539, float InternalParameter_2540 = 0, float InternalParameter_2541 = 1)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302();
            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2538, InternalParameter_2539);
            float InternalVar_3 = EditorGUI.Slider(InternalVar_1, InternalVar_2, InternalParameter_2539.floatValue, InternalParameter_2540, InternalParameter_2541);
            EditorGUI.EndProperty();

            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2539.floatValue = InternalVar_3;
            }
        }

        public static void InternalMethod_2234(SerializedProperty InternalParameter_2542, GUIContent InternalParameter_2543)
        {
            bool InternalVar_1 = EditorGUIUtility.wideMode;
            EditorGUIUtility.wideMode = true;
            Rect InternalVar_2 = InternalType_575.InternalMethod_2302();
            GUIContent InternalVar_3 = EditorGUI.BeginProperty(InternalVar_2, InternalParameter_2543, InternalParameter_2542);
            EditorGUI.MultiPropertyField(InternalVar_2, InternalType_554.InternalField_2473, InternalParameter_2542.FindPropertyRelative("X"), InternalVar_3);
            EditorGUI.EndProperty();
            EditorGUIUtility.wideMode = InternalVar_1;
        }

        public static void InternalMethod_2235(GUIContent InternalParameter_2544, SerializedProperty InternalParameter_2545)
        {
            InternalMethod_3377(InternalType_575.InternalMethod_2302(), InternalParameter_2544, InternalParameter_2545);
        }

        public static void InternalMethod_3377(Rect InternalParameter_2085, GUIContent InternalParameter_2086, SerializedProperty InternalParameter_2152)
        {
            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_1 = EditorGUI.BeginProperty(InternalParameter_2085, InternalParameter_2086, InternalParameter_2152);
            bool InternalVar_2 = EditorGUI.Toggle(InternalParameter_2085, InternalVar_1, InternalParameter_2152.boolValue);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2152.boolValue = InternalVar_2;
            }
        }

        public static void InternalMethod_2236(float InternalParameter_2546 = 1)
        {
            GUILayout.Space(InternalParameter_2546 * InternalField_2558);
        }

        public static void InternalMethod_2237(GUIContent InternalParameter_2547, SerializedProperty InternalParameter_2548)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_501);
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2547, InternalParameter_2548);
            EditorGUI.BeginChangeCheck();
            float InternalVar_3 = EditorGUI.FloatField(InternalVar_1, InternalVar_2, InternalParameter_2548.floatValue);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2548.floatValue = InternalVar_3;
            }
            EditorGUI.EndProperty();
        }

        public static void InternalMethod_3004(GUIContent InternalParameter_1749, SerializedProperty InternalParameter_1401, float InternalParameter_1392, float InternalParameter_1068)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_501);
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_1749, InternalParameter_1401);
            EditorGUI.BeginChangeCheck();
            float InternalVar_3 = EditorGUI.FloatField(InternalVar_1, InternalVar_2, InternalParameter_1401.floatValue);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_1401.floatValue = Mathf.Clamp(InternalVar_3, InternalParameter_1392, InternalParameter_1068);
            }
            EditorGUI.EndProperty();
        }

        public static void InternalMethod_2238(GUIContent InternalParameter_2549, SerializedProperty InternalParameter_2550, int InternalParameter_2551, int InternalParameter_2552)
        {
            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_501);
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2549, InternalParameter_2550);
            EditorGUI.BeginChangeCheck();
            int InternalVar_3 = EditorGUI.IntField(InternalVar_1, InternalVar_2, InternalParameter_2550.intValue);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2550.intValue = Mathf.Clamp(InternalVar_3, InternalParameter_2551, InternalParameter_2552);
            }
            EditorGUI.EndProperty();
        }

        public static void InternalMethod_2239(GUIContent InternalParameter_2553, SerializedProperty InternalParameter_2554, int InternalParameter_2555, int InternalParameter_2556)
        {
            EditorGUI.BeginChangeCheck();
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2553, InternalParameter_2554);
            int InternalVar_3 = EditorGUI.IntSlider(InternalVar_1, InternalVar_2, InternalParameter_2554.intValue, InternalParameter_2555, InternalParameter_2556);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2554.intValue = InternalVar_3;
            }
        }

        public static void InternalMethod_2240(GUIContent InternalParameter_2557, SerializedProperty InternalParameter_2558, ThreeD<bool> InternalParameter_2559 = default)
        {
            float InternalVar_1 = InternalProperty_472;

            InternalType_575.InternalMethod_2305();
            InternalMethod_2226(InternalParameter_2557, InternalParameter_2558);

            InternalProperty_472 = InternalField_2550;

            EditorGUI.BeginDisabledGroup(InternalParameter_2559.X);
            InternalMethod_2237(InternalType_554.InternalField_2464, InternalParameter_2558.FindPropertyRelative("x"));
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(InternalParameter_2559.Y);
            InternalMethod_2237(InternalType_554.InternalField_2465, InternalParameter_2558.FindPropertyRelative("y"));
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(InternalParameter_2559.Z);
            InternalMethod_2237(InternalType_554.InternalField_2466, InternalParameter_2558.FindPropertyRelative("z"));
            EditorGUI.EndDisabledGroup();

            InternalType_575.InternalMethod_2307();

            InternalProperty_472 = InternalVar_1;
        }

        public static void InternalMethod_2241(GUIContent InternalParameter_2560, SerializedProperty InternalParameter_2561, TwoD<bool> InternalParameter_2562 = default)
        {
            float InternalVar_1 = InternalProperty_472;

            InternalType_575.InternalMethod_2305();
            InternalMethod_2226(InternalParameter_2560, InternalParameter_2561);

            InternalProperty_472 = InternalField_2550;

            EditorGUI.BeginDisabledGroup(InternalParameter_2562.X);
            InternalMethod_2237(InternalType_554.InternalField_2464, InternalParameter_2561.FindPropertyRelative("x"));
            EditorGUI.EndDisabledGroup();

            EditorGUI.BeginDisabledGroup(InternalParameter_2562.Y);
            InternalMethod_2237(InternalType_554.InternalField_2465, InternalParameter_2561.FindPropertyRelative("y"));
            EditorGUI.EndDisabledGroup();

            InternalType_575.InternalMethod_2307();

            InternalProperty_472 = InternalVar_1;
        }

        public static void InternalMethod_1932(GUIContent InternalParameter_2184, InternalType_593 InternalParameter_2183, Length2.Calculated InternalParameter_2182, Vector2 InternalParameter_2181, Vector2 InternalParameter_2180)
        {
            InternalType_573.InternalType_575.InternalMethod_2305();
            InternalMethod_2225(InternalParameter_2184);

            InternalType_573.InternalType_575.InternalMethod_2304(false, out Rect InternalVar_1, out Rect InternalVar_2, out Rect _);
            float InternalVar_3 = InternalProperty_472;
            InternalProperty_472 = InternalField_2550;
            InternalMethod_1930(InternalVar_1, InternalType_554.InternalField_2464, InternalParameter_2183.InternalProperty_502, InternalParameter_2182.X, InternalParameter_2168: InternalParameter_2181.x, InternalParameter_2167: InternalParameter_2180.x);
            InternalMethod_1930(InternalVar_2, InternalType_554.InternalField_2465, InternalParameter_2183.InternalProperty_504, InternalParameter_2182.Y, InternalParameter_2168: InternalParameter_2181.y, InternalParameter_2167: InternalParameter_2180.y);
            InternalProperty_472 = InternalVar_3;
            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        public static bool InternalMethod_2388(GUIContent InternalParameter_2591, InternalType_595 InternalParameter_2590, InternalType_662 InternalParameter_2589, Length3.Calculated InternalParameter_2588, ThreeD<bool> InternalParameter_2587, bool InternalParameter_2586, bool InternalParameter_2585)
        {
            float InternalVar_1 = InternalProperty_472;

            InternalType_575.InternalMethod_2305();

            InternalParameter_2585 = InternalMethod_2227(InternalParameter_2591, InternalParameter_2585, InternalParameter_2590.InternalProperty_954);

            InternalType_575.InternalMethod_2304(InternalParameter_2586, out Rect InternalVar_2, out Rect InternalVar_3, out Rect InternalVar_4);

            float InternalVar_5 = InternalParameter_2586 && InternalProperty_468 ? InternalField_2560 : InternalField_2559;

            InternalProperty_472 = InternalField_2550;
            EditorGUI.BeginDisabledGroup(InternalParameter_2587.X);
            InternalMethod_1930(InternalVar_2, InternalType_554.InternalField_2464, InternalParameter_2590.InternalProperty_510, InternalParameter_2588.X, InternalParameter_2589.InternalProperty_546.InternalProperty_540, InternalParameter_2589.InternalProperty_546.InternalProperty_538, InternalVar_5);
            EditorGUI.EndDisabledGroup();
            EditorGUI.BeginDisabledGroup(InternalParameter_2587.Y);
            InternalMethod_1930(InternalVar_3, InternalType_554.InternalField_2465, InternalParameter_2590.InternalProperty_512, InternalParameter_2588.Y, InternalParameter_2589.InternalProperty_544.InternalProperty_540, InternalParameter_2589.InternalProperty_544.InternalProperty_538, InternalVar_5);
            EditorGUI.EndDisabledGroup();

            if (InternalParameter_2586)
            {
                EditorGUI.BeginDisabledGroup(InternalParameter_2587.Z);
                InternalMethod_1930(InternalVar_4, InternalType_554.InternalField_2466, InternalParameter_2590.InternalProperty_514, InternalParameter_2588.Z, InternalParameter_2589.InternalProperty_542.InternalProperty_540, InternalParameter_2589.InternalProperty_542.InternalProperty_538, InternalVar_5);
                EditorGUI.EndDisabledGroup();
            }
            InternalType_575.InternalMethod_2307();

            if (InternalParameter_2585)
            {
                EditorGUILayout.Space(1);
                InternalMethod_2387(InternalParameter_2590, InternalParameter_2589, InternalParameter_2588, InternalParameter_2586);
            }

            InternalProperty_472 = InternalVar_1;

            return InternalParameter_2585;
        }

        public static void InternalMethod_2387(InternalType_595 InternalParameter_2584, InternalType_662 InternalParameter_2577, Length3.Calculated InternalParameter_2576, bool InternalParameter_2575)
        {
            InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());

            float InternalVar_1 = InternalProperty_472;

            GUIStyle InternalVar_2 = new GUIStyle(InternalType_574.InternalProperty_476);
            InternalVar_2.overflow.left = Mathf.RoundToInt(EditorGUIUtility.currentViewWidth);
            InternalVar_2.overflow.right = 8;

            InternalType_575.InternalMethod_2306(InternalVar_2);
            InternalProperty_472 = InternalField_2550;
            InternalMethod_2382(InternalType_554.InternalField_2464, InternalParameter_2584.InternalProperty_510, InternalParameter_2577.InternalProperty_546, InternalParameter_2576.X, InternalParameter_2584.InternalProperty_510.InternalProperty_508 == LengthType.Value);
            InternalMethod_2382(InternalType_554.InternalField_2465, InternalParameter_2584.InternalProperty_512, InternalParameter_2577.InternalProperty_544, InternalParameter_2576.Y, InternalParameter_2584.InternalProperty_512.InternalProperty_508 == LengthType.Value);

            if (InternalParameter_2575)
            {
                InternalMethod_2382(InternalType_554.InternalField_2466, InternalParameter_2584.InternalProperty_514, InternalParameter_2577.InternalProperty_542, InternalParameter_2576.Z, InternalParameter_2584.InternalProperty_514.InternalProperty_508 == LengthType.Value);
            }

            InternalProperty_472 = InternalVar_1;

            InternalType_575.InternalMethod_2307();
        }

        public static void InternalMethod_2245<T>(GUIContent InternalParameter_2578, SerializedProperty InternalParameter_2579, T InternalParameter_2580) where T : System.Enum
        {
            EditorGUI.BeginChangeCheck();
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2578, InternalParameter_2579);
            System.Enum InternalVar_3 = EditorGUI.EnumFlagsField(InternalVar_1, InternalVar_2, InternalParameter_2580);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2579.intValue = System.Convert.ToInt32(InternalVar_3);
            }
        }

        public static void InternalMethod_2246<T>(GUIContent InternalParameter_2581, SerializedProperty InternalParameter_2582, T InternalParameter_2583) where T : System.Enum
        {
            EditorGUI.BeginChangeCheck();
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();
            GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_2581, InternalParameter_2582);
            System.Enum InternalVar_3 = EditorGUI.EnumPopup(InternalVar_1, InternalVar_2, InternalParameter_2583);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2582.intValue = System.Convert.ToInt32(InternalVar_3);
            }
        }

        public static (bool, bool) InternalMethod_2386(GUIContent InternalParameter_2574, InternalType_598 InternalParameter_2573, InternalType_597 InternalParameter_2572, LengthBounds.Calculated InternalParameter_2571, bool InternalParameter_2570, bool InternalParameter_2569, bool InternalParameter_2568)
        {
            LengthBounds InternalVar_1 = new LengthBounds()
            {
                Left = new Length(InternalParameter_2573.InternalProperty_526.InternalProperty_506, InternalParameter_2573.InternalProperty_526.InternalProperty_508),
                Right = new Length(InternalParameter_2573.InternalProperty_528.InternalProperty_506, InternalParameter_2573.InternalProperty_528.InternalProperty_508),
                Top = new Length(InternalParameter_2573.InternalProperty_532.InternalProperty_506, InternalParameter_2573.InternalProperty_532.InternalProperty_508),
                Bottom = new Length(InternalParameter_2573.InternalProperty_530.InternalProperty_506, InternalParameter_2573.InternalProperty_530.InternalProperty_508),
                Front = new Length(InternalParameter_2573.InternalProperty_534.InternalProperty_506, InternalParameter_2573.InternalProperty_534.InternalProperty_508),
                Back = new Length(InternalParameter_2573.InternalProperty_536.InternalProperty_506, InternalParameter_2573.InternalProperty_536.InternalProperty_508),
            };

            MinMaxBounds InternalVar_2 = new MinMaxBounds()
            {
                Left = new MinMax(InternalParameter_2572.InternalProperty_524.InternalProperty_540, InternalParameter_2572.InternalProperty_524.InternalProperty_538),
                Right = new MinMax(InternalParameter_2572.InternalProperty_522.InternalProperty_540, InternalParameter_2572.InternalProperty_522.InternalProperty_538),
                Top = new MinMax(InternalParameter_2572.InternalProperty_518.InternalProperty_540, InternalParameter_2572.InternalProperty_518.InternalProperty_538),
                Bottom = new MinMax(InternalParameter_2572.InternalProperty_520.InternalProperty_540, InternalParameter_2572.InternalProperty_520.InternalProperty_538),
                Front = new MinMax(InternalParameter_2572.InternalProperty_516.InternalProperty_540, InternalParameter_2572.InternalProperty_516.InternalProperty_538),
                Back = new MinMax(InternalParameter_2572.InternalProperty_299.InternalProperty_540, InternalParameter_2572.InternalProperty_299.InternalProperty_538),
            };

            bool InternalVar_3 = InternalParameter_2570 ? InternalVar_1.InternalMethod_25() : InternalVar_1.XY.InternalMethod_28();

            InternalType_575.InternalMethod_2308();
            Rect InternalVar_4 = InternalType_575.InternalMethod_2302();
            InternalParameter_2569 = InternalType_553.InternalMethod_2208(InternalVar_4, InternalParameter_2569);

            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_5 = EditorGUI.BeginProperty(InternalVar_4, InternalParameter_2574, InternalParameter_2573.InternalProperty_954);
            Length InternalVar_6 = InternalMethod_2384(InternalVar_4, InternalVar_5, InternalVar_1.Left, InternalVar_2.Left, InternalParameter_2571.Left, InternalVar_3, InternalParameter_2407: false);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_594 InternalVar_7 = InternalParameter_2573.InternalProperty_526;

                InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                InternalVar_7.InternalProperty_508 = InternalVar_6.Type;

                InternalVar_7 = InternalParameter_2573.InternalProperty_528;

                InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                InternalVar_7.InternalProperty_508 = InternalVar_6.Type;

                InternalVar_7 = InternalParameter_2573.InternalProperty_532;

                InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                InternalVar_7.InternalProperty_508 = InternalVar_6.Type;

                InternalVar_7 = InternalParameter_2573.InternalProperty_530;

                InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                InternalVar_7.InternalProperty_508 = InternalVar_6.Type;

                if (InternalParameter_2570)
                {
                    InternalVar_7 = InternalParameter_2573.InternalProperty_534;

                    InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                    InternalVar_7.InternalProperty_508 = InternalVar_6.Type;

                    InternalVar_7 = InternalParameter_2573.InternalProperty_536;

                    InternalVar_7.InternalProperty_506 = InternalVar_6.Raw;
                    InternalVar_7.InternalProperty_508 = InternalVar_6.Type;
                }
            }

            if (InternalParameter_2569)
            {
                float InternalVar_7 = InternalProperty_468 ? InternalField_2560 : InternalField_2559;
                float InternalVar_8 = InternalProperty_472;

                EditorGUILayout.Space(1);

                InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
                InternalType_575.InternalMethod_2309(InternalType_574.InternalProperty_475);
                InternalType_575.InternalMethod_2305();
                InternalMethod_2236(0.5f);
                using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
                {
                    InternalType_575.InternalMethod_2305();
                    InternalType_575.InternalMethod_2308();
                    InternalType_575.InternalMethod_2304(InternalParameter_2570, out Rect InternalVar_9, out Rect InternalVar_10, out Rect InternalVar_11);
                    InternalType_575.InternalMethod_2304(InternalParameter_2570, out Rect InternalVar_12, out Rect InternalVar_13, out Rect InternalVar_14);
                    InternalType_575.InternalMethod_2310();
                    InternalType_575.InternalMethod_2307();

                    InternalProperty_472 = InternalField_2553 - 10;
                    InternalMethod_1930(InternalVar_9, InternalType_554.InternalField_2467, InternalParameter_2573.InternalProperty_526, InternalParameter_2571.Left, InternalParameter_2572.InternalProperty_524.InternalProperty_540, InternalParameter_2572.InternalProperty_524.InternalProperty_538, InternalVar_7);
                    InternalMethod_1930(InternalVar_12, InternalType_554.InternalField_2468, InternalParameter_2573.InternalProperty_528, InternalParameter_2571.Right, InternalParameter_2572.InternalProperty_522.InternalProperty_540, InternalParameter_2572.InternalProperty_522.InternalProperty_538, InternalVar_7);
                    InternalProperty_472 = InternalField_2553;
                    InternalMethod_1930(InternalVar_10, InternalType_554.InternalField_2469, InternalParameter_2573.InternalProperty_532, InternalParameter_2571.Top, InternalParameter_2572.InternalProperty_518.InternalProperty_540, InternalParameter_2572.InternalProperty_518.InternalProperty_538, InternalVar_7);
                    InternalMethod_1930(InternalVar_13, InternalType_554.InternalField_2470, InternalParameter_2573.InternalProperty_530, InternalParameter_2571.Bottom, InternalParameter_2572.InternalProperty_520.InternalProperty_540, InternalParameter_2572.InternalProperty_520.InternalProperty_538, InternalVar_7);

                    if (InternalParameter_2570)
                    {
                        InternalProperty_472 = InternalField_2553 - 10;
                        InternalMethod_1930(InternalVar_11, InternalType_554.InternalField_2471, InternalParameter_2573.InternalProperty_534, InternalParameter_2571.Front, InternalParameter_2572.InternalProperty_516.InternalProperty_540, InternalParameter_2572.InternalProperty_516.InternalProperty_538, InternalVar_7);
                        InternalMethod_1930(InternalVar_14, InternalType_554.InternalField_2472, InternalParameter_2573.InternalProperty_536, InternalParameter_2571.Back, InternalParameter_2572.InternalProperty_299.InternalProperty_540, InternalParameter_2572.InternalProperty_299.InternalProperty_538, InternalVar_7);
                    }

                    InternalProperty_472 = InternalVar_8;
                }
                InternalType_575.InternalMethod_2307();

                EditorGUILayout.Space(1);

                InternalType_575.InternalMethod_2305();
                InternalMethod_2236(1.25f);
                InternalVar_4 = InternalType_575.InternalMethod_2302(GUILayout.Width(InternalProperty_469 + 2 * InternalField_2551));

                EditorGUI.BeginChangeCheck();
                GUIContent InternalVar_15 = EditorGUI.BeginProperty(InternalVar_4, InternalType_554.InternalField_2476, InternalParameter_2572.InternalProperty_954);
                InternalParameter_2568 = InternalType_553.InternalMethod_2208(InternalVar_4, InternalParameter_2568);
                EditorGUI.LabelField(InternalVar_4, InternalVar_15);

                float4 InternalVar_16 = new float4(InternalVar_2.Left.Min, InternalVar_2.Right.Min, InternalVar_2.Top.Min, InternalVar_2.Bottom.Min);
                float2 InternalVar_17 = new float2(InternalVar_2.Front.Min, InternalVar_2.Back.Min);

                float4 InternalVar_18 = new float4(InternalVar_2.Left.Max, InternalVar_2.Right.Max, InternalVar_2.Top.Max, InternalVar_2.Bottom.Max);
                float2 InternalVar_19 = new float2(InternalVar_2.Front.Max, InternalVar_2.Back.Max);

                bool InternalVar_20 = InternalParameter_2570 ? math.any(math.isfinite(InternalVar_16) | math.isfinite(InternalVar_17).xxyy) && math.any(math.isinf(InternalVar_16) | math.isinf(InternalVar_17).xxyy) : math.any(math.isfinite(InternalVar_16)) && math.any(math.isinf(InternalVar_16));
                bool InternalVar_21 = InternalParameter_2570 ? math.any(math.isfinite(InternalVar_18) | math.isfinite(InternalVar_19).xxyy) && math.any(math.isinf(InternalVar_18) | math.isinf(InternalVar_17).xxyy) : math.any(math.isfinite(InternalVar_18)) && math.any(math.isinf(InternalVar_18));
                bool InternalVar_22 = InternalParameter_2570 ? InternalVar_2.InternalMethod_2415() : InternalVar_2.XY.InternalMethod_2411();
                bool InternalVar_23 = InternalParameter_2570 ? InternalVar_2.InternalMethod_2414() : InternalVar_2.XY.InternalMethod_2410();
                bool4 InternalVar_24 = new bool4(InternalVar_20, InternalVar_22, InternalVar_21, InternalVar_23);

                MinMax InternalVar_25 = InternalMethod_2383(GUIContent.none, InternalVar_1.Left, InternalVar_2.Left, InternalParameter_2571.Left, false, InternalParameter_2382: true, InternalVar_24);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalType_599 InternalVar_26 = InternalParameter_2572.InternalProperty_524;
                    InternalType_594 InternalVar_27 = InternalParameter_2573.InternalProperty_526;
                    InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                    InternalVar_26.InternalProperty_538 = InternalVar_25.Max;

                    InternalVar_26 = InternalParameter_2572.InternalProperty_522;
                    InternalVar_27 = InternalParameter_2573.InternalProperty_528;
                    InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                    InternalVar_26.InternalProperty_538 = InternalVar_25.Max;

                    InternalVar_26 = InternalParameter_2572.InternalProperty_518;
                    InternalVar_27 = InternalParameter_2573.InternalProperty_532;
                    InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                    InternalVar_26.InternalProperty_538 = InternalVar_25.Max;

                    InternalVar_26 = InternalParameter_2572.InternalProperty_520;
                    InternalVar_27 = InternalParameter_2573.InternalProperty_530;
                    InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                    InternalVar_26.InternalProperty_538 = InternalVar_25.Max;

                    if (InternalParameter_2570)
                    {
                        InternalVar_26 = InternalParameter_2572.InternalProperty_516;
                        InternalVar_27 = InternalParameter_2573.InternalProperty_534;
                        InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                        InternalVar_26.InternalProperty_538 = InternalVar_25.Max;

                        InternalVar_26 = InternalParameter_2572.InternalProperty_299;
                        InternalVar_27 = InternalParameter_2573.InternalProperty_536;
                        InternalVar_26.InternalProperty_540 = InternalVar_25.Min;
                        InternalVar_26.InternalProperty_538 = InternalVar_25.Max;
                    }
                }

                InternalType_575.InternalMethod_2307();

                if (InternalParameter_2568)
                {
                    InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
                    InternalType_575.InternalMethod_2306(InternalType_574.InternalProperty_475);
                    InternalMethod_2236(3);
                    InternalMethod_2385(InternalParameter_2573, InternalParameter_2572, InternalParameter_2571, InternalParameter_2570);
                    InternalType_575.InternalMethod_2307();
                }

                InternalType_575.InternalMethod_2310();
            }

            InternalType_575.InternalMethod_2310();

            return (InternalParameter_2569, InternalParameter_2568);
        }

        public static void InternalMethod_2385(InternalType_598 InternalParameter_2567, InternalType_597 InternalParameter_2416, LengthBounds.Calculated InternalParameter_2415, bool InternalParameter_2414)
        {
            float InternalVar_1 = InternalProperty_472;

            InternalType_575.InternalMethod_2305();
            InternalType_575.InternalMethod_2308();
            InternalProperty_472 = InternalField_2553 - 10;
            InternalMethod_2382(InternalType_554.InternalField_2467, InternalParameter_2567.InternalProperty_526, InternalParameter_2416.InternalProperty_524, InternalParameter_2415.Left, InternalParameter_2567.InternalProperty_526.InternalProperty_508 == LengthType.Value);
            InternalMethod_2382(InternalType_554.InternalField_2468, InternalParameter_2567.InternalProperty_528, InternalParameter_2416.InternalProperty_522, InternalParameter_2415.Right, InternalParameter_2567.InternalProperty_528.InternalProperty_508 == LengthType.Value);
            InternalType_575.InternalMethod_2310();
            InternalType_575.InternalMethod_2308();
            InternalProperty_472 = InternalField_2553;
            InternalMethod_2382(InternalType_554.InternalField_2469, InternalParameter_2567.InternalProperty_532, InternalParameter_2416.InternalProperty_518, InternalParameter_2415.Top, InternalParameter_2567.InternalProperty_532.InternalProperty_508 == LengthType.Value);

            Rect InternalVar_2 = GUILayoutUtility.GetLastRect();
            InternalVar_2.y += InternalVar_2.height + InternalField_2557;
            InternalVar_2.height = 1;
            InternalVar_2.width = EditorGUIUtility.currentViewWidth;
            InternalVar_2.x = 0;

            InternalType_574.InternalMethod_2290(InternalVar_2, InternalType_574.InternalProperty_474);

            InternalMethod_2382(InternalType_554.InternalField_2470, InternalParameter_2567.InternalProperty_530, InternalParameter_2416.InternalProperty_520, InternalParameter_2415.Bottom, InternalParameter_2567.InternalProperty_530.InternalProperty_508 == LengthType.Value);
            InternalType_575.InternalMethod_2310();
            if (InternalParameter_2414)
            {
                InternalType_575.InternalMethod_2308();
                InternalProperty_472 = InternalField_2553 - 10;
                InternalMethod_2382(InternalType_554.InternalField_2471, InternalParameter_2567.InternalProperty_534, InternalParameter_2416.InternalProperty_516, InternalParameter_2415.Front, InternalParameter_2567.InternalProperty_534.InternalProperty_508 == LengthType.Value);
                InternalMethod_2382(InternalType_554.InternalField_2472, InternalParameter_2567.InternalProperty_536, InternalParameter_2416.InternalProperty_299, InternalParameter_2415.Back, InternalParameter_2567.InternalProperty_536.InternalProperty_508 == LengthType.Value);
                InternalType_575.InternalMethod_2310();
            }
            InternalType_575.InternalMethod_2307();

            InternalProperty_472 = InternalVar_1;
        }

        public static void InternalMethod_2249(InternalType_600 InternalParameter_2595, UIBlock InternalParameter_2596, GUIContent[] InternalParameter_2597)
        {
            float InternalVar_1 = InternalProperty_471;

            InternalType_575.InternalMethod_2305();
            Rect InternalVar_2 = InternalType_575.InternalMethod_2302();
            InternalVar_2.width *= 0.5f;
            InternalVar_2.x += (0.5f * InternalVar_2.width) - (InternalField_2551 + InternalField_2557) * 0.5f;

            Rect InternalVar_3 = InternalVar_2;
            InternalVar_3.x = 0;
            InternalVar_3.width = InternalVar_1;

            EditorGUI.BeginProperty(InternalVar_3, GUIContent.none, InternalParameter_2595.InternalProperty_574);
            EditorGUI.BeginChangeCheck();
            Rect InternalVar_4 = InternalVar_2;
            InternalVar_4.width = InternalField_2551 + InternalField_2557;
            bool InternalVar_5 = InternalParameter_2595.InternalProperty_573 != Axis.None;
            bool InternalVar_6 = GUI.Toggle(InternalVar_4, InternalVar_5, new GUIContent() { tooltip = InternalVar_5 ? "Unlock Aspect Ratio" : "Lock Aspect Ratio" }, InternalType_574.InternalProperty_489);
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2595.InternalProperty_573 = !InternalVar_6 ? Axis.None : Axis.X;

                if (InternalParameter_2595.InternalProperty_573 != Axis.None)
                {
                    InternalParameter_2595.InternalProperty_571 = InternalParameter_2596.CalculatedSize[0].Value == 0 ? Vector3.zero : InternalParameter_2596.CalculatedSize.Value / InternalParameter_2596.CalculatedSize[0].Value;
                }
            }

            EditorGUI.BeginChangeCheck();
            EditorGUI.BeginDisabledGroup(!InternalVar_6);
            InternalVar_2.width -= InternalVar_4.width;
            InternalVar_2.x += InternalVar_4.width;
            float InternalVar_7 = InternalMethod_3332(InternalParameter_2596) ? InternalVar_2.width / 3f : InternalVar_2.width / 2f;
            int InternalVar_8 = InternalMethod_1887(InternalVar_2, InternalParameter_2595.InternalProperty_573.Index(), InternalParameter_2597, InternalVar_7);
            EditorGUI.EndDisabledGroup();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2595.InternalProperty_573 = !InternalVar_6 ? Axis.None : (Axis)(InternalVar_8 + 1);

                if (InternalParameter_2595.InternalProperty_573 != Axis.None)
                {
                    InternalParameter_2595.InternalProperty_571 = InternalParameter_2596.CalculatedSize.Value / InternalParameter_2596.CalculatedSize[InternalVar_8].Value;
                }
            }
            EditorGUI.EndProperty();
            InternalType_575.InternalMethod_2307();
        }

        public static Length InternalMethod_2384(Rect InternalParameter_2413, GUIContent InternalParameter_2412, Length InternalParameter_2411, MinMax InternalParameter_2410, Length.Calculated InternalParameter_2409, bool InternalParameter_2408, bool InternalParameter_2407)
        {
            bool InternalVar_1 = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = InternalParameter_2408;

            bool InternalVar_2 = InternalParameter_2410.Min == InternalParameter_2410.Max;
            bool InternalVar_3 = InternalParameter_2411.Raw == InternalParameter_2410.Min;
            bool InternalVar_4 = InternalParameter_2411.Raw == InternalParameter_2410.Max;

            GUIStyle InternalVar_5 = InternalParameter_2407 ?
                                       InternalVar_2 ? InternalType_574.InternalProperty_485 :
                                       InternalVar_3 ? InternalType_574.InternalProperty_482 :
                                       InternalVar_4 ? InternalType_574.InternalProperty_483 :
                                       EditorStyles.numberField : EditorStyles.numberField;

            float InternalVar_6 = InternalProperty_473 < InternalField_2561 ? InternalField_2560 : InternalField_2559;

            Rect InternalVar_7 = InternalParameter_2413;
            InternalVar_7.width = Mathf.Max(InternalField_2560, InternalVar_7.width - InternalVar_6) - InternalField_2557;
            EditorGUI.BeginChangeCheck();
            float InternalVar_8 = InternalParameter_2411.Raw;
            float InternalVar_9 = float.IsNaN(InternalVar_8) ? 0 : InternalParameter_2411.Type == LengthType.Value ? InternalVar_8 : InternalVar_8 * 100;
            InternalVar_9 = EditorGUI.FloatField(InternalVar_7, InternalParameter_2412, InternalVar_9, InternalVar_5);
            InternalVar_8 = InternalVar_9 / (InternalParameter_2411.Type == LengthType.Value ? 1 : 100);
            bool InternalVar_10 = EditorGUI.EndChangeCheck();

            EditorGUI.BeginChangeCheck();
            Rect InternalVar_11 = InternalVar_7;
            InternalVar_11.width = InternalVar_6;
            InternalVar_11.x += InternalVar_7.width + InternalField_2557;
            LengthType InternalVar_12 = InternalMethod_2257(InternalVar_11, InternalParameter_2411.Type);
            bool InternalVar_13 = EditorGUI.EndChangeCheck();

            EditorGUI.showMixedValue = InternalVar_1;

            if (InternalVar_13)
            {
                InternalParameter_2411.Type = InternalVar_12;
                InternalParameter_2411.Raw = InternalParameter_2411.Type == LengthType.Value ? InternalParameter_2409.Value : InternalParameter_2409.Percent;
            }

            if (InternalVar_10)
            {
                InternalParameter_2411.Raw = InternalVar_8;
            }

            if (InternalParameter_2411.Type == LengthType.Value)
            {
                InternalParameter_2411.Raw = InternalParameter_2410.Clamp(InternalParameter_2411.Raw);
            }

            return InternalParameter_2411;
        }

        public static void InternalMethod_1930(Rect InternalParameter_2172, GUIContent InternalParameter_2171, InternalType_594 InternalParameter_2170, Length.Calculated InternalParameter_2169, float InternalParameter_2168 = float.NegativeInfinity, float InternalParameter_2167 = float.PositiveInfinity, float InternalParameter_2166 = InternalField_2559)
        {
            EditorGUI.BeginDisabledGroup(InternalProperty_682);
            bool InternalVar_1 = InternalParameter_2168 == InternalParameter_2167;
            bool InternalVar_2 = InternalParameter_2170.InternalProperty_506 <= InternalParameter_2168;
            bool InternalVar_3 = InternalParameter_2170.InternalProperty_506 >= InternalParameter_2167;

            GUIStyle InternalVar_4 = InternalParameter_2170.InternalProperty_508 == LengthType.Value ?
                                       InternalVar_1 ? InternalType_574.InternalProperty_485 :
                                       InternalVar_2 ? InternalType_574.InternalProperty_482 :
                                       InternalVar_3 ? InternalType_574.InternalProperty_483 :
                                       EditorStyles.numberField : EditorStyles.numberField;

            GUIContent InternalVar_5 = EditorGUI.BeginProperty(InternalParameter_2172, InternalParameter_2171, InternalParameter_2170.InternalProperty_954);
            Rect InternalVar_6 = InternalParameter_2172;
            InternalVar_6.width = Mathf.Max(InternalField_2560, InternalVar_6.width - InternalParameter_2166) - InternalField_2557;
            EditorGUI.BeginChangeCheck();
            float InternalVar_7 = InternalParameter_2170.InternalProperty_506;

            float InternalVar_8 = 0;
            if (!float.IsNaN(InternalVar_7))
            {
                if (InternalProperty_682)
                {
                    InternalVar_8 = InternalParameter_2170.InternalProperty_508 == LengthType.Value ? InternalParameter_2169.Percent * 100f : InternalParameter_2169.Value;
                }
                else
                {
                    InternalVar_8 = InternalParameter_2170.InternalProperty_508 == LengthType.Value ? InternalVar_7 : InternalVar_7 * 100;
                }
            }

            InternalVar_8 = EditorGUI.FloatField(InternalVar_6, InternalVar_5, InternalVar_8, InternalVar_4);
            InternalVar_7 = InternalVar_8 / (InternalParameter_2170.InternalProperty_508 == LengthType.Value ? 1 : 100);
            bool InternalVar_9 = EditorGUI.EndChangeCheck();

            EditorGUI.BeginChangeCheck();
            Rect InternalVar_10 = InternalVar_6;
            InternalVar_10.width = InternalParameter_2166;
            InternalVar_10.x += InternalVar_6.width + InternalField_2557;
            
            LengthType InternalVar_11 = InternalMethod_2257(InternalVar_10, !InternalProperty_682 ? InternalParameter_2170.InternalProperty_509.hasMultipleDifferentValues ? (LengthType)(-1) : InternalParameter_2170.InternalProperty_508 : (InternalParameter_2170.InternalProperty_508 == LengthType.Value ? LengthType.Percent : LengthType.Value));
            
            bool InternalVar_12 = EditorGUI.EndChangeCheck();
            EditorGUI.EndProperty();

            if (InternalVar_12)
            {
                InternalMethod_2252(InternalParameter_2170, InternalVar_11);
            }

            if (InternalVar_9)
            {
                InternalParameter_2170.InternalProperty_506 = InternalVar_7;
            }

            EditorGUI.EndDisabledGroup();
        }

        public static void InternalMethod_2252(InternalType_594 InternalParameter_2611, LengthType InternalParameter_2612)
        {
            Object[] InternalVar_1 = InternalParameter_2611.InternalProperty_954.serializedObject.targetObjects;

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Length; ++InternalVar_2)
            {
                float InternalVar_3 = InternalMethod_2262(InternalVar_1[InternalVar_2] as UIBlock, InternalParameter_2611.InternalProperty_954.propertyPath, InternalParameter_2612);
                InternalMethod_2253(InternalVar_1[InternalVar_2], InternalParameter_2611.InternalProperty_507.propertyPath, InternalVar_3);
            }

            InternalParameter_2611.InternalProperty_954.serializedObject.UpdateIfRequiredOrScript();
            InternalParameter_2611.InternalProperty_508 = InternalParameter_2612;
            InternalParameter_2611.InternalProperty_954.serializedObject.ApplyModifiedProperties();
        }

        public static void InternalMethod_2253(Object InternalParameter_2613, string InternalParameter_2614, float InternalParameter_2615)
        {
            SerializedObject InternalVar_1 = new SerializedObject(InternalParameter_2613);
            SerializedProperty InternalVar_2 = InternalVar_1.FindProperty($"{InternalParameter_2614}");

            InternalVar_2.floatValue = InternalParameter_2615;

            InternalVar_2.serializedObject.ApplyModifiedProperties();
        }

        public static T InternalMethod_2254<T>(Rect InternalParameter_2616, T InternalParameter_2617, GUIContent[] InternalParameter_2618, float InternalParameter_2619 = 2 * InternalField_2550) where T : struct, System.Enum
        {
            Rect InternalVar_1 = InternalParameter_2616;
            InternalVar_1.width = InternalParameter_2619;
            InternalVar_1.height = EditorGUIUtility.singleLineHeight;

            string[] InternalVar_2 = System.Enum.GetNames(typeof(T));
            T InternalVar_3 = InternalParameter_2617;
            for (int InternalVar_4 = 0; InternalVar_4 < InternalVar_2.Length; ++InternalVar_4)
            {
                if (InternalVar_4 >= InternalParameter_2618.Length)
                {
                    break;
                }

                if (!System.Enum.TryParse(InternalVar_2[InternalVar_4], out T InternalVar_5))
                {
                    continue;
                }

                GUIStyle InternalVar_6 = InternalVar_4 == 0 ? InternalType_574.InternalProperty_478 : InternalVar_4 == InternalParameter_2618.Length - 1 ? InternalType_574.InternalProperty_481 : InternalType_574.InternalProperty_480;
                bool InternalVar_7 = InternalVar_5.Equals(InternalParameter_2617);
                bool InternalVar_8 = GUI.Toggle(InternalVar_1, InternalVar_7, InternalParameter_2618[InternalVar_4], style: InternalVar_6);

                InternalVar_1.x += InternalParameter_2619;

                if (InternalVar_8 && !InternalVar_7)
                {
                    InternalVar_3 = InternalVar_5;

                    if (EditorGUIUtility.editingTextField)
                    {
                        EditorGUI.FocusTextInControl(null);
                    }
                }
            }

            return InternalVar_3;
        }

        public static int InternalMethod_1887(Rect InternalParameter_2226, int InternalParameter_2164, GUIContent[] InternalParameter_2077, float InternalParameter_2076, bool InternalParameter_1796 = false, int InternalParameter_1797 = -1)
        {
            Rect InternalVar_1 = InternalParameter_2226;
            InternalVar_1.width = InternalParameter_2076;
            InternalVar_1.height = EditorGUIUtility.singleLineHeight;

            int InternalVar_2 = InternalParameter_2164;
            for (int InternalVar_3 = 0; InternalVar_3 < InternalParameter_2077.Length; ++InternalVar_3)
            {
                GUIStyle InternalVar_4 = InternalVar_3 == 0 ? InternalType_574.InternalProperty_478 : InternalVar_3 == InternalParameter_2077.Length - 1 ? InternalType_574.InternalProperty_481 : InternalType_574.InternalProperty_480;
                bool InternalVar_5 = InternalVar_3 == InternalParameter_2164;
                EditorGUI.BeginDisabledGroup(InternalVar_3 == InternalParameter_1797);
                bool InternalVar_6 = GUI.Toggle(InternalVar_1, InternalVar_5, InternalParameter_2077[InternalVar_3], style: InternalVar_4);
                EditorGUI.EndDisabledGroup();

                InternalVar_1.x += InternalParameter_2076;

                if (InternalVar_6 && !InternalVar_5)
                {
                    InternalVar_2 = InternalVar_3;

                    if (EditorGUIUtility.editingTextField)
                    {
                        EditorGUI.FocusTextInControl(null);
                    }
                }
                else if (InternalParameter_1796 && !InternalVar_6 && InternalVar_5)
                {
                    InternalVar_2 = -1;

                    if (EditorGUIUtility.editingTextField)
                    {
                        EditorGUI.FocusTextInControl(null);
                    }
                }
            }

            return InternalVar_2;
        }

        public static int InternalMethod_2256(Rect InternalParameter_2625, int InternalParameter_2626, GUIContent[] InternalParameter_2627)
        {
            return InternalMethod_1887(InternalParameter_2625, InternalParameter_2626, InternalParameter_2627, InternalParameter_2625.width / InternalParameter_2627.Length);
        }

        public static LengthType InternalMethod_2257(Rect InternalParameter_2628, LengthType InternalParameter_2629)
        {
            return (LengthType)InternalMethod_1887(InternalParameter_2628, (int)InternalParameter_2629, InternalType_554.InternalField_2460, InternalParameter_2628.width * 0.5f);
        }

        public static MinMax InternalMethod_2383(GUIContent InternalParameter_2393, Length InternalParameter_2392, MinMax InternalParameter_2390, Length.Calculated InternalParameter_2389, bool InternalParameter_2388, bool InternalParameter_2382 = false, bool4 InternalParameter_2179 = default)
        {
            float InternalVar_1 = InternalProperty_472;

            using var InternalVar_2 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);

            InternalType_575.InternalMethod_2309(EditorStyles.inspectorFullWidthMargins);

            bool InternalVar_3 = !string.IsNullOrEmpty(InternalParameter_2393.text);

            Rect InternalVar_4 = InternalType_575.InternalMethod_2305();
            if (InternalVar_3)
            {
                Rect InternalVar_5 = InternalType_575.InternalMethod_2302(GUILayout.Width(InternalProperty_472), GUILayout.Height(InternalParameter_2382 ? EditorGUIUtility.singleLineHeight : 2 * EditorGUIUtility.singleLineHeight));
                EditorGUI.LabelField(InternalVar_5, InternalParameter_2393);
            }

            GUIStyle InternalVar_6 = InternalParameter_2388 && InternalParameter_2392.Raw == InternalParameter_2390.Min ? InternalType_574.InternalProperty_482 : EditorStyles.numberField;
            GUIStyle InternalVar_7 = InternalParameter_2388 && InternalParameter_2392.Raw == InternalParameter_2390.Max ? InternalType_574.InternalProperty_483 : EditorStyles.numberField;

            if (InternalParameter_2382)
            {
                InternalType_575.InternalMethod_2305();
            }
            else
            {
                InternalType_575.InternalMethod_2308();
            }

            InternalProperty_472 = 3f * InternalField_2550;
            EditorGUI.BeginChangeCheck();
            InternalParameter_2390.Min = InternalMethod_2260(InternalType_554.InternalField_2474, InternalParameter_2390.Min, InternalParameter_2389.Value, float.NegativeInfinity, InternalVar_6, InternalParameter_2179.xy);
            InternalParameter_2390.Max = InternalMethod_2260(InternalType_554.InternalField_2475, InternalParameter_2390.Max, InternalParameter_2389.Value, float.PositiveInfinity, InternalVar_7, InternalParameter_2179.zw);
            bool InternalVar_8 = EditorGUI.EndChangeCheck();

            if (InternalParameter_2382)
            {
                InternalType_575.InternalMethod_2307();
            }
            else
            {
                InternalType_575.InternalMethod_2310();
            }

            InternalVar_2.Dispose();

            InternalType_575.InternalMethod_2307();
            InternalType_575.InternalMethod_2310();

            InternalProperty_472 = InternalVar_1;

            float InternalVar_9 = Mathf.Min(InternalParameter_2390.Min, InternalParameter_2390.Max);
            float InternalVar_10 = Mathf.Max(InternalParameter_2390.Min, InternalParameter_2390.Max);

            InternalParameter_2390.Min = InternalVar_9;
            InternalParameter_2390.Max = InternalVar_10;

            return InternalParameter_2390;
        }

        public static void InternalMethod_2382(GUIContent InternalParameter_2178, InternalType_594 InternalParameter_2177, InternalType_599 InternalParameter_2176, Length.Calculated InternalParameter_2175, bool InternalParameter_2174)
        {
            float InternalVar_1 = InternalProperty_472;

            bool InternalVar_2 = !string.IsNullOrEmpty(InternalParameter_2178.text);

            if (InternalVar_2)
            {
                InternalType_575.InternalMethod_2309(InternalType_574.InternalProperty_477);
                Rect InternalVar_3 = InternalType_575.InternalMethod_2302(GUILayout.Width(InternalProperty_472));
                GUIContent InternalVar_4 = EditorGUI.BeginProperty(InternalVar_3, InternalParameter_2178, InternalParameter_2176.InternalProperty_954);
                EditorGUI.LabelField(InternalVar_3, InternalVar_4);
            }
            else
            {
                InternalType_575.InternalMethod_2306(InternalType_574.InternalProperty_477);

                InternalType_575.InternalMethod_2302(GUILayout.Width(InternalProperty_472));
            }

            using var InternalVar_5 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);
            GUIStyle InternalVar_6 = InternalParameter_2174 && InternalParameter_2177.InternalProperty_506 == InternalParameter_2176.InternalProperty_540 ? InternalType_574.InternalProperty_482 : EditorStyles.numberField;
            GUIStyle InternalVar_7 = InternalParameter_2174 && InternalParameter_2177.InternalProperty_506 == InternalParameter_2176.InternalProperty_538 ? InternalType_574.InternalProperty_483 : EditorStyles.numberField;

            InternalType_575.InternalMethod_2308();
            InternalProperty_472 = 3f * InternalField_2550;
            EditorGUI.BeginChangeCheck();
            InternalMethod_2261(InternalType_554.InternalField_2474, InternalParameter_2176.InternalProperty_539, InternalParameter_2175.Value, float.NegativeInfinity, InternalVar_6);
            InternalMethod_2261(InternalType_554.InternalField_2475, InternalParameter_2176.InternalProperty_525, InternalParameter_2175.Value, float.PositiveInfinity, InternalVar_7, InternalParameter_2176.InternalProperty_540);
            bool InternalVar_8 = EditorGUI.EndChangeCheck();
            InternalType_575.InternalMethod_2310();
            InternalVar_5.Dispose();

            if (InternalVar_2)
            {
                EditorGUI.EndProperty();
                InternalType_575.InternalMethod_2310();
            }
            else
            {
                InternalType_575.InternalMethod_2307();
            }

            InternalProperty_472 = InternalVar_1;

            if (InternalVar_8)
            {
                float InternalVar_9 = Mathf.Min(InternalParameter_2176.InternalProperty_540, InternalParameter_2176.InternalProperty_538);
                float InternalVar_10 = Mathf.Max(InternalParameter_2176.InternalProperty_540, InternalParameter_2176.InternalProperty_538);

                InternalParameter_2176.InternalProperty_540 = InternalVar_9;
                InternalParameter_2176.InternalProperty_538 = InternalVar_10;
            }
        }

        public static float InternalMethod_2260(GUIContent InternalParameter_2642, float InternalParameter_2643, float InternalParameter_2644, float InternalParameter_2645, GUIStyle InternalParameter_2646, bool2 InternalParameter_2647 = default)
        {
            bool InternalVar_1 = EditorGUI.showMixedValue;
            InternalType_575.InternalMethod_2305();
            bool InternalVar_2 = InternalParameter_2643 != InternalParameter_2645;

            EditorGUI.showMixedValue = InternalParameter_2647.x; 
            Rect InternalVar_3 = InternalType_575.InternalMethod_2302(GUILayout.Width(InternalField_2551));
            bool InternalVar_4 = EditorGUI.Toggle(InternalVar_3, InternalVar_2);
            EditorGUI.BeginDisabledGroup(!InternalVar_4);

            int InternalVar_5 = InternalParameter_2646.fontSize;
            TextAnchor InternalVar_6 = InternalParameter_2646.alignment;
            InternalParameter_2646.fontSize = InternalParameter_2643 == InternalParameter_2645 ? 10 : 12;
            InternalParameter_2646.alignment = TextAnchor.MiddleLeft;

            EditorGUI.showMixedValue = InternalParameter_2647.y; 
            Rect InternalVar_7 = InternalType_575.InternalMethod_2302(InternalType_575.InternalProperty_501);
            InternalParameter_2643 = EditorGUI.FloatField(InternalVar_7, InternalParameter_2642, InternalParameter_2643, InternalParameter_2646);

            InternalParameter_2646.fontSize = InternalVar_5;
            InternalParameter_2646.alignment = InternalVar_6;

            EditorGUI.EndDisabledGroup();

            EditorGUI.showMixedValue = InternalVar_1;

            InternalType_575.InternalMethod_2307();

            if (InternalVar_2 && !InternalVar_4)
            {
                return InternalParameter_2645;
            }

            if (!InternalVar_2 && InternalVar_4)
            {
                return InternalParameter_2644;
            }

            return InternalParameter_2643;
        }

        public static void InternalMethod_2261(GUIContent InternalParameter_679, SerializedProperty InternalParameter_682, float InternalParameter_681, float InternalParameter_677, GUIStyle InternalParameter_676, float? InternalParameter_683 = null)
        {
            InternalType_575.InternalMethod_2305();

            Rect InternalVar_1 = InternalType_575.InternalMethod_2302(GUILayout.MinWidth(InternalField_2560 + InternalField_2551));
            Rect InternalVar_2 = InternalVar_1;
            InternalVar_2.width = InternalField_2551;

            Rect InternalVar_3 = InternalVar_1;
            InternalVar_3.width -= InternalField_2551;
            InternalVar_3.x += InternalField_2551 + InternalField_2557;

            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_4 = EditorGUI.BeginProperty(InternalVar_1, InternalParameter_679, InternalParameter_682);
            bool InternalVar_5 = InternalParameter_682.floatValue != InternalParameter_677;
            bool InternalVar_6 = EditorGUI.Toggle(InternalVar_2, InternalVar_5);
            EditorGUI.BeginDisabledGroup(!InternalVar_6);

            int InternalVar_7 = InternalParameter_676.fontSize;
            TextAnchor InternalVar_8 = InternalParameter_676.alignment;
            InternalParameter_676.fontSize = !InternalVar_6 ? 10 : 12;
            InternalParameter_676.alignment = TextAnchor.MiddleLeft;

            float InternalVar_9 = EditorGUI.FloatField(InternalVar_3, InternalVar_4, InternalParameter_682.floatValue, InternalParameter_676);

            InternalParameter_676.fontSize = InternalVar_7;
            InternalParameter_676.alignment = InternalVar_8;

            EditorGUI.EndDisabledGroup();
            EditorGUI.EndProperty();
            bool InternalVar_10 = EditorGUI.EndChangeCheck();
            InternalType_575.InternalMethod_2307();

            if (InternalVar_10)
            {
                if (InternalParameter_683.HasValue && !float.IsInfinity(InternalParameter_683.Value))
                {
                    InternalVar_9 = Mathf.Max(InternalParameter_683.Value, InternalVar_9);
                }

                if (InternalVar_5 && !InternalVar_6)
                {
                    InternalParameter_682.floatValue = InternalParameter_677;
                }

                else if (!InternalVar_5 && InternalVar_6)
                {
                    InternalParameter_682.floatValue = InternalParameter_681;
                }
                else
                {
                    InternalParameter_682.floatValue = InternalVar_9;
                }
            }
        }

        #region 
        
        public static float InternalMethod_2262(UIBlock InternalParameter_2653, string InternalParameter_2654, LengthType InternalParameter_2655)
        {
            string[] InternalVar_1 = InternalParameter_2654.Split('.');

            if (InternalVar_1[0].Equals(nameof(UIBlock.AutoLayout), System.StringComparison.InvariantCultureIgnoreCase))
            {
                Length.Calculated InternalVar_2 = InternalParameter_2653.CalculatedSpacing;
                return InternalParameter_2655 == LengthType.Value ? InternalVar_2.Value : InternalVar_2.Percent;
            }

            if (InternalVar_1[0].Equals(nameof(UIBlock.Layout), System.StringComparison.InvariantCultureIgnoreCase))
            {
                return InternalMethod_2263(InternalParameter_2653, InternalVar_1, InternalParameter_2655);
            }

            switch (InternalParameter_2653)
            {
                case UIBlock2D uiBlock2D:
                    return InternalMethod_2265(uiBlock2D, InternalVar_1, InternalParameter_2655);
                case UIBlock3D uiblock3D:
                    return InternalMethod_2264(uiblock3D, InternalVar_1, InternalParameter_2655);
            }

            Debug.LogError("Matching calculated property path not found.");

            return float.NaN;
        }

        
        private static float InternalMethod_2263(UIBlock InternalParameter_2656, string[] InternalParameter_2657, LengthType InternalParameter_2658)
        {
            PropertyInfo InternalVar_1 = typeof(UIBlock).GetProperty(nameof(UIBlock.InternalProperty_17), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo InternalVar_2 = InternalVar_1.PropertyType.GetField($"{InternalParameter_2657[1]}", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo InternalVar_3 = InternalVar_2.FieldType.GetField(InternalParameter_2657[2], BindingFlags.Public | BindingFlags.Instance);

            Length.Calculated InternalVar_4 = (Length.Calculated)InternalVar_3.GetValue(InternalVar_2.GetValue(InternalVar_1.GetValue(InternalParameter_2656)));

            return InternalParameter_2658 == LengthType.Value ? InternalVar_4.Value : InternalVar_4.Percent;
        }

        
        private static float InternalMethod_2264(UIBlock3D InternalParameter_2659, string[] InternalParameter_2660, LengthType InternalParameter_2661)
        {
            PropertyInfo InternalVar_1 = typeof(UIBlock3D).GetProperty(nameof(UIBlock3D.InternalProperty_43), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo InternalVar_2 = InternalVar_1.PropertyType.GetField($"{InternalParameter_2660[1]}", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            Length.Calculated InternalVar_3 = (Length.Calculated)InternalVar_2.GetValue(InternalVar_1.GetValue(InternalParameter_2659));
            return InternalParameter_2661 == LengthType.Value ? InternalVar_3.Value : InternalVar_3.Percent;
        }

        
        private static float InternalMethod_2265(UIBlock2D InternalParameter_2662, string[] InternalParameter_2663, LengthType InternalParameter_2664)
        {
            PropertyInfo InternalVar_1 = typeof(UIBlock2D).GetProperty(nameof(UIBlock2D.InternalProperty_42), BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo InternalVar_2 = InternalVar_1.PropertyType.GetField(InternalParameter_2663[1], BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            Length.Calculated InternalVar_3 = default;

            if (InternalParameter_2663.Length == 2)
            {
                InternalVar_3 = (Length.Calculated)InternalVar_2.GetValue(InternalVar_1.GetValue(InternalParameter_2662));
            }
            else
            {
                FieldInfo InternalVar_4 = InternalVar_2.FieldType.GetField(InternalParameter_2663[2], BindingFlags.Public | BindingFlags.Instance);

                if (InternalParameter_2663.Length == 3)
                {
                    InternalVar_3 = (Length.Calculated)InternalVar_4.GetValue(InternalVar_2.GetValue(InternalVar_1.GetValue(InternalParameter_2662)));
                }
                else
                {
                    FieldInfo InternalVar_5 = InternalVar_4.FieldType.GetField(InternalParameter_2663[3], BindingFlags.Public | BindingFlags.Instance);

                    InternalVar_3 = (Length.Calculated)InternalVar_5.GetValue(InternalVar_4.GetValue(InternalVar_2.GetValue(InternalVar_1.GetValue(InternalParameter_2662))));
                }
            }

            return InternalParameter_2664 == LengthType.Value ? InternalVar_3.Value : InternalVar_3.Percent;
        }
        #endregion
    }
}

