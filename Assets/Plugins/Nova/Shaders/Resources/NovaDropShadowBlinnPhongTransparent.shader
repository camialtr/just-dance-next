Shader "Hidden/Nova/NovaDropShadowBlinnPhongTransparent"
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
        _CullMode ("CullMode", Float) = 2
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

            #define NOVA_BLINNPHONG_LIGHTING
            
            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_RADIAL_FILL            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../DropShadow.cginc"


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

            #define NOVA_BLINNPHONG_LIGHTING
            
            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_RADIAL_FILL            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../DropShadow.cginc"

            
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

            #define NOVA_BLINNPHONG_LIGHTING
            
            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK            #pragma multi_compile_local __ NOVA_RADIAL_FILL            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING            #include "../DropShadow.cginc"


            NOVA_DUMMY_INSTANCE_SETUP

            ENDCG

        }
    }
    Fallback "Diffuse"
}
