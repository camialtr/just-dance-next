// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_20;
using UnityEditor;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [CustomEditor(typeof(UIBlock3D)), CanEditMultipleObjects]
    internal class InternalType_552 : InternalType_547<UIBlock3D>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_612 InternalField_2444 = new InternalType_612();

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalField_2444.InternalProperty_954 = serializedObject.FindProperty(InternalType_646.InternalType_659.InternalField_3330);
        }

        protected override void InternalMethod_2184(UIBlock3D InternalParameter_2485)
        {
            InternalType_576.InternalMethod_2321(InternalField_2427, InternalParameter_2485);

            InternalType_576.InternalMethod_2313(InternalField_2426, InternalParameter_2485);
            InternalType_576.InternalMethod_2311(InternalField_2426, InternalParameter_2485, InternalField_2425);

            InternalType_10.Calculated InternalVar_1 = serializedObject.isEditingMultipleObjects ? default : InternalProperty_683.InternalProperty_43;
            InternalType_577.InternalMethod_1492(InternalParameter_2485.CalculatedSize.Value, InternalField_2444, InternalField_2429, InternalField_2428, ref InternalVar_1);

            InternalType_576.InternalMethod_2320(InternalField_2426, InternalParameter_2485);
        }
    }
}
