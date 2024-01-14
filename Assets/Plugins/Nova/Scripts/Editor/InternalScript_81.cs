// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Text;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
#if UNITY_2021_2_OR_NEWER
    [EditorTool(displayName: "Spacing Tool", componentToolTarget: typeof(UIBlock))]
#else
    [EditorToolAttribute(displayName: "Spacing Tool", targetType = typeof(UIBlock))]
#endif
    internal class InternalType_710 : InternalType_700
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static InternalType_710 InternalField_3368 = null;

        private void OnEnable()
        {
            InternalField_3368 = this;
        }
        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override GUIContent toolbarIcon
        {
            get
            {
                return new GUIContent(EditorGUIUtility.IconContent($"{InternalType_554.InternalProperty_7}/SpacingToolIcon.png")) { tooltip = "Padding/Margin Tool" };
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3268 = 20;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_715 InternalField_3269 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_715 InternalField_3270 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_704 InternalProperty_1016 { get; private set; } = new InternalType_704();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_704 InternalProperty_1017 { get; private set; } = new InternalType_704();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_1018 => !InternalProperty_1017.InternalProperty_1006 && InternalProperty_1016.InternalProperty_1006 && !InternalProperty_1016.InternalProperty_1005 && !InternalProperty_958;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_1019 => !InternalProperty_1016.InternalProperty_1006 && InternalProperty_1017.InternalProperty_1006 && !InternalProperty_1017.InternalProperty_1005 && !InternalProperty_958;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected override bool InternalProperty_999 => InternalProperty_1017.InternalProperty_1006 || InternalProperty_1016.InternalProperty_1006;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected override bool InternalProperty_990 => true;

        protected override void InternalMethod_3112()
        {
            InternalProperty_1017.SetColor(InternalProperty_964);
            InternalProperty_1017.InternalField_3242 = InternalMethod_3189;
            InternalProperty_1017.midpointHandleSizeFunction = InternalMethod_3128;
            InternalProperty_1017.InternalField_3238 = InternalMethod_3038;
            InternalProperty_1017.InternalField_3239 = InternalMethod_3037;

            InternalProperty_1016.SetColor(InternalProperty_965);
            InternalProperty_1016.InternalField_3242 = InternalMethod_3189;
            InternalProperty_1016.midpointHandleSizeFunction = InternalMethod_3129;
            InternalProperty_1016.InternalField_3238 = InternalMethod_3038;
            InternalProperty_1016.InternalField_3239 = InternalMethod_3037;
        }

        protected override void InternalMethod_3122()
        {
            if (InternalProperty_979)
            {
                InternalMethod_3046(InternalParameter_2814: true);
                return;
            }

            InternalMethod_3046();

            bool InternalVar_1 = InternalProperty_1016.InternalProperty_1006;
            bool InternalVar_2 = InternalProperty_1017.InternalProperty_1006;

            InternalMethod_3182();

            InternalMethod_3184();

            if ((InternalVar_1 || InternalVar_2 || InternalProperty_1017.InternalProperty_1006 || InternalProperty_1016.InternalProperty_1006) &&
               (InternalVar_1 == InternalProperty_1017.InternalProperty_1006 || InternalVar_2 == InternalProperty_1016.InternalProperty_1006))
            {
                HandleUtility.Repaint();
            }
        }

        private void InternalMethod_3182()
        {
            EditorGUI.BeginChangeCheck();
            using (new Handles.DrawingScope(InternalProperty_965, InternalProperty_997))
            {
                Bounds InternalVar_1 = new Bounds(Vector3.zero, InternalProperty_974.CalculatedSize.Value);
                Bounds InternalVar_2 = new Bounds(InternalProperty_974.CalculatedPadding.Offset, InternalProperty_974.PaddedSize);
                Bounds InternalVar_3 = InternalMethod_3186(InternalVar_2, InternalVar_1, InternalField_3268);

                if (InternalField_3269 == null)
                {
                    InternalField_3269 = new InternalType_715(InternalVar_2, InternalProperty_997, InternalMethod_3114);
                    InternalField_3269.speed = InternalField_3228;
                }

                Bounds InternalVar_4 = InternalVar_2;
                if (InternalProperty_1018)
                {
                    if (!InternalField_3269.isAnimating)
                    {
                        Vector3 InternalVar_5 = InternalVar_3.center + Vector3.Scale(InternalVar_3.extents, InternalProperty_1016.InternalProperty_1009);
                        Vector3 InternalVar_6 = InternalVar_4.max;
                        Vector3 InternalVar_7 = InternalVar_4.min;

                        int InternalVar_8 = InternalVar_1.size.z == 0 ? 2 : !InternalType_718.InternalMethod_3233(InternalProperty_959, 0) ? 0 : !InternalType_718.InternalMethod_3233(InternalProperty_959, 1) ? 1 : 2;

                        for (int InternalVar_9 = 0; InternalVar_9 < 3; ++InternalVar_9)
                        {
                            float InternalVar_10 = InternalType_187.InternalMethod_892(InternalProperty_1016.InternalProperty_1009[InternalVar_9]);

                            if (InternalVar_10 < 0)
                            {
                                InternalVar_7[InternalVar_9] = InternalVar_5[InternalVar_9];
                            }
                            else if (InternalVar_10 > 0)
                            {
                                InternalVar_6[InternalVar_9] = InternalVar_5[InternalVar_9];
                            }
                        }

                        InternalVar_7[InternalVar_8] = InternalVar_4.min[InternalVar_8];
                        InternalVar_6[InternalVar_8] = InternalVar_4.max[InternalVar_8];

                        InternalVar_4.SetMinMax(InternalVar_7, InternalVar_6);

                        InternalField_3269.target = InternalVar_4;
                        InternalField_3269.InternalField_3277 = InternalProperty_997;
                        InternalField_3269.InternalProperty_1020 = InternalField_3269.InternalField_3277;
                    }
                }
                else
                {
                    InternalField_3269.value = InternalVar_2;
                }

                InternalProperty_1016.axes = InternalProperty_959;
                InternalProperty_1016.InternalProperty_1008 = InternalVar_2.size;
                InternalProperty_1016.center = InternalVar_2.center;
                InternalProperty_1016.InternalField_3254 = InternalField_3269.value;
                InternalProperty_1016.InternalField_3255 = InternalVar_3;
                InternalProperty_1016.InternalField_3243 = !InternalProperty_1017.InternalProperty_1006;

                InternalProperty_1016.DrawHandle();

                if (InternalProperty_1016.InternalProperty_1005)
                {
                    InternalMethod_3119(InternalProperty_1016.InternalProperty_1007, new InternalType_702()
                    {
                        InternalField_3235 = InternalType_718.InternalMethod_3235(InternalVar_1),
                        InternalField_3236 = () => InternalMethod_3188(InternalProperty_1016.InternalProperty_1009),
                    });
                }
            }

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            InternalMethod_3183(new Bounds(InternalProperty_1016.center, InternalProperty_1016.InternalProperty_1008));

            InternalProperty_974.CalculateLayout();

            using (new Handles.DrawingScope(InternalProperty_965, InternalProperty_997))
            {
                if (InternalProperty_1016.InternalMethod_3162(new Bounds(InternalProperty_974.CalculatedPadding.Offset, InternalProperty_974.PaddedSize), out Bounds InternalVar_1))
                {
                    InternalMethod_3183(InternalVar_1);
                }
            }
        }

        private void InternalMethod_3183(Bounds InternalParameter_2868)
        {
            Vector3 InternalVar_1 = InternalProperty_974.CalculatedSize.Value - InternalParameter_2868.size - InternalProperty_974.CalculatedPadding.Size;
            Vector3 InternalVar_2 = InternalProperty_974.CalculatedPadding.InternalMethod_3192().Value;
            Vector3 InternalVar_3 = InternalProperty_974.CalculatedPadding.InternalMethod_3193().Value;

            for (int InternalVar_4 = 0; InternalVar_4 < 3; ++InternalVar_4)
            {
                if (InternalProperty_1016.InternalProperty_1009[InternalVar_4] < 0)
                {
                    InternalVar_2[InternalVar_4] += InternalVar_1[InternalVar_4];
                }

                if (InternalProperty_1016.InternalProperty_1009[InternalVar_4] > 0)
                {
                    InternalVar_3[InternalVar_4] += InternalVar_1[InternalVar_4];
                }
            }

            InternalVar_2 = InternalType_718.InternalMethod_3219(InternalProperty_974.PaddingMinMax.InternalMethod_29().Clamp(InternalVar_2));
            InternalVar_3 = InternalType_718.InternalMethod_3219(InternalProperty_974.PaddingMinMax.InternalMethod_27().Clamp(InternalVar_3));

            if (InternalVar_2 != InternalProperty_974.CalculatedPadding.InternalMethod_3192().Value || InternalVar_3 != InternalProperty_974.CalculatedPadding.InternalMethod_3193().Value)
            {
                if (!InternalProperty_988)
                {
                    Undo.RecordObject(InternalProperty_974, "Padding");
                }

                InternalProperty_988 = true;

                for (int InternalVar_4 = 0; InternalVar_4 < 3; ++InternalVar_4)
                {
                    Length2 InternalVar_5 = InternalProperty_974.Padding[InternalVar_4];
                    Vector2 InternalVar_6 = Length2.InternalMethod_2426(new Vector2(InternalVar_2[InternalVar_4], InternalVar_3[InternalVar_4]), InternalVar_5, InternalProperty_974.PaddingMinMax[InternalVar_4], Vector2.one * InternalProperty_974.CalculatedSize[InternalVar_4].Value);
                    InternalVar_5.Raw = InternalType_718.InternalMethod_3219(InternalVar_6);
                    InternalProperty_974.Padding[InternalVar_4] = InternalVar_5;
                }
            }
        }

        private void InternalMethod_3184()
        {
            InternalType_5 InternalVar_1 = InternalProperty_974.InternalMethod_3592();
            bool InternalVar_2 = InternalVar_1 != null;
            Vector3 InternalVar_3 = InternalType_44.InternalMethod_3206(InternalProperty_974);
            Vector3 InternalVar_4 = InternalVar_2 ? (Vector3)InternalVar_1.InternalProperty_146.InternalProperty_139 : Vector3.zero;

            EditorGUI.BeginChangeCheck();

            using (new Handles.DrawingScope(InternalProperty_964, InternalProperty_996))
            {
                Vector3 InternalVar_5 = InternalProperty_974.InternalMethod_1035();
                Bounds InternalVar_6 = new Bounds(InternalVar_5, Vector3.Scale(InternalProperty_974.RotatedSize, InternalProperty_974.transform.localScale));

                Bounds InternalVar_7 = new Bounds(InternalVar_5 - InternalProperty_974.CalculatedMargin.Offset, InternalVar_6.size + InternalProperty_974.CalculatedMargin.Size);

                Bounds InternalVar_8 = InternalMethod_3186(InternalVar_7, InternalVar_6, -InternalField_3268);

                if (InternalField_3270 == null)
                {
                    InternalField_3270 = new InternalType_715(InternalVar_7, InternalProperty_996, InternalMethod_3114);
                    InternalField_3270.speed = InternalField_3228;
                }

                Bounds InternalVar_9 = InternalVar_7;
                if (InternalProperty_1019)
                {
                    if (!InternalField_3270.isAnimating)
                    {
                        InternalVar_9.Encapsulate(InternalVar_8.center + Vector3.Scale(InternalVar_8.extents, InternalProperty_1017.InternalProperty_1009));

                        InternalField_3270.target = InternalVar_9;
                        InternalField_3270.InternalField_3277 = InternalProperty_996;
                        InternalField_3270.InternalProperty_1020 = InternalField_3270.InternalField_3277;
                    }
                }
                else
                {
                    InternalField_3270.value = InternalVar_7;
                }

                InternalProperty_1017.axes = InternalProperty_959;
                InternalProperty_1017.InternalProperty_1008 = InternalVar_7.size;
                InternalProperty_1017.center = InternalVar_7.center;
                InternalProperty_1017.InternalField_3254 = InternalField_3270.value;
                InternalProperty_1017.InternalField_3255 = InternalVar_8;
                InternalProperty_1017.InternalField_3243 = !InternalProperty_1016.InternalProperty_1006;

                InternalProperty_1017.DrawHandle();

                if (InternalProperty_1017.InternalProperty_1005)
                {
                    InternalMethod_3119(InternalProperty_1017.InternalProperty_1007, new InternalType_702()
                    {
                        InternalField_3235 = InternalType_718.InternalMethod_3235(InternalVar_6),
                        InternalField_3236 = () => InternalMethod_3187(InternalProperty_1017.InternalProperty_1009)
                    });
                }
            }

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            InternalMethod_3185(InternalVar_3, InternalVar_4, new Bounds(InternalProperty_1017.center, InternalProperty_1017.InternalProperty_1008));
            InternalProperty_974.CalculateLayout();

            using (new Handles.DrawingScope(InternalProperty_964, InternalProperty_996))
            {
                if (InternalProperty_1017.InternalMethod_3162(InternalProperty_995, out Bounds InternalVar_5))
                {
                    InternalMethod_3185(InternalVar_3, InternalVar_4, InternalVar_5);
                }
            }
        }

        private void InternalMethod_3185(Vector3 InternalParameter_2869, Vector3 InternalParameter_2870, Bounds InternalParameter_2871)
        {
            Vector3 InternalVar_1 = InternalParameter_2871.size - InternalProperty_974.InternalMethod_1039();
            Vector3 InternalVar_2 = InternalProperty_974.CalculatedMargin.InternalMethod_3192().Value;
            Vector3 InternalVar_3 = InternalProperty_974.CalculatedMargin.InternalMethod_3193().Value;

            for (int InternalVar_4 = 0; InternalVar_4 < 3; ++InternalVar_4)
            {
                if (InternalProperty_1017.InternalProperty_1009[InternalVar_4] < 0)
                {
                    InternalVar_2[InternalVar_4] += InternalVar_1[InternalVar_4];
                }

                if (InternalProperty_1017.InternalProperty_1009[InternalVar_4] > 0)
                {
                    InternalVar_3[InternalVar_4] += InternalVar_1[InternalVar_4];
                }
            }

            InternalVar_2 = InternalType_718.InternalMethod_3219(InternalProperty_974.MarginMinMax.InternalMethod_29().Clamp(InternalVar_2));
            InternalVar_3 = InternalType_718.InternalMethod_3219(InternalProperty_974.MarginMinMax.InternalMethod_27().Clamp(InternalVar_3));

            if (InternalVar_2 != InternalProperty_974.CalculatedMargin.InternalMethod_3192().Value || InternalVar_3 != InternalProperty_974.CalculatedMargin.InternalMethod_3193().Value)
            {
                if (!InternalProperty_988)
                {
                    Undo.RecordObject(InternalProperty_974, "Margin");
                }

                InternalProperty_988 = true;

                for (int InternalVar_4 = 0; InternalVar_4 < 3; ++InternalVar_4)
                {
                    Length2 InternalVar_5 = InternalProperty_974.Margin[InternalVar_4];
                    Vector2 InternalVar_6 = Length2.InternalMethod_2426(new Vector2(InternalVar_2[InternalVar_4], InternalVar_3[InternalVar_4]), InternalVar_5, InternalProperty_974.MarginMinMax[InternalVar_4], Vector2.one * InternalParameter_2869[InternalVar_4]);
                    InternalVar_5.Raw = InternalType_718.InternalMethod_3219(InternalVar_6);
                    InternalProperty_974.Margin[InternalVar_4] = InternalVar_5;
                }

                Vector3 InternalVar_7 = InternalProperty_974.InternalMethod_1035();

                Vector3 InternalVar_8 = Vector3.Scale(InternalProperty_974.RotatedSize, InternalProperty_974.transform.localScale);
                Vector3 InternalVar_9 = InternalType_182.InternalMethod_852(InternalVar_7, InternalVar_3 + InternalVar_2 + InternalVar_8, 0.5f * (InternalVar_2 - InternalVar_3), InternalParameter_2869, InternalParameter_2870, (Vector3)InternalProperty_974.Alignment);
                InternalProperty_974.Position.Raw = InternalType_718.InternalMethod_3339(Length3.InternalMethod_2424(InternalVar_9, InternalProperty_974.Position, InternalProperty_974.PositionMinMax, InternalParameter_2869), InternalMethod_3338(InternalProperty_974.Position));
            }
        }

        private Bounds InternalMethod_3186(Bounds InternalParameter_2872, Bounds InternalParameter_2873, float InternalParameter_2874)
        {
            bool InternalVar_1 = InternalType_187.InternalMethod_892(InternalParameter_2874) < 0;

            Vector3 InternalVar_2 = InternalVar_1 ? InternalParameter_2872.min : Vector3.one * float.MaxValue;
            Vector3 InternalVar_3 = InternalVar_1 ? InternalParameter_2872.max : Vector3.one * float.MinValue;

            Vector3[] InternalVar_4 = InternalType_718.InternalField_3291;

            PrimitiveBoundsHandle.Axes InternalVar_5 = InternalParameter_2873.size.z == 0 ? InternalField_3212 : InternalProperty_959;

            Vector3 InternalVar_6 = Camera.current.transform.position - InternalParameter_2872.center;

            int InternalVar_7 = !InternalType_718.InternalMethod_3233(InternalVar_5, 0) ? 0 : !InternalType_718.InternalMethod_3233(InternalVar_5, 1) ? 1 : 2;
            float InternalVar_8 = InternalType_187.InternalMethod_892(InternalVar_6[InternalVar_7]);

            for (int InternalVar_9 = 0; InternalVar_9 < InternalVar_4.Length; ++InternalVar_9)
            {
                Vector3 InternalVar_10 = InternalVar_4[InternalVar_9];
                Vector3 InternalVar_11 = InternalParameter_2872.center + Vector3.Scale(InternalParameter_2872.extents, InternalType_718.InternalMethod_3243(InternalVar_10, InternalVar_5, InternalVar_8));

                Vector3 InternalVar_12 = InternalType_718.InternalMethod_3242(InternalVar_11, InternalVar_5, InternalType_187.InternalMethod_892(InternalParameter_2874), InternalParameter_2873, Mathf.Abs(InternalParameter_2874));

                InternalVar_2 = Vector3.Min(InternalVar_2, InternalVar_12);
                InternalVar_3 = Vector3.Max(InternalVar_3, InternalVar_12);
            }

            InternalVar_2[InternalVar_7] = InternalParameter_2872.min[InternalVar_7];
            InternalVar_3[InternalVar_7] = InternalParameter_2872.max[InternalVar_7];

            InternalParameter_2872.SetMinMax(InternalVar_2, InternalVar_3);

            return InternalParameter_2872;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private StringBuilder InternalField_3271 = new StringBuilder();
        private string InternalMethod_3187(Vector3 InternalParameter_2875)
        {
            InternalField_3271.Clear();

            InternalField_3271.Append("Margin");

            for (int InternalVar_1 = 0; InternalVar_1 < 3; ++InternalVar_1)
            {
                float InternalVar_2 = InternalType_187.InternalMethod_892(InternalParameter_2875[InternalVar_1]);

                if (InternalVar_2 == 0 || !InternalType_718.InternalMethod_3233(InternalProperty_959, InternalVar_1))
                {
                    continue;
                }

                InternalField_3271.Append($"\n{InternalType_182.InternalMethod_861(InternalVar_1, (int)InternalVar_2)}: {InternalMethod_3130(InternalProperty_974.CalculatedMargin, InternalVar_1, InternalVar_2).Value.ToString("F2")}");
            }

            return InternalField_3271.ToString();
        }

        private string InternalMethod_3188(Vector3 InternalParameter_2876)
        {
            InternalField_3271.Clear();

            InternalField_3271.Append("Padding");

            for (int InternalVar_1 = 0; InternalVar_1 < 3; ++InternalVar_1)
            {
                float InternalVar_2 = InternalType_187.InternalMethod_892(InternalParameter_2876[InternalVar_1]);

                if (InternalVar_2 == 0 || !InternalType_718.InternalMethod_3233(InternalProperty_959, InternalVar_1))
                {
                    continue;
                }

                InternalField_3271.Append($"\n{InternalType_182.InternalMethod_861(InternalVar_1, (int)InternalVar_2)}: {InternalMethod_3130(InternalProperty_974.CalculatedPadding, InternalVar_1, InternalVar_2).Value.ToString("F2")}");
            }

            return InternalField_3271.ToString();
        }

        private void InternalMethod_3189(Vector3 InternalParameter_2877, Quaternion InternalParameter_2878, float InternalParameter_2879, bool InternalParameter_2880)
        {
            Color InternalVar_1 = InternalParameter_2880 ? InternalProperty_971 : Color.white;
            Color InternalVar_2 = InternalParameter_2880 ? InternalProperty_971 : Handles.color;
            Color InternalVar_3 = InternalParameter_2880 ? InternalProperty_971 : InternalField_3214;

            InternalType_718.InternalMethod_3245(InternalParameter_2877, InternalParameter_2878, InternalParameter_2879, InternalVar_1, InternalVar_2, InternalVar_3);
        }
    }

    internal static class InternalType_711
    {
        public static MinMax3 InternalMethod_29(ref this MinMaxBounds InternalParameter_1905)
        {
            return new MinMax3(InternalParameter_1905.Left, InternalParameter_1905.Bottom, InternalParameter_1905.Front);
        }

        public static MinMax3 InternalMethod_27(ref this MinMaxBounds InternalParameter_1904)
        {
            return new MinMax3(InternalParameter_1904.Right, InternalParameter_1904.Top, InternalParameter_1904.Back);
        }

        public static Length3.Calculated InternalMethod_3192(in this LengthBounds.Calculated InternalParameter_2883)
        {
            return new Length3.Calculated(InternalParameter_2883.Left, InternalParameter_2883.Bottom, InternalParameter_2883.Front);
        }

        public static Length3.Calculated InternalMethod_3193(in this LengthBounds.Calculated InternalParameter_2884)
        {
            return new Length3.Calculated(InternalParameter_2884.Right, InternalParameter_2884.Top, InternalParameter_2884.Back);
        }
    }
}
