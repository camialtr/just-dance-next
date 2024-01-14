// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;
namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    [InternalType_703(typeof(InternalType_713))]
#if UNITY_2021_2_OR_NEWER
    [EditorTool(displayName: "Gradient Tool", componentToolTarget: typeof(UIBlock2D))]
#else
    [EditorToolAttribute(displayName: "Gradient Tool", targetType = typeof(UIBlock2D))]
#endif

    internal class InternalType_708 : InternalType_701
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static InternalType_708 InternalField_3367 = null;

        private void OnEnable()
        {
            InternalField_3367 = this;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public override GUIContent toolbarIcon
        {
            get
            {
                return new GUIContent(EditorGUIUtility.IconContent($"{InternalType_554.InternalProperty_7}/GradientToolIcon.png")) { tooltip = "Gradient Tool" };
            }
        }

        private struct InternalType_709
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public Vector2 InternalField_3265;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public Vector2 InternalField_3266;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public float InternalField_3267;
        }

        public override bool IsAvailable()
        {
            UIBlock2D InternalVar_1 = target as UIBlock2D;

            return InternalVar_1 != null && InternalVar_1.Gradient.Enabled;
        }

        protected override void InternalMethod_3122()
        {
            if (!IsAvailable())
            {
                ToolManager.SetActiveTool<InternalType_713>();
                return;
            }

            if (InternalProperty_979)
            {
                return;
            }

            UIBlock2D InternalVar_1 = InternalProperty_974 as UIBlock2D;
            ref RadialGradient InternalVar_2 = ref InternalVar_1.Gradient;
            Vector2 InternalVar_3 = InternalVar_1.CalculatedSize.XY.Value;

            InternalType_709 InternalVar_4 = new InternalType_709()
            {
                InternalField_3265 = InternalMethod_3171(ref InternalVar_2.Radius, ref InternalVar_3),
                InternalField_3266 = InternalMethod_3171(ref InternalVar_2.Center, ref InternalVar_3),
                InternalField_3267 = InternalVar_2.Rotation,
            };

            if (InternalMethod_3175(InternalVar_1, ref InternalVar_4))
            {
                Undo.RecordObject(InternalVar_1, "Gradient");

                InternalMethod_3173(ref InternalVar_2.Radius, ref InternalVar_4.InternalField_3265, ref InternalVar_3);
                InternalMethod_3173(ref InternalVar_2.Center, ref InternalVar_4.InternalField_3266, ref InternalVar_3);
                InternalVar_2.Rotation = InternalVar_4.InternalField_3267;
                InternalProperty_989 = true;

                InternalType_180.InternalMethod_849();
            }
        }

        private Vector2 InternalMethod_3171(ref Length2 InternalParameter_2856, ref Vector2 InternalParameter_2857)
        {
            return new Vector2(
                InternalMethod_3172(ref InternalParameter_2856.X, ref InternalParameter_2857.x),
                InternalMethod_3172(ref InternalParameter_2856.Y, ref InternalParameter_2857.y));
        }

        private float InternalMethod_3172(ref Length InternalParameter_2858, ref float InternalParameter_2859)
        {
            if (InternalParameter_2858.Type == LengthType.Value)
            {
                return InternalParameter_2858.Value;
            }
            else
            {
                return InternalParameter_2858.Percent * InternalParameter_2859;
            }
        }

        private void InternalMethod_3173(ref Length2 InternalParameter_2860, ref Vector2 InternalParameter_2861, ref Vector2 InternalParameter_2862)
        {
            InternalMethod_3174(ref InternalParameter_2860.X, ref InternalParameter_2861.x, ref InternalParameter_2862.x);
            InternalMethod_3174(ref InternalParameter_2860.Y, ref InternalParameter_2861.y, ref InternalParameter_2862.y);
        }

        private void InternalMethod_3174(ref Length InternalParameter_2863, ref float InternalParameter_2864, ref float InternalParameter_2865)
        {
            if (InternalParameter_2863.Type == LengthType.Value)
            {
                InternalParameter_2863.Value = InternalParameter_2864;
            }
            else
            {
                InternalParameter_2863.Percent = InternalParameter_2864 / InternalParameter_2865;
            }
        }

        private bool InternalMethod_3175(UIBlock2D InternalParameter_2866, ref InternalType_709 InternalParameter_2867)
        {
            if (!InternalParameter_2866.Gradient.Enabled)
            {
                return false;
            }

            Quaternion InternalVar_1 = Quaternion.AngleAxis(InternalParameter_2867.InternalField_3267, Vector3.forward);
            Vector3 InternalVar_2 = InternalVar_1 * Vector3.up;
            Vector3 InternalVar_3 = InternalVar_1 * Vector3.right;

            Vector2 InternalVar_4 = InternalParameter_2866.CalculatedSize.XY.Value;

            Vector3 InternalVar_5 = InternalParameter_2867.InternalField_3266;
            Vector3 InternalVar_6 = InternalVar_5 + (InternalParameter_2867.InternalField_3265.x * InternalVar_3);
            Vector3 InternalVar_7 = InternalVar_5 + (InternalParameter_2867.InternalField_3265.y * InternalVar_2);

            Vector2 InternalVar_8 = new Vector2(InternalVar_4.x == 0 ? 0 : 1 / InternalVar_4.x, InternalVar_4.y == 0 ? 0 : 1 / InternalVar_4.y);

            using (new Handles.DrawingScope(Color.white, InternalParameter_2866.transform.localToWorldMatrix))
            {
                EditorGUI.BeginChangeCheck();
                Handles.color = InternalProperty_968;
                Handles.DrawAAPolyLine(InternalField_3220, InternalVar_5, InternalVar_6);

                Vector3 InternalVar_9 = HandleCompat.FreeMoveHandle(InternalVar_6, InternalField_3225 * HandleUtility.GetHandleSize(InternalVar_6), Vector3.zero, Handles.SphereHandleCap);

                bool InternalVar_10 = EditorGUI.EndChangeCheck();

                EditorGUI.BeginChangeCheck();
                Handles.color = InternalProperty_969;
                Handles.DrawAAPolyLine(InternalField_3220, InternalVar_5, InternalVar_7);
                Vector3 InternalVar_11 = HandleCompat.FreeMoveHandle(InternalVar_7, InternalField_3225 * HandleUtility.GetHandleSize(InternalVar_7), Vector3.zero, Handles.SphereHandleCap);
                bool InternalVar_12 = EditorGUI.EndChangeCheck();

                float InternalVar_13 = 0;

                if (InternalVar_10)
                {
                    Vector3 InternalVar_14 = InternalVar_6 - InternalVar_5;
                    Vector3 InternalVar_15 = InternalVar_9 - InternalVar_5;

                    InternalVar_14.z = InternalVar_15.z = 0;

                    InternalVar_13 = Vector3.SignedAngle(InternalVar_14, InternalVar_15, Vector3.forward);

                    if (Mathf.Abs(InternalVar_13) == 180)
                    {
                        InternalVar_13 = 0;
                    }
                }

                if (InternalVar_12)
                {
                    Vector3 InternalVar_14 = InternalVar_7 - InternalVar_5;
                    Vector3 InternalVar_15 = InternalVar_11 - InternalVar_5;

                    InternalVar_14.z = InternalVar_15.z = 0;

                    InternalVar_13 = Vector3.SignedAngle(InternalVar_14, InternalVar_15, Vector3.forward);

                    if (Mathf.Abs(InternalVar_13) == 180)
                    {
                        InternalVar_13 = 0;
                    }
                }

                if (InternalVar_10 || InternalVar_12)
                {
                    InternalParameter_2867.InternalField_3267 = Handles.SnapValue(InternalType_187.InternalMethod_937(InternalParameter_2867.InternalField_3267 + InternalVar_13, 360f), EditorSnapSettings.rotate);

                    InternalParameter_2867.InternalField_3265 = new Vector2(Vector2.Distance(InternalVar_9, InternalVar_5), Vector2.Distance(InternalVar_11, InternalVar_5));
                    return true;
                }

                EditorGUI.BeginChangeCheck();

                Handles.color = Color.white;
                InternalVar_5 = HandleCompat.FreeMoveHandle(InternalVar_5, InternalField_3225 * HandleUtility.GetHandleSize(InternalVar_5), EditorSnapSettings.move, Handles.SphereHandleCap);

                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2867.InternalField_3266 = InternalVar_5;
                    return true;
                }
            }

            return false;
        }

        protected override void InternalMethod_3112()
        {
        }
    }
}