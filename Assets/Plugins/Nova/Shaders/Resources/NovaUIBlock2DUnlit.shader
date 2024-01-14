Shader "Hidden/Nova/NovaUIBlock2DUnlit"
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
        _NovaTextureArray ("NovaTextureArray", 2DArray) = "" { }
        [HideInInspector]
        _NovaDynamicTexture ("NovaDynamicTexture", 2D) = "white" { }
        [HideInInspector]
        _ClipMaskTex ("ClipMaskTex", 2D) = "white" { }
        [HideInInspector]
        _ZTest ("ZTest", Float) = 4
    }

    SubShader
    {
        ZWrite [_ZWrite]
        // Separate alpha blend to avoid setting the render target
        // alpha value to be < 1
        Blend [_SrcBlend] [_DstBlend], One OneMinusSrcAlpha
        Lighting Off
        Tags { "DisableBatching" = "True" }
        Cull [_CullMode]
        ZTest [_ZTest]

        Pass
        {
            CGPROGRAM

            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            // 
            #pragma target 3.5
            
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma instancing_options assumeuniformscaling
            #pragma instancing_options nolightmap
            #pragma instancing_options nolodfade
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2

            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK
            #pragma multi_compile_local __ NOVA_DYNAMIC_IMAGE NOVA_STATIC_IMAGE
            #pragma multi_compile_local __ NOVA_INNER_SHADOW
            #pragma multi_compile_local __ NOVA_OUTER_BORDER NOVA_INNER_BORDER NOVA_CENTER_BORDER
            #pragma multi_compile_local __ NOVA_RADIAL_FILL
            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING
            #include "../UIBlock2D.cginc"

            NOVA_DUMMY_INSTANCE_SETUP
            ENDCG
        }
    }
}
