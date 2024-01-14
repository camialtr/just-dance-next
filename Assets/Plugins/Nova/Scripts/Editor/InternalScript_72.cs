// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0.InternalNamespace_10;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    [Obfuscation]
    internal enum SurfacePreset
    {
        Unlit,
        Matte,
        Plastic,
        Glossy,
        Rubber,
        PolishedMetal,
        BrushedMetal,
    }

    [CustomPropertyDrawer(typeof(Surface))]
    internal class InternalType_590 : InternalType_583<InternalType_610>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_2607 = 0.8f;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_2608 = 0.5f;

        protected override float InternalMethod_2353(GUIContent InternalParameter_2767)
        {
            if (!InternalField_2609)
            {
                return EditorGUI.GetPropertyHeight(InternalField_2604.InternalProperty_954, InternalParameter_2767, false);
            }

            switch (InternalField_2604.InternalProperty_663)
            {
                case LightingModel.Unlit:
                    return 2f * InternalType_720.InternalField_3298;
                case LightingModel.Lambert:
                    return 4f * InternalType_720.InternalField_3298;
                case LightingModel.BlinnPhong:
                case LightingModel.Standard:
                case LightingModel.StandardSpecular:
                default:
                    return 6f * InternalType_720.InternalField_3298;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_2609 = true;
        protected override void OnGUI(Rect position, GUIContent label)
        {
            Rect InternalVar_1 = position;
            InternalVar_1.width = EditorGUIUtility.labelWidth;
            InternalField_2609 = EditorGUI.Foldout(InternalVar_1, InternalField_2609, label, true);

            EditorGUI.BeginChangeCheck();

            Rect InternalVar_2 = position;
            InternalVar_2.width -= EditorGUIUtility.labelWidth;
            InternalVar_2.x += EditorGUIUtility.labelWidth;

            bool InternalVar_3 = EditorGUI.showMixedValue;
            EditorGUI.showMixedValue = InternalField_2604.InternalProperty_954.hasMultipleDifferentValues;

            SurfacePreset InternalVar_4 = (SurfacePreset)EditorGUI.EnumPopup(InternalVar_2, InternalMethod_2355(InternalField_2604));

            EditorGUI.showMixedValue = InternalVar_3;

            if (EditorGUI.EndChangeCheck())
            {
                InternalMethod_2356(InternalVar_4, InternalField_2604);
            }

            if (!InternalField_2609)
            {
                EditorGUI.EndFoldoutHeaderGroup();
                return;
            }

            position.InternalMethod_3251();

            EditorGUI.indentLevel++;

            EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_664);

            switch (InternalField_2604.InternalProperty_663)
            {
                case LightingModel.BlinnPhong:
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_660, InternalType_554.InternalType_567.InternalField_2520);
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_662, InternalType_554.InternalType_567.InternalField_2521);
                    break;
                case LightingModel.Standard:
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_660, InternalType_554.InternalType_567.InternalField_2523);
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_662, InternalType_554.InternalType_567.InternalField_2522);
                    break;
                case LightingModel.StandardSpecular:
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_658, InternalType_554.InternalType_567.InternalField_2524);
                    position.InternalMethod_3251();
                    EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_660, InternalType_554.InternalType_567.InternalField_2523);
                    break;
            }

            if (InternalField_2604.InternalProperty_663 != LightingModel.Unlit)
            {
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_666);
                position.InternalMethod_3251();
                EditorGUI.PropertyField(position, InternalField_2604.InternalProperty_668);
            }

            EditorGUI.indentLevel--;

            EditorGUI.EndFoldoutHeaderGroup();
        }

        
        public static SurfacePreset InternalMethod_2355(InternalType_610 InternalParameter_2771)
        {
            LightingModel InternalVar_1 = InternalParameter_2771.InternalProperty_663;
            float InternalVar_2 = InternalParameter_2771.InternalProperty_659;
            float InternalVar_3 = InternalParameter_2771.InternalProperty_661;
            Color InternalVar_4 = InternalParameter_2771.InternalProperty_657;

            switch (InternalVar_1)
            {
                case LightingModel.Lambert:
                    return SurfacePreset.Matte;
                case LightingModel.BlinnPhong:
                    return SurfacePreset.Plastic;
                case LightingModel.Standard:
                    Standard InternalVar_5 = new Standard(InternalVar_2, InternalVar_3);

                    if (InternalVar_5.Metallic > InternalField_2607)
                    {
                        return InternalVar_5.Smoothness > InternalField_2608 ? SurfacePreset.PolishedMetal : SurfacePreset.BrushedMetal;
                    }

                    return InternalVar_5.Smoothness > InternalField_2608 ? SurfacePreset.Glossy : SurfacePreset.Rubber;

                case LightingModel.StandardSpecular:
                    StandardSpecular InternalVar_6 = new StandardSpecular(InternalVar_4, InternalVar_2);

                    Color.RGBToHSV(InternalVar_4, out float InternalVar_7, out float InternalVar_8, out float InternalVar_9);

                    if (InternalVar_9 > InternalField_2607)
                    {
                        return InternalVar_6.Smoothness > InternalField_2608 ? SurfacePreset.PolishedMetal : SurfacePreset.BrushedMetal;
                    }

                    return InternalVar_6.Smoothness > InternalField_2608 ? SurfacePreset.Glossy : SurfacePreset.Rubber;
            }

            return SurfacePreset.Unlit;
        }

        public static void InternalMethod_569(InternalType_610 InternalParameter_3106, LightingModel InternalParameter_3107)
        {
            InternalType_266 InternalVar_1 = InternalType_266.InternalField_785;
            switch (InternalParameter_3106.InternalProperty_954.serializedObject.targetObject)
            {
                case UIBlock2D uIBlock2D:
                    InternalVar_1 = InternalType_266.InternalField_786;
                    break;
                case TextBlock textBlock:
                    InternalVar_1 = InternalType_266.InternalField_788;
                    break;
                case UIBlock3D uIBlock3D:
                    InternalVar_1 = InternalType_266.InternalField_787;
                    break;
            }

            InternalNamespace_0.InternalType_104 InternalVar_2 = (InternalNamespace_0.InternalType_104)InternalParameter_3107;
            if (InternalVar_1 != InternalType_266.InternalField_785 && !InternalType_409.InternalMethod_1925(InternalVar_1, InternalVar_2))
            {
                bool InternalVar_3 = EditorUtility.DisplayDialog("Lighting Model Not Included", $"The {InternalVar_2.InternalMethod_1922()} lighting model is not marked to be included in builds for {InternalVar_1.InternalMethod_1923()}s. Would you like to include it?", "Yes", "No");

                if (InternalVar_3)
                {
                    switch (InternalVar_1)
                    {
                        case InternalType_266.InternalField_786:
                            NovaSettings.UIBlock2DLightingModels |= (LightingModelBuildFlag)InternalVar_2.InternalMethod_1924();
                            break;
                        case InternalType_266.InternalField_787:
                            NovaSettings.UIBlock3DLightingModels |= (LightingModelBuildFlag)InternalVar_2.InternalMethod_1924();
                            break;
                        case InternalType_266.InternalField_788:
                            NovaSettings.TextBlockLightingModels |= (LightingModelBuildFlag)InternalVar_2.InternalMethod_1924();
                            break;
                    }
                }
            }

            InternalParameter_3106.InternalProperty_663 = InternalParameter_3107;
        }

        public static void InternalMethod_2356(SurfacePreset InternalParameter_2772, InternalType_610 InternalParameter_2773)
        {
            switch (InternalParameter_2772)
            {
                case SurfacePreset.Unlit:
                    InternalMethod_569(InternalParameter_2773, LightingModel.Unlit);
                    break;
                case SurfacePreset.Matte:
                    InternalMethod_569(InternalParameter_2773, LightingModel.Lambert);
                    break;
                case SurfacePreset.Plastic:
                    Surface InternalVar_1 = Surface.Plastic(shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                    InternalMethod_569(InternalParameter_2773, InternalVar_1.LightingModel);


                    BlinnPhong InternalVar_2 = InternalVar_1.BlinnPhong;
                    InternalParameter_2773.InternalProperty_659 = InternalVar_2.Specular;
                    InternalParameter_2773.InternalProperty_661 = InternalVar_2.Gloss;
                    break;
                case SurfacePreset.Glossy:
                    if (InternalParameter_2773.InternalProperty_663 == LightingModel.StandardSpecular)
                    {
                        Surface InternalVar_3 = Surface.Glossy(InternalParameter_2773.InternalProperty_657, shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        StandardSpecular InternalVar_4 = InternalVar_3.StandardSpecular;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;

                        Color.RGBToHSV(InternalVar_4.SpecularColor, out float InternalVar_5, out float InternalVar_6, out float InternalVar_7);
                        InternalParameter_2773.InternalProperty_661 = InternalVar_7;
                        InternalParameter_2773.InternalProperty_657 = InternalVar_4.SpecularColor;
                    }
                    else
                    {
                        Surface InternalVar_3 = Surface.Glossy(shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        Standard InternalVar_4 = InternalVar_3.Standard;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;
                        InternalParameter_2773.InternalProperty_661 = InternalVar_4.Metallic;
                    }
                    break;
                case SurfacePreset.Rubber:
                    if (InternalParameter_2773.InternalProperty_663 == LightingModel.StandardSpecular)
                    {
                        Surface InternalVar_3 = Surface.Rubber(InternalParameter_2773.InternalProperty_657, shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        StandardSpecular InternalVar_4 = InternalVar_3.StandardSpecular;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;

                        Color.RGBToHSV(InternalVar_4.SpecularColor, out float InternalVar_5, out float InternalVar_6, out float InternalVar_7);
                        InternalParameter_2773.InternalProperty_661 = InternalVar_7;
                        InternalParameter_2773.InternalProperty_657 = InternalVar_4.SpecularColor;
                    }
                    else
                    {
                        Surface InternalVar_3 = Surface.Rubber(shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        Standard InternalVar_4 = InternalVar_3.Standard;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;
                        InternalParameter_2773.InternalProperty_661 = InternalVar_4.Metallic;
                    }
                    break;
                case SurfacePreset.PolishedMetal:
                    if (InternalParameter_2773.InternalProperty_663 == LightingModel.StandardSpecular)
                    {
                        Surface InternalVar_3 = Surface.PolishedMetal(InternalParameter_2773.InternalProperty_657, shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        StandardSpecular InternalVar_4 = InternalVar_3.StandardSpecular;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;

                        Color.RGBToHSV(InternalVar_4.SpecularColor, out float InternalVar_5, out float InternalVar_6, out float InternalVar_7);
                        InternalParameter_2773.InternalProperty_661 = InternalVar_7;
                        InternalParameter_2773.InternalProperty_657 = InternalVar_4.SpecularColor;
                    }
                    else
                    {
                        Surface InternalVar_3 = Surface.PolishedMetal(shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        Standard InternalVar_4 = InternalVar_3.Standard;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;
                        InternalParameter_2773.InternalProperty_661 = InternalVar_4.Metallic;
                    }
                    break;
                case SurfacePreset.BrushedMetal:
                    if (InternalParameter_2773.InternalProperty_663 == LightingModel.StandardSpecular)
                    {
                        Surface InternalVar_3 = Surface.BrushedMetal(InternalParameter_2773.InternalProperty_657, shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        StandardSpecular InternalVar_4 = InternalVar_3.StandardSpecular;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;

                        Color.RGBToHSV(InternalVar_4.SpecularColor, out float InternalVar_5, out float InternalVar_6, out float InternalVar_7);
                        InternalParameter_2773.InternalProperty_661 = InternalVar_7;
                        InternalParameter_2773.InternalProperty_657 = InternalVar_4.SpecularColor;
                    }
                    else
                    {
                        Surface InternalVar_3 = Surface.BrushedMetal(shadowCasting: InternalParameter_2773.InternalProperty_665, receiveShadows: InternalParameter_2773.InternalProperty_667);
                        InternalMethod_569(InternalParameter_2773, InternalVar_3.LightingModel);

                        Standard InternalVar_4 = InternalVar_3.Standard;
                        InternalParameter_2773.InternalProperty_659 = InternalVar_4.Smoothness;
                        InternalParameter_2773.InternalProperty_661 = InternalVar_4.Metallic;
                    }
                    break;
            }
        }
    }
}