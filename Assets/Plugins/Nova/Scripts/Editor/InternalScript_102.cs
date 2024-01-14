// Copyright (c) Supernova Technologies LLC

using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    internal abstract class InternalType_700 : InternalType_701
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3195 = 0.03f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3196 = InternalType_704.InternalField_3237;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3198 = Vector3.right;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3 InternalField_3199 = Vector3.up;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int InternalField_3200 = 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const int InternalField_3201 = 2;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        List<InternalType_427> InternalField_3202 = new List<InternalType_427>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<InternalType_152<InternalType_427>, System.Action> InternalField_3203 = new Dictionary<InternalType_152<InternalType_427>, System.Action>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_153<InternalType_152<InternalType_427>> InternalField_3204 = new InternalType_153<InternalType_152<InternalType_427>>();

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<Vector3> InternalField_3205 = new List<Vector3>();

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<Ray> InternalField_3206 = new List<Ray>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected bool InternalProperty_958 => InternalField_3200 != 0;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected PrimitiveBoundsHandle.Axes InternalProperty_959 { get; private set; }

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Vector3[] InternalField_3207 = new Vector3[4];

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected bool InternalProperty_960 { get; set; } = false;

        sealed private protected override void InternalMethod_3120()
        {
            EventType InternalVar_1 = Event.current.type;

            InternalMethod_3050();

            if (InternalVar_1 == EventType.MouseMove ||
                InternalVar_1 == EventType.MouseDrag ||
                InternalVar_1 == EventType.MouseUp)
            {
                InternalField_3203.Clear();
                InternalField_3204.Clear();
                InternalField_3206.Clear();
                InternalField_3205.Clear();
            }
        }

        sealed private protected override void InternalMethod_3121()
        {
            EventType InternalVar_1 = Event.current.type;
            bool InternalVar_2 = InternalVar_1 == EventType.Repaint;

            if (InternalVar_2)
            {
                for (int InternalVar_3 = 0; InternalVar_3 < InternalField_3204.Count; ++InternalVar_3)
                {
                    if (!InternalField_3203.TryGetValue(InternalField_3204[InternalVar_3], out System.Action InternalVar_4))
                    {
                        Debug.LogWarning($"[{InternalVar_3}/{InternalField_3204.Count}, {InternalField_3203.Count}] {InternalField_3204[InternalVar_3]} not found");
                    }

                    InternalVar_4.Invoke();
                }
            }
        }

        private protected void InternalMethod_3037(InternalType_152<InternalType_427> InternalParameter_2786)
        {
            InternalField_3204.Add(InternalParameter_2786);
        }

        protected bool InternalMethod_3038(Bounds InternalParameter_2787, Vector3 InternalParameter_2788, Ray InternalParameter_2789, out Vector3 InternalParameter_2790, out InternalType_152<InternalType_427> InternalParameter_2791)
        {
            InternalParameter_2791 = InternalType_152<InternalType_427>.InternalField_441;
            InternalParameter_2790 = Vector3.one * float.MaxValue;
            InternalType_427 InternalVar_1 = default;

            if (!InternalType_534.InternalProperty_685)
            {
                return false;
            }

            if (!InternalType_537.InternalMethod_843(InternalParameter_2789, InternalField_3202, InternalProperty_986, InternalProperty_1001, InternalParameter_1002: InternalProperty_980.InternalProperty_433 + InternalField_3201))
            {
                return false;
            }

            int InternalVar_2 = 0;

            for (int InternalVar_3 = 0; InternalVar_3 < InternalField_3202.Count; InternalVar_3++)
            {
                if (!InternalProperty_983.Contains(InternalField_3202[InternalVar_3].InternalField_1638 as UIBlock))
                {
                    InternalVar_2 = InternalVar_3;
                    break;
                }

                if (InternalVar_3 == InternalField_3202.Count - 1)
                {
                    return false;
                }
            }

            InternalVar_1 = InternalField_3202[InternalVar_2];

            InternalParameter_2790 = InternalVar_1.InternalField_1640;

            InternalParameter_2791 = InternalType_152<InternalType_427>.InternalMethod_716();

            if (InternalMethod_3041(InternalParameter_2790, InternalParameter_2789))
            {
                Matrix4x4 InternalVar_3 = Handles.matrix;
                InternalField_3203[InternalParameter_2791] = () => InternalMethod_3042(InternalParameter_2789.direction, InternalVar_1);
                return true;
            }


            return false;
        }

        private void InternalMethod_3039(Vector3 InternalParameter_2792, Color InternalParameter_2793)
        {
            using (new Handles.DrawingScope(InternalParameter_2793, Matrix4x4.identity))
            {
                UnityEngine.Rendering.CompareFunction InternalVar_1 = Handles.zTest;
                Handles.zTest = UnityEngine.Rendering.CompareFunction.Always;
                Handles.DrawSolidDisc(InternalParameter_2792, Vector3.right, 0.4f * InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2792));
                Handles.DrawSolidDisc(InternalParameter_2792, Vector3.up, 0.4f * InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2792));
                Handles.DrawSolidDisc(InternalParameter_2792, Vector3.forward, 0.4f * InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2792));
                Handles.zTest = InternalVar_1;
            }
        }

        private void InternalMethod_3040(Vector3 InternalParameter_2794, Vector3 InternalParameter_2795, Color InternalParameter_2796)
        {
            using (new Handles.DrawingScope(InternalParameter_2796, Matrix4x4.identity))
            {
                UnityEngine.Rendering.CompareFunction InternalVar_1 = Handles.zTest;
                Handles.zTest = UnityEngine.Rendering.CompareFunction.Always;
                Handles.DrawLine(InternalParameter_2794, InternalParameter_2795);
                Handles.color = Color.black;
                Handles.DrawSolidDisc(InternalParameter_2794, Vector3.forward, 0.4f * InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2794));
                Handles.color = Color.white;
                Handles.DrawWireDisc(InternalParameter_2794, Vector3.forward, 0.4f * InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2794));
                Handles.zTest = InternalVar_1;
            }
        }

        private bool InternalMethod_3041(Unity.Mathematics.float3 InternalParameter_2797, Ray InternalParameter_2798)
        {
            Vector2 InternalVar_1 = HandleUtility.WorldToGUIPoint(InternalParameter_2797);
            Vector2 InternalVar_2 = HandleUtility.WorldToGUIPoint(InternalParameter_2798.origin);
            float InternalVar_3 = Vector2.Distance(InternalVar_1, InternalVar_2);

            if (InternalVar_3 >= InternalField_3196)
            {
                return false;
            }

            Unity.Mathematics.float3 InternalVar_4 = InternalParameter_2798.direction;
            Unity.Mathematics.float3 InternalVar_5 = -InternalParameter_2798.direction;
            Unity.Mathematics.float3 InternalVar_6 = InternalParameter_2798.direction;

            for (int InternalVar_7 = 0; InternalVar_7 < InternalField_3205.Count; ++InternalVar_7)
            {
                Unity.Mathematics.float3 InternalVar_8 = InternalField_3205[InternalVar_7];
                Unity.Mathematics.float3 InternalVar_9 = InternalField_3206[InternalVar_7].direction;
                Unity.Mathematics.float3 InternalVar_10 = InternalField_3206[InternalVar_7].origin;

                if (Unity.Mathematics.math.all(InternalType_187.InternalMethod_927(ref InternalVar_8, ref InternalParameter_2797)) &&
                    (Unity.Mathematics.math.all(InternalType_187.InternalMethod_927(ref InternalVar_9, ref InternalVar_4)) ||
                    Unity.Mathematics.math.all(InternalType_187.InternalMethod_927(ref InternalVar_9, ref InternalVar_5))) &&
                    Unity.Mathematics.math.all(InternalType_187.InternalMethod_927(ref InternalVar_10, ref InternalVar_6)))
                {
                    return false;
                }
            }

            InternalField_3205.Add(InternalParameter_2797);
            InternalField_3206.Add(InternalParameter_2798);

            return true;
        }

        private void InternalMethod_3042(Vector3 InternalParameter_2799, InternalType_427 InternalParameter_2800)
        {
            Bounds InternalVar_1 = InternalProperty_991;
            Matrix4x4 InternalVar_2 = InternalProperty_993;

            UIBlock InternalVar_3 = InternalParameter_2800.InternalField_1638 as UIBlock;
            Matrix4x4 InternalVar_4 = InternalParameter_2800.InternalField_1641 ? InternalVar_3.InternalMethod_1036() : InternalVar_3.transform.localToWorldMatrix;
            Matrix4x4 InternalVar_5 = InternalVar_4.inverse;
            Bounds InternalVar_6 = InternalParameter_2800.InternalField_1639;
            Vector3 InternalVar_7 = InternalParameter_2800.InternalField_1640;

            bool InternalVar_8 = InternalType_187.InternalMethod_914(InternalVar_1.size.z);
            Vector3 InternalVar_9 = InternalVar_5.MultiplyPoint(InternalVar_2.MultiplyPoint(InternalVar_1.center));
            Vector3 InternalVar_10 = InternalVar_2.MultiplyVector(Vector3.forward);
            Vector3 InternalVar_11 = InternalVar_4.MultiplyVector(Vector3.forward);
            float InternalVar_12 = Vector3.Dot(InternalVar_10, InternalVar_11);

            bool InternalVar_13 = InternalType_187.InternalMethod_922(Mathf.Abs(InternalVar_12), 1);
            bool InternalVar_14 = InternalVar_13 || InternalType_187.InternalMethod_914(InternalVar_12);

            bool InternalVar_15 = InternalVar_8 && 
                            InternalType_187.InternalMethod_922(InternalVar_9.z, InternalVar_6.center.z) && 
                            InternalVar_13; 

            Vector3 InternalVar_16 = InternalVar_5.MultiplyVector(InternalParameter_2799);
            Vector3 InternalVar_17 = InternalVar_5.MultiplyPoint(InternalVar_7);

            Bounds InternalVar_18 = InternalType_718.InternalMethod_3216(InternalVar_1, InternalVar_2);
            Bounds InternalVar_19 = InternalType_718.InternalMethod_3216(InternalVar_6, InternalVar_4);
            Vector3 InternalVar_20 = InternalVar_4.MultiplyPoint(InternalVar_6.ClosestPoint(InternalVar_17));

            Vector3 InternalVar_21 = InternalVar_5.MultiplyPoint(InternalVar_20);
            Vector3 InternalVar_22 = InternalVar_15 ? InternalVar_5.MultiplyVector(InternalParameter_2799) :
                               new Vector3(InternalType_187.InternalMethod_922(InternalVar_17.x, InternalVar_21.x) ? InternalVar_16.x : 0,
                                                               InternalType_187.InternalMethod_922(InternalVar_17.y, InternalVar_21.y) ? InternalVar_16.y : 0,
                                                               InternalType_187.InternalMethod_922(InternalVar_17.z, InternalVar_21.z) ? InternalVar_16.z : 0).normalized;
            if (InternalVar_22 == Vector3.zero)
            {
                goto HighlightHitBounds;
            }

            using (new Handles.DrawingScope(InternalProperty_962, Matrix4x4.identity))
            {
                Handles.zTest = UnityEngine.Rendering.CompareFunction.Always;

                Vector3 InternalVar_23 = InternalVar_21 - InternalVar_17;

                Vector3 InternalVar_24 = InternalType_718.InternalMethod_3222(Vector3.Cross(Vector3.forward, InternalVar_16), 45);

                if (InternalVar_23 != Vector3.zero)
                {
                    InternalVar_23 = InternalType_718.InternalMethod_3222(InternalVar_23.normalized, 45);
                    InternalVar_24 = Vector3.Cross(Vector3.Cross(Vector3.forward, InternalVar_23), Vector3.forward).normalized;
                }

                Ray InternalVar_25 = new Ray((InternalVar_20 + InternalVar_7) * 0.5f, InternalVar_4.MultiplyVector(InternalVar_24));

                if (InternalVar_15)
                {
                    float InternalVar_26 = Vector3.Distance(InternalProperty_986.transform.position, InternalVar_25.origin);
                    Vector3 InternalVar_27 = InternalProperty_986.ViewportToWorldPoint(new Vector3(0, 0, InternalVar_26));
                    Vector3 InternalVar_28 = InternalProperty_986.ViewportToWorldPoint(new Vector3(1, 1, InternalVar_26));

                    float InternalVar_29 = 0.5f * Vector3.Distance(InternalVar_27, InternalVar_28);

                    Vector3 InternalVar_30 = InternalVar_25.GetPoint(InternalVar_29);
                    Vector3 InternalVar_31 = InternalVar_25.GetPoint(-InternalVar_29);

                    InternalType_718.InternalMethod_3317(InternalField_3220, false, InternalVar_30, InternalVar_31);

                    Vector2 InternalVar_32 = HandleUtility.WorldToGUIPoint(InternalVar_30);
                    Vector2 InternalVar_33 = HandleUtility.WorldToGUIPoint(InternalVar_31);

                    Vector3[] InternalVar_34 = InternalType_718.InternalField_3292;

                    for (int InternalVar_35 = 0; InternalVar_35 < InternalVar_34.Length; ++InternalVar_35)
                    {
                        Vector3 InternalVar_36 = InternalVar_34[InternalVar_35];

                        Vector3 InternalVar_37 = InternalVar_4.MultiplyPoint(InternalVar_6.center + Vector3.Scale(InternalVar_6.extents, InternalVar_36));
                        Vector3 InternalVar_38 = InternalVar_2.MultiplyPoint(InternalVar_1.center + Vector3.Scale(InternalVar_1.extents, InternalVar_36));

                        float InternalVar_39 = HandleUtility.DistancePointToLine(HandleUtility.WorldToGUIPoint(InternalVar_37), InternalVar_32, InternalVar_33);
                        float InternalVar_40 = HandleUtility.DistancePointToLine(HandleUtility.WorldToGUIPoint(InternalVar_38), InternalVar_32, InternalVar_33);

                        if (InternalVar_39 < InternalField_3196)
                        {
                            Handles.color = InternalField_3214;
                            Handles.DrawSolidDisc(InternalVar_37, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_37) * InternalField_3195);
                            Handles.color = InternalProperty_961;
                            InternalType_718.InternalMethod_3238(InternalVar_37, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_37) * InternalField_3195);
                        }

                        if (InternalVar_40 < InternalField_3196)
                        {
                            Handles.color = InternalField_3214;
                            Handles.DrawSolidDisc(InternalVar_38, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_38) * InternalField_3195);
                            Handles.color = InternalProperty_961;
                            InternalType_718.InternalMethod_3238(InternalVar_38, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_38) * InternalField_3195);
                        }
                    }
                }
                else
                {
                    Matrix4x4 InternalVar_26 = InternalVar_14 ? InternalVar_4 : Matrix4x4.identity;
                    Vector3 InternalVar_27 = InternalVar_14 ? InternalVar_17 : InternalVar_7;
                    Vector3 InternalVar_28 = InternalVar_14 ? InternalType_718.InternalMethod_3222(InternalVar_5.MultiplyVector(InternalParameter_2799)) : InternalType_718.InternalMethod_3222(InternalParameter_2799);

                    Bounds InternalVar_29 = InternalVar_14 ? InternalType_718.InternalMethod_3216(InternalVar_1, InternalVar_5 * InternalVar_2) : InternalVar_18;
                    InternalVar_29.Encapsulate(InternalVar_14 ? InternalVar_6 : InternalVar_19);

                    InternalMethod_3043(InternalVar_26, InternalVar_29, InternalVar_27, InternalVar_28);
                }

                Handles.color = InternalField_3214;
                Handles.DrawSolidDisc(InternalVar_7, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_7) * InternalField_3195);
                Handles.color = InternalProperty_961;
                InternalType_718.InternalMethod_3238(InternalVar_7, InternalProperty_986.transform.forward, HandleUtility.GetHandleSize(InternalVar_7) * InternalField_3195);
            }

        HighlightHitBounds:

            if (InternalVar_6.size != InternalVar_3.CalculatedSize.Value)
            {
                using (new Handles.DrawingScope(InternalProperty_962, InternalVar_3.transform.localToWorldMatrix))
                {
                    InternalType_718.InternalMethod_3315(Vector3.zero, InternalVar_3.CalculatedSize.Value, InternalField_3220);
                }
            }

            using (new Handles.DrawingScope(InternalProperty_962, InternalVar_4))
            {
                InternalType_718.InternalMethod_3315(InternalVar_6.center, InternalVar_6.size, InternalField_3220);
            }

            using (new Handles.DrawingScope(InternalProperty_962, InternalVar_2))
            {
                InternalType_718.InternalMethod_3315(InternalVar_1.center, InternalVar_1.size, InternalField_3220);
            }

            if (!InternalProperty_979 && InternalProperty_974.RotatedSize != InternalProperty_974.CalculatedSize.Value)
            {
                using (new Handles.DrawingScope(InternalProperty_962, InternalProperty_997))
                {
                    InternalType_718.InternalMethod_3315(Vector3.zero, InternalProperty_974.CalculatedSize.Value, InternalField_3220);
                }
            }
        }

        private void InternalMethod_3043(Matrix4x4 InternalParameter_2801, Bounds InternalParameter_2802, Vector3 InternalParameter_2803, Vector3 InternalParameter_2804)
        {
            for (int InternalVar_1 = 0; InternalVar_1 < 3; ++InternalVar_1)
            {
                if (InternalParameter_2804[InternalVar_1] == 0)
                {
                    continue;
                }

                float InternalVar_2 = Mathf.Sign(InternalParameter_2804[InternalVar_1]);

                for (int InternalVar_3 = 0; InternalVar_3 < InternalType_447.InternalField_1777; ++InternalVar_3)
                {
                    Vector3 InternalVar_4 = InternalType_447.InternalMethod_1743(InternalVar_3, InternalVar_1, InternalVar_2);
                    Vector3 InternalVar_5 = InternalParameter_2802.center + Vector3.Scale(InternalParameter_2802.extents, InternalVar_4);
                    InternalVar_5[InternalVar_1] = InternalParameter_2803[InternalVar_1];

                    InternalField_3207[InternalVar_3] = InternalVar_5;
                }

                using (new Handles.DrawingScope(Color.white, InternalParameter_2801))
                {
                    UnityEngine.Rendering.CompareFunction InternalVar_3 = Handles.zTest;
                    Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
                    Handles.DrawSolidRectangleWithOutline(InternalField_3207, InternalProperty_962.InternalMethod_968(0.04f), Color.clear);
                    Handles.DrawSolidRectangleWithOutline(InternalField_3207, Color.clear, InternalProperty_962);
                    Handles.zTest = InternalVar_3;
                }
            }
        }

        protected float InternalMethod_3044(Vector3 InternalParameter_2805, Bounds InternalParameter_2806, out Vector3 InternalParameter_2807, out InternalType_152<InternalType_427> InternalParameter_2808)
        {
            bool InternalVar_4 = InternalMethod_3045(InternalParameter_2805, InternalParameter_2806, out float InternalVar_1, out Vector3 InternalVar_2, out InternalType_152<InternalType_427> InternalVar_3);
            bool InternalVar_8 = InternalMethod_3045(-InternalParameter_2805, InternalParameter_2806, out float InternalVar_5, out Vector3 InternalVar_6, out InternalType_152<InternalType_427> InternalVar_7);

            if (InternalVar_4 && InternalVar_8)
            {
                InternalParameter_2807 = InternalVar_5 < InternalVar_1 ? InternalVar_6 : InternalVar_2;
                InternalParameter_2808 = InternalVar_5 < InternalVar_1 ? InternalVar_7 : InternalVar_3;
                return Mathf.Min(InternalVar_1, InternalVar_5);
            }

            if (InternalVar_4)
            {
                InternalParameter_2807 = InternalVar_2;
                InternalParameter_2808 = InternalVar_3;
                return InternalVar_1;
            }

            if (InternalVar_8)
            {
                InternalParameter_2807 = InternalVar_6;
                InternalParameter_2808 = InternalVar_7;
                return InternalVar_5;
            }

            InternalParameter_2808 = InternalType_152<InternalType_427>.InternalField_441;
            InternalParameter_2807 = InternalParameter_2806.center;
            return float.MaxValue;
        }

        protected bool InternalMethod_3045(Vector3 InternalParameter_2809, Bounds InternalParameter_2810, out float InternalParameter_2811, out Vector3 InternalParameter_2812, out InternalType_152<InternalType_427> InternalParameter_2813)
        {
            Vector3 InternalVar_1 = new Vector3(InternalType_187.InternalMethod_892(InternalParameter_2809.x), InternalType_187.InternalMethod_892(InternalParameter_2809.y), InternalType_187.InternalMethod_892(InternalParameter_2809.z));

            Vector3 InternalVar_2 = Vector3.Scale(InternalParameter_2810.extents, InternalVar_1);
            Vector3 InternalVar_3 = InternalParameter_2810.center + InternalVar_2;

            Ray InternalVar_4 = new Ray(Handles.matrix.MultiplyPoint(InternalVar_3), Handles.matrix.MultiplyVector(InternalParameter_2809));

            bool InternalVar_6 = InternalMethod_3038(InternalParameter_2810, InternalParameter_2809, InternalVar_4, out Vector3 InternalVar_5, out InternalParameter_2813);

            Vector3 InternalVar_7 = Handles.inverseMatrix.MultiplyPoint(InternalVar_5);

            Vector2 InternalVar_8 = HandleUtility.WorldToGUIPoint(InternalVar_3);
            Vector2 InternalVar_9 = HandleUtility.WorldToGUIPoint(InternalVar_7);
            InternalParameter_2811 = Vector2.Distance(InternalVar_9, InternalVar_8);

            InternalParameter_2812 = InternalVar_7 - InternalVar_2;

            return InternalVar_6 && InternalParameter_2811 < InternalType_704.InternalField_3237;
        }

        protected void InternalMethod_3046(bool InternalParameter_2814 = false)
        {
            InternalMethod_3047(InternalProperty_991, InternalProperty_993);

            if (!InternalParameter_2814)
            {
                return;
            }

            using (new Handles.DrawingScope(InternalProperty_990 ? InternalProperty_964 : InternalProperty_963, InternalProperty_993))
            {
                InternalType_718.InternalMethod_3315(InternalProperty_991.center, InternalProperty_991.size, InternalField_3220);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private EventType InternalField_3208 = EventType.Ignore;
        protected void InternalMethod_3047(Bounds InternalParameter_2815, Matrix4x4 InternalParameter_2816)
        {
            Event InternalVar_1 = Event.current;

            InternalField_3200 = GUIUtility.GetControlID(FocusType.Passive);

            if (InternalProperty_998)
            {
                if (InternalMethod_3131(InternalVar_1.type) && InternalVar_1.isMouse)
                {
                    switch (InternalVar_1.type)
                    {
                        case EventType.MouseUp:
                            switch (InternalField_3208)
                            {
                                case EventType.MouseDown:
                                    InternalField_3208 = InternalVar_1.type;
                                    InternalType_537.InternalMethod_2149();
                                    return;
                            }
                            break;
                        default:
                            InternalField_3208 = InternalVar_1.type;
                            break;
                    }
                }

                HandleUtility.AddDefaultControl(InternalField_3200);
            }

            Vector3 InternalVar_2 = InternalParameter_2815.center;

            Color InternalVar_3 = InternalProperty_990 ? InternalProperty_964 : InternalProperty_963;

            EditorGUI.BeginChangeCheck();

            using (new Handles.DrawingScope(Color.white, InternalParameter_2816))
            {
                InternalType_718.InternalMethod_3236();

                Handles.color = InternalField_3214;

                Vector3 InternalVar_4 = Vector3.Cross(InternalField_3198, InternalField_3199);

                float InternalVar_5 = InternalProperty_984 * HandleUtility.GetHandleSize(InternalParameter_2815.center);

                Handles.DrawSolidDisc(InternalParameter_2815.center, InternalVar_4, 1.1f * InternalVar_5);

                Handles.color = InternalVar_3.InternalMethod_968(0.5f);
                InternalType_718.InternalMethod_3238(InternalParameter_2815.center, InternalVar_4, 1.1f * InternalVar_5, InternalField_3220);

                Handles.color = Color.clear;

                InternalVar_2 = Handles.Slider2D(InternalField_3200,
                                               InternalParameter_2815.center,
                                               InternalVar_4,
                                               InternalField_3198,
                                               InternalField_3199,
                                               InternalVar_5,
                                               Handles.CircleHandleCap,
                                               EditorSnapSettings.move);



                switch (InternalType_718.InternalMethod_3237()) 
                {
                    case InternalType_717.InternalField_3280:
                        InternalField_3200 = GUIUtility.hotControl;
                        break;
                    default:
                        if (InternalField_3200 != GUIUtility.hotControl)
                        {
                            InternalField_3200 = 0;
                        }
                        break;
                }

                if (!InternalProperty_979 && InternalField_3200 != 0 && InternalField_3208 == EventType.MouseDrag)
                {
                    InternalMethod_3119(InternalField_3200, new InternalType_702()
                    {
                        InternalField_3235 = InternalType_718.InternalMethod_3235(InternalParameter_2815),
                        InternalField_3236 = InternalMethod_3049,
                    });
                }
            }

            if (!EditorGUI.EndChangeCheck())
            {
                return;
            }

            InternalMethod_3048(InternalParameter_2815, InternalVar_2, ref InternalParameter_2816);

            InternalType_64.InternalProperty_200.InternalMethod_431();

            Vector3 InternalVar_6 = InternalParameter_2816.MultiplyPoint(InternalParameter_2815.center);
            Bounds InternalVar_8 = InternalMethod_3117(out Matrix4x4 InternalVar_7);
            Vector3 InternalVar_9 = InternalVar_7.MultiplyPoint(InternalVar_8.center);

            if (InternalVar_9 == InternalVar_6)
            {
                return;
            }

            Vector3 InternalVar_10 = InternalVar_8.center;

            using (new Handles.DrawingScope(Color.white, InternalVar_7))
            {
                Vector3 InternalVar_11 = InternalType_718.InternalMethod_3234(HandleUtility.WorldToGUIPoint(InternalVar_6), HandleUtility.WorldToGUIPoint(InternalVar_9));
                InternalVar_11 = Vector3.Scale(InternalType_718.InternalMethod_3222(InternalVar_11, 45), new Vector3(InternalType_187.InternalMethod_892(InternalVar_11.x), InternalType_187.InternalMethod_892(InternalVar_11.y), InternalType_187.InternalMethod_892(InternalVar_11.z)));

                Matrix4x4 InternalVar_12 = Handles.matrix.inverse;
                Vector3 InternalVar_13 = InternalType_718.InternalMethod_3232(InternalVar_12.MultiplyVector(InternalVar_11), InternalProperty_959).normalized;

                Bounds InternalVar_14 = new Bounds(InternalVar_10, InternalVar_8.size);
                Bounds InternalVar_15 = new Bounds(InternalVar_10, Vector3.zero);

                for (int InternalVar_16 = 0; InternalVar_16 < 3; ++InternalVar_16)
                {
                    if (InternalVar_13[InternalVar_16] == 0)
                    {
                        continue;
                    }

                    Vector3 InternalVar_17 = Vector3.zero;
                    InternalVar_17[InternalVar_16] = 1;

                    float InternalVar_20 = InternalMethod_3044(InternalVar_17, InternalVar_14, out Vector3 InternalVar_18, out InternalType_152<InternalType_427> InternalVar_19);
                    float InternalVar_23 = InternalMethod_3044(InternalVar_17, InternalVar_15, out Vector3 InternalVar_21, out InternalType_152<InternalType_427> InternalVar_22);

                    float InternalVar_24 = Mathf.Min(InternalVar_20, InternalVar_23);

                    if (InternalVar_24 < InternalType_704.InternalField_3237)
                    {
                        InternalVar_10[InternalVar_16] = InternalVar_20 < InternalVar_23 ? InternalVar_18[InternalVar_16] : InternalVar_21[InternalVar_16];

                        InternalMethod_3037(InternalVar_20 < InternalVar_23 ? InternalVar_19 : InternalVar_22);
                    }
                }

                if (InternalVar_10 != InternalVar_2)
                {
                    InternalMethod_3048(InternalVar_8, InternalVar_10, ref InternalVar_7);
                }
            }
        }

        private void InternalMethod_3048(Bounds InternalParameter_2817, Vector3 InternalParameter_2818, ref Matrix4x4 InternalParameter_2819)
        {
            Vector3 InternalVar_1 = InternalParameter_2819.MultiplyPoint(InternalParameter_2817.center);
            Vector3 InternalVar_2 = InternalParameter_2819.MultiplyPoint(InternalParameter_2818);

            for (int InternalVar_3 = 0; InternalVar_3 < InternalProperty_981.Length; InternalVar_3++)
            {
                UIBlock InternalVar_4 = InternalProperty_981[InternalVar_3];

                InternalType_5 InternalVar_5 = InternalVar_4.InternalMethod_3592();
                bool InternalVar_6 = InternalVar_5 != null;
                Vector3 InternalVar_7 = InternalType_44.InternalMethod_3206(InternalVar_4);
                Vector3 InternalVar_8 = InternalVar_6 ? (Vector3)InternalVar_5.InternalProperty_146.InternalProperty_139 : Vector3.zero;

                Matrix4x4 InternalVar_9 = InternalVar_4.InternalMethod_1036();
                Matrix4x4 InternalVar_10 = InternalVar_9.inverse;

                PrimitiveBoundsHandle.Axes InternalVar_11 = InternalProperty_979 ? InternalProperty_959 : InternalType_718.InternalMethod_3223(InternalProperty_986, InternalVar_9);

                Vector3 InternalVar_12 = InternalVar_4.InternalMethod_1035();

                InternalVar_12 += InternalType_718.InternalMethod_3232(InternalVar_10.MultiplyPoint(InternalVar_2) - InternalVar_10.MultiplyPoint(InternalVar_1), InternalVar_11);

                InternalVar_12 = new Vector3(InternalType_187.InternalMethod_914(InternalVar_12.x) ? 0 : InternalVar_12.x,
                                            InternalType_187.InternalMethod_914(InternalVar_12.y) ? 0 : InternalVar_12.y,
                                            InternalType_187.InternalMethod_914(InternalVar_12.z) ? 0 : InternalVar_12.z);

                if (!InternalProperty_988)
                {
                    InternalProperty_988 = true;

                    Undo.RecordObjects(InternalProperty_981, "Position");
                }

                Vector3 InternalVar_13 = InternalType_182.InternalMethod_852(InternalVar_12, InternalVar_4.LayoutSize, InternalVar_4.CalculatedMargin.Offset, InternalVar_7, InternalVar_8, (Vector3)InternalVar_4.Alignment);
                InternalVar_4.Position.Raw = InternalType_718.InternalMethod_3219(Length3.InternalMethod_2424(Handles.SnapValue(InternalVar_13, EditorSnapSettings.move), InternalVar_4.Position, InternalVar_4.PositionMinMax, InternalVar_7));
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private StringBuilder InternalField_3209 = new StringBuilder();
        private string InternalMethod_3049()
        {
            InternalField_3209.Clear();
            for (int InternalVar_1 = 0; InternalVar_1 < 3; ++InternalVar_1)
            {
                if (!InternalType_718.InternalMethod_3233(InternalProperty_959, InternalVar_1))
                {
                    continue;
                }

                if (InternalField_3209.Length > 0)
                {
                    InternalField_3209.Append("\n");
                }

                string InternalVar_2 = InternalType_182.InternalMethod_861(InternalVar_1, (int)InternalProperty_974.Alignment[InternalVar_1]);
                InternalField_3209.Append($"{InternalVar_2}: {InternalProperty_974.CalculatedPosition[InternalVar_1].Value.ToString("F2")}");
            }

            return InternalField_3209.ToString();
        }

        private void InternalMethod_3050()
        {
            InternalProperty_959 = PrimitiveBoundsHandle.Axes.None;

            InternalProperty_959 = InternalType_718.InternalMethod_3223(InternalProperty_986, InternalProperty_993);

            bool InternalVar_1 = (InternalProperty_959 & PrimitiveBoundsHandle.Axes.X) != 0;
            bool InternalVar_2 = (InternalProperty_959 & PrimitiveBoundsHandle.Axes.Y) != 0;

            InternalField_3198 = InternalVar_1 ? Vector3.right : Vector3.up;
            InternalField_3199 = InternalVar_1 && InternalVar_2 ? Vector3.up : Vector3.forward;
        }
    }
}
