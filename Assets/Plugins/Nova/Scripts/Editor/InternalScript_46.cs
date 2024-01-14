// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal enum InternalType_550
    {
        InternalField_2440,
        InternalField_2441
    }

    [CustomEditor(typeof(UIBlock2D)), CanEditMultipleObjects]
    internal class InternalType_551 : InternalType_547<UIBlock2D>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_604 InternalField_2442 = new InternalType_604();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_550 InternalField_2443 = InternalType_550.InternalField_2440;

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalField_2442.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_658.InternalField_3328);

            if (serializedObject.FindProperty(InternalType_646.InternalType_658.InternalField_2991).objectReferenceValue != null)
            {
                InternalField_2443 = InternalType_550.InternalField_2441;
            }
        }

        protected override void InternalMethod_2184(UIBlock2D InternalParameter_2485)
        {
            Vector3 InternalVar_1 = InternalParameter_2485.CalculatedSize.Value;
            float InternalVar_2 = .5f * Mathf.Min(InternalVar_1.x, InternalVar_1.y);

            InternalType_8.Calculated InternalVar_3 = serializedObject.isEditingMultipleObjects ? default : InternalProperty_683.InternalProperty_42;

            InternalType_576.InternalMethod_2321(InternalField_2427, InternalParameter_2485);
            InternalType_576.InternalMethod_2313(InternalField_2426, InternalParameter_2485);
            InternalType_576.InternalMethod_2311(InternalField_2426, InternalParameter_2485, InternalField_2425);
            InternalType_577.InternalMethod_1929(InternalVar_2, InternalField_2442, InternalField_2429, InternalField_2428, ref InternalField_2443, ref InternalVar_3);
            InternalType_577.InternalMethod_1423(InternalField_2442.InternalProperty_607, InternalVar_3.Border);

            InternalType_577.InternalMethod_480(InternalField_2442, InternalVar_3.Shadow);
            InternalType_576.InternalMethod_2320(InternalField_2426, InternalParameter_2485);
        }
    }
}

