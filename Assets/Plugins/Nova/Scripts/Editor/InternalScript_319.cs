// Copyright (c) Supernova Technologies LLC

using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using Navigator = Nova.InternalNamespace_0.InternalType_757<Nova.UIBlock>;

namespace Nova.InternalNamespace_17
{
    internal class InternalType_742 : InternalType_136<InternalType_742>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        const float InternalField_3442 = 2.5f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        const float InternalField_3443 = 1.2f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly Vector3[] InternalField_3444 = new Vector3[] { new Vector2(1, 0), new Vector2(-1, 0), new Vector2(0, 1), new Vector2(0, -1), new Vector3(0, 0, 1), new Vector3(0, 0, -1) };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Dictionary<GestureRecognizer, NavNode> InternalField_3445 = new Dictionary<GestureRecognizer, NavNode>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static GestureRecognizer[] InternalField_3446 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static HashSet<GestureRecognizer> InternalField_3447 = new HashSet<GestureRecognizer>();

        protected override void InternalMethod_657()
        {
            SceneView.duringSceneGui -= InternalMethod_3429;
            EditorApplication.playModeStateChanged -= InternalMethod_3415;
        }

        protected override void InternalMethod_656()
        {
            SceneView.duringSceneGui -= InternalMethod_3429;
            SceneView.duringSceneGui += InternalMethod_3429;
            EditorApplication.playModeStateChanged -= InternalMethod_3415;
            EditorApplication.playModeStateChanged += InternalMethod_3415;
        }

        private static void InternalMethod_3415(PlayModeStateChange InternalParameter_3175)
        {
            InternalMethod_3428();
        }

        public static UIBlock InternalMethod_3416(GestureRecognizer InternalParameter_3176, Vector3 InternalParameter_3177)
        {
            if (InternalMethod_3417(InternalParameter_3176, InternalParameter_3177, out UIBlock InternalVar_1))
            {
                return InternalVar_1;
            }

            return InternalMethod_3418(InternalParameter_3176, InternalParameter_3177);
        }

        public static bool InternalMethod_3417(GestureRecognizer InternalParameter_3178, Vector3 InternalParameter_3179, out UIBlock InternalParameter_3180)
        {
            InternalParameter_3180 = null;
            if (InternalField_3445.TryGetValue(InternalParameter_3178, out NavNode InternalVar_1))
            {
                GestureRecognizer InternalVar_2 = InternalVar_1.GetLink(InternalParameter_3179).Target;
                InternalParameter_3180 = InternalVar_2 == null ? null : InternalVar_2.UIBlock;
            }

            return InternalParameter_3180 != null;
        }

        private static UIBlock InternalMethod_3418(GestureRecognizer InternalParameter_3181, Vector3 InternalParameter_3182)
        {
            if (!InternalMethod_3419(InternalParameter_3181, InternalParameter_3182, out Ray InternalVar_1, out UIBlock InternalVar_2))
            {
                return null;
            }

            UIBlock InternalVar_3 = InternalVar_2;
            while (InternalVar_3 != null && InternalVar_3.TryGetComponent(out GestureRecognizer InternalVar_4) && InternalVar_4.OnSelect == SelectBehavior.ScopeNavigation && InternalVar_4.AutoSelect)
            {
                if (Navigator.InternalMethod_3580(InternalVar_1, InternalParameter_3181.UIBlock, InternalVar_4.UIBlock, Interaction.AllLayers, InternalParameter_3288: true, InternalMethod_3426, out InternalType_428 InternalVar_5, InternalParameter_3291: true))
                {
                    InternalVar_3 = InternalVar_5.InternalField_1642 as UIBlock;
                    InternalVar_2 = InternalVar_3;
                }
                else
                {
                    InternalVar_3 = null;
                }
            }

            return InternalVar_2;
        }

        private static bool InternalMethod_3419(GestureRecognizer InternalParameter_3183, Vector3 InternalParameter_3184, out Ray InternalParameter_3185, out UIBlock InternalParameter_3186)
        {
            InternalParameter_3185 = default;
            InternalParameter_3186 = null;

            if (InternalParameter_3183 == null || !InternalParameter_3183.Navigable || InternalParameter_3183.Navigation.GetLink(InternalParameter_3184) == NavLink.Empty)
            {
                return false;
            }

            if (InternalMethod_3420(InternalParameter_3183, InternalParameter_3184, out InternalParameter_3186))
            {
                return true;
            }

            InternalParameter_3185 = Navigator.InternalMethod_3583(InternalParameter_3184, InternalParameter_3183.UIBlock);

            GestureRecognizer InternalVar_1 = InternalMethod_3425(InternalParameter_3183.UIBlock);

            if (InternalMethod_3421(InternalParameter_3183, InternalVar_1, InternalParameter_3185, InternalParameter_3184, out InternalParameter_3186))
            {
                return true;
            }

            if (InternalMethod_3422(InternalParameter_3183, InternalVar_1, InternalParameter_3185, InternalParameter_3184, out InternalParameter_3186))
            {
                return true;
            }

            return false;
        }

        private static bool InternalMethod_3420(GestureRecognizer InternalParameter_3187, Vector3 InternalParameter_3188, out UIBlock InternalParameter_3189)
        {
            InternalParameter_3189 = null;

            if (!InternalParameter_3187.Navigation.InternalMethod_2715(InternalParameter_3188, out InternalType_5 InternalVar_1) || (InternalVar_1 != null && !InternalMethod_3426(InternalVar_1)))
            {
                return false;
            }

            InternalParameter_3189 = InternalVar_1 as UIBlock;
            return true;
        }

        private static bool InternalMethod_3421(GestureRecognizer InternalParameter_3190, GestureRecognizer InternalParameter_3191, Ray InternalParameter_3192, Vector3 InternalParameter_3193, out UIBlock InternalParameter_3194)
        {
            InternalParameter_3194 = null;

            UIBlock InternalVar_1 = InternalParameter_3191 == null ? null : InternalParameter_3191.UIBlock;

            if (!Navigator.InternalMethod_3580(InternalParameter_3192, InternalParameter_3190.UIBlock, InternalVar_1, Interaction.AllLayers, InternalParameter_3288: true, InternalMethod_3426, out InternalType_428 InternalVar_2))
            {
                return false;
            }

            InternalParameter_3194 = InternalVar_2.InternalField_1642 as UIBlock;

            if (InternalVar_1 != null && InternalParameter_3190.UIBlock != InternalVar_1 && Navigator.InternalMethod_3586(InternalVar_1, InternalParameter_3190.UIBlock, InternalParameter_3193, Interaction.AllLayers, out InternalType_756 InternalVar_3))
            {
                InternalParameter_3194 = InternalVar_3.InternalField_3547 as UIBlock;
            }

            return true;
        }

        private static bool InternalMethod_3422(GestureRecognizer InternalParameter_3195, GestureRecognizer InternalParameter_3196, Ray InternalParameter_3197, Vector3 InternalParameter_3198, out UIBlock InternalParameter_3199)
        {
            InternalParameter_3199 = null;

            if (InternalParameter_3195.Navigation.GetLink(InternalParameter_3198).Fallback != NavLinkFallback.NavigateOutsideScope)
            {
                return false;
            }

            UIBlock InternalVar_1 = InternalParameter_3196 == null ? null : InternalParameter_3196.UIBlock;

            while (InternalVar_1 != null)
            {
                InternalParameter_3196 = InternalMethod_3425(InternalVar_1);
                InternalVar_1 = InternalParameter_3196 == null ? null : InternalParameter_3196.UIBlock;

                if (Navigator.InternalMethod_3580(InternalParameter_3197, InternalParameter_3195.UIBlock, InternalVar_1, Interaction.AllLayers, true, InternalMethod_3426, out InternalType_428 InternalVar_2))
                {
                    InternalParameter_3199 = InternalVar_2.InternalField_1642 as UIBlock;
                    break;
                }
            }

            return InternalParameter_3199 != null;
        }

        private static void InternalMethod_3423(GestureRecognizer InternalParameter_3200)
        {
            if (!InternalMethod_3426(InternalParameter_3200.UIBlock))
            {
                InternalField_3445.Remove(InternalParameter_3200);
                return;
            }

            InternalField_3445[InternalParameter_3200] = new NavNode()
            {
                Left = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.left)),
                Right = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.right)),
                Up = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.up)),
                Down = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.down)),
                Forward = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.forward)),
                Back = InternalMethod_3424(InternalMethod_3418(InternalParameter_3200, Vector3.back)),
            };
        }

        private static GestureRecognizer InternalMethod_3424(UIBlock InternalParameter_3201)
        {
            return InternalParameter_3201 == null ? null : InternalParameter_3201.GetComponent<GestureRecognizer>();
        }

        private static GestureRecognizer InternalMethod_3425(UIBlock InternalParameter_3202)
        {
            if (InternalParameter_3202 == null)
            {
                return null;
            }

            for (UIBlock InternalVar_1 = InternalParameter_3202.Parent; InternalVar_1 != null; InternalVar_1 = InternalVar_1.Parent)
            {
                if (InternalMethod_3427(InternalVar_1, out GestureRecognizer InternalVar_2) && InternalVar_2.OnSelect == SelectBehavior.ScopeNavigation)
                {
                    return InternalVar_2;
                }
            }

            return null;
        }


        private static bool InternalMethod_3426(InternalType_5 InternalParameter_3203) => InternalMethod_3427(InternalParameter_3203, out _);
        private static bool InternalMethod_3427(InternalType_5 InternalParameter_3204, out GestureRecognizer InternalParameter_3205)
        {
            InternalParameter_3205 = null;
            UIBlock InternalVar_1 = InternalParameter_3204 as UIBlock;

            if (InternalVar_1 == null || !InternalVar_1.TryGetComponent(out InternalParameter_3205) || !SceneViewUtils.IsVisibleInSceneView(InternalVar_1.gameObject))
            {
                return false;
            }

            return NovaApplication.InPlayer(InternalParameter_3205) ? InternalParameter_3205.InternalProperty_164 : InternalParameter_3205.Navigable;
        }

        private static void InternalMethod_3428()
        {
            InternalField_3445.Clear();

            InternalField_3446 = InternalType_534.InternalProperty_1090 ?
                       Selection.GetFiltered<GestureRecognizer>(SelectionMode.Deep).Where(x => x.enabled && InternalMethod_3426(x.UIBlock)).ToArray() :
                       StageUtility.GetCurrentStageHandle().FindComponentsOfType<GestureRecognizer>().Where(x => x.enabled && x.gameObject.activeInHierarchy && x.Navigable).ToArray();

            foreach (GestureRecognizer InternalVar_1 in InternalField_3446)
            {
                InternalMethod_3423(InternalVar_1);
            }
        }

        private static void InternalMethod_3429(SceneView InternalParameter_3206)
        {
            if (Event.current.type != EventType.Repaint || !InternalType_534.InternalProperty_1089)
            {
                return;
            }

            InternalMethod_3428();

            InternalField_3447.Clear();

            Color InternalVar_1 = Handles.color;
            Handles.color = InternalType_573.InternalType_574.InternalProperty_494;

            foreach (GestureRecognizer InternalVar_2 in InternalField_3446)
            {
                InternalMethod_3430(InternalVar_2);

                InternalField_3447.Add(InternalVar_2);
            }

            Handles.color = InternalVar_1;
        }

        private static void InternalMethod_3430(GestureRecognizer InternalParameter_3207)
        {
            UIBlock InternalVar_1 = InternalParameter_3207.UIBlock;

            for (int InternalVar_2 = 0; InternalVar_2 < InternalField_3444.Length; ++InternalVar_2)
            {
                Vector3 InternalVar_3 = InternalField_3444[InternalVar_2];
                UIBlock InternalVar_4 = InternalMethod_3416(InternalParameter_3207, InternalVar_3);

                if (InternalVar_4 == null)
                {
                    continue;
                }

                bool InternalVar_5 = false;

                if (InternalVar_4.TryGetComponent(out GestureRecognizer InternalVar_6))
                {
                    InternalVar_5 = InternalMethod_3417(InternalVar_6, -InternalVar_3, out UIBlock InternalVar_7);
                    InternalVar_5 &= InternalVar_7 == InternalVar_1;
                }

                if (InternalVar_5 && InternalField_3447.Contains(InternalVar_6))
                {
                    continue;
                }

                InternalMethod_3431(InternalVar_3, InternalVar_1, InternalVar_4, InternalVar_5);
            }
        }

        private static void InternalMethod_3431(Vector3 InternalParameter_3208, UIBlock InternalParameter_3209, UIBlock InternalParameter_3210, bool InternalParameter_3211)
        {
            if (InternalParameter_3209 == null || InternalParameter_3210 == null)
            {
                return;
            }

            Transform InternalVar_1 = InternalParameter_3209.transform;
            Transform InternalVar_2 = InternalParameter_3210.transform;

            Vector3 InternalVar_3 = InternalParameter_3208.z == 0 ? new Vector3(InternalParameter_3208.y, -InternalParameter_3208.x, 0) : new Vector3(InternalParameter_3208.z, 0, -InternalParameter_3208.x);
            Vector3 InternalVar_4 = InternalVar_1.TransformPoint(Vector3.Scale(InternalParameter_3209.CalculatedSize.Value * 0.5f, InternalParameter_3208));
            Vector3 InternalVar_5 = InternalVar_2.TransformPoint(Vector3.Scale(InternalParameter_3210.CalculatedSize.Value * 0.5f, -InternalParameter_3208));
            float InternalVar_6 = HandleUtility.GetHandleSize(InternalVar_4) * 0.05f;
            float InternalVar_7 = HandleUtility.GetHandleSize(InternalVar_5) * 0.05f;

            float InternalVar_8 = Vector3.Distance(InternalVar_4, InternalVar_5);
            bool InternalVar_9 = InternalVar_8 > InternalType_187.InternalField_494;

            if (!InternalParameter_3211 || !InternalVar_9)
            {
                InternalVar_4 += InternalVar_1.TransformDirection(InternalVar_3) * InternalVar_6;
                InternalVar_5 += InternalVar_2.TransformDirection(InternalVar_3) * InternalVar_7;
            }

            UnityEngine.Rendering.CompareFunction InternalVar_10 = Handles.zTest;
            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;

            if (InternalVar_9)
            {
                Vector3 InternalVar_11 = InternalVar_1.rotation * InternalParameter_3208 * InternalVar_8 * 0.3f;
                Vector3 InternalVar_12 = InternalVar_2.rotation * -InternalParameter_3208 * InternalVar_8 * 0.3f;

                Handles.DrawBezier(InternalVar_4, InternalVar_5, InternalVar_4 + InternalVar_11, InternalVar_5 + InternalVar_12, Handles.color, null, InternalField_3442);
            }

            if (InternalParameter_3211)
            {
                Vector3 InternalVar_11 = InternalVar_4 + InternalVar_1.rotation * (InternalParameter_3208 + InternalVar_3) * InternalVar_6 * InternalField_3443;
                Vector3 InternalVar_12 = InternalVar_4 + InternalVar_1.rotation * (InternalParameter_3208 - InternalVar_3) * InternalVar_6 * InternalField_3443;
                Handles.DrawAAPolyLine(InternalField_3442, InternalVar_11, InternalVar_4, InternalVar_12);
            }

            Vector3 InternalVar_13 = InternalVar_5 + InternalVar_2.rotation * (-InternalParameter_3208 + InternalVar_3) * InternalVar_7 * InternalField_3443;
            Vector3 InternalVar_14 = InternalVar_5 + InternalVar_2.rotation * (-InternalParameter_3208 - InternalVar_3) * InternalVar_7 * InternalField_3443;
            Handles.DrawAAPolyLine(InternalField_3442, InternalVar_13, InternalVar_5, InternalVar_14);

            Handles.zTest = InternalVar_10;
        }

        private static void InternalMethod_3432(Ray InternalParameter_3212, UIBlock InternalParameter_3213)
        {
            Ray InternalVar_1 = InternalType_718.InternalMethod_3217(InternalParameter_3212, InternalParameter_3213.transform.worldToLocalMatrix);
            InternalType_441 InternalVar_2 = new InternalType_441(InternalParameter_3213.CalculatedSize.Value);

            float3 InternalVar_3 = InternalVar_2.InternalMethod_1722(InternalVar_1.origin);
            InternalType_434 InternalVar_4 = new InternalType_434(InternalVar_1);

            float InternalVar_5 = InternalType_440.InternalMethod_3619(ref InternalVar_2, InternalVar_3, ref InternalVar_4);

            Vector3 InternalVar_6 = InternalVar_4.InternalMethod_1706(InternalVar_5);
            Vector3 InternalVar_7 = InternalParameter_3213.transform.TransformPoint(InternalVar_6);

            Color InternalVar_8 = Handles.color;
            Handles.color = Color.magenta;
            Handles.DrawWireDisc(InternalVar_7, InternalParameter_3213.transform.forward, Vector3.Magnitude(InternalParameter_3212.origin - InternalVar_7));
            Handles.color = InternalVar_8;
        }
    }
}
