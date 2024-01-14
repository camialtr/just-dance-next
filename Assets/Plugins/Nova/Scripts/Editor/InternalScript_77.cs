// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_17.InternalNamespace_21;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using static Nova.InternalNamespace_17.InternalNamespace_18.InternalType_573;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal static class InternalType_577
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2596 = "Visuals";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2597 = "Body";

        public static void InternalMethod_1929(float InternalParameter_2165, InternalType_604 InternalParameter_1598, InternalType_610 InternalParameter_1597, InternalType_611 InternalParameter_359, ref InternalType_550 InternalParameter_346, ref InternalType_8.Calculated InternalParameter_345)
        {
            using (InternalType_553 bodyFoldout = InternalType_573.InternalMethod_2230(InternalField_2597, InternalParameter_1598.InternalProperty_616))
            {
                if (bodyFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);

                    InternalMethod_1966(InternalParameter_1598, ref InternalParameter_345);
                    InternalMethod_2333(InternalParameter_1598, ref InternalParameter_346);
                }
            }

            using (InternalType_553 visualsFoldout = InternalType_573.InternalMethod_2229(InternalField_2596))
            {
                if (visualsFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);

                    InternalType_573.InternalMethod_2235(InternalType_554.InternalType_560.InternalField_2501, InternalParameter_359.InternalProperty_673);
                    InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_558.InternalField_2496, InternalParameter_1598.InternalProperty_603, InternalParameter_345.CornerRadius, InternalParameter_2168: 0, InternalParameter_2167: InternalParameter_2165);
                    InternalMethod_3378(InternalParameter_1598.InternalProperty_1056, InternalParameter_345.RadialFill);
                    InternalMethod_2331(InternalParameter_359);
                    InternalType_573.InternalMethod_2235(InternalType_554.InternalType_558.InternalField_2497, InternalParameter_1598.InternalProperty_614);
                    InternalMethod_2335(InternalParameter_1597, false);
                }
            }
        }

        
        public static void InternalMethod_2327(InternalType_611 InternalParameter_2732, InternalType_610 InternalParameter_2733, InternalType_548 InternalParameter_2734)
        {
            using (InternalType_553 bodyFoldout = InternalType_573.InternalMethod_2229(InternalField_2597))
            {
                if (bodyFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);
                    TextBlock InternalVar_2 = InternalParameter_2732.InternalProperty_954.serializedObject.targetObject as TextBlock;
                    InternalMethod_2337(InternalParameter_2734);
                }
            }

            using (InternalType_553 visualsFoldout = InternalType_573.InternalMethod_2229(InternalField_2596))
            {
                if (visualsFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);
                    InternalType_573.InternalMethod_2235(InternalType_554.InternalType_560.InternalField_2501, InternalParameter_2732.InternalProperty_673);
                    InternalMethod_2331(InternalParameter_2732);
                    InternalMethod_2335(InternalParameter_2733, false);
                }
            }
        }

        public static void InternalMethod_1492(Vector3 InternalParameter_344, InternalType_612 InternalParameter_343, InternalType_610 InternalParameter_342, InternalType_611 InternalParameter_341, ref InternalType_10.Calculated InternalParameter_340)
        {
            using (InternalType_553 bodyFoldout = InternalType_573.InternalMethod_2229(InternalField_2597))
            {
                if (bodyFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);
                    InternalMethod_2231(InternalType_554.InternalType_559.InternalField_2498, InternalParameter_343.InternalProperty_675);
                }
            }

            using (InternalType_553 visualsFoldout = InternalType_573.InternalMethod_2229(InternalField_2596))
            {
                if (visualsFoldout)
                {
                    using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);

                    InternalType_573.InternalMethod_2235(InternalType_554.InternalType_560.InternalField_2501, InternalParameter_341.InternalProperty_673);
                    float InternalVar_2 = Mathf.Min(InternalParameter_344.x, InternalParameter_344.y);
                    InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_559.InternalField_2499, InternalParameter_343.InternalProperty_676, InternalParameter_340.CornerRadius, InternalParameter_2168: 0, InternalParameter_2167: 0.5f * InternalVar_2);
                    InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_559.InternalField_2500, InternalParameter_343.InternalProperty_678, InternalParameter_340.EdgeRadius, InternalParameter_2168: 0, InternalParameter_2167: 0.5f * Mathf.Min(InternalVar_2, InternalParameter_344.z));
                    InternalMethod_2335(InternalParameter_342, true);
                }
            }
        }

        public static void InternalMethod_3378(InternalType_642 InternalParameter_1795, RadialFill.Calculated InternalParameter_2394)
        {
            InternalType_573.InternalType_575.InternalMethod_2305();

            EditorGUI.BeginChangeCheck();
            bool InternalVar_1 = InternalType_573.InternalMethod_2228(InternalType_534.InternalProperty_332);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_332 = InternalVar_1;
            }

            Rect InternalVar_2 = InternalType_573.InternalType_575.InternalMethod_2302();
            InternalVar_2.x -= InternalType_553.InternalField_2445 + InternalType_573.InternalField_2557;
            InternalType_573.InternalMethod_3377(InternalVar_2, InternalType_554.InternalType_207.InternalField_3395, InternalParameter_1795.InternalProperty_1065);

            InternalType_573.InternalType_575.InternalMethod_2307();

            if (!InternalVar_1)
            {
                return;
            }


            InternalType_573.InternalType_575.InternalMethod_2306(InternalType_573.InternalType_574.InternalProperty_475);
            InternalType_573.InternalMethod_2236(4f / 3f);
            InternalType_573.InternalType_575.InternalMethod_2308();

            EditorGUI.BeginDisabledGroup(!InternalParameter_1795.InternalProperty_1064);

            InternalType_573.InternalMethod_1932(InternalType_554.InternalType_207.InternalField_3396, InternalParameter_1795.InternalProperty_1058, InternalParameter_2394.Center, MinMax2.Unclamped.Min, MinMax2.Unclamped.Max);
            InternalType_573.InternalMethod_2233(InternalType_554.InternalType_207.InternalField_3397, InternalParameter_1795.InternalProperty_1061, InternalParameter_2540: -360f, InternalParameter_2541: 360f);
            InternalType_573.InternalMethod_2233(InternalType_554.InternalType_207.InternalField_3398, InternalParameter_1795.InternalProperty_1063, InternalParameter_2540: -360f, InternalParameter_2541: 360f);

            EditorGUI.EndDisabledGroup();

            InternalType_573.InternalType_575.InternalMethod_2310();
            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        public static void InternalMethod_1423(InternalType_606 InternalParameter_126, Border.Calculated InternalParameter_125)
        {
            using (InternalType_553 foldout = InternalType_573.InternalMethod_2230("Border", InternalParameter_126.InternalProperty_632))
            {
                using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
                {
                    if (foldout)
                    {
                        InternalMethod_2231(InternalType_554.InternalType_571.InternalField_2541, InternalParameter_126.InternalProperty_628);

                        InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_571.InternalField_2542, InternalParameter_126.InternalProperty_629, InternalParameter_125.Width, InternalParameter_2168: 0);

                        Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();
                        GUIContent InternalVar_2 = EditorGUI.BeginProperty(InternalVar_1, InternalType_554.InternalType_571.InternalField_2543, InternalParameter_126.InternalProperty_634);
                        EditorGUI.BeginChangeCheck();
                        BorderDirection InternalVar_3 = (BorderDirection)EditorGUI.EnumPopup(InternalVar_1, InternalVar_2, InternalParameter_126.InternalProperty_633);
                        if (EditorGUI.EndChangeCheck())
                        {
                            InternalParameter_126.InternalProperty_633 = InternalVar_3;
                        }
                        EditorGUI.EndProperty();
                    }
                }
            }
        }

        public static void InternalMethod_480(InternalType_604 InternalParameter_124, Shadow.Calculated InternalParameter_123)
        {
            using (InternalType_553 foldout = InternalType_573.InternalMethod_2230("Shadow", InternalParameter_124.InternalProperty_609.InternalProperty_644))
            {
                if (!foldout)
                {
                    return;
                }

                using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);


                InternalType_607 InternalVar_2 = InternalParameter_124.InternalProperty_609;
                Rect InternalVar_3 = InternalType_573.InternalType_575.InternalMethod_2302();
                EditorGUI.BeginChangeCheck();
                GUIContent InternalVar_4 = EditorGUI.BeginProperty(InternalVar_3, InternalType_554.InternalType_570.InternalField_2537, InternalVar_2.InternalProperty_646);
                ShadowDirection InternalVar_5 = (ShadowDirection)EditorGUI.EnumPopup(InternalVar_3, InternalVar_4, InternalVar_2.InternalProperty_645);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalVar_2.InternalProperty_645 = InternalVar_5;
                }

                InternalType_573.InternalMethod_2231(InternalType_554.InternalType_570.InternalField_2536, InternalVar_2.InternalProperty_636);
                InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_570.InternalField_2538, InternalVar_2.InternalProperty_637, InternalParameter_123.Width);
                InternalType_573.InternalMethod_1930(InternalType_573.InternalType_575.InternalMethod_2302(), InternalType_554.InternalType_570.InternalField_2539, InternalVar_2.InternalProperty_639, InternalParameter_123.Blur, InternalParameter_2168: 0);
                InternalType_573.InternalMethod_1932(InternalType_554.InternalType_570.InternalField_2540, InternalVar_2.InternalProperty_641, InternalParameter_123.Offset, MinMax2.Unclamped.Min, MinMax2.Unclamped.Max);
            }
        }

        public static void InternalMethod_2331(InternalType_611 InternalParameter_2741)
        {
            using var InternalVar_1 = new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel);

            Rect InternalVar_2 = InternalType_573.InternalType_575.InternalMethod_2302();
            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_3 = EditorGUI.BeginProperty(InternalVar_2, InternalType_554.InternalType_560.InternalField_2502, InternalParameter_2741.InternalProperty_669);
            short InternalVar_4 = (short)EditorGUI.IntField(InternalVar_2, InternalVar_3, InternalParameter_2741.InternalProperty_669.intValue);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2741.InternalProperty_669.intValue = InternalVar_4;
            }
        }

        public static void InternalMethod_1966(InternalType_604 InternalParameter_2205, ref InternalType_8.Calculated InternalParameter_2199)
        {
            EditorGUI.BeginChangeCheck();
            InternalType_573.InternalType_575.InternalMethod_2308();
            InternalType_573.InternalType_575.InternalMethod_2305();
            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Width(InternalType_553.InternalField_2445));
            bool InternalVar_2 = InternalType_553.InternalMethod_2208(InternalVar_1, InternalType_534.InternalProperty_450);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_450 = InternalVar_2;
            }

            InternalType_573.InternalMethod_2236(-InternalType_573.InternalType_575.InternalField_2593);
            InternalType_573.InternalMethod_2231(InternalType_554.InternalType_558.InternalField_2495, InternalParameter_2205.InternalProperty_602);
            InternalType_573.InternalType_575.InternalMethod_2307();

            EditorGUILayout.Space(1);

            if (InternalVar_2)
            {
                InternalMethod_478(InternalParameter_2205.InternalProperty_605, InternalParameter_2199.Gradient);
            }

            InternalType_573.InternalType_575.InternalMethod_2310();
        }

        public static void InternalMethod_2333(InternalType_604 InternalParameter_2744, ref InternalType_550 InternalParameter_2745)
        {
            SerializedObject InternalVar_1 = InternalParameter_2744.InternalProperty_954.serializedObject;
            SerializedProperty InternalVar_2 = InternalVar_1.FindProperty(InternalType_646.InternalType_658.InternalField_2990);
            SerializedProperty InternalVar_3 = InternalVar_1.FindProperty(InternalType_646.InternalType_658.InternalField_2991);

            bool InternalVar_4 = InternalType_534.InternalProperty_452;

            using (new EditorGUI.IndentLevelScope(-EditorGUI.indentLevel))
            {
                EditorGUI.BeginChangeCheck();
                InternalType_573.InternalType_575.InternalMethod_2308();
                InternalType_573.InternalType_575.InternalMethod_2305();
                Rect InternalVar_5 = InternalType_573.InternalType_575.InternalMethod_2302();
                InternalVar_4 = InternalType_553.InternalMethod_2208(InternalVar_5, InternalVar_4);
                if (EditorGUI.EndChangeCheck())
                {
                    InternalType_534.InternalProperty_452 = InternalVar_4;
                }

                InternalVar_5.xMax -= InternalType_573.InternalField_2559 + InternalType_573.InternalField_2557;

                switch (InternalParameter_2745)
                {
                    case InternalType_550.InternalField_2440:
                        {
                            InternalType_609 InternalVar_6 = InternalParameter_2744.InternalProperty_611.InternalProperty_647;
                            if (InternalVar_6.InternalProperty_655 == ImageScaleMode.Sliced && !InternalVar_6.InternalProperty_656.hasMultipleDifferentValues)
                            {
                                Rect InternalVar_7 = InternalVar_5;
                                InternalVar_7.xMin += EditorGUIUtility.labelWidth;
                                InternalType_573.InternalMethod_3639(InternalVar_7, InternalType_554.InternalType_569.InternalField_3635);
                            }

                            EditorGUI.BeginChangeCheck();
                            GUIContent InternalVar_8 = EditorGUI.BeginProperty(InternalVar_5, InternalType_554.InternalType_569.InternalField_2530, InternalVar_2);
                            Texture InternalVar_9 = EditorGUI.ObjectField(InternalVar_5, InternalVar_8, InternalVar_2.objectReferenceValue, typeof(Texture), false) as Texture;
                            EditorGUI.EndProperty();
                            bool InternalVar_10 = EditorGUI.EndChangeCheck();
                            if (!InternalVar_10)
                            {
                                break;
                            }

                            if (InternalVar_9 == null)
                            {
                                InternalVar_2.objectReferenceValue = null;
                            }
                            else if (InternalVar_9 is Texture2D || InternalVar_9 is RenderTexture)
                            {
                                InternalVar_2.objectReferenceValue = InternalVar_9;
                            }
                            else
                            {
                                Debug.LogError("Unsupported texture type. Texture must be a Texture2D or RenderTexture");
                                InternalVar_2.objectReferenceValue = null;
                            }

                            break;
                        }
                    case InternalType_550.InternalField_2441:
                        {
                            EditorGUI.BeginChangeCheck();
                            GUIContent InternalVar_6 = EditorGUI.BeginProperty(InternalVar_5, InternalType_554.InternalType_569.InternalField_2530, InternalVar_3);
                            Sprite InternalVar_7 = EditorGUI.ObjectField(InternalVar_5, InternalVar_6, InternalVar_3.objectReferenceValue, typeof(Sprite), false) as Sprite;
                            EditorGUI.EndProperty();
                            bool InternalVar_8 = EditorGUI.EndChangeCheck();
                            if (!InternalVar_8)
                            {
                                break;
                            }

                            InternalVar_3.objectReferenceValue = InternalVar_7;

                            if (!(InternalVar_7 is Sprite newSprite))
                            {
                                break;
                            }
                            break;
                        }
                }

                Rect InternalVar_11 = InternalVar_5;
                InternalVar_11.x = InternalVar_11.xMax + InternalType_573.InternalField_2557;
                InternalVar_11.width = InternalType_573.InternalField_2559;
                EditorGUI.BeginChangeCheck();
                Rect InternalVar_12 = InternalVar_11;
                InternalVar_12.width += InternalType_573.InternalField_2550;
                InternalType_550 InternalVar_13 = InternalType_573.InternalMethod_2254(InternalVar_11, InternalParameter_2745, InternalType_554.InternalType_569.InternalField_2535);
                bool InternalVar_14 = EditorGUI.EndChangeCheck() && InternalVar_13 != InternalParameter_2745;
                InternalType_573.InternalType_575.InternalMethod_2307();
                InternalType_573.InternalType_575.InternalMethod_2310();

                if (InternalVar_14)
                {
                    InternalVar_2.objectReferenceValue = null;
                    InternalVar_3.objectReferenceValue = null;
                    InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_653 = Vector2.one;
                    InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_651 = Vector2.zero;
                    InternalParameter_2745 = InternalVar_13;
                }

                if (InternalVar_4)
                {
                    EditorGUILayout.Space(1);
                    InternalType_573.InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
                    InternalType_573.InternalType_575.InternalMethod_2306(InternalType_573.InternalType_574.InternalProperty_475);
                    InternalType_573.InternalMethod_2236(1.5f);
                    InternalType_573.InternalType_575.InternalMethod_2308();

                    Rect InternalVar_15 = InternalType_573.InternalType_575.InternalMethod_2302();
                    EditorGUI.BeginChangeCheck();
                    GUIContent InternalVar_16 = EditorGUI.BeginProperty(InternalVar_15, InternalType_554.InternalType_569.InternalField_2532, InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_656);
                    ImageScaleMode InternalVar_17 = (ImageScaleMode)EditorGUI.EnumPopup(InternalVar_15, InternalVar_16, InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_655);
                    EditorGUI.EndProperty();
                    if (EditorGUI.EndChangeCheck())
                    {
                        InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_653 = Vector2.one;
                        InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_651 = Vector2.zero;
                        InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_655 = InternalVar_17;
                    }

                    if (InternalVar_17 == ImageScaleMode.Manual)
                    {
                        InternalType_573.InternalMethod_2241(InternalType_554.InternalType_569.InternalField_2533, InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_652);
                        InternalType_573.InternalMethod_2241(InternalType_554.InternalType_569.InternalField_2534, InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_654);
                    }
                    else if (InternalVar_17 == ImageScaleMode.Sliced || InternalVar_17 == ImageScaleMode.Tiled)
                    {
                        InternalType_573.InternalMethod_3004(InternalType_554.InternalType_569.InternalField_1333, InternalParameter_2744.InternalProperty_611.InternalProperty_647.InternalProperty_1068, .01f, float.MaxValue);
                    }

                    if (NovaSettings.PackedImagesEnabled)
                    {
                        Rect InternalVar_18 = InternalType_573.InternalType_575.InternalMethod_2302();
                        EditorGUI.BeginChangeCheck();
                        GUIContent InternalVar_19 = EditorGUI.BeginProperty(InternalVar_18, InternalType_554.InternalType_569.InternalField_2531, InternalParameter_2744.InternalProperty_611.InternalProperty_650);
                        ImagePackMode InternalVar_20 = InternalParameter_2744.InternalProperty_611.InternalProperty_649;
                        ImagePackMode InternalVar_21 = (ImagePackMode)EditorGUI.EnumPopup(InternalVar_18, InternalVar_19, InternalVar_20);
                        EditorGUI.EndProperty();
                        if (EditorGUI.EndChangeCheck() && InternalVar_20 != InternalVar_21)
                        {
                            InternalParameter_2744.InternalProperty_611.InternalProperty_649 = InternalVar_21;
                        }
                    }


                    InternalType_573.InternalType_575.InternalMethod_2310();
                    InternalType_573.InternalType_575.InternalMethod_2307();
                }


            }
        }

        private static void InternalMethod_3337()
        {
            InternalType_573.InternalMethod_3336(InternalType_554.InternalType_567.InternalField_3355);

            EditorGUI.BeginDisabledGroup(true);

            Rect InternalVar_1 = InternalType_573.InternalType_575.InternalMethod_2302();
            EditorGUI.EnumPopup(InternalVar_1, InternalType_554.InternalType_567.InternalField_2516, SurfacePreset.Unlit);

            EditorGUI.EndDisabledGroup();
        }

        private static void InternalMethod_2335(InternalType_610 InternalParameter_2747, bool InternalParameter_2748)
        {
            if (InternalType_333.InternalProperty_1033)
            {
                InternalMethod_3337();
                return;
            }

            InternalType_573.InternalType_575.InternalMethod_2305();

            bool InternalVar_1 = false;

            if (InternalParameter_2747.InternalProperty_663 != LightingModel.Unlit)
            {
                EditorGUI.BeginChangeCheck();
                Rect InternalVar_2 = InternalType_573.InternalType_575.InternalMethod_2302(GUILayout.Width(InternalType_553.InternalField_2445));
                InternalVar_1 = InternalType_553.InternalMethod_2208(InternalVar_2, InternalType_534.InternalProperty_451);
                if (EditorGUI.EndChangeCheck())
                {
                    InternalType_534.InternalProperty_451 = InternalVar_1;
                }

                InternalType_573.InternalMethod_2236(-1f);
            }

            SurfacePreset InternalVar_3 = InternalType_590.InternalMethod_2355(InternalParameter_2747);

            Rect InternalVar_4 = InternalType_573.InternalType_575.InternalMethod_2302();
            EditorGUI.BeginChangeCheck();
            bool InternalVar_5 = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = InternalParameter_2747.InternalProperty_954.hasMultipleDifferentValues;
            InternalVar_3 = (SurfacePreset)EditorGUI.EnumPopup(InternalVar_4, InternalType_554.InternalType_567.InternalField_2516, InternalVar_3);
            EditorGUI.showMixedValue = InternalVar_5;
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_590.InternalMethod_2356(InternalVar_3, InternalParameter_2747);
            }

            InternalType_573.InternalType_575.InternalMethod_2307();

            if (!InternalVar_1 || InternalVar_3 == SurfacePreset.Unlit || InternalParameter_2747.InternalProperty_664.hasMultipleDifferentValues)
            {
                return;
            }

            InternalType_573.InternalType_575.InternalMethod_2306(InternalType_574.InternalProperty_475);
            InternalType_573.InternalMethod_2236(1.5f);
            InternalType_573.InternalType_575.InternalMethod_2308();

            Rect InternalVar_6 = InternalType_573.InternalType_575.InternalMethod_2302();
            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_7 = EditorGUI.BeginProperty(InternalVar_6, InternalType_554.InternalType_567.InternalField_2517, InternalParameter_2747.InternalProperty_664);
            LightingModel InternalVar_8 = (LightingModel)EditorGUI.EnumPopup(InternalVar_6, InternalVar_7, InternalParameter_2747.InternalProperty_663);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_590.InternalMethod_569(InternalParameter_2747, InternalVar_8);
            }

            Rect InternalVar_9 = InternalType_573.InternalType_575.InternalMethod_2302();
            EditorGUI.BeginChangeCheck();
            GUIContent InternalVar_10 = EditorGUI.BeginProperty(InternalVar_9, InternalType_554.InternalType_567.InternalField_2518, InternalParameter_2747.InternalProperty_666);
            ShadowCastingMode InternalVar_11 = (ShadowCastingMode)EditorGUI.EnumPopup(InternalVar_9, InternalVar_10, InternalParameter_2747.InternalProperty_665);
            EditorGUI.EndProperty();
            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2747.InternalProperty_665 = InternalVar_11;
            }

            if (InternalParameter_2748)
            {
                Rect InternalVar_12 = InternalType_573.InternalType_575.InternalMethod_2302();
                EditorGUI.BeginChangeCheck();
                GUIContent InternalVar_13 = EditorGUI.BeginProperty(InternalVar_12, InternalType_554.InternalType_567.InternalField_2519, InternalParameter_2747.InternalProperty_668);
                bool InternalVar_14 = EditorGUI.Toggle(InternalVar_12, InternalVar_13, InternalParameter_2747.InternalProperty_667);
                EditorGUI.EndProperty();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2747.InternalProperty_667 = InternalVar_14;
                }
            }


            switch (InternalVar_8)
            {
                case LightingModel.Lambert:
                    break;
                case LightingModel.BlinnPhong:
                    InternalType_573.InternalMethod_2233(InternalType_554.InternalType_567.InternalField_2520, InternalParameter_2747.InternalProperty_660, 0, 1);
                    InternalType_573.InternalMethod_2233(InternalType_554.InternalType_567.InternalField_2521, InternalParameter_2747.InternalProperty_662, 0, 1);
                    break;
                case LightingModel.Standard:
                    InternalType_573.InternalMethod_2233(InternalType_554.InternalType_567.InternalField_2522, InternalParameter_2747.InternalProperty_662, 0, 1);
                    InternalType_573.InternalMethod_2233(InternalType_554.InternalType_567.InternalField_2523, InternalParameter_2747.InternalProperty_660, 0, 1);
                    break;
                case LightingModel.StandardSpecular:
                    InternalType_573.InternalMethod_2231(InternalType_554.InternalType_567.InternalField_2524, InternalParameter_2747.InternalProperty_658, false);
                    InternalType_573.InternalMethod_2233(InternalType_554.InternalType_567.InternalField_2523, InternalParameter_2747.InternalProperty_660, 0, 1);
                    break;
                default:
                    break;
            }

            InternalType_573.InternalType_575.InternalMethod_2310();
            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        private static void InternalMethod_478(InternalType_605 InternalParameter_119, RadialGradient.Calculated InternalParameter_118)
        {
            InternalType_573.InternalType_575.InternalMethod_2306(InternalType_573.InternalType_574.InternalProperty_475);
            InternalType_573.InternalType_575.InternalMethod_2308();
            InternalType_573.InternalType_575.InternalMethod_2305();

            InternalType_573.InternalMethod_2236(4f / 3f);

            EditorGUI.BeginChangeCheck();
            bool InternalVar_1 = InternalType_573.InternalMethod_2228(InternalType_534.InternalProperty_453);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_453 = InternalVar_1;
            }

            EditorGUI.BeginChangeCheck();

            Rect InternalVar_2 = InternalType_573.InternalType_575.InternalMethod_2302();
            Rect InternalVar_3 = InternalVar_2;
            InternalVar_3.width = InternalType_573.InternalProperty_472;
            InternalVar_3.width += InternalType_573.InternalField_2551;
            InternalVar_3.x -= InternalType_573.InternalField_2558 + InternalType_573.InternalField_2557;

            Rect InternalVar_4 = InternalVar_2;
            InternalVar_4.xMin = InternalVar_3.xMax;

            GUIContent InternalVar_5 = EditorGUI.BeginProperty(InternalVar_3, InternalType_554.InternalType_568.InternalField_2525, InternalParameter_119.InternalProperty_626);
            InternalParameter_119.InternalProperty_625 = EditorGUI.Toggle(InternalVar_3, InternalVar_5, InternalParameter_119.InternalProperty_625);
            EditorGUI.EndProperty();

            EditorGUI.BeginDisabledGroup(!InternalParameter_119.InternalProperty_625);

            InternalType_573.InternalMethod_2232(InternalVar_4, InternalType_554.InternalType_568.InternalField_2526, InternalParameter_119.InternalProperty_618);
            EditorGUI.EndDisabledGroup();

            if (EditorGUI.EndChangeCheck() && InternalParameter_119.InternalProperty_625)
            {
                InternalParameter_119.InternalMethod_2518();
                UnityEditor.EditorTools.ToolManager.SetActiveTool<InternalType_708>();
            }

            InternalType_573.InternalType_575.InternalMethod_2307();

            if (InternalVar_1)
            {
                InternalType_573.InternalMethod_2236(2 / InternalType_573.InternalField_2558);
                InternalType_573.InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
                InternalType_573.InternalType_575.InternalMethod_2306(InternalType_573.InternalType_574.InternalProperty_475);
                InternalType_573.InternalMethod_2236(2.5f);
                InternalType_573.InternalType_575.InternalMethod_2308();
                EditorGUI.BeginDisabledGroup(!InternalParameter_119.InternalProperty_625);

                InternalType_573.InternalMethod_1932(InternalType_554.InternalType_568.InternalField_2527, InternalParameter_119.InternalProperty_619, InternalParameter_118.Center, MinMax2.Unclamped.Min, MinMax2.Unclamped.Max);
                InternalType_573.InternalMethod_1932(InternalType_554.InternalType_568.InternalField_2528, InternalParameter_119.InternalProperty_621, InternalParameter_118.Radius, MinMax2.Positive.Min, MinMax2.Positive.Max);
                InternalType_573.InternalMethod_2237(InternalType_554.InternalType_568.InternalField_2529, InternalParameter_119.InternalProperty_624);

                EditorGUI.EndDisabledGroup();
                InternalType_573.InternalType_575.InternalMethod_2310();
                InternalType_573.InternalType_575.InternalMethod_2307();
            }

            InternalType_573.InternalType_575.InternalMethod_2310();
            InternalType_573.InternalType_575.InternalMethod_2307();
        }

        private static void InternalMethod_2337(InternalType_548 InternalParameter_2750)
        {
            InternalType_573.InternalType_575.InternalMethod_2305();
            EditorGUI.BeginChangeCheck();
            bool InternalVar_1 = InternalType_573.InternalMethod_2228(InternalType_534.InternalProperty_454);
            InternalType_573.InternalMethod_2236(-InternalType_573.InternalType_575.InternalField_2593);
            if (EditorGUI.EndChangeCheck())
            {
                InternalType_534.InternalProperty_454 = InternalVar_1;
            }

            EditorGUI.BeginChangeCheck();
            EditorGUI.BeginChangeCheck();
            Rect InternalVar_2 = InternalType_573.InternalType_575.InternalMethod_2302();

            string InternalVar_3 = null;
            using (var scope = InternalParameter_2750.InternalField_2430 ? InternalType_719.InternalMethod_3246() : default)
            {
                InternalVar_3 = EditorGUI.TextField(InternalVar_2, InternalType_554.InternalType_572.InternalField_2545, InternalParameter_2750.InternalProperty_458);
            }

            if (EditorGUI.EndChangeCheck())
            {
                InternalParameter_2750.InternalProperty_458 = InternalVar_3;
            }

            EditorGUILayout.LabelField(InternalType_554.InternalType_572.InternalField_2549, GUILayout.Width(InternalType_573.InternalField_2551));
            InternalType_573.InternalType_575.InternalMethod_2307();
            if (InternalVar_1)
            {
                InternalType_573.InternalType_574.InternalMethod_3438(GUILayoutUtility.GetLastRect());
                InternalType_573.InternalType_575.InternalMethod_2306(InternalType_573.InternalType_574.InternalProperty_475);
                InternalType_573.InternalMethod_2236(1.5f);
                InternalType_573.InternalType_575.InternalMethod_2308();

                int InternalVar_4 = InternalParameter_2750.InternalField_2431 ? -1000 : InternalMethod_2338(InternalParameter_2750.InternalProperty_459);
                int InternalVar_5 = InternalParameter_2750.InternalField_2432 ? -1000 : InternalMethod_2340(InternalParameter_2750.InternalProperty_460);
                EditorGUI.BeginChangeCheck();
                (int InternalVar_6, int InternalVar_7) = InternalType_576.InternalMethod_214(InternalType_554.InternalType_572.InternalField_2544, InternalVar_4, InternalVar_5, InternalType_554.InternalField_83);
                if (EditorGUI.EndChangeCheck())
                {
                    if (InternalVar_6 != InternalVar_4)
                    {
                        InternalParameter_2750.InternalProperty_459 = InternalMethod_2339(InternalVar_6);
                    }

                    if (InternalVar_7 != InternalVar_5)
                    {
                        InternalParameter_2750.InternalProperty_460 = InternalMethod_2341(InternalVar_7);
                    }
                }

                EditorGUI.BeginChangeCheck();
                Rect InternalVar_8 = InternalType_573.InternalType_575.InternalMethod_2302();
                Color InternalVar_9 = InternalType_573.InternalMethod_2250(InternalVar_8, InternalType_554.InternalType_572.InternalField_2546, InternalParameter_2750.InternalProperty_461, InternalParameter_2750.InternalField_2433);
                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2750.InternalProperty_461 = InternalVar_9;
                }

                EditorGUI.BeginChangeCheck();
                Rect InternalVar_10 = InternalType_573.InternalType_575.InternalMethod_2302();
                TMPro.TMP_FontAsset InternalVar_11 = null;
                using (var scope = InternalParameter_2750.InternalField_2434 ? InternalType_719.InternalMethod_3246() : default)
                {
                    InternalVar_11 = EditorGUI.ObjectField(InternalVar_10, InternalType_554.InternalType_572.InternalField_2547, InternalParameter_2750.InternalProperty_462, typeof(TMPro.TMP_FontAsset), allowSceneObjects: false) as TMPro.TMP_FontAsset;
                }
                if (EditorGUI.EndChangeCheck())
                {
                    InternalMethod_570(InternalVar_11);
                    InternalParameter_2750.InternalProperty_462 = InternalVar_11;
                }

                EditorGUI.BeginChangeCheck();
                Rect InternalVar_12 = InternalType_573.InternalType_575.InternalMethod_2302();
                float InternalVar_13 = 0f;
                using (var scope = InternalParameter_2750.InternalField_2435 ? InternalType_719.InternalMethod_3246() : default)
                {
                    InternalVar_13 = EditorGUI.FloatField(InternalVar_12, InternalType_554.InternalType_572.InternalField_2548, InternalParameter_2750.InternalProperty_463);
                }

                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2750.InternalProperty_463 = InternalVar_13;
                }

                InternalType_573.InternalType_575.InternalMethod_2310();
                InternalType_573.InternalType_575.InternalMethod_2307();
            }

            if (EditorGUI.EndChangeCheck())
            {
                InternalType_180.InternalMethod_849();
            }
        }

        private static void InternalMethod_570(TMPro.TMP_FontAsset InternalParameter_3105)
        {
            if (InternalType_325.InternalMethod_1950(InternalParameter_3105.material.shader))
            {
                return;
            }


            bool InternalVar_1 = EditorUtility.DisplayDialog("Unsupported TMP Shader", $"The provided font is using an unsupported TMP shader: [{InternalParameter_3105.material.shader.name}]. Nova currently only supports the [{InternalType_178.InternalField_479}] shader.\n\nWould you like to change the font over to use the supported shader?", "Yes", "No");

            if (!InternalVar_1)
            {
                return;
            }

            Shader InternalVar_2 = InternalType_325.InternalMethod_1953();
            if (InternalVar_2 == null)
            {
                Debug.LogWarning($"Failed to change the shader to {InternalType_178.InternalField_479} on the font {InternalParameter_3105.name}. Please change it manually.", InternalParameter_3105);
                return;
            }

            InternalParameter_3105.material.shader = InternalVar_2;
        }

        private static int InternalMethod_2338(TMPro.HorizontalAlignmentOptions InternalParameter_2751)
        {
            switch (InternalParameter_2751)
            {
                case TMPro.HorizontalAlignmentOptions.Left:
                    return -1;
                case TMPro.HorizontalAlignmentOptions.Right:
                    return 1;
            }

            return 0;
        }

        private static TMPro.HorizontalAlignmentOptions InternalMethod_2339(int InternalParameter_2752)
        {
            switch (InternalParameter_2752)
            {
                case -1:
                    return TMPro.HorizontalAlignmentOptions.Left;
                case 1:
                    return TMPro.HorizontalAlignmentOptions.Right;
            }

            return TMPro.HorizontalAlignmentOptions.Center;
        }

        private static int InternalMethod_2340(TMPro.VerticalAlignmentOptions InternalParameter_2753)
        {
            switch (InternalParameter_2753)
            {
                case TMPro.VerticalAlignmentOptions.Bottom:
                    return -1;
                case TMPro.VerticalAlignmentOptions.Top:
                    return 1;
            }

            return 0;
        }

        private static TMPro.VerticalAlignmentOptions InternalMethod_2341(int InternalParameter_2754)
        {
            switch (InternalParameter_2754)
            {
                case -1:
                    return TMPro.VerticalAlignmentOptions.Bottom;
                case 1:
                    return TMPro.VerticalAlignmentOptions.Top;
            }

            return TMPro.VerticalAlignmentOptions.Middle;
        }
    }
}

