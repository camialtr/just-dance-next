// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal enum InternalType_717 { InternalField_3280, InternalField_3281, InternalField_3282, InternalField_3283 };

    internal static class InternalType_718
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3284 = 45;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3285 = 135;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3286 = 1f;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3287 = 10;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public const float InternalField_3288 = 4 * (Unity.Mathematics.math.SQRT2 - 1) / 3f;

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly Vector3[] InternalField_3289 = new Vector3[] { new Vector3(-1, -1, -1),
                                                                   new Vector3(-1, -1, 1),
                                                                   new Vector3(-1, 1, -1),
                                                                   new Vector3(-1, 1, 1),
                                                                   new Vector3(1, -1, -1),
                                                                   new Vector3(1, -1, 1),
                                                                   new Vector3(1, 1, -1),
                                                                   new Vector3(1, 1, 1) };

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly Vector3[] InternalField_3290 = new Vector3[] { new Vector3(-1, -1, -1),
                                                                        new Vector3(-1, -1, 1),
                                                                        new Vector3(-1, 1, -1),
                                                                        new Vector3(-1, 1, 1),
                                                                        new Vector3(1, -1, -1),
                                                                        new Vector3(1, -1, 1),
                                                                        new Vector3(1, 1, -1),
                                                                        new Vector3(1, 1, 1),
                                                                        new Vector3(0, -1, -1),
                                                                        new Vector3(0, -1, 1),
                                                                        new Vector3(0, 1, -1),
                                                                        new Vector3(0, 1, 1),
                                                                        new Vector3(1, 0, 1),
                                                                        new Vector3(1, 0, -1),
                                                                        new Vector3(-1, 0, -1),
                                                                        new Vector3(-1, 0, 1),
                                                                        new Vector3(1, 1, 0),
                                                                        new Vector3(1, -1, 0),
                                                                        new Vector3(-1, -1, 0),
                                                                        new Vector3(-1, 1, 0),
                                                                        new Vector3(1, 0, 0),
                                                                        new Vector3(-1, 0, 0),
                                                                        new Vector3(0, 1, 0),
                                                                        new Vector3(0, -1, 0),
                                                                        new Vector3(0, 0, 1),
                                                                        new Vector3(0, 0, -1),
                                                                            Vector3.zero};

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly Vector3[] InternalField_3291 = new Vector3[] { new Vector2(-1, -1),
                                                                     new Vector2(-1, 1),
                                                                     new Vector2(1, 1),
                                                                     new Vector2(1, -1)};

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public static readonly Vector3[] InternalField_3292 = new Vector3[] { InternalField_3291[0],
                                                                        InternalField_3291[1],
                                                                        InternalField_3291[2],
                                                                        InternalField_3291[3],
                                                                        new Vector2(1, 0),
                                                                        new Vector2(-1, 0),
                                                                        new Vector2(0, 1),
                                                                        new Vector2(0, -1),
                                                                        Vector2.zero};

        
        private static Bounds InternalMethod_3215(Vector3 InternalParameter_2915, Vector3 InternalParameter_2916)
        {
            Bounds InternalVar_1 = default;
            InternalVar_1.SetMinMax(InternalParameter_2915, InternalParameter_2916);
            return InternalVar_1;
        }

        
        public static Bounds InternalMethod_3216(Bounds InternalParameter_2917, Matrix4x4 InternalParameter_2918)
        {
            Vector3 InternalVar_1 = Vector3.one * float.MaxValue;
            Vector3 InternalVar_2 = Vector3.one * float.MinValue;

            for (int InternalVar_3 = 0; InternalVar_3 < InternalField_3289.Length; ++InternalVar_3)
            {
                Vector3 InternalVar_4 = InternalParameter_2917.center + Vector3.Scale(InternalField_3289[InternalVar_3], InternalParameter_2917.extents);
                Vector3 InternalVar_5 = InternalParameter_2918.MultiplyPoint(InternalVar_4);

                InternalVar_1 = Vector3.Min(InternalVar_1, InternalVar_5);
                InternalVar_2 = Vector3.Max(InternalVar_2, InternalVar_5);
            }

            return InternalMethod_3215(InternalVar_1, InternalVar_2);
        }


        
        public static Ray InternalMethod_3217(Ray InternalParameter_2919, Matrix4x4 InternalParameter_2920)
        {
            return new Ray(InternalParameter_2920.MultiplyPoint(InternalParameter_2919.origin), InternalParameter_2920.MultiplyVector(InternalParameter_2919.direction));
        }

        
        public static Vector3 InternalMethod_3339(Vector3 InternalParameter_31, Vector3 InternalParameter_30)
        {
            Vector3 InternalVar_1 = InternalType_187.InternalMethod_879(math.rcp(InternalParameter_30));

            InternalParameter_31.x = Mathf.Round(InternalParameter_31.x * InternalVar_1.x) * InternalParameter_30.x;
            InternalParameter_31.y = Mathf.Round(InternalParameter_31.y * InternalVar_1.y) * InternalParameter_30.y;
            InternalParameter_31.z = Mathf.Round(InternalParameter_31.z * InternalVar_1.z) * InternalParameter_30.z;

            return InternalParameter_31;
        }

        
        public static Vector3 InternalMethod_3219(Vector3 InternalParameter_2923, float InternalParameter_2924 = 0.001f)
        {
            return InternalMethod_3339(InternalParameter_2923, Vector3.one * InternalParameter_2924);
        }

        
        public static MouseCursor InternalMethod_3220(Vector2 InternalParameter_2925, out Vector2 InternalParameter_2926, float InternalParameter_2927 = 45)
        {
            float InternalVar_1 = Mathf.Clamp(InternalParameter_2927 * 0.5f, 0, 45);
            float InternalVar_2 = Mathf.Atan2(InternalParameter_2925.x, InternalParameter_2925.y) * Mathf.Rad2Deg;

            if (InternalVar_2 < 0f)
            {
                InternalVar_2 = 360f + InternalVar_2;
            }

            if (InternalVar_2 < 45 - InternalVar_1)
            {
                InternalParameter_2926 = Vector2.up;
                return MouseCursor.ResizeVertical;
            }

            if (InternalVar_2 < 45 + InternalVar_1)
            {
                InternalParameter_2926 = Vector2.one.normalized;
                return MouseCursor.ResizeUpRight;
            }

            if (InternalVar_2 < 135 - InternalVar_1)
            {
                InternalParameter_2926 = Vector2.right;
                return MouseCursor.ResizeHorizontal;
            }

            if (InternalVar_2 < 135 + InternalVar_1)
            {
                InternalParameter_2926 = new Vector2(1, -1).normalized;
                return MouseCursor.ResizeUpLeft;
            }

            if (InternalVar_2 < 225 - InternalVar_1)
            {
                InternalParameter_2926 = Vector2.down;
                return MouseCursor.ResizeVertical;
            }

            if (InternalVar_2 < 225 + InternalVar_1)
            {
                InternalParameter_2926 = new Vector2(-1, -1).normalized;
                return MouseCursor.ResizeUpRight;
            }

            if (InternalVar_2 < 315 - InternalVar_1)
            {
                InternalParameter_2926 = Vector3.left;
                return MouseCursor.ResizeHorizontal;
            }

            if (InternalVar_2 < 315 + InternalVar_1)
            {
                InternalParameter_2926 = new Vector2(-1, 1).normalized;
                return MouseCursor.ResizeUpLeft;
            }

            InternalParameter_2926 = Vector2.up;
            return MouseCursor.ResizeVertical;
        }

        
        public static Vector2 InternalMethod_3221(Vector2 InternalParameter_2928, float InternalParameter_2929 = 10)
        {
            float InternalVar_1 = Mathf.Clamp(InternalParameter_2929 * 0.5f, 0, 45);

            float InternalVar_2 = Mathf.Atan2(InternalParameter_2928.x, InternalParameter_2928.y) * Mathf.Rad2Deg;

            if (InternalVar_2 < 0f)
            {
                InternalVar_2 = 360f + InternalVar_2;
            }

            if (InternalVar_2 < 45 - InternalVar_1)
            {
                return Vector2.up;
            }

            if (InternalVar_2 < 45 + InternalVar_1)
            {
                return Vector2.one.normalized;
            }

            if (InternalVar_2 < 135 - InternalVar_1)
            {
                return Vector2.right;
            }

            if (InternalVar_2 < 135 + InternalVar_1)
            {
                return new Vector2(1, -1).normalized;
            }

            if (InternalVar_2 < 225 - InternalVar_1)
            {
                return Vector2.down;
            }

            if (InternalVar_2 < 225 + InternalVar_1)
            {
                return new Vector2(-1, -1).normalized;
            }

            if (InternalVar_2 < 315 - InternalVar_1)
            {
                return Vector2.left;
            }

            if (InternalVar_2 < 315 + InternalVar_1)
            {
                return new Vector2(-1, 1).normalized;
            }

            return Vector2.up;
        }

        
        public static Vector3 InternalMethod_3222(Vector3 InternalParameter_2930, float InternalParameter_2931 = 10)
        {
            Vector2 InternalVar_1 = InternalMethod_3221(new Vector2(InternalParameter_2930.x, InternalParameter_2930.y), InternalParameter_2931);
            Vector2 InternalVar_2 = InternalMethod_3221(new Vector2(InternalParameter_2930.y, InternalParameter_2930.z), InternalParameter_2931);
            Vector2 InternalVar_3 = InternalMethod_3221(new Vector2(InternalParameter_2930.x, InternalParameter_2930.z), InternalParameter_2931);

            return new Vector3(InternalVar_1.x * InternalVar_3.x, InternalVar_1.y * InternalVar_2.x, InternalVar_2.y * InternalVar_3.y).normalized;
        }

        
        public static PrimitiveBoundsHandle.Axes InternalMethod_3223(Camera InternalParameter_2932, Matrix4x4 InternalParameter_2933)
        {
            Vector3 InternalVar_1 = Vector3.zero;
            PrimitiveBoundsHandle.Axes InternalVar_2 = PrimitiveBoundsHandle.Axes.None;

            Vector3 InternalVar_3 = InternalParameter_2933.MultiplyVector(Vector3.right);
            Vector3 InternalVar_4 = InternalParameter_2933.MultiplyVector(Vector3.up);

            float InternalVar_5 = Vector3.Angle(InternalParameter_2932.transform.forward, InternalVar_3);
            float InternalVar_6 = Vector3.Angle(InternalParameter_2932.transform.forward, InternalVar_4);

            int InternalVar_7 = 2;

            if (InternalVar_5 > InternalField_3284 && InternalVar_5 < InternalField_3285)
            {
                InternalVar_2 |= PrimitiveBoundsHandle.Axes.X;
            }
            else
            {
                InternalVar_7 = 0;
            }

            if (InternalVar_6 > InternalField_3284 && InternalVar_6 < InternalField_3285)
            {
                InternalVar_2 |= PrimitiveBoundsHandle.Axes.Y;
            }
            else
            {
                InternalVar_7 = 1;
            }

            if (InternalVar_7 != 2)
            {
                InternalVar_1[2] = 1;
                InternalVar_2 |= PrimitiveBoundsHandle.Axes.Z;
            }

            return InternalVar_2;
        }

        
        public static Vector3 InternalMethod_3224(Vector3 InternalParameter_2934, Vector3 InternalParameter_2935, Vector3 InternalParameter_2936)
        {
            Vector3 InternalVar_1 = InternalParameter_2936 - InternalParameter_2935;
            Vector3 InternalVar_2 = InternalVar_1.normalized;
            Vector3 InternalVar_3 = InternalParameter_2934 - InternalParameter_2935;

            float InternalVar_4 = Mathf.Clamp(Vector3.Dot(InternalVar_3, InternalVar_2), 0, InternalVar_1.magnitude);
            return InternalParameter_2935 + InternalVar_2 * InternalVar_4;
        }

        
        public static void InternalMethod_3315(Vector3 InternalParameter_3110, Vector3 InternalParameter_3111, float InternalParameter_3112, bool InternalParameter_3113 = true)
        {
            if (InternalParameter_3111.z == 0)
            {
                InternalMethod_3316(InternalParameter_3110, InternalParameter_3111, InternalParameter_3112, InternalParameter_3113);
                return;
            }

            Vector3 InternalVar_1 = 0.5f * InternalParameter_3111;

            Vector3 InternalVar_2 = InternalParameter_3110 + Vector3.Scale(new Vector3(-1, -1, -1), InternalVar_1); 
            Vector3 InternalVar_3 = InternalParameter_3110 + Vector3.Scale(new Vector3(1, -1, -1), InternalVar_1); 
            Vector3 InternalVar_4 = InternalParameter_3110 + Vector3.Scale(new Vector3(1, -1, 1), InternalVar_1); 
            Vector3 InternalVar_5 = InternalParameter_3110 + Vector3.Scale(new Vector3(-1, -1, 1), InternalVar_1); 

            Vector3 InternalVar_6 = InternalParameter_3110 + Vector3.Scale(new Vector3(-1, 1, 1), InternalVar_1); 
            Vector3 InternalVar_7 = InternalParameter_3110 + Vector3.Scale(new Vector3(1, 1, 1), InternalVar_1); 
            Vector3 InternalVar_8 = InternalParameter_3110 + Vector3.Scale(new Vector3(1, 1, -1), InternalVar_1); 
            Vector3 InternalVar_9 = InternalParameter_3110 + Vector3.Scale(new Vector3(-1, 1, -1), InternalVar_1); 

            InternalMethod_3317(InternalParameter_3112, InternalParameter_3113, InternalVar_2, InternalVar_3, InternalVar_4, InternalVar_5, InternalVar_6, InternalVar_7, InternalVar_8, InternalVar_9, InternalVar_2);

            InternalMethod_3317(InternalParameter_3112, InternalParameter_3113, InternalVar_2, InternalVar_5);
            InternalMethod_3317(InternalParameter_3112, InternalParameter_3113, InternalVar_3, InternalVar_8);
            InternalMethod_3317(InternalParameter_3112, InternalParameter_3113, InternalVar_4, InternalVar_7);
            InternalMethod_3317(InternalParameter_3112, InternalParameter_3113, InternalVar_6, InternalVar_9);
        }

        
        public static void InternalMethod_3316(Vector3 InternalParameter_3114, Vector3 InternalParameter_3115, float InternalParameter_3116, bool InternalParameter_3117 = true)
        {
            Vector3 InternalVar_1 = 0.5f * InternalParameter_3115;

            Vector3 InternalVar_2 = InternalParameter_3114 + Vector3.Scale(new Vector3(-1, -1, 0), InternalVar_1); 
            Vector3 InternalVar_3 = InternalParameter_3114 + Vector3.Scale(new Vector3(1, -1, 0), InternalVar_1); 

            Vector3 InternalVar_4 = InternalParameter_3114 + Vector3.Scale(new Vector3(1, 1, 0), InternalVar_1); 
            Vector3 InternalVar_5 = InternalParameter_3114 + Vector3.Scale(new Vector3(-1, 1, 0), InternalVar_1); 

            InternalMethod_3317(InternalParameter_3116, InternalParameter_3117, InternalVar_2, InternalVar_3, InternalVar_4, InternalVar_5, InternalVar_2);
        }

        public static void InternalMethod_3317(float InternalParameter_3118, bool InternalParameter_3119 = true, params Vector3[] InternalParameter_3120)
        {
            Color InternalVar_1 = Handles.color;

            if (InternalParameter_3119)
            {
                Handles.color = Color.black;

                Handles.DrawAAPolyLine(InternalField_3286 * InternalParameter_3118, InternalParameter_3120);
            }

            Handles.color = InternalVar_1;

            Handles.DrawAAPolyLine(InternalParameter_3118, InternalParameter_3120);
        }

        
        public static Vector2 InternalMethod_3231(Vector3 InternalParameter_2951, Vector3 InternalParameter_2952)
        {
            Vector3 InternalVar_1 = HandleUtility.WorldToGUIPoint(InternalParameter_2951);
            Vector3 InternalVar_2 = HandleUtility.WorldToGUIPoint(InternalParameter_2951 + InternalParameter_2952);
            Vector2 InternalVar_3 = InternalVar_2 - InternalVar_1;
            InternalVar_3.y *= -1;

            return InternalVar_3.normalized;
        }

        
        public static Vector3 InternalMethod_3232(Vector3 InternalParameter_2953, PrimitiveBoundsHandle.Axes InternalParameter_2954)
        {
            Vector3 InternalVar_1 = new Vector3((InternalParameter_2954 & PrimitiveBoundsHandle.Axes.X) != 0 ? 1 : 0, (InternalParameter_2954 & PrimitiveBoundsHandle.Axes.Y) != 0 ? 1 : 0, (InternalParameter_2954 & PrimitiveBoundsHandle.Axes.Z) != 0 ? 1 : 0);

            return Vector3.Scale(InternalParameter_2953, InternalVar_1);
        }

        
        public static bool InternalMethod_3233(PrimitiveBoundsHandle.Axes InternalParameter_2955, int InternalParameter_2956)
        {
            switch (InternalParameter_2956)
            {
                case 0:
                    return (InternalParameter_2955 & PrimitiveBoundsHandle.Axes.X) != 0;
                case 1:
                    return (InternalParameter_2955 & PrimitiveBoundsHandle.Axes.Y) != 0;
                case 2:
                    return (InternalParameter_2955 & PrimitiveBoundsHandle.Axes.Z) != 0;
            }

            return false;
        }

        
        public static Vector3 InternalMethod_3234(Vector2 InternalParameter_2957, Vector2 InternalParameter_2958, bool InternalParameter_2959 = false)
        {
            Vector2 InternalVar_1 = InternalMethod_3221((InternalParameter_2957 - InternalParameter_2958).normalized, InternalParameter_2959 ? 0 : 45);

            Vector3 InternalVar_2 = HandleUtility.GUIPointToWorldRay(InternalParameter_2957).origin;
            Vector3 InternalVar_3 = HandleUtility.GUIPointToWorldRay(InternalParameter_2957 + InternalVar_1 * InternalField_3287).origin;
            Vector3 InternalVar_4 = InternalVar_3 - InternalVar_2;
            InternalVar_4.y *= -1;
            return InternalVar_4.normalized;
        }

        
        public static Vector2 InternalMethod_3235(Bounds InternalParameter_2960)
        {
            Vector2 InternalVar_1 = Vector2.one * float.MaxValue;
            Vector2 InternalVar_2 = Vector2.one * float.MinValue;

            Vector3[] InternalVar_3 = InternalParameter_2960.size.z == 0 ? InternalField_3291 : InternalField_3289;

            for (int InternalVar_4 = 0; InternalVar_4 < InternalVar_3.Length; ++InternalVar_4)
            {
                Vector3 InternalVar_5 = InternalVar_3[InternalVar_4];
                Vector2 InternalVar_6 = HandleUtility.WorldToGUIPoint(InternalParameter_2960.center + Vector3.Scale(InternalParameter_2960.extents, InternalVar_5));

                InternalVar_1 = Vector2.Min(InternalVar_6, InternalVar_1);
                InternalVar_2 = Vector2.Max(InternalVar_6, InternalVar_2);
            }

            Vector2 InternalVar_7 = 0.5f * (InternalVar_1 + InternalVar_2);
            return new Vector2(InternalVar_7.x, InternalVar_2.y);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Stack<int> InternalField_3293 = new Stack<int>();

        
        public static void InternalMethod_3236()
        {
            InternalField_3293.Push(GUIUtility.hotControl);
        }

        
        public static InternalType_717 InternalMethod_3237()
        {
            InternalType_717 InternalVar_1 = InternalType_717.InternalField_3283;

            if (InternalField_3293.Count == 0)
            {
                Debug.LogError("Mismatch between Begin/End handle manipulation checks.");
                return InternalVar_1;
            }

            int InternalVar_2 = InternalField_3293.Pop();
            int InternalVar_3 = GUIUtility.hotControl;

            if (InternalVar_3 == 0 && InternalVar_2 == 0)
            {
                InternalVar_1 = InternalType_717.InternalField_3283;
            }
            else if (InternalVar_3 != 0 && InternalVar_2 == 0)
            {
                InternalVar_1 = InternalType_717.InternalField_3280;
            }
            else if (InternalVar_3 == 0 && InternalVar_2 != 0)
            {
                InternalVar_1 = InternalType_717.InternalField_3282;
            }
            else if (InternalVar_3 == InternalVar_2)
            {
                InternalVar_1 = InternalType_717.InternalField_3281;
            }

            return InternalVar_1;
        }

        public static void InternalMethod_3238(Vector3 InternalParameter_2961, Vector3 InternalParameter_2962, float InternalParameter_2963, float InternalParameter_2964 = 3)
        {
            Vector3 InternalVar_1 = Vector3.Cross(Vector3.Cross(InternalParameter_2962, Vector3.up), InternalParameter_2962);

            Matrix4x4 InternalVar_2 = Matrix4x4.TRS(InternalParameter_2961, Quaternion.LookRotation(InternalParameter_2962, InternalVar_1), Vector3.one);

            using (new Handles.DrawingScope(Handles.color, Handles.matrix * InternalVar_2))
            {
                InternalMethod_3239(new Bounds(Vector3.zero, Vector2.one * InternalParameter_2963 * 2), InternalParameter_2963, InternalParameter_2964);
            }
        }

        public static void InternalMethod_3239(Bounds InternalParameter_2965, float InternalParameter_2966, float InternalParameter_2967 = 3)
        {
            Vector3 InternalVar_1 = InternalParameter_2965.extents;
            InternalParameter_2966 = Mathf.Min(InternalParameter_2966, InternalVar_1.x, InternalVar_1.y);

            InternalMethod_3241(InternalParameter_2965, Vector2.left, InternalParameter_2966, InternalParameter_2967 + 1);
            InternalMethod_3241(InternalParameter_2965, Vector2.up, InternalParameter_2966, InternalParameter_2967 + 1);
            InternalMethod_3241(InternalParameter_2965, Vector2.down, InternalParameter_2966, InternalParameter_2967 + 1);
            InternalMethod_3241(InternalParameter_2965, Vector2.right, InternalParameter_2966, InternalParameter_2967 + 1);

            if (InternalType_187.InternalMethod_914(InternalParameter_2966))
            {
                return;
            }

            InternalMethod_3240(InternalParameter_2965, new Vector2(-1, -1), InternalParameter_2966, InternalParameter_2967);
            InternalMethod_3240(InternalParameter_2965, new Vector2(-1, 1), InternalParameter_2966, InternalParameter_2967);
            InternalMethod_3240(InternalParameter_2965, new Vector2(1, -1), InternalParameter_2966, InternalParameter_2967);
            InternalMethod_3240(InternalParameter_2965, new Vector2(1, 1), InternalParameter_2966, InternalParameter_2967);
        }

        private static void InternalMethod_3240(Bounds InternalParameter_2968, Vector2 InternalParameter_2969, float InternalParameter_2970, float InternalParameter_2971)
        {
            Vector3 InternalVar_1 = InternalParameter_2968.center + Vector3.Scale(InternalParameter_2968.extents, InternalParameter_2969);

            Vector3 InternalVar_2 = new Vector3(InternalVar_1.x - InternalParameter_2969.x * InternalParameter_2970, InternalVar_1.y, InternalVar_1.z);
            Vector3 InternalVar_3 = new Vector3(InternalVar_1.x, InternalVar_1.y - InternalParameter_2969.y * InternalParameter_2970, InternalVar_1.z);

            Vector3 InternalVar_4 = InternalVar_2;
            InternalVar_4.x += InternalParameter_2969.x * InternalParameter_2970 * InternalField_3288;

            Vector3 InternalVar_5 = InternalVar_3;
            InternalVar_5.y += InternalParameter_2969.y * InternalParameter_2970 * InternalField_3288;

            Handles.DrawBezier(InternalVar_2, InternalVar_3, InternalVar_4, InternalVar_5, Handles.color, null, InternalParameter_2971);
        }

        private static void InternalMethod_3241(Bounds InternalParameter_2972, Vector2 InternalParameter_2973, float InternalParameter_2974, float InternalParameter_2975)
        {
            Vector3 InternalVar_1 = InternalParameter_2972.center + Vector3.Scale(InternalParameter_2972.extents, InternalParameter_2973);

            Vector3 InternalVar_2 = Vector2.one - Vector2.Max(InternalParameter_2973, -InternalParameter_2973);

            Vector3 InternalVar_3 = Vector3.Scale(InternalVar_2, InternalParameter_2972.extents - new Vector3(InternalParameter_2974, InternalParameter_2974, InternalParameter_2974));
            Vector3 InternalVar_4 = InternalVar_1 + InternalVar_3;
            Vector3 InternalVar_5 = InternalVar_1 - InternalVar_3;

            Handles.DrawAAPolyLine(InternalParameter_2975, InternalVar_4, InternalVar_5);
        }

        public static Vector3 InternalMethod_3242(Vector3 InternalParameter_2976, PrimitiveBoundsHandle.Axes InternalParameter_2977, float InternalParameter_2978, Bounds InternalParameter_2979, float InternalParameter_2980)
        {
            Vector3 InternalVar_1 = (InternalParameter_2976 - InternalParameter_2979.center).normalized;

            Vector3 InternalVar_2 = new Vector3(InternalType_187.InternalMethod_892(InternalVar_1.x), InternalType_187.InternalMethod_892(InternalVar_1.y), InternalType_187.InternalMethod_892(InternalVar_1.z));
            Vector3 InternalVar_3 = InternalParameter_2979.center + 0.5f * Vector3.Scale(InternalVar_2, InternalParameter_2979.size);

            Vector2 InternalVar_4 = HandleUtility.WorldToGUIPoint(InternalParameter_2976);
            Vector2 InternalVar_5 = HandleUtility.WorldToGUIPoint(InternalVar_3);

            float InternalVar_6 = Vector2.Distance(InternalVar_4, InternalVar_5);

            int InternalVar_7 = !InternalMethod_3233(InternalParameter_2977, 0) ? 0 : !InternalMethod_3233(InternalParameter_2977, 1) ? 1 : 2;

            Vector3 InternalVar_8 = Vector3.zero;
            InternalVar_8[InternalVar_7] = 1;

            if (InternalVar_6 < InternalParameter_2980)
            {
                Matrix4x4 InternalVar_9 = Handles.inverseMatrix;

                Vector2 InternalVar_10 = InternalMethod_3231(InternalVar_3, InternalMethod_3232((-InternalVar_2).normalized, InternalParameter_2977));
                InternalVar_10.y *= -1;

                Vector2 InternalVar_11 = InternalVar_5 + InternalVar_10 * InternalParameter_2980 * InternalParameter_2978;

                Ray InternalVar_12 = HandleUtility.GUIPointToWorldRay(InternalVar_11);
                Ray InternalVar_13 = InternalMethod_3217(InternalVar_12, InternalVar_9);

                Plane InternalVar_14 = new Plane(InternalVar_8, InternalVar_3);

                if (InternalVar_14.Raycast(InternalVar_13, out float InternalVar_15))
                {
                    InternalParameter_2976 = InternalVar_13.GetPoint(InternalVar_15);
                }
            }

            return InternalParameter_2976;
        }

        
        public static Vector3 InternalMethod_3243(Vector2 InternalParameter_2981, PrimitiveBoundsHandle.Axes InternalParameter_2982, float InternalParameter_2983 = 0)
        {
            return new Vector3((InternalParameter_2982 & PrimitiveBoundsHandle.Axes.X) != 0 ? InternalParameter_2981.x : InternalParameter_2983,
                               (InternalParameter_2982 & PrimitiveBoundsHandle.Axes.Y) != 0 ? (InternalParameter_2982 & PrimitiveBoundsHandle.Axes.X) != 0 ? InternalParameter_2981.y : InternalParameter_2981.x : InternalParameter_2983,
                               (InternalParameter_2982 & PrimitiveBoundsHandle.Axes.Z) != 0 ? InternalParameter_2981.y : InternalParameter_2983);
        }

        
        public static Vector2 InternalMethod_3244(Vector3 InternalParameter_2984, PrimitiveBoundsHandle.Axes InternalParameter_2985)
        {
            return new Vector2((InternalParameter_2985 & PrimitiveBoundsHandle.Axes.X) == 0 ? InternalParameter_2984.z : InternalParameter_2984.x,
                               (InternalParameter_2985 & PrimitiveBoundsHandle.Axes.Y) == 0 ? InternalParameter_2984.z : InternalParameter_2984.y);
        }

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Vector3[] InternalField_3294 = new Vector3[4];
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Vector3[] InternalField_3295 = new Vector3[4];
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Vector3[] InternalField_3296 = new Vector3[4];

        
        public static void InternalMethod_3245(Vector3 InternalParameter_2986, Quaternion InternalParameter_2987, float InternalParameter_2988, Color InternalParameter_2989, Color InternalParameter_2990, Color InternalParameter_2991)
        {
            Matrix4x4 InternalVar_1 = Matrix4x4.Rotate(InternalParameter_2987);

            const float InternalVar_2 = 0.5f;
            const float InternalVar_3 = 0.9f;
            const float InternalVar_4 = 1f;

            Vector3 InternalVar_5 = InternalVar_1.MultiplyVector(new Vector3(-1, -1, 0).normalized);
            Vector3 InternalVar_6 = InternalVar_1.MultiplyVector(new Vector3(1, -1, 0).normalized);
            Vector3 InternalVar_7 = InternalVar_1.MultiplyVector(new Vector3(1, 1, 0).normalized);
            Vector3 InternalVar_8 = InternalVar_1.MultiplyVector(new Vector3(-1, 1, 0).normalized);

            InternalField_3294[0] = InternalParameter_2986 + (InternalVar_2 * InternalParameter_2988 * InternalVar_5);
            InternalField_3294[1] = InternalParameter_2986 + (InternalVar_2 * InternalParameter_2988 * InternalVar_6);
            InternalField_3294[2] = InternalParameter_2986 + (InternalVar_2 * InternalParameter_2988 * InternalVar_7);
            InternalField_3294[3] = InternalParameter_2986 + (InternalVar_2 * InternalParameter_2988 * InternalVar_8);

            InternalField_3295[0] = InternalParameter_2986 + (InternalVar_3 * InternalParameter_2988 * InternalVar_5);
            InternalField_3295[1] = InternalParameter_2986 + (InternalVar_3 * InternalParameter_2988 * InternalVar_6);
            InternalField_3295[2] = InternalParameter_2986 + (InternalVar_3 * InternalParameter_2988 * InternalVar_7);
            InternalField_3295[3] = InternalParameter_2986 + (InternalVar_3 * InternalParameter_2988 * InternalVar_8);

            InternalField_3296[0] = InternalParameter_2986 + (InternalVar_4 * InternalParameter_2988 * InternalVar_5);
            InternalField_3296[1] = InternalParameter_2986 + (InternalVar_4 * InternalParameter_2988 * InternalVar_6);
            InternalField_3296[2] = InternalParameter_2986 + (InternalVar_4 * InternalParameter_2988 * InternalVar_7);
            InternalField_3296[3] = InternalParameter_2986 + (InternalVar_4 * InternalParameter_2988 * InternalVar_8);

            using (new Handles.DrawingScope(Color.white, Handles.matrix))
            {
                Handles.color = InternalParameter_2991;
                Handles.DrawAAConvexPolygon(InternalField_3295);
                Handles.color = InternalParameter_2990;
                Handles.DrawAAConvexPolygon(InternalField_3295);
                Handles.color = InternalParameter_2989;
                Handles.DrawAAConvexPolygon(InternalField_3294);
            }
        }
    }
}
