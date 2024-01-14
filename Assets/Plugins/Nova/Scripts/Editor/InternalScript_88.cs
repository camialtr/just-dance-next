// Copyright (c) Supernova Technologies LLC

using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    
    internal class InternalType_704 : InternalType_706
    {
        public delegate bool InternalType_705(Bounds bounds, Vector3 movementAxis, Ray worldSpaceRay, out Vector3 worldSpaceSnapPoint, out InternalType_152<InternalType_427> hitID);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3237 = 3f;

        protected override Bounds InternalMethod_3158(Vector3 InternalParameter_2840, Vector3 InternalParameter_2841, Bounds InternalParameter_2842) => InternalMethod_3138(InternalParameter_2840, InternalParameter_2841, InternalParameter_2842);

        private Bounds InternalMethod_3138(Vector3 InternalParameter_2837, Vector3 InternalParameter_2838, Bounds InternalParameter_2839)
        {
            Vector3 InternalVar_1 = InternalParameter_2839.center + Vector3.Scale(InternalParameter_2838, InternalParameter_2839.extents);

            Matrix4x4 InternalVar_2 = Handles.matrix;
            Matrix4x4 InternalVar_3 = InternalVar_2.inverse;

            Ray InternalVar_4 = new Ray(InternalVar_2.MultiplyPoint(InternalVar_1), Vector3.forward);

            InternalType_152<InternalType_427> InternalVar_5 = InternalType_152<InternalType_427>.InternalField_441;
            Vector3 InternalVar_6 = Vector3.zero;

            InternalVar_4.direction = InternalVar_2.MultiplyVector(InternalParameter_2837);

            bool InternalVar_7 = InternalField_3238 != null ? InternalField_3238.Invoke(InternalParameter_2839, InternalParameter_2838, InternalVar_4, out InternalVar_6, out InternalVar_5) : false;

            Vector3 InternalVar_8 = InternalVar_3.MultiplyPoint(InternalVar_6);

            Vector2 InternalVar_9 = HandleUtility.WorldToGUIPoint(InternalVar_1);
            Vector2 InternalVar_10 = HandleUtility.WorldToGUIPoint(InternalVar_8);
            float InternalVar_11 = Vector2.Distance(InternalVar_10, InternalVar_9);

            if (InternalVar_7 && InternalVar_11 < InternalField_3237)
            {
                Vector3 InternalVar_12 = InternalParameter_2839.min;
                Vector3 InternalVar_13 = InternalParameter_2839.max;

                Vector3 InternalVar_14 = InternalVar_12;
                Vector3 InternalVar_15 = InternalVar_13;

                for (int InternalVar_16 = 0; InternalVar_16 < 3; ++InternalVar_16)
                {
                    if (InternalParameter_2838[InternalVar_16] < 0)
                    {
                        InternalVar_12[InternalVar_16] = InternalVar_8[InternalVar_16];
                    }

                    if (InternalParameter_2838[InternalVar_16] > 0)
                    {
                        InternalVar_13[InternalVar_16] = InternalVar_8[InternalVar_16];
                    }
                }

                InternalParameter_2839.SetMinMax(InternalVar_12, InternalVar_13);

                if (InternalVar_14 != InternalVar_12 || InternalVar_15 != InternalVar_13)
                {
                    InternalField_3239?.Invoke(InternalVar_5);
                }
            }

            return InternalParameter_2839;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_705 InternalField_3238 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public System.Action<InternalType_152<InternalType_427>> InternalField_3239 = null;

        public InternalType_704()
        {
            midpointHandleDrawFunction = null;
        }
    }

    internal class InternalType_706 : PrimitiveBoundsHandle
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3240 = 4f;
        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_3241 = 30; 
        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_3361 = 100;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public System.Action<Vector3, Quaternion, float, bool> InternalField_3242 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Vector2 InternalProperty_1003 { get; private set; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Matrix4x4 InternalProperty_1004 { get; private set; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_3243 = true;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_1005 => InternalField_3245 && InternalField_3243;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_3244 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_1006 => InternalField_3244 && InternalField_3243;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_3245 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector2 InternalField_3246 = Vector2.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3247 = Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3248 = Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector2 InternalField_3249 = Vector2.up;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_3250;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int InternalProperty_1007 => InternalField_3250;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3251 = Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3252 = Vector3.zero;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3253;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_1008
        {
            get
            {
                Vector3 InternalVar_1 = GetSize();
                return new Vector3((axes & Axes.X) != 0 ? InternalVar_1.x : InternalField_3253.x,
                                   (axes & Axes.Y) != 0 ? InternalVar_1.y : InternalField_3253.y,
                                   (axes & Axes.Z) != 0 ? InternalVar_1.z : InternalField_3253.z);
            }
            set
            {
                float InternalVar_1 = InternalType_187.InternalMethod_932(value.x) ? value.x : 0;
                float InternalVar_2 = InternalType_187.InternalMethod_932(value.y) ? value.y : 0;
                float InternalVar_3 = InternalType_187.InternalMethod_932(value.z) ? value.z : 0;

                Vector3 InternalVar_4 = new Vector3(InternalVar_1, InternalVar_2, InternalVar_3);

                InternalField_3253 = InternalVar_4;

                SetSize(InternalVar_4);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Bounds InternalField_3254;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Bounds? InternalField_3255;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_1009 { get; private set; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int InternalProperty_1010 { get; private set; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_1011 => Event.current.shift || InternalProperty_1012;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_1012 { get; set; }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalProperty_1013 => (axes & Axes.X) == 0 ? 0 : (axes & Axes.Y) == 0 ? 1 : 2;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3[] InternalField_3256 = new Vector3[5];

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private float InternalField_3257 = 0;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3258 = Vector3.zero;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Vector3 InternalProperty_1014 => InternalField_3258;

        protected virtual Bounds InternalMethod_3158(Vector3 InternalParameter_2840, Vector3 InternalParameter_2841, Bounds InternalParameter_2842) { return InternalParameter_2842; }

        public new void DrawHandle()
        {
            InternalMethod_3159();

            bool InternalVar_1 = Event.current.type == EventType.Repaint;
            bool InternalVar_2 = InternalField_3243 && (GUIUtility.hotControl == 0 || InternalField_3245);

            if (InternalVar_2 && InternalMethod_3160() && !InternalVar_1)
            {
                InternalMethod_3161();
            }

            if (!InternalField_3245)
            {
                InternalField_3250 = 0;
            }

            InternalMethod_3165();
        }

        private void InternalMethod_3159()
        {
            Bounds InternalVar_1 = InternalField_3255.HasValue ? InternalField_3255.Value : InternalField_3254;

            Matrix4x4 InternalVar_2 = Handles.inverseMatrix;
            Vector3 InternalVar_3 = InternalVar_2.MultiplyPoint(Camera.current.transform.position);
            Vector3 InternalVar_4 = InternalVar_3 - center;
            InternalField_3257 = center[InternalProperty_1013] + (0.5f * InternalProperty_1008[InternalProperty_1013] * InternalType_187.InternalMethod_892(InternalVar_4[InternalProperty_1013]));

            Vector3 InternalVar_5 = InternalVar_1.center;
            InternalVar_5[InternalProperty_1013] = InternalField_3257;

            Vector3 InternalVar_6 = InternalVar_1.extents;
            InternalVar_6[InternalProperty_1013] = 0;

            Vector3 InternalVar_7 = Vector3.zero;
            InternalVar_7[InternalProperty_1013] = 1;

            Vector2 InternalVar_8 = Event.current.mousePosition;

            Vector3[] InternalVar_9 = InternalType_718.InternalField_3291;

            InternalField_3256[4] = InternalVar_5 + Vector3.Scale(InternalType_718.InternalMethod_3243(InternalVar_9[0], axes), InternalVar_6);
            Vector2 InternalVar_10 = HandleUtility.WorldToGUIPoint(InternalField_3256[4]);

            int InternalVar_11 = 4;
            float InternalVar_12 = float.MaxValue;

            for (int InternalVar_13 = InternalVar_9.Length - 1; InternalVar_13 >= 0; --InternalVar_13)
            {
                InternalField_3256[InternalVar_13] = InternalVar_5 + Vector3.Scale(InternalType_718.InternalMethod_3243(InternalVar_9[InternalVar_13], axes), InternalVar_6);
                Vector2 InternalVar_14 = HandleUtility.WorldToGUIPoint(InternalField_3256[InternalVar_13]);

                Vector2 InternalVar_15 = InternalType_718.InternalMethod_3224(InternalVar_8, InternalVar_10, InternalVar_14);

                float InternalVar_16 = (InternalVar_8 - InternalVar_15).sqrMagnitude;

                if (InternalVar_16 < InternalVar_12)
                {
                    InternalVar_12 = InternalVar_16;
                    InternalVar_11 = InternalVar_13;
                }

                InternalVar_10 = InternalVar_14;
            }

            Ray InternalVar_17 = HandleUtility.GUIPointToWorldRay(InternalVar_8);
            Ray InternalVar_18 = new Ray(InternalVar_2.MultiplyPoint(InternalVar_17.origin), InternalVar_2.MultiplyVector(InternalVar_17.direction));

            Plane InternalVar_19 = new Plane(InternalVar_7, InternalVar_5);

            if (InternalVar_19.Raycast(InternalVar_18, out float InternalVar_20))
            {
                Vector3 InternalVar_21 = InternalVar_18.GetPoint(InternalVar_20);

                InternalField_3248 = InternalType_718.InternalMethod_3224(InternalVar_21, InternalField_3256[InternalVar_11], InternalField_3256[InternalVar_11 + 1]);
            }
            else
            {
                InternalField_3248 = Vector3.one * float.NegativeInfinity;
            }

            InternalField_3258 = Handles.matrix.MultiplyPoint(InternalVar_5);
        }

        private bool InternalMethod_3160()
        {
            Vector2 InternalVar_1 = HandleUtility.WorldToGUIPoint(InternalField_3254.min);
            Vector2 InternalVar_2 = HandleUtility.WorldToGUIPoint(InternalField_3254.max);
            Vector2 InternalVar_3 = InternalVar_2 - InternalVar_1;
            InternalVar_3 = Vector2.Max(-InternalVar_3, InternalVar_3);

            Vector2 InternalVar_4 = Event.current.mousePosition;

            float InternalVar_5 = Vector2.Distance(HandleUtility.WorldToGUIPoint(InternalField_3248), InternalVar_4);

            InternalField_3244 = InternalVar_5 <= 0.5f * InternalField_3241;

            if (!InternalField_3244 && !InternalField_3245)
            {
                return false;
            }

            Rect InternalVar_6 = new Rect(InternalVar_4 - (Vector2.one * InternalField_3361), Vector2.one * InternalField_3361 * 2);

            if (!InternalField_3245)
            {
                Vector2 InternalVar_7 = HandleUtility.WorldToGUIPoint(InternalField_3254.center);

                if (Vector2.Distance(InternalVar_7, InternalVar_4) < InternalVar_5) 
                {
                    return false;
                }

                Vector3 InternalVar_8 = center;
                InternalVar_8[InternalProperty_1013] = InternalField_3257;

                Vector3 InternalVar_9 = (InternalField_3248 - InternalVar_8);

                InternalVar_9 = new Vector3(InternalField_3253.x == 0 ? 0 : InternalVar_9.x / InternalField_3253.x,
                                             InternalField_3253.y == 0 ? 0 : InternalVar_9.y / InternalField_3253.y,
                                             InternalField_3253.z == 0 ? 0 : InternalVar_9.z / InternalField_3253.z);

                Vector3 InternalVar_10 = new Vector3(InternalType_187.InternalMethod_892(InternalVar_9.x), InternalType_187.InternalMethod_892(InternalVar_9.y), InternalType_187.InternalMethod_892(InternalVar_9.z));

                InternalVar_9 = Vector3.Scale(InternalType_718.InternalMethod_3222(InternalVar_9), InternalVar_10);

                InternalField_3247 = InternalType_718.InternalMethod_3232(InternalVar_9, axes);
                InternalField_3246 = InternalType_718.InternalMethod_3231(InternalVar_8, InternalField_3247.normalized);
            }

            InternalField_3250 = GUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.AddCursorRect(InternalVar_6, InternalType_718.InternalMethod_3220(InternalField_3246, out InternalField_3249), InternalField_3250);

            Vector3 InternalVar_11 = new Vector3(InternalType_187.InternalMethod_892(InternalField_3247.x), InternalType_187.InternalMethod_892(InternalField_3247.y), InternalType_187.InternalMethod_892(InternalField_3247.z));
            InternalVar_11[InternalProperty_1013] = InternalType_187.InternalMethod_892(InternalField_3257 - center[InternalProperty_1013]);
            InternalProperty_1009 = InternalVar_11;

            return true;
        }

        private void InternalMethod_3161()
        {
            InternalType_718.InternalMethod_3236();

            EditorGUI.BeginChangeCheck();

            Vector3 InternalVar_1 = Handles.Slider(InternalField_3250, InternalField_3248, InternalType_718.InternalMethod_3243(InternalField_3249, axes), 0, Handles.ArrowHandleCap, 0);

            bool InternalVar_2 = EditorGUI.EndChangeCheck();

            switch (InternalType_718.InternalMethod_3237())
            {
                case InternalType_717.InternalField_3280:
                    InternalField_3245 = true;

                    InternalField_3251 = InternalProperty_1008;
                    InternalField_3252 = center;

                    InternalProperty_1003 = Event.current.mousePosition;
                    InternalProperty_1004 = Handles.matrix;
                    break;
                case InternalType_717.InternalField_3282:
                    InternalField_3245 = false;
                    break;
            }

            if (!InternalVar_2)
            {
                return;
            }

            Vector3 InternalVar_3 = InternalType_718.InternalMethod_3222(InternalType_718.InternalMethod_3234(InternalProperty_1003, InternalProperty_1003 + InternalField_3249));
            Vector3 InternalVar_4 = InternalType_718.InternalMethod_3232(Handles.matrix.inverse.MultiplyVector(InternalVar_3), axes).normalized;

            Bounds InternalVar_5 = new Bounds(InternalField_3252, InternalField_3251);
            Vector3 InternalVar_6 = InternalField_3252 + Vector3.Scale(InternalField_3251 * 0.5f, InternalProperty_1009);

            Vector3 InternalVar_7 = Vector3.zero;

            if (InternalProperty_1011)
            {
                Vector3 InternalVar_8 = InternalType_718.InternalMethod_3232(Vector3.one, axes).normalized;

                InternalVar_7 = InternalVar_8 * HandleUtility.CalcLineTranslation(InternalProperty_1003,
                                                                         Event.current.mousePosition,
                                                                         InternalVar_6,
                                                                         InternalProperty_1009);
            }
            else
            {
                for (int InternalVar_8 = 0; InternalVar_8 < 3; ++InternalVar_8)
                {
                    if (InternalProperty_1009[InternalVar_8] == 0 || InternalVar_8 == InternalProperty_1013)
                    {
                        continue;
                    }

                    Vector3 InternalVar_9 = Vector3.zero;
                    InternalVar_9[InternalVar_8] = InternalProperty_1009[InternalVar_8];

                    InternalVar_7[InternalVar_8] = HandleUtility.CalcLineTranslation(InternalProperty_1003,
                                                                       Event.current.mousePosition,
                                                                       InternalVar_6,
                                                                       InternalVar_9);
                }
            }

            if (InternalVar_7 == Vector3.zero)
            {
                return;
            }

            Vector3 InternalVar_10 = InternalVar_6 + Vector3.Scale(InternalVar_7, InternalProperty_1009);
            Vector3 InternalVar_11 = InternalVar_5.min;
            Vector3 InternalVar_12 = InternalVar_5.max;

            for (int InternalVar_13 = 0; InternalVar_13 < 3; ++InternalVar_13)
            {
                if (InternalProperty_1009[InternalVar_13] < 0)
                {
                    InternalVar_11[InternalVar_13] = Handles.SnapValue(InternalVar_10[InternalVar_13], EditorSnapSettings.move[InternalVar_13]);
                }

                if (InternalProperty_1009[InternalVar_13] > 0)
                {
                    InternalVar_12[InternalVar_13] = Handles.SnapValue(InternalVar_10[InternalVar_13], EditorSnapSettings.move[InternalVar_13]);
                }
            }

            Bounds InternalVar_14 = default(Bounds);

            InternalVar_14.SetMinMax(InternalVar_11, InternalVar_12);

            Vector3 InternalVar_15 = InternalVar_14.size;
            Vector3 InternalVar_16 = InternalVar_14.center;

            if (InternalVar_15 == InternalProperty_1008)
            {
                return;
            }

            if (InternalProperty_1011)
            {
                InternalMethod_3163(InternalField_3251, InternalField_3252, InternalProperty_1009, ref InternalVar_15, ref InternalVar_16);

                InternalVar_14 = new Bounds(InternalVar_16, InternalVar_15);
            }

            InternalProperty_1008 = InternalVar_14.size;
            center = InternalVar_14.center;
        }

        public bool InternalMethod_3162(Bounds InternalParameter_2843, out Bounds InternalParameter_2844)
        {
            Vector3 InternalVar_1 = InternalType_718.InternalMethod_3222(InternalType_718.InternalMethod_3234(InternalProperty_1003, InternalProperty_1003 + InternalField_3249));
            Vector3 InternalVar_2 = InternalType_718.InternalMethod_3232(Handles.matrix.inverse.MultiplyVector(InternalVar_1), axes).normalized;

            Vector2 InternalVar_3 = InternalType_718.InternalMethod_3221(InternalField_3246);

            Vector3 InternalVar_4 = InternalParameter_2843.min;
            Vector3 InternalVar_5 = InternalParameter_2843.max;

            bool InternalVar_6 = InternalVar_3 == Vector2.left || InternalVar_3 == Vector2.right || InternalVar_3 == Vector2.up || InternalVar_3 == Vector2.down;

            if (InternalVar_6)
            {
                Bounds InternalVar_7 = InternalMethod_3158(InternalVar_2, InternalProperty_1009, InternalParameter_2843);
                InternalVar_4 = InternalVar_7.min;
                InternalVar_5 = InternalVar_7.max;
            }
            else
            {
                for (int InternalVar_7 = 0; InternalVar_7 < 3; ++InternalVar_7)
                {
                    if (InternalVar_2[InternalVar_7] == 0)
                    {
                        continue;
                    }

                    Vector3 InternalVar_8 = Vector3.zero;
                    InternalVar_8[InternalVar_7] = InternalType_187.InternalMethod_892(InternalVar_2[InternalVar_7]);

                    Bounds InternalVar_9 = InternalMethod_3158(InternalVar_8, InternalProperty_1009, InternalParameter_2843);

                    InternalVar_4[InternalVar_7] = InternalVar_9.min[InternalVar_7];
                    InternalVar_5[InternalVar_7] = InternalVar_9.max[InternalVar_7];
                }
            }

            InternalParameter_2843.SetMinMax(InternalVar_4, InternalVar_5);

            Vector3 InternalVar_10 = InternalType_187.InternalMethod_879(InternalParameter_2843.center);
            Vector3 InternalVar_11 = InternalType_187.InternalMethod_879(InternalParameter_2843.size);

            if (InternalProperty_1011)
            {
                InternalMethod_3163(InternalField_3251, InternalField_3252, InternalProperty_1009, ref InternalVar_11, ref InternalVar_10);
            }

            Unity.Mathematics.float3 InternalVar_12 = InternalVar_11;
            Unity.Mathematics.float3 InternalVar_13 = InternalProperty_1008;

            Unity.Mathematics.bool3 InternalVar_14 = InternalVar_12 == InternalVar_13;

            InternalParameter_2844 = new Bounds(Unity.Mathematics.math.select(center, InternalVar_10, InternalVar_14), InternalVar_11);

            return Unity.Mathematics.math.any(InternalVar_14);
        }

        private static void InternalMethod_3163(Vector3 InternalParameter_2845, Vector3 InternalParameter_2846, Vector3 InternalParameter_2847, ref Vector3 InternalParameter_2848, ref Vector3 InternalParameter_2849)
        {
            Vector3 InternalVar_1 = InternalParameter_2848 - InternalParameter_2845;
            Vector3 InternalVar_2 = new Vector3(InternalParameter_2845.x == 0 ? 0 : InternalVar_1.x / InternalParameter_2845.x,
                                                 InternalParameter_2845.y == 0 ? 0 : InternalVar_1.y / InternalParameter_2845.y,
                                                 InternalParameter_2845.z == 0 ? 0 : InternalVar_1.z / InternalParameter_2845.z);

            float InternalVar_3 = InternalType_187.InternalMethod_870(InternalType_187.InternalMethod_870(InternalVar_2.x, InternalVar_2.y), InternalVar_2.z);

            InternalParameter_2848 = InternalParameter_2845 + (InternalParameter_2845 * InternalVar_3);
            InternalParameter_2849 = InternalParameter_2846 + Vector3.Scale(InternalParameter_2848 - InternalParameter_2845, InternalParameter_2847) * 0.5f;
        }

        private static Vector3 InternalMethod_3164(Axes InternalParameter_2850)
        {
            Vector3 InternalVar_1 = (InternalParameter_2850 & Axes.X) != 0 ? Vector3.right : Vector3.up;
            Vector3 InternalVar_2 = (InternalParameter_2850 & Axes.X) != 0 && (InternalParameter_2850 & Axes.Y) != 0 ? Vector3.up : Vector3.forward;

            return Vector3.Cross(InternalVar_1, InternalVar_2);
        }

        protected void InternalMethod_3165()
        {
            bool InternalVar_1 = Event.current.type == EventType.Repaint;

            if (!InternalVar_1)
            {
                return;
            }

            InternalType_718.InternalMethod_3315(InternalField_3254.center, InternalField_3254.size, InternalField_3240);

            Vector3[] InternalVar_2 = InternalType_718.InternalField_3291;

            Vector3 InternalVar_3 = InternalMethod_3164(axes);

            float InternalVar_4 = InternalField_3257 - center[InternalProperty_1013];

            int InternalVar_5 = InternalField_3245 ? InternalField_3250 : 0;

            for (int InternalVar_6 = 0; InternalVar_6 < InternalVar_2.Length; ++InternalVar_6)
            {
                Vector3 InternalVar_7 = InternalType_718.InternalMethod_3243(InternalVar_2[InternalVar_6], axes, InternalType_187.InternalMethod_892(InternalVar_4));
                Vector3 InternalVar_8 = center + Vector3.Scale(0.5f * InternalProperty_1008, InternalVar_7);
                float InternalVar_9 = midpointHandleSizeFunction != null ? midpointHandleSizeFunction.Invoke(InternalVar_8) : DefaultMidpointHandleSizeFunction(InternalVar_8);

                InternalField_3242?.Invoke(InternalVar_8, Quaternion.LookRotation(InternalVar_3), InternalVar_9, InternalVar_7 == InternalProperty_1009 && InternalField_3245);
            }
        }

        protected override void DrawWireframe() { }
    }
}
