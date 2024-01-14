// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
#if UNITY_2021_2_OR_NEWER
    [EditorTool(displayName: "UI Block Tool", componentToolTarget: typeof(UIBlock))]
#else
    [EditorToolAttribute(displayName: "UI Block Tool", targetType = typeof(UIBlock))]
#endif
    internal class InternalType_713 : InternalType_699
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_707 InternalField_3275 = new InternalType_707();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static InternalType_713 InternalField_3369 = null;

        private void OnEnable()
        {
            InternalField_3369 = this;
        }

        protected override void InternalMethod_3112()
        {
            base.InternalMethod_3112();

            switch (InternalProperty_974)
            {
                case UIBlock3D colorBlock3D:
                case UIBlock2D colorBlock:
                default:
                    InternalMethod_3201();
                    break;
            }
        }

        protected override void InternalMethod_3122()
        {
            base.InternalMethod_3122();

            if (InternalProperty_979 || !InternalProperty_998)
            {
                return;
            }

            Vector3 InternalVar_1 = InternalProperty_974.CalculatedSize.Value;
            float InternalVar_2 = .5f * Mathf.Min(InternalVar_1.x, InternalVar_1.y);

            switch (InternalProperty_974)
            {
                case UIBlock2D colorBlock:
                {
                    ref Length InternalVar_3 = ref colorBlock.CornerRadius;

                    if (InternalMethod_3202(colorBlock, InternalMethod_3199(ref InternalVar_3, ref InternalVar_2), out float InternalVar_4))
                    {
                        Undo.RecordObject(colorBlock, nameof(UIBlock2D.CornerRadius));

                        InternalMethod_3200(ref InternalVar_3, ref InternalVar_4, ref InternalVar_2);
                    }
                    break;
                }
                case UIBlock3D colorBlock3D:
                {
                    if (InternalProperty_955.axes == InternalField_3212)
                    {
                        ref Length InternalVar_3 = ref colorBlock3D.CornerRadius;

                        if (InternalMethod_3202(colorBlock3D, InternalMethod_3199(ref InternalVar_3, ref InternalVar_2), out float InternalVar_4))
                        {
                            Undo.RecordObject(colorBlock3D, nameof(UIBlock3D.CornerRadius));

                            InternalMethod_3200(ref InternalVar_3, ref InternalVar_4, ref InternalVar_2);
                        }
                    }
                    else
                    {
                        float InternalVar_3 = Mathf.Min(InternalVar_2, 0.5f * InternalVar_1.z);

                        ref Length InternalVar_4 = ref colorBlock3D.EdgeRadius;

                        if (InternalMethod_3203(colorBlock3D, InternalMethod_3199(ref InternalVar_4, ref InternalVar_3), out float InternalVar_5))
                        {
                            Undo.RecordObject(colorBlock3D, nameof(UIBlock3D.EdgeRadius));

                            InternalMethod_3200(ref InternalVar_4, ref InternalVar_5, ref InternalVar_3);
                        }
                    }
                    break;
                }
            }
        }

        private float InternalMethod_3199(ref Length InternalParameter_2894, ref float InternalParameter_2895)
        {
            return InternalParameter_2894.Type == LengthType.Value ? InternalParameter_2894.Raw : InternalParameter_2895 * InternalParameter_2894.Raw;
        }

        private void InternalMethod_3200(ref Length InternalParameter_2896, ref float InternalParameter_2897, ref float InternalParameter_2898)
        {
            InternalParameter_2896.Raw = Length.InternalMethod_2428(InternalParameter_2897, InternalParameter_2896, MinMax.Positive, InternalParameter_2898);
            InternalProperty_989 = true;
        }

        private void InternalMethod_3201()
        {
            InternalField_3275.InternalField_3260 = InternalMethod_3204;
            InternalField_3275.InternalField_3261 = InternalMethod_3128;
        }

        protected bool InternalMethod_3202(UIBlock InternalParameter_2899, float InternalParameter_2900, out float InternalParameter_2901)
        {
            InternalParameter_2901 = InternalParameter_2900;

            Vector3 InternalVar_1 = 0.5f * InternalParameter_2899.CalculatedSize.Value;

            float InternalVar_2 = Mathf.Min(InternalVar_1.x, InternalVar_1.y);

            Vector3 InternalVar_3 = InternalVar_1.z == 0 ? Vector3.zero : InternalProperty_997.inverse.MultiplyPoint(InternalProperty_955.InternalProperty_1014);
            Vector3 InternalVar_4 = InternalVar_1.z == 0 ? InternalParameter_2899.CalculatedSize.Value : InternalType_718.InternalMethod_3232(InternalParameter_2899.CalculatedSize.Value, InternalProperty_959);

            InternalField_3275.InternalField_3264 = InternalProperty_955.axes;
            InternalField_3275.InternalField_3263 = InternalParameter_2900;
            InternalField_3275.InternalField_3262 = new Bounds(InternalVar_3, InternalVar_4);

            using (new Handles.DrawingScope(InternalProperty_966, InternalProperty_997))
            {
                EditorGUI.BeginChangeCheck();
                InternalField_3275.InternalMethod_3168();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2901 = Mathf.Clamp(InternalField_3275.InternalField_3263, 0, InternalVar_2);
                    return true;
                }
            }

            return false;
        }

        protected bool InternalMethod_3203(UIBlock InternalParameter_2902, float InternalParameter_2903, out float InternalParameter_2904)
        {
            InternalParameter_2904 = InternalParameter_2903;

            Vector3 InternalVar_1 = 0.5f * InternalParameter_2902.CalculatedSize.Value;

            float InternalVar_2 = Mathf.Min(InternalVar_1.x, InternalVar_1.y, InternalVar_1.z);

            Vector3 InternalVar_3 = InternalVar_1.z == 0 ? Vector3.zero : InternalProperty_997.inverse.MultiplyPoint(InternalProperty_955.InternalProperty_1014);
            Vector3 InternalVar_4 = InternalVar_1.z == 0 ? InternalParameter_2902.CalculatedSize.Value : InternalType_718.InternalMethod_3232(InternalParameter_2902.CalculatedSize.Value, InternalProperty_959);

            InternalField_3275.InternalField_3264 = InternalProperty_955.axes;
            InternalField_3275.InternalField_3263 = InternalParameter_2903;
            InternalField_3275.InternalField_3262 = new Bounds(InternalVar_3, InternalVar_4);

            using (new Handles.DrawingScope(InternalProperty_967, InternalProperty_997))
            {
                EditorGUI.BeginChangeCheck();
                InternalField_3275.InternalMethod_3168();
                if (EditorGUI.EndChangeCheck())
                {
                    InternalParameter_2904 = Mathf.Clamp(InternalField_3275.InternalField_3263, 0, InternalVar_2);
                    return true;
                }
            }

            return false;
        }

        private void InternalMethod_3204(int InternalParameter_2905, Vector3 InternalParameter_2906, Quaternion InternalParameter_2907, float InternalParameter_2908, EventType InternalParameter_2909)
        {
            if (!InternalProperty_998)
            {
                return;
            }

            InternalMethod_3119(InternalParameter_2905, new InternalType_702()
            {
                InternalField_3235 = InternalType_718.InternalMethod_3235(InternalProperty_994),
                InternalField_3236 = InternalMethod_3205
            });

            const float InternalVar_1 = 0.6f;
            const float InternalVar_2 = 0.8f;
            const float InternalVar_3 = 5;

            Vector3 InternalVar_4 = InternalParameter_2907 * Vector3.forward;

            float InternalVar_5 = InternalProperty_993.ValidTRS() ? 1 / Unity.Mathematics.math.cmin(InternalProperty_993.lossyScale) : 1;

            InternalType_718.InternalMethod_3238(InternalParameter_2906, InternalVar_4, InternalVar_2 * InternalParameter_2908, InternalVar_3);
            Color InternalVar_6 = Handles.color;
            Handles.color = Color.white;
            Handles.DrawSolidDisc(InternalParameter_2906, InternalVar_4, InternalVar_1 * InternalParameter_2908);
            Handles.DrawWireDisc(InternalParameter_2906, InternalVar_4, InternalVar_1 * InternalParameter_2908);

            Handles.color = Color.clear;
            Handles.CircleHandleCap(InternalParameter_2905, InternalParameter_2906, InternalParameter_2907, InternalVar_2 * InternalParameter_2908, InternalParameter_2909);
            Handles.color = InternalVar_6;
        }

        private string InternalMethod_3205()
        {
            bool InternalVar_1 = InternalProperty_974 is UIBlock2D;
            string InternalVar_2 = InternalVar_1 ? "Radius" : InternalField_3275.InternalField_3264 == InternalField_3212 ? "Corner Radius" : "Edge Radius";
            return $"{InternalVar_2}: {InternalField_3275.InternalField_3263.ToString("F2")}";
        }
    }
}
