Shader "Hidden/Nova/NovaUIBlock3DUnlit"
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
        _ClipMaskTex ("ClipMaskTex", 2D) = "white" { }
        [HideInInspector]
        _ZTest ("ZTest", Float) = 4
    }

    SubShader
    {
        Pass
        {
            ZWrite [_ZWrite]
            // Separate alpha blend to avoid setting the render target
            // alpha value to be < 1
            Blend [_SrcBlend] [_DstBlend], One OneMinusSrcAlpha
            Lighting Off
            Cull [_CullMode]
            Tags { "DisableBatching" = "True" }
            ZTest [_ZTest]

            CGPROGRAM

            // 
            #pragma vertex NovaVert
            #pragma fragment NovaFrag
            #define PROCEDURAL_INSTANCING_ON
            #pragma instancing_options procedural:setup
            #pragma instancing_options assumeuniformscaling
            #pragma instancing_options nolightmap
            #pragma instancing_options nolodfade
            #pragma skip_variants FOG_LINEAR FOG_EXP FOG_EXP2
            
            #pragma multi_compile_local __ NOVA_CLIP_RECT NOVA_CLIP_MASK
            #pragma multi_compile_local __ NOVA_FALLBACK_RENDERING
            
            #include "../UIBlock3D.cginc"

            NOVA_DUMMY_INSTANCE_SETUP
            ENDCG
        }
    }
}
