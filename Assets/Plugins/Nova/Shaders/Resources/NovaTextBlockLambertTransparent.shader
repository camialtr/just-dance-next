Shader "Hidden/Nova/NovaTextBlockLambertTransparent"
{
    Properties
    {
        [HideInInspector]
        _ZWrite ("ZWrite", Float) = 1
        [HideInInspector]
        _SrcBlend ("SrcBlend", Float) = 1
        [HideInInspector]
        _DstBlend ("DstBlend", Float) = 0
        [HideInInspector]
        _CullMode ("CullMode", Float) = 2
        [HideInInspector]
        _AdditiveLightingSrcBlend ("AdditiveLightingSrcBlend", Float) = 1
        [HideInInspector]
        _AdditiveLightingDstBlend ("AdditiveLightingDstBlend", Float) = 1
        [HideInInspector]
        [HDR]_FaceColor ("Face Color", Color) = (1, 1, 1, 1)
        [HideInInspector]
        _FaceDilate ("Face Dilate", Range(-1, 1)) = 0
        [HideInInspector]
        [HDR]_OutlineColor ("Outline Color", Color) = (0, 0, 0, 1)
        [HideInInspector]
        _OutlineWidth ("Outline Thickness", Range(0, 1)) = 0
        [HideInInspector]
        _OutlineSoftness ("Outline Softness", Range(0, 1)) = 0
        [HideInInspector]
        [HDR]_UnderlayColor ("Border Color", Color) = (0, 0, 0, .5)
        [HideInInspector]
        _UnderlayOffsetX ("Border OffsetX", Range(-1, 1)) = 0
        [HideInInspector]
        _UnderlayOffsetY ("Border OffsetY", Range(-1, 1)) = 0
        [HideInInspector]
        _UnderlayDilate ("Border Dilate", Range(-1, 1)) = 0
        [HideInInspector]
        _UnderlaySoftness ("Border Softness", Range(0, 1)) = 0
        [HideInInspector]
        _WeightNormal ("Weight Normal", float) = 0
        [HideInInspector]
        _WeightBold ("Weight Bold", float) = .5
        [HideInInspector]
        _ShaderFlags ("Flags", float) = 0
        [HideInInspector]
        _ScaleRatioA ("Scale RatioA", float) = 1
        [HideInInspector]
        _ScaleRatioB ("Scale RatioB", float) = 1
        [HideInInspector]
        _ScaleRatioC ("Scale RatioC", float) = 1
        [HideInInspector]
        _MainTex ("Font Atlas", 2D) = "white" { }
        [HideInInspector]
        _TextureWidth ("Texture Width", float) = 512
        [HideInInspector]
        _TextureHeight ("Texture Height", float) = 512
        [HideInInspector]
        _GradientScale ("Gradient Scale", float) = 5
        [HideInInspector]
        _ScaleX ("Scale X", float) = 1
        [HideInInspector]
        _ScaleY ("Scale Y", float) = 1
        [HideInInspector]
        _PerspectiveFilter ("Perspective Correction", Range(0, 1)) = 0.875
        [HideInInspector]
        _Sharpness ("Sharpness", Range(-1, 1)) = 0
        [HideInInspector]
        _VertexOffsetX ("Vertex OffsetX", float) = 0
        [HideInInspector]
        _VertexOffsetY ("Vertex OffsetY", float) = 0
        [HideInInspector]
        _MaskSoftnessX ("Mask SoftnessX", float) = 0
        [HideInInspector]
        _MaskSoftnessY ("Mask SoftnessY", float) = 0
        [HideInInspector]
        _StencilComp ("Stencil Comparison", Float) = 8
        [HideInInspector]
        _Stencil ("Stencil ID", Float) = 0
        [HideInInspector]
        _StencilOp ("Stencil Operation", Float) = 0
        [HideInInspector]
        _StencilWriteMask ("Stencil Write Mask", Float) = 255
        [HideInInspector]
        _StencilReadMask ("Stencil Read Mask", Float) = 255
        [HideInInspector]
        _CullMode ("Cull Mode", Float) = 0
        [HideInInspector]
        _ColorMask ("Color Mask", Float) = 15
        [HideInInspector]
        _ClipMaskTex ("ClipMaskTex", 2D) = "white" { }
        [HideInInspector]
        _ZTest ("ZTest", Float) = 4

    }

    CGINCLUDE

    ENDCG

    SubShader
    {
        
        // ---- forward rendering base pass:
        Pass
        {
            Name "FORWARD"
            Tags { "LightMode" = "ForwardBase" "DisableBatching" = "True" }
            ZWrite [_ZWrite]
            // Separate alpha blend to avoid setting the render target
            // alpha value to be < 1
            Blend [_SrcBlend] [_DstBlend], One OneMinusSrcAlpha
            Cull [_CullMode]
            ZTest [_ZTest]

            CGPROGRAM
            #define _ALPHABLEND_ON 1
			// 

            // compile directives
            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            #pragma target 3.5
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma instancing_options assumeuniformscaling
            #pragma instancing_options nolightmap
            #pragma instancing_options nolodfade
            
            #pragma multi_compile_fwdbasealpha noshadow

            #pragma skip_variants LIGHTMAP_ON DIRLIGHTMAP_COMBINED DYNAMICLIGHTMAP_ON LIGHTMAP_SHADOW_MIXING SHADOWS_SHADOWMASK
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2

            #include "HLSLSupport.cginc"
            
            #define UNITY_INSTANCED_SH
            #define UNITY_INSTANCED_LIGHTMAPSTS
            #include "UnityShaderVariables.cginc"
            #include "UnityShaderUtilities.cginc"
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            #include "AutoLight.cginc"

            #define INTERNAL_DATA
            #define WorldReflectionVector(data, normal) data.worldRefl
            #define WorldNormalVector(data, normal) normal

            #define NOVA_FORWARD_BASE_PASS

            #define NOVA_LAMBERT_LIGHTING
            
            #pragma multi_compile_local __ OUTLINE_ON            #pragma multi_compile_local __ UNDERLAY_ON UNDERLAY_INNER            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_SUPER_SAMPLE            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../TextBlock.cginc"


            NOVA_DUMMY_INSTANCE_SETUP

            ENDCG

        }

        // ---- forward rendering additive lights pass:
        Pass
        {
            Name "FORWARD"
            Tags { "LightMode" = "ForwardAdd" "DisableBatching" = "True" }
            ZWrite Off
            Blend [_AdditiveLightingSrcBlend] [_AdditiveLightingDstBlend]
            ZTest [_ZTest]
            
            CGPROGRAM
            #define _ALPHABLEND_ON 1

			// 
            // compile directives
            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            #pragma target 3.5
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma skip_variants SHADOWS_SHADOWMASK
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2

            #define NOVA_FORWARD_ADD_PASS

            #pragma multi_compile_fwdadd_fullshadows noshadow
            
            #include "HLSLSupport.cginc"
            
            #define UNITY_INSTANCED_SH
            #define UNITY_INSTANCED_LIGHTMAPSTS
            #include "UnityShaderVariables.cginc"
            #include "UnityShaderUtilities.cginc"
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            #include "AutoLight.cginc"

            #define INTERNAL_DATA
            #define WorldReflectionVector(data, normal) data.worldRefl
            #define WorldNormalVector(data, normal) normal

            #define NOVA_LAMBERT_LIGHTING
            
            #pragma multi_compile_local __ OUTLINE_ON            #pragma multi_compile_local __ UNDERLAY_ON UNDERLAY_INNER            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_SUPER_SAMPLE            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../TextBlock.cginc"

            
            NOVA_DUMMY_INSTANCE_SETUP

            ENDCG

        }

        // ---- shadow caster pass:
        Pass
        {
            Name "ShadowCaster"
            Tags { "LightMode" = "ShadowCaster" "DisableBatching" = "True" }
            ZWrite On
            ZTest LEqual

            CGPROGRAM
            #define _ALPHABLEND_ON 1

			// 
            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            #pragma target 3.5
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
            #pragma multi_compile_shadowcaster
            #include "HLSLSupport.cginc"
            
            #define UNITY_INSTANCED_SH
            #define UNITY_INSTANCED_LIGHTMAPSTS
            #include "UnityShaderVariables.cginc"
            #include "UnityShaderUtilities.cginc"

            #define NOVA_SHADOW_CAST_PASS
            
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            
            #define INTERNAL_DATA
            #define WorldReflectionVector(data, normal) data.worldRefl
            #define WorldNormalVector(data, normal) normal

            #define NOVA_LAMBERT_LIGHTING
            
            #pragma multi_compile_local __ OUTLINE_ON            #pragma multi_compile_local __ UNDERLAY_ON UNDERLAY_INNER            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_SUPER_SAMPLE            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../TextBlock.cginc"


            NOVA_DUMMY_INSTANCE_SETUP

            ENDCG

        }
    }
    Fallback "Diffuse"
}
