Shader "Hidden/Nova/NovaTextBlockUnlit"
{
    Properties
    {
        [HDR]_FaceColor ("Face Color", Color) = (1, 1, 1, 1)
        _FaceDilate ("Face Dilate", Range(-1, 1)) = 0

        [HDR]_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth ("Outline Thickness", Range(0, 1)) = 0
        _OutlineSoftness ("Outline Softness", Range(0, 1)) = 0

        [HDR]_UnderlayColor ("Border Color", Color) = (0, 0, 0, .5)
        _UnderlayOffsetX ("Border OffsetX", Range(-1, 1)) = 0
        _UnderlayOffsetY ("Border OffsetY", Range(-1, 1)) = 0
        _UnderlayDilate ("Border Dilate", Range(-1, 1)) = 0
        _UnderlaySoftness ("Border Softness", Range(0, 1)) = 0

        _WeightNormal ("Weight Normal", float) = 0
        _WeightBold ("Weight Bold", float) = .5

        _ShaderFlags ("Flags", float) = 0
        _ScaleRatioA ("Scale RatioA", float) = 1
        _ScaleRatioB ("Scale RatioB", float) = 1
        _ScaleRatioC ("Scale RatioC", float) = 1

        _MainTex ("Font Atlas", 2D) = "white" { }
        _TextureWidth ("Texture Width", float) = 512
        _TextureHeight ("Texture Height", float) = 512
        _GradientScale ("Gradient Scale", float) = 5
        _ScaleX ("Scale X", float) = 1
        _ScaleY ("Scale Y", float) = 1
        _PerspectiveFilter ("Perspective Correction", Range(0, 1)) = 0.875
        _Sharpness ("Sharpness", Range(-1, 1)) = 0

        _VertexOffsetX ("Vertex OffsetX", float) = 0
        _VertexOffsetY ("Vertex OffsetY", float) = 0

        _MaskSoftnessX ("Mask SoftnessX", float) = 0
        _MaskSoftnessY ("Mask SoftnessY", float) = 0

        _StencilComp ("Stencil Comparison", Float) = 8
        _Stencil ("Stencil ID", Float) = 0
        _StencilOp ("Stencil Operation", Float) = 0
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        _StencilReadMask ("Stencil Read Mask", Float) = 255

        _CullMode ("Cull Mode", Float) = 0
        _ColorMask ("Color Mask", Float) = 15
        [HideInInspector]
        _ClipMaskTex ("ClipMaskTex", 2D) = "white" { }
        [HideInInspector]
        _ZTest ("ZTest", Float) = 4
    }

    SubShader
    {
        Tags { "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" "DisableBatching" = "True" }

        Stencil
        {
            Ref [_Stencil]
            Comp [_StencilComp]
            Pass [_StencilOp]
            ReadMask [_StencilReadMask]
            WriteMask [_StencilWriteMask]
        }

        Cull [_CullMode]
        ZWrite Off
        Lighting Off
        Fog
        {
            Mode Off
        }
        
        Blend One OneMinusSrcAlpha
        ColorMask [_ColorMask]
        ZTest [_ZTest]

        Pass
        {
            CGPROGRAM

            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            #pragma target 3.5
            // 
            
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma instancing_options assumeuniformscaling
            #pragma instancing_options nolightmap
            #pragma instancing_options nolodfade
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2

            #pragma multi_compile_local __ OUTLINE_ON
            #pragma multi_compile_local __ UNDERLAY_ON UNDERLAY_INNER

            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK
            #pragma multi_compile_local __ NOVA_SUPER_SAMPLE
            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING
            #pragma multi_compile __ UNITY_UI_ALPHACLIP
            #include "../TextBlock.cginc"

            NOVA_DUMMY_INSTANCE_SETUP
            ENDCG
        }
    }
}
