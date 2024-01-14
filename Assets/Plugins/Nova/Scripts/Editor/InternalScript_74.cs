// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    internal class InternalType_707
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3259 = 32f;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_1015 { get; private set; } = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Handles.CapFunction InternalField_3260 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Handles.SizeFunction InternalField_3261 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Bounds InternalField_3262;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float InternalField_3263;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public PrimitiveBoundsHandle.Axes InternalField_3264;

        public void InternalMethod_3168()
        {
            if (!InternalProperty_1015 && GUIUtility.hotControl != 0)
            {
                return;
            }

            bool InternalVar_1 = InternalProperty_1015;

            bool InternalVar_2 = InternalField_3262.extents.z == 0;

            Vector3[] InternalVar_3 = InternalType_718.InternalField_3291;

            Vector2 InternalVar_4 = HandleUtility.WorldToGUIPoint(InternalField_3262.min);
            Vector2 InternalVar_5 = HandleUtility.WorldToGUIPoint(InternalField_3262.max);

            if (InternalType_187.InternalMethod_871(InternalVar_5.x - InternalVar_4.x) < InternalField_3259 ||
                InternalType_187.InternalMethod_871(InternalVar_5.y - InternalVar_4.y) < InternalField_3259)
            {
                return;
            }

            for (int InternalVar_6 = 0; InternalVar_6 < InternalVar_3.Length; ++InternalVar_6)
            {
                Vector3 InternalVar_7 = InternalVar_2 ? InternalVar_3[InternalVar_6] : InternalType_718.InternalMethod_3243(InternalVar_3[InternalVar_6], InternalField_3264);

                Vector3 InternalVar_8 = InternalField_3262.center + Vector3.Scale(InternalField_3262.extents, InternalVar_7);
                Vector3 InternalVar_9 = InternalVar_8 - Vector3.Scale(Vector3.one * InternalField_3263, InternalVar_7);
                Vector3 InternalVar_10 = InternalProperty_1015 ? InternalVar_9 : InternalType_718.InternalMethod_3242(InternalVar_9, InternalField_3264, 1, InternalField_3262, InternalField_3259);

                Vector3 InternalVar_11 = Vector3.Min(InternalVar_8, Vector3.zero);
                Vector3 InternalVar_12 = Vector3.Max(InternalVar_8, Vector3.zero);

                InternalVar_10 = Vector3.Max(Vector3.Min(InternalVar_10, InternalVar_12), InternalVar_11);

                float InternalVar_13 = InternalField_3261 != null ? InternalField_3261.Invoke(InternalVar_10) : PrimitiveBoundsHandle.DefaultMidpointHandleSizeFunction(InternalVar_10);

                EditorGUI.BeginChangeCheck();
                InternalType_718.InternalMethod_3236();
                Vector3 InternalVar_14 = Handles.Slider(InternalVar_10, -InternalVar_7.normalized, InternalVar_13, InternalMethod_3169, EditorSnapSettings.scale);
                InternalVar_14 = Vector3.Max(Vector3.Min(InternalField_3262.max, InternalVar_14), InternalField_3262.min);
                switch (InternalType_718.InternalMethod_3237())
                {
                    case InternalType_717.InternalField_3280:
                        InternalProperty_1015 = true;
                        break;
                    case InternalType_717.InternalField_3282:
                        InternalProperty_1015 = false;
                        break;
                }

                if (EditorGUI.EndChangeCheck())
                {
                    Vector3 InternalVar_15 = InternalVar_14 - InternalVar_8;

                    InternalField_3263 = Mathf.Max(Mathf.Max(Mathf.Abs(InternalVar_15.x), Mathf.Abs(InternalVar_15.y)), Mathf.Abs(InternalVar_15.z));
                }
            }

            Bounds InternalVar_16 = new Bounds(InternalField_3262.center, InternalType_718.InternalMethod_3244(InternalField_3262.size, InternalField_3264));
            Matrix4x4 InternalVar_17 = Handles.matrix;

            if ((InternalField_3264 & PrimitiveBoundsHandle.Axes.Z) != 0)
            {
                Quaternion InternalVar_18 = InternalMethod_3170();
                InternalVar_16.center = InternalVar_18 * InternalVar_16.center;
                InternalVar_17 = Matrix4x4.TRS(InternalVar_17.GetColumn(3), InternalVar_17.rotation * InternalVar_18, InternalVar_17.lossyScale);
            }

            using (new Handles.DrawingScope(Handles.color, InternalVar_17))
            {
                InternalType_718.InternalMethod_3239(InternalVar_16, InternalField_3263);
            }
        }

        private void InternalMethod_3169(int InternalParameter_2851, Vector3 InternalParameter_2852, Quaternion InternalParameter_2853, float InternalParameter_2854, EventType InternalParameter_2855)
        {
            InternalField_3260?.Invoke(InternalParameter_2851, InternalParameter_2852, InternalMethod_3170(), InternalParameter_2854, InternalParameter_2855);
        }

        private Quaternion InternalMethod_3170()
        {
            int InternalVar_1 = (InternalField_3264 & PrimitiveBoundsHandle.Axes.X) == 0 ? 0 :
                                   (InternalField_3264 & PrimitiveBoundsHandle.Axes.Y) == 0 ? 1 :
                                   2;

            Vector3 InternalVar_2 = Vector3.zero;
            InternalVar_2[InternalVar_1] = 1;

            Vector3 InternalVar_3 = InternalVar_1 == 0 ? Vector3.down :
                         InternalVar_1 == 1 ? Vector3.forward :
                         Vector3.up;

            return Quaternion.LookRotation(InternalVar_2, InternalVar_3);
        }
    }
}
