// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_20;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    internal class InternalType_703 : System.Attribute
    {
        public InternalType_703(System.Type InternalParameter_2836)
        {
            InternalProperty_1002 = InternalParameter_2836;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public System.Type InternalProperty_1002 { get; private set; }
    }

    internal abstract class InternalType_701 : EditorTool
    {
        [InitializeOnLoadMethod]
        private static void InternalMethod_3051()
        {
            Selection.selectionChanged += InternalMethod_3053;
            ToolManager.activeToolChanged += InternalMethod_3052;

            InternalField_3234 = new NovaHashMap<InternalType_131, bool>(16, Allocator.Persistent);
            NovaApplication.EditorBeforeAssemblyReload += () =>
            {
                InternalField_3234.Dispose();
            };
        }

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_701> InternalField_3210 = new List<InternalType_701>();
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static System.Type InternalField_3211;

        private static void InternalMethod_3052()
        {
            System.Type InternalVar_1 = ToolManager.activeToolType;

            UIBlock InternalVar_2 = Selection.activeGameObject != null ? Selection.activeGameObject.GetComponent<UIBlock>() : null;

            if (InternalVar_1.IsSubclassOf(typeof(InternalType_701)))
            {
                InternalField_3211 = InternalVar_1;
            }
            else if (InternalVar_2 != null)
            {
                InternalField_3211 = null;
            }
        }

        private static void InternalMethod_3053()
        {
            bool InternalVar_1 = Selection.activeGameObject == null;

            if (InternalVar_1)
            {
                return;
            }

            bool InternalVar_3 = InternalType_779.InternalMethod_3699<UIBlock>(out System.Type InternalVar_2);

            if (InternalVar_3 && InternalField_3211 != null)
            {
                InternalMethod_3132(InternalField_3211, InternalVar_2);
            }
        }

        private static void InternalMethod_3054(InternalType_701 InternalParameter_2820)
        {
            InternalField_3210.Add(InternalParameter_2820);
        }

        private static void InternalMethod_3055(InternalType_701 InternalParameter_2821)
        {
            InternalField_3210.Remove(InternalParameter_2821);
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly PrimitiveBoundsHandle.Axes InternalField_3212 = PrimitiveBoundsHandle.Axes.X | PrimitiveBoundsHandle.Axes.Y;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly PrimitiveBoundsHandle.Axes InternalField_3213 = PrimitiveBoundsHandle.Axes.All;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_961 => InternalType_573.InternalType_574.InternalField_2585;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_962 => InternalType_573.InternalType_574.InternalField_2585;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_963 => InternalType_573.InternalType_574.InternalField_2586;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_964 => InternalType_573.InternalType_574.InternalField_2588;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_965 => InternalType_573.InternalType_574.InternalField_2587;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_966 => InternalType_573.InternalType_574.InternalField_2586;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_967 => InternalType_573.InternalType_574.InternalField_2591;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_968 => InternalType_573.InternalType_574.InternalProperty_496;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_969 => InternalType_573.InternalType_574.InternalProperty_494;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_970 => InternalType_573.InternalType_574.InternalProperty_495;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_971 => Color.yellow;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static Color InternalProperty_972 => InternalType_573.InternalType_574.InternalField_2586;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3214 = Color.black.InternalMethod_968(0.25f);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3215 = new Color(0.85f, 0.85f, 0.85f);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3216 = new Color(.3f, .3f, .3f);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3217 = new Color(.85f, .85f, .85f);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3218 = new Color(0.15f, 0.15f, 0.15f);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly Color InternalField_3219 = new Color(1, 0.5f, 0);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3220 = InternalType_706.InternalField_3240;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static InternalType_701 InternalProperty_973 { get; private set; } = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public UIBlock InternalProperty_974 => InternalProperty_981 == null || InternalProperty_981.Length == 0 ? null : InternalProperty_981[0];
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_600 InternalProperty_975 { get; private set; } = new InternalType_600();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_600 InternalProperty_976 { get; private set; } = new InternalType_600();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_600 InternalProperty_977 { get; private set; } = new InternalType_600();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_600 InternalProperty_978 { get; private set; } = new InternalType_600();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_979 => InternalProperty_980.InternalProperty_433 > 1;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_521<UIBlock> InternalProperty_980 => InternalField_3223.InternalMethod_2043();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected UIBlock[] InternalProperty_981 => InternalField_3221;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock[] InternalField_3221 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private HashSet<UIBlock> InternalField_3222 = new HashSet<UIBlock>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Object[] InternalProperty_982 { get; private set; }
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<UIBlock> InternalField_3223 = new List<UIBlock>();
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_153<UIBlock> InternalField_3224 = new InternalType_153<UIBlock>(InternalType_189<UIBlock>.InternalField_551);
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected InternalType_153<UIBlock> InternalProperty_983 => InternalField_3224;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3225 = 0.15f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float InternalProperty_984 => InternalField_3225 / InternalProperty_985;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float InternalProperty_985 => InternalProperty_993.ValidTRS() ? math.cmax(InternalProperty_993.lossyScale) : 1;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private SceneView InternalField_3226 = null;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Camera InternalField_3227 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Camera InternalProperty_986 => InternalField_3227;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected const float InternalField_3228 = 20;
        protected struct InternalType_702
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public Vector2 InternalField_3235;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public System.Func<string> InternalField_3236;
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Dictionary<int, InternalType_702> InternalField_3229 = new Dictionary<int, InternalType_702>();

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Texture2D InternalField_3230 = null;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_987 { get; private set; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected bool InternalProperty_988 { get; set; } = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected bool InternalProperty_989 { get; set; } = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected virtual bool InternalProperty_990 { get; } = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Bounds InternalProperty_991 { get; private set; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Matrix4x4 InternalProperty_992 { get; private set; } = Matrix4x4.identity;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Matrix4x4 InternalProperty_993 { get; private set; } = Matrix4x4.identity;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Bounds InternalProperty_994 => new Bounds(Vector3.zero, InternalProperty_974.CalculatedSize.Value); 
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected Bounds InternalProperty_995 => new Bounds(InternalProperty_974.InternalMethod_1035() - InternalProperty_974.CalculatedMargin.Offset, InternalProperty_974.InternalMethod_1039());

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Matrix4x4 InternalProperty_996 => InternalProperty_979 ? Matrix4x4.identity : InternalProperty_974.InternalMethod_1036();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private protected Matrix4x4 InternalProperty_997 => InternalProperty_974.transform.localToWorldMatrix;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3356 = 0.001f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const float InternalField_3357 = 1e-6f;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected bool InternalProperty_998 { get; private set; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected virtual bool InternalProperty_999 => false;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3231 = null;


        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalField_3232 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UIBlock InternalProperty_1000
        {
            get
            {
                return InternalField_3232;
            }
            set
            {
                InternalField_3232 = value;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static NovaHashMap<InternalType_131, bool> InternalField_3234;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        protected NovaHashMap<InternalType_131, bool> InternalProperty_1001 => InternalField_3234;

        private void InternalMethod_3111()
        {
            if (InternalProperty_975.InternalProperty_954 != null)
            {
                InternalProperty_975.InternalProperty_954.serializedObject.Dispose();
            }

            if (InternalProperty_976.InternalProperty_954 != null)
            {
                InternalProperty_976.InternalProperty_954.serializedObject.Dispose();
            }

            if (InternalProperty_977.InternalProperty_954 != null)
            {
                InternalProperty_977.InternalProperty_954.serializedObject.Dispose();
            }

            if (InternalProperty_978.InternalProperty_954 != null)
            {
                InternalProperty_978.InternalProperty_954.serializedObject.Dispose();
            }

            InternalField_3221 = null;
            InternalField_3222 = null;

            InternalField_3229 = null;

            InternalProperty_982 = null;
            InternalField_3223 = null;
            InternalField_3224 = null;
            InternalField_3230 = null;
        }

        private void Awake()
        {
            InternalMethod_3054(this);
        }

        private void OnEnable()
        {
        }

        private void OnDisable()
        {
            if (this == InternalProperty_973)
            {
                OnWillBeDeactivated();
            }
        }

        private void OnDestroy()
        {
            InternalMethod_3055(this);


            InternalMethod_3111();
        }

        public override void OnActivated()
        {
            Handles.lighting = false;
            HandleUtility.handleMaterial.color = Color.white;

            InternalField_3230 = InternalType_573.InternalType_574.InternalMethod_2296(InternalField_3216);

            Undo.undoRedoPerformed -= InternalMethod_3113;
            Undo.undoRedoPerformed += InternalMethod_3113;
            Selection.selectionChanged -= InternalMethod_3116;
            Selection.selectionChanged += InternalMethod_3116;

            InternalField_3211 = GetType();

            InternalProperty_973 = this;

            InternalMethod_3116();

            InternalMethod_3112();
        }

        protected abstract void InternalMethod_3112();

        private void InternalMethod_3113()
        {
            if (InternalProperty_974 == null)
            {
                return;
            }

            InternalProperty_974.InternalMethod_73();
        }

        private protected void InternalMethod_3114()
        {
            if (InternalField_3226 == null)
            {
                return;
            }

            InternalField_3226.Repaint();
        }

        private void InternalMethod_3115()
        {
            if (InternalProperty_975.InternalProperty_954 != null)
            {
                InternalProperty_975.InternalProperty_954.serializedObject.Update();
            }

            if (InternalProperty_976.InternalProperty_954 != null)
            {
                InternalProperty_976.InternalProperty_954.serializedObject.Update();
            }

            if (InternalProperty_977.InternalProperty_954 != null)
            {
                InternalProperty_977.InternalProperty_954.serializedObject.Update();
            }

            if (InternalProperty_978.InternalProperty_954 != null)
            {
                InternalProperty_978.InternalProperty_954.serializedObject.Update();
            }
        }

        private void InternalMethod_3116()
        {
            if (InternalProperty_973 != this || this == null)
            {
                return;
            }

            InternalProperty_993 = Matrix4x4.identity;
            InternalProperty_998 = false;

            UIBlock[] InternalVar_1 = Selection.GetFiltered<UIBlock>(UnityEditor.SelectionMode.Editable);

            if (InternalVar_1 == null || InternalVar_1.Length == 0)
            {
                InternalField_3223.Clear();
                InternalField_3224.Clear();

                return;
            }

            UIBlock[] InternalVar_2 = InternalVar_1.Where(x => !(x is UIBlock2D) && !(x is UIBlock3D) && !(x is TextBlock)).ToArray();
            UIBlock2D[] InternalVar_3 = InternalVar_1.Where(x => x is UIBlock2D).Cast<UIBlock2D>().ToArray();
            UIBlock3D[] InternalVar_4 = InternalVar_1.Where(x => x is UIBlock3D).Cast<UIBlock3D>().ToArray();
            TextBlock[] InternalVar_5 = InternalVar_1.Where(x => x is TextBlock).Cast<TextBlock>().ToArray();

            bool InternalVar_6 = InternalVar_2 != null && InternalVar_2.Length > 0;
            bool InternalVar_7 = InternalVar_3 != null && InternalVar_3.Length > 0;
            bool InternalVar_8 = InternalVar_4 != null && InternalVar_4.Length > 0;
            bool InternalVar_9 = InternalVar_5 != null && InternalVar_5.Length > 0;

            InternalProperty_975.InternalProperty_954 = InternalVar_6 ? new SerializedObject(InternalVar_2).FindProperty(InternalType_646.InternalType_657.InternalField_2984) : null;
            InternalProperty_976.InternalProperty_954 = InternalVar_7 ? new SerializedObject(InternalVar_3).FindProperty(InternalType_646.InternalType_657.InternalField_2984) : null;
            InternalProperty_977.InternalProperty_954 = InternalVar_8 ? new SerializedObject(InternalVar_4).FindProperty(InternalType_646.InternalType_657.InternalField_2984) : null;
            InternalProperty_978.InternalProperty_954 = InternalVar_9 ? new SerializedObject(InternalVar_5).FindProperty(InternalType_646.InternalType_657.InternalField_2984) : null;

            InternalField_3223.Clear();

            InternalVar_1.InternalMethod_987(InternalField_3223, InternalParameter_958: true);

            InternalProperty_982 = InternalField_3223.Cast<Object>().ToArray();

            InternalField_3221 = Selection.GetFiltered<UIBlock>(UnityEditor.SelectionMode.TopLevel | UnityEditor.SelectionMode.Editable);
            InternalField_3222.Clear();

            for (int InternalVar_10 = 0; InternalVar_10 < InternalField_3221.Length; ++InternalVar_10)
            {
                InternalField_3222.Add(InternalField_3221[InternalVar_10]);
            }

            InternalField_3224.Clear();
            InternalField_3234.Clear();

            for (int InternalVar_10 = 0; InternalVar_10 < InternalProperty_980.InternalProperty_433; ++InternalVar_10)
            {
                InternalField_3224.Add(InternalProperty_980[InternalVar_10]);
                InternalField_3234.Add(InternalProperty_980[InternalVar_10].InternalProperty_29, false);
            }
        }

        public override void OnWillBeDeactivated()
        {
            InternalField_3221 = null;
            InternalField_3223.Clear();

            Undo.undoRedoPerformed -= InternalMethod_3113;
            Selection.selectionChanged -= InternalMethod_3116;
            InternalProperty_973 = null;
        }

        
        protected Bounds InternalMethod_3117(out Matrix4x4 InternalParameter_2822)
        {
            Bounds InternalVar_1 = default(Bounds);

            UIBlock InternalVar_2 = InternalProperty_974;

            bool InternalVar_3 = InternalProperty_990 ? InternalVar_2.LayoutSize.z == 0 : InternalVar_2.CalculatedSize.Value.z == 0;

            float4x4 InternalVar_4 = InternalProperty_990 ? InternalVar_2.InternalMethod_1036() : InternalVar_2.transform.localToWorldMatrix;
            float4x4 InternalVar_5 = math.inverse(InternalVar_4);

            if (InternalProperty_979)
            {
                for (int InternalVar_6 = 0; InternalVar_6 < InternalProperty_980.InternalProperty_433; ++InternalVar_6)
                {
                    UIBlock InternalVar_7 = InternalProperty_980[InternalVar_6];

                    if (!InternalVar_7.gameObject.activeInHierarchy)
                    {
                        continue;
                    }

                    float4x4 InternalVar_8 = InternalProperty_990 ? InternalVar_7.InternalMethod_1036() : InternalVar_7.transform.localToWorldMatrix;
                    Bounds InternalVar_9 = InternalProperty_990 ? new Bounds(InternalVar_7.InternalMethod_1035() - InternalVar_7.CalculatedMargin.Offset, InternalVar_7.InternalMethod_1039()) : new Bounds(Vector3.zero, InternalVar_7.RotatedSize);

                    if (InternalVar_3)
                    {
                        InternalVar_3 = InternalType_187.InternalMethod_945(ref InternalVar_5, ref InternalVar_8) && InternalVar_9.size.z == 0;

                        if (!InternalVar_3) 
                        {
                            InternalVar_1 = InternalType_718.InternalMethod_3216(InternalVar_1, InternalVar_4);
                        }
                    }

                    float4x4 InternalVar_10 = InternalVar_3 ? math.mul(InternalVar_5, InternalVar_8) : InternalVar_8;

                    InternalVar_9 = InternalType_718.InternalMethod_3216(InternalVar_9, InternalVar_10);

                    if (InternalVar_6 == 0)
                    {
                        InternalVar_1 = InternalVar_9;
                    }
                    else
                    {
                        InternalVar_1.Encapsulate(InternalVar_9);
                    }
                }
            }

            if (InternalVar_3 || !InternalProperty_979)
            {
                if (InternalProperty_979)
                {
                    InternalParameter_2822 = Matrix4x4.Rotate(InternalVar_2.transform.rotation);
                    InternalVar_1 = InternalType_718.InternalMethod_3216(InternalVar_1, InternalParameter_2822.inverse * ((Matrix4x4)InternalVar_4));
                }
                else
                {
                    InternalVar_1 = InternalProperty_990 ? InternalProperty_995 : InternalProperty_994;
                    InternalParameter_2822 = (Matrix4x4)InternalVar_4;
                }
            }
            else
            {
                InternalParameter_2822 = Matrix4x4.identity;
            }

            InternalVar_1.center = InternalType_187.InternalMethod_3642(InternalVar_1.center);
            InternalVar_1.size = InternalType_187.InternalMethod_3642(InternalVar_1.size);

            return InternalVar_1;
        }

        private protected bool InternalMethod_3118(UIBlock InternalParameter_2823)
        {
            return InternalField_3222.Contains(InternalParameter_2823);
        }

        private protected void InternalMethod_3119(int InternalParameter_2824, InternalType_702 InternalParameter_2825)
        {
            if (InternalField_3229.ContainsKey(InternalParameter_2824))
            {
                return;
            }

            InternalField_3229.Add(InternalParameter_2824, InternalParameter_2825);
        }

        private protected static Vector3 InternalMethod_3338(Length3 InternalParameter_32)
        {
            ThreeD<bool> InternalVar_1 = InternalParameter_32.Type == LengthType.Value;
            return new Vector3(InternalVar_1.X ? InternalField_3356 : InternalField_3357,
                               InternalVar_1.Y ? InternalField_3356 : InternalField_3357,
                               InternalVar_1.Z ? InternalField_3356 : InternalField_3357);
        }

        private protected virtual void InternalMethod_3120() { }
        private protected virtual void InternalMethod_3121() { }

        protected abstract void InternalMethod_3122();

        public override void OnToolGUI(EditorWindow editorWindow)
        {
            InternalField_3229.Clear();

            InternalField_3226 = editorWindow as SceneView;
            InternalField_3227 = InternalField_3226.camera;

            if (InternalProperty_974 == null || !InternalProperty_974.gameObject.activeInHierarchy || InternalField_3227 == null)
            {
                return;
            }

            EventType InternalVar_1 = Event.current.type;

            bool InternalVar_2 = InternalVar_1 == EventType.Repaint;

            InternalProperty_973 = this;

            if (!InternalVar_2)
            {
                InternalMethod_3123();
            }

            InternalMethod_3124();

            InternalMethod_3120();

            InternalProperty_987 = false;
            EditorGUI.BeginChangeCheck();
            InternalMethod_3122();
            InternalProperty_987 = EditorGUI.EndChangeCheck();

            if (InternalProperty_988 || InternalProperty_989)
            {
                InternalProperty_988 = false;
                InternalProperty_989 = false;

                InternalType_64.InternalProperty_200.InternalMethod_431();

                for (int InternalVar_3 = 0; InternalVar_3 < InternalProperty_980.InternalProperty_433; ++InternalVar_3)
                {
                    InternalProperty_980[InternalVar_3].InternalMethod_113();
                }

                InternalMethod_3115();
            }

            InternalMethod_3121();

            if (InternalVar_2)
            {
                InternalMethod_3127();
            }

            if (InternalProperty_987 || Event.current.type == EventType.MouseMove)
            {
                InternalType_180.InternalMethod_849();
            }
        }

        private void InternalMethod_3123()
        {
            InternalProperty_991 = InternalMethod_3117(out Matrix4x4 InternalVar_1);
            InternalProperty_993 = InternalVar_1;
            InternalProperty_992 = InternalVar_1.inverse;
        }

        private void InternalMethod_3124()
        {
            if (!(EditorWindow.focusedWindow is SceneView))
            {
                InternalProperty_998 = false;
                InternalField_3231 = null;
                return;
            }

            if (GUIUtility.hotControl != 0 || InternalProperty_999)
            {
                InternalProperty_998 = true;
                InternalField_3231 = null;

                return;
            }

            Event InternalVar_1 = Event.current;

            switch (InternalVar_1.type)
            {
                case EventType.Repaint:
                    InternalMethod_3126();
                    break;
                case EventType.Layout:
                    InternalMethod_3125();
                    break;
            }
        }

        private void InternalMethod_3125()
        {
            Event InternalVar_1 = Event.current;

            Ray InternalVar_2 = HandleUtility.GUIPointToWorldRay(InternalVar_1.mousePosition);

            float3 InternalVar_3 = InternalProperty_991.center;
            float3 InternalVar_4 = InternalProperty_991.size;

            if (!InternalType_187.InternalMethod_935(ref InternalVar_3) || !InternalType_187.InternalMethod_935(ref InternalVar_4))
            {
                return;
            }

            InternalProperty_998 = InternalProperty_991.IntersectRay(InternalType_718.InternalMethod_3217(InternalVar_2, InternalProperty_992));
            object InternalVar_5 = HandleUtility.RaySnap(InternalVar_2);

            bool InternalVar_6 = InternalVar_5 != null && (InternalVar_5 is RaycastHit hit) && hit.transform.GetComponent<UIBlock>() == null;

            if ((InternalType_537.InternalMethod_2163() || !InternalProperty_998) && !InternalVar_6)
            {
                bool InternalVar_8 = InternalType_537.InternalMethod_2152(InternalVar_2, out InternalType_428 InternalVar_7);
                InternalField_3231 = InternalVar_8 ? InternalVar_7.InternalField_1642 as UIBlock : null;
            }
            else
            {
                InternalField_3231 = null;
            }

        }

        private void InternalMethod_3126()
        {
            Event InternalVar_1 = Event.current;

            bool InternalVar_2 = (EditorGUI.actionKey || InternalVar_1.shift) && InternalProperty_979;
            Color InternalVar_3 = InternalVar_2 ? InternalProperty_971 : InternalProperty_972;

            UIBlock InternalVar_4 = InternalField_3231 != null ? InternalField_3231 : InternalProperty_1000;

            if (InternalVar_4 != null)
            {
                using (new Handles.DrawingScope(InternalVar_3, InternalVar_4.transform.localToWorldMatrix))
                {
                    Bounds InternalVar_5 = new Bounds(Vector3.zero, InternalVar_4.CalculatedSize.Value);

                    switch (InternalVar_4)
                    {
                        case UIBlock2D uiBlock2d:
                            InternalType_718.InternalMethod_3239(InternalVar_5, uiBlock2d.InternalProperty_42.CornerRadius.Value, InternalField_3220);
                            break;
                        default:
                            InternalType_718.InternalMethod_3315(InternalVar_5.center, InternalVar_5.size, InternalField_3220);
                            break;
                    }
                }
            }

            if (InternalVar_2)
            {
                for (int InternalVar_5 = 0; InternalVar_5 < InternalProperty_980.InternalProperty_433; ++InternalVar_5)
                {
                    UIBlock InternalVar_6 = InternalProperty_980[InternalVar_5];

                    if (InternalVar_6 == InternalField_3231 || InternalVar_6 == InternalProperty_1000)
                    {
                        continue;
                    }

                    using (new Handles.DrawingScope(InternalProperty_972, InternalVar_6.transform.localToWorldMatrix))
                    {
                        switch (InternalVar_6)
                        {
                            case UIBlock2D uiBlock2d:
                                InternalType_718.InternalMethod_3239(new Bounds(Vector3.zero, InternalVar_6.CalculatedSize.Value), uiBlock2d.InternalProperty_42.CornerRadius.Value);
                                break;
                            default:
                                InternalType_718.InternalMethod_3315(Vector3.zero, InternalVar_6.CalculatedSize.Value, InternalField_3220);
                                break;
                        }
                    }
                }
            }
        }

        private void InternalMethod_3127()
        {
            if (GUIUtility.hotControl == 0)
            {
                return;
            }

            if (!InternalField_3229.TryGetValue(GUIUtility.hotControl, out InternalType_702 InternalVar_1))
            {
                return;
            }

            using (new Handles.DrawingScope(Matrix4x4.identity))
            {
                GUIStyle InternalVar_2 = new GUIStyle()
                {
                    fontSize = 8,
                    fontStyle = FontStyle.Bold,
                    alignment = TextAnchor.MiddleCenter,
                    normal = new GUIStyleState()
                    {
                        textColor = InternalField_3217,
                        background = InternalField_3230
                    },
                };

                GUIContent InternalVar_3 = new GUIContent(InternalVar_1.InternalField_3236?.Invoke());

                Vector2 InternalVar_4 = InternalVar_2.CalcSize(InternalVar_3);

                const float InternalVar_5 = 5;

                Vector2 InternalVar_6 = new Vector2(-0.5f, 1);

                Vector2 InternalVar_7 = new Vector2(0, InternalVar_5) + (InternalVar_4 * 0.5f * InternalVar_6);
                Ray InternalVar_8 = HandleUtility.GUIPointToWorldRay(InternalVar_1.InternalField_3235 + InternalVar_7);

                Rect InternalVar_9 = HandleUtility.WorldPointToSizedRect(InternalVar_8.origin, InternalVar_3, InternalVar_2);
                Handles.BeginGUI();
                EditorGUI.DropShadowLabel(InternalVar_9, InternalVar_3, InternalVar_2);
                Handles.EndGUI();
            }
        }

        protected float InternalMethod_3128(Vector3 InternalParameter_2826)
        {
            return HandleUtility.GetHandleSize(InternalParameter_2826) * InternalProperty_984 * 0.5f;
        }

        protected float InternalMethod_3129(Vector3 InternalParameter_2827)
        {
            return InternalMethod_3128(InternalParameter_2827) / math.cmax(InternalProperty_974.transform.localScale);
        }

        public static Length.Calculated InternalMethod_3130(LengthBounds.Calculated InternalParameter_2828, int InternalParameter_2829, float InternalParameter_2830)
        {
            switch (InternalParameter_2829)
            {
                case 1:
                    return InternalParameter_2830 < 0 ? InternalParameter_2828.Bottom : InternalParameter_2828.Top;
                case 2:
                    return InternalParameter_2830 < 0 ? InternalParameter_2828.Front : InternalParameter_2828.Back;
                default:
                    return InternalParameter_2830 < 0 ? InternalParameter_2828.Left : InternalParameter_2828.Right;
            }
        }

        protected static bool InternalMethod_3131(EventType InternalParameter_2831) => InternalParameter_2831 != EventType.Repaint && InternalParameter_2831 != EventType.Layout;

        private static void InternalMethod_3132(System.Type InternalParameter_2832, System.Type InternalParameter_2833)
        {
            EditorToolAttribute InternalVar_1 = InternalMethod_3133(InternalParameter_2832);

            if (InternalVar_1 != null && InternalVar_1.targetType != null)
            {
                if (!InternalVar_1.targetType.IsAssignableFrom(InternalParameter_2833))
                {
                    InternalType_703 InternalVar_2 = InternalMethod_3134(InternalParameter_2832);

                    if (InternalVar_2 != null && InternalVar_2.InternalProperty_1002 != null)
                    {
                        InternalMethod_3132(InternalVar_2.InternalProperty_1002, InternalParameter_2833);
                        return;
                    }

                    ToolManager.RestorePreviousPersistentTool();

                    return;
                }
            }

            try
            {
                ToolManager.SetActiveTool(InternalParameter_2832);
            }
            catch
            {
                InternalType_703 InternalVar_2 = InternalMethod_3134(InternalParameter_2832);

                if (InternalVar_2 != null && InternalVar_2.InternalProperty_1002 != null)
                {
                    InternalMethod_3132(InternalVar_2.InternalProperty_1002, InternalParameter_2833);
                }
            }
        }

        private static EditorToolAttribute InternalMethod_3133(System.Type InternalParameter_2834)
        {
            return InternalParameter_2834.GetCustomAttributes(typeof(EditorToolAttribute), false).FirstOrDefault() as EditorToolAttribute;
        }

        private static InternalType_703 InternalMethod_3134(System.Type InternalParameter_2835)
        {
            return InternalParameter_2835.GetCustomAttributes(typeof(InternalType_703), false).FirstOrDefault() as InternalType_703;
        }
    }
}
