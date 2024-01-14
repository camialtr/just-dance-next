// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_25;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    internal class InternalType_699 : InternalType_700
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override GUIContent toolbarIcon
        {
            get
            {
                return new GUIContent(EditorGUIUtility.IconContent($"{InternalType_554.InternalProperty_7}/UIBlockToolIcon.png")) { tooltip = "UI Block Tool" };
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<Bounds> InternalField_3190 = new List<Bounds>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3191 = Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Matrix4x4 InternalField_3192 = Matrix4x4.identity;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Matrix4x4 InternalField_3193 = Matrix4x4.identity;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Bounds InternalField_3194 = default(Bounds);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected InternalType_704 InternalProperty_955 { get; private set; } = new InternalType_704();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected override bool InternalProperty_999 => InternalProperty_955.InternalProperty_1006;

        protected override void InternalMethod_3112()
        {
            InternalProperty_955.SetColor(InternalProperty_963);
            InternalProperty_955.InternalField_3242 = InternalMethod_3028;
            InternalProperty_955.midpointHandleSizeFunction = InternalMethod_3128;
            InternalProperty_955.InternalField_3238 = InternalMethod_3038;
            InternalProperty_955.InternalField_3239 = InternalMethod_3037;
        }

        protected override void InternalMethod_3122()
        {
            InternalMethod_3022();

            InternalMethod_3046();
        }

        private void InternalMethod_3022()
        {
            Bounds InternalVar_1 = InternalProperty_991;
            Matrix4x4 InternalVar_2 = InternalProperty_993;

            InternalProperty_955.axes = InternalVar_1.extents.z == 0 ? InternalField_3212 : InternalProperty_959;
            InternalProperty_955.InternalProperty_1008 = InternalVar_1.size;
            InternalProperty_955.center = InternalVar_1.center;
            InternalProperty_955.InternalField_3254 = InternalVar_1;

            InternalProperty_955.InternalProperty_1012 = InternalProperty_956;

            using (new Handles.DrawingScope(InternalProperty_963, InternalVar_2))
            {
                EditorGUI.BeginChangeCheck();
                InternalType_718.InternalMethod_3236();


                InternalProperty_955.DrawHandle();

                bool InternalVar_3 = InternalType_718.InternalMethod_3237() == InternalType_717.InternalField_3280;

                if (InternalVar_3)
                {
                    InternalField_3194 = InternalVar_1;

                    Vector3 InternalVar_4 = InternalVar_2.MultiplyPoint(InternalField_3194.center);
                    InternalField_3192 = Matrix4x4.TRS(InternalVar_4, InternalVar_2.rotation, Vector3.one);
                    InternalField_3193 = InternalField_3192.inverse;

                    InternalMethod_3027(ref InternalField_3193);
                }

                if (InternalProperty_955.InternalProperty_1007 != 0)
                {
                    InternalMethod_3119(InternalProperty_955.InternalProperty_1007, new InternalType_702()
                    {
                        InternalField_3235 = InternalType_718.InternalMethod_3235(InternalVar_1),
                        InternalField_3236 = InternalMethod_3029
                    });
                }

                if (!EditorGUI.EndChangeCheck())
                {
                    return;
                }

                InternalMethod_3023(ref InternalVar_2, new Bounds(InternalProperty_955.center, InternalProperty_955.InternalProperty_1008));
            }

            InternalType_64.InternalProperty_200.InternalMethod_431();

            Bounds InternalVar_6 = InternalMethod_3117(out Matrix4x4 InternalVar_5);

            using (new Handles.DrawingScope(InternalProperty_963, InternalVar_5))
            {
                if (InternalProperty_955.InternalMethod_3162(InternalVar_6, out Bounds InternalVar_7))
                {
                    InternalProperty_955.InternalProperty_1008 = InternalVar_7.size;
                    InternalProperty_955.center = InternalVar_7.center;

                    InternalMethod_3023(ref InternalVar_5, InternalVar_7);
                }
            }
        }

        private void InternalMethod_3023(ref Matrix4x4 InternalParameter_2774, Bounds InternalParameter_2775)
        {
            Vector3 InternalVar_1 = InternalType_187.InternalMethod_879(InternalParameter_2775.size.InternalMethod_1043(InternalField_3194.size, InternalParameter_1057: 1));

            Vector3 InternalVar_2 = InternalParameter_2774.MultiplyPoint(InternalParameter_2775.center);

            Matrix4x4 InternalVar_3 = Matrix4x4.TRS(InternalVar_2, InternalField_3192.rotation, Vector3.Scale(InternalField_3192.lossyScale, InternalVar_1));

            if (!InternalProperty_979)
            {
                InternalMethod_3025(InternalProperty_980[0], InternalField_3190[0], InternalVar_1, ref InternalVar_3, InternalField_3191);
            }
            else
            {
                for (int InternalVar_4 = 0; InternalVar_4 < InternalProperty_980.InternalProperty_433; ++InternalVar_4)
                {
                    InternalMethod_3025(InternalProperty_980[InternalVar_4], InternalField_3190[InternalVar_4], InternalVar_1, ref InternalVar_3);
                }
            }
        }

        private void InternalMethod_3025(UIBlock InternalParameter_2776, Bounds InternalParameter_2777, Vector3 InternalParameter_2778, ref Matrix4x4 InternalParameter_2779, Vector3 InternalParameter_2780 = default)
        {
            InternalType_5 InternalVar_1 = InternalParameter_2776.InternalMethod_3592();
            bool InternalVar_2 = InternalVar_1 != null;
            Vector3 InternalVar_3 = InternalType_44.InternalMethod_3206(InternalParameter_2776);
            Vector3 InternalVar_4 = InternalVar_2 ? (Vector3)InternalVar_1.InternalProperty_146.InternalProperty_139 : Vector3.zero;
            Matrix4x4 InternalVar_5 = InternalParameter_2776.InternalMethod_1036();
            Matrix4x4 InternalVar_6 = Unity.Mathematics.math.inverse(InternalVar_5);

            Quaternion InternalVar_7 = InternalParameter_2779.rotation * Quaternion.Inverse(InternalParameter_2776.transform.rotation);

            InternalVar_7 = (Unity.Mathematics.quaternion)InternalType_187.InternalMethod_880(((Unity.Mathematics.quaternion)InternalVar_7).value);

            InternalParameter_2778 = InternalVar_7 * InternalParameter_2778;
            InternalParameter_2778 = Vector3.Max(-InternalParameter_2778, InternalParameter_2778);

            ThreeD<AutoSize> InternalVar_8 = InternalParameter_2776.AutoSize;

            bool InternalVar_9 = InternalParameter_2776.AspectRatioAxis != Axis.None;

            InternalParameter_2778 = new Vector3(InternalVar_8.X != AutoSize.None || (InternalVar_9 && InternalParameter_2776.AspectRatioAxis != Axis.X) ? 1 : InternalParameter_2778.x,
                                     InternalVar_8.Y != AutoSize.None || (InternalVar_9 && InternalParameter_2776.AspectRatioAxis != Axis.Y) ? 1 : InternalParameter_2778.y,
                                     InternalVar_8.Z != AutoSize.None || (InternalVar_9 && InternalParameter_2776.AspectRatioAxis != Axis.Z) ? 1 : InternalParameter_2778.z);

            Vector3 InternalVar_10 = InternalType_718.InternalMethod_3219(Vector3.Scale(InternalParameter_2777.size, InternalParameter_2778));
            Vector3 InternalVar_11 = InternalType_187.InternalMethod_879(InternalParameter_2776.SizeMinMax.Clamp(InternalVar_10));

            if (InternalParameter_2776.CalculatedSize.Value == InternalVar_11)
            {
                return;
            }

            if (!InternalProperty_988)
            {
                Undo.RecordObjects(InternalProperty_982, "UI Block Tool");
            }

            InternalProperty_988 = true;

            if (!InternalVar_2)
            {
                InternalVar_3 = InternalParameter_2777.size;
            }

            InternalParameter_2776.Size.Raw = InternalType_718.InternalMethod_3219(Length3.InternalMethod_2424(InternalVar_11, InternalParameter_2776.Size, InternalParameter_2776.SizeMinMax, InternalVar_3));

            if (!InternalVar_2)
            {
                InternalParameter_2776.PreviewSize = InternalVar_11;
                InternalNamespace_0.InternalNamespace_12.InternalType_457.InternalMethod_1860();
                InternalVar_3 = Vector3.zero;
            }

            if (!InternalMethod_3118(InternalParameter_2776))
            {
                return;
            }

            Vector3 InternalVar_12 = InternalParameter_2776.RotateSize ? (Vector3)InternalType_182.InternalMethod_859(InternalVar_11, InternalParameter_2776.transform.localRotation) : InternalVar_11;
            Vector3 InternalVar_13 = Vector3.Scale(InternalVar_12, InternalParameter_2776.transform.localScale) + InternalParameter_2776.CalculatedMargin.Size;

            Vector3 InternalVar_14;

            if (InternalVar_2)
            {
                ThreeD<AutoSize> InternalVar_15 = AutoSize.None;
                switch (InternalVar_1)
                {
                    case UIBlock parentComponent:
                        InternalVar_15 = parentComponent.AutoSize;
                        break;
                    case InternalType_33 parentObject:
                        InternalVar_15 = parentObject.InternalProperty_74;
                        break;
                }

                if (InternalType_728.InternalMethod_3278(InternalVar_15 == AutoSize.Shrink))
                {
                    InternalParameter_2776.CalculateLayout();
                    InternalVar_3 = InternalType_44.InternalMethod_3206(InternalParameter_2776);
                }
            }

            if (InternalProperty_979)
            {
                Vector3 InternalVar_15 = InternalParameter_2779.MultiplyPoint(InternalParameter_2777.center);
                InternalVar_14 = InternalVar_6.MultiplyPoint(InternalVar_15);
            }
            else
            {
                Vector3 InternalVar_15 = InternalParameter_2776.transform.localRotation * InternalProperty_955.InternalProperty_1009;
                InternalVar_14 = InternalType_182.InternalMethod_851(InternalParameter_2780, InternalVar_13, InternalParameter_2776.CalculatedMargin.Offset, InternalVar_3, InternalVar_4, -InternalVar_15);
            }

            if (InternalVar_2)
            {
                Vector3 InternalVar_15 = InternalType_182.InternalMethod_852(InternalVar_14, InternalVar_13, InternalParameter_2776.CalculatedMargin.Offset, InternalVar_3, InternalVar_4, (Vector3)InternalParameter_2776.Alignment);
                InternalParameter_2776.Position.Raw = InternalType_718.InternalMethod_3339(Length3.InternalMethod_2424(InternalVar_15, InternalParameter_2776.Position, InternalParameter_2776.PositionMinMax, InternalVar_3), InternalMethod_3338(InternalParameter_2776.Position));
            }
            else if (!SceneViewUtils.IsInCurrentPrefabStage(InternalParameter_2776.gameObject))
            {
                Undo.RecordObject(InternalParameter_2776.transform, "UI Block Tool");
                InternalParameter_2776.transform.localPosition = InternalType_718.InternalMethod_3219(InternalVar_14);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_956
        {
            get
            {
                for (int InternalVar_1 = 0; InternalVar_1 < InternalProperty_980.InternalProperty_433; ++InternalVar_1)
                {
                    if (InternalProperty_980[InternalVar_1].AspectRatioAxis == Axis.None)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void InternalMethod_3027(ref Matrix4x4 InternalParameter_2781)
        {
            InternalField_3190.Clear();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalProperty_980.InternalProperty_433; ++InternalVar_1)
            {
                UIBlock InternalVar_2 = InternalProperty_980[InternalVar_1];
                InternalField_3190.Add(new Bounds(InternalParameter_2781.MultiplyPoint(InternalVar_2.transform.position), InternalVar_2.CalculatedSize.Value));
            }

            if (!InternalProperty_979)
            {
                UIBlock InternalVar_1 = InternalProperty_980[0];

                Vector3 InternalVar_2 = InternalVar_1.transform.localRotation * InternalProperty_955.InternalProperty_1009;

                Vector3 InternalVar_3 = InternalVar_1.InternalMethod_1035();
                Vector3 InternalVar_4 = InternalVar_1.InternalMethod_1039();

                InternalType_5 InternalVar_5 = InternalVar_1.InternalMethod_3592();
                bool InternalVar_6 = InternalVar_5 != null;

                Vector3 InternalVar_7 = InternalVar_6 ? InternalVar_5.InternalProperty_148 : Vector3.zero;
                Vector3 InternalVar_8 = InternalVar_6 ? (Vector3)InternalVar_5.InternalProperty_146.InternalProperty_139 : Vector3.zero;

                Vector3 InternalVar_9 = InternalType_182.InternalMethod_852(InternalVar_3, InternalVar_4, InternalVar_1.CalculatedMargin.Offset, InternalVar_7, InternalVar_8, -InternalVar_2);
                InternalField_3191 = InternalVar_9;
            }
        }

        private void InternalMethod_3028(Vector3 InternalParameter_2782, Quaternion InternalParameter_2783, float InternalParameter_2784, bool InternalParameter_2785)
        {
            Color InternalVar_1 = InternalParameter_2785 ? InternalProperty_971 : Color.white;
            Color InternalVar_2 = InternalParameter_2785 ? InternalProperty_971 : Handles.color;
            Color InternalVar_3 = InternalParameter_2785 ? InternalProperty_971 : InternalField_3214;

            InternalType_718.InternalMethod_3245(InternalParameter_2782, InternalParameter_2783, InternalParameter_2784, InternalVar_1, InternalVar_2, InternalVar_3);
        }

        private string InternalMethod_3029()
        {
            Vector3 InternalVar_1 = InternalProperty_974.CalculatedSize.Value;

            return InternalVar_1.z == 0 ? $"{InternalVar_1.x.ToString("F2")} x {InternalVar_1.y.ToString("F2")}" : $"{InternalVar_1.x.ToString("F2")} x {InternalVar_1.y.ToString("F2")} x {InternalVar_1.z.ToString("F2")}";
        }
    }
}
