// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_21
{
    internal static class InternalType_712
    {
        [DrawGizmo(GizmoType.Pickable | GizmoType.Active | GizmoType.InSelectionHierarchy | GizmoType.NonSelected | GizmoType.NotInSelectionHierarchy, typeof(UIBlock))]
        public static void InternalMethod_3194(UIBlock InternalParameter_2885, GizmoType InternalParameter_2886)
        {
            if (!InternalType_534.InternalProperty_720)
            {
                return;
            }

            bool InternalVar_1 = (InternalParameter_2886 & GizmoType.Selected) != 0;
            bool InternalVar_2 = (InternalParameter_2886 & GizmoType.InSelectionHierarchy) != 0;

            bool InternalVar_3 = InternalVar_1 || InternalVar_2;

            if (!InternalVar_3)
            {
                return;
            }

            Color InternalVar_4 = SceneView.selectedOutlineColor;
            InternalVar_4.a = 1;

            InternalMethod_3313(InternalParameter_2885, InternalVar_1 ? InternalVar_4 : InternalType_573.InternalType_574.InternalProperty_719);
        }

        private static void InternalMethod_3313(UIBlock InternalParameter_3108, Color InternalParameter_3109)
        {
            using (new Handles.DrawingScope(InternalParameter_3109, InternalParameter_3108.transform.localToWorldMatrix))
            {
                InternalType_718.InternalMethod_3315(Vector3.zero, InternalParameter_3108.CalculatedSize.Value, 2, InternalParameter_3113: false);
            }
        }
    }
}
