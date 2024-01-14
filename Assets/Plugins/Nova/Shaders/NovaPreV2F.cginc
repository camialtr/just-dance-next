#ifndef NOVA_PRE_V2F_INCLUDED
#define NOVA_PRE_V2F_INCLUDED

#if defined(NOVA_LAMBERT_LIGHTING) || defined(NOVA_BLINNPHONG_LIGHTING) || defined(NOVA_STANDARD_LIGHTING) || defined(NOVA_STANDARDSPECULAR_LIGHTING)
    #define NOVA_LIT
#endif

#if defined(NOVA_FORWARD_ADD_PASS) || defined(NOVA_FORWARD_BASE_PASS)
    #define NOVA_FORWARD_PASS
#endif

#define POST_NOVA_TEX(idx) TEXCOORD##idx;

#if defined(NOVA_FORWARD_BASE_PASS)
    #ifdef LIGHTMAP_ON
        #ifdef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
            #if defined(NOVA_ALPHA)
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    DECLARE_LIGHT_COORDS(POST_NOVA_1)
            #else
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    UNITY_LIGHTING_COORDS(POST_NOVA_1, POST_NOVA_2)
            #endif

        #else
            #ifdef DIRLIGHTMAP_COMBINED
                #define NOVA_TSPACE_V2F(a, b, c) \
                    float3 tSpace0 : POST_NOVA_TEX(a) \
                    float3 tSpace1 : POST_NOVA_TEX(b) \
                    float3 tSpace2 : POST_NOVA_TEX(c)
            #else
                #define NOVA_TSPACE_V2F(a, b, c)
            #endif

            #if defined(NOVA_ALPHA)
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    DECLARE_LIGHT_COORDS(POST_NOVA_1) \
                    NOVA_TSPACE_V2F(POST_NOVA_2, POST_NOVA_3, POST_NOVA_4)
            #else
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    UNITY_SHADOW_COORDS(POST_NOVA_1) \
                    NOVA_TSPACE_V2F(POST_NOVA_2, POST_NOVA_3, POST_NOVA_4)
            #endif
        #endif
    #else
        #if UNITY_SHOULD_SAMPLE_SH
            #define NOVA_SH_V2F(a) half3 sh : POST_NOVA_TEX(a)
        #else
            #define NOVA_SH_V2F(a)
        #endif

        #if defined(NOVA_ALPHA)
            #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    DECLARE_LIGHT_COORDS(POST_NOVA_1) \
                    NOVA_SH_V2F(POST_NOVA_2)
        #else
            #ifdef UNITY_HALF_PRECISION_FRAGMENT_SHADER_REGISTERS
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    UNITY_LIGHTING_COORDS(POST_NOVA_1, POST_NOVA_2) \
                    NOVA_SH_V2F(POST_NOVA_3)
            #else
                #define NOVA_LIT_PASS_V2F_END \
                    float4 lmap : POST_NOVA_TEX(POST_NOVA_0) \
                    UNITY_SHADOW_COORDS(POST_NOVA_1) \
                    NOVA_SH_V2F(POST_NOVA_2)
            #endif
        #endif
    #endif

#elif defined(NOVA_FORWARD_ADD_PASS)
    #ifndef NOVA_ALPHA
        #define NOVA_LIT_PASS_V2F_END UNITY_LIGHTING_COORDS(POST_NOVA_0, POST_NOVA_1)
    #else
        #define NOVA_LIT_PASS_V2F_END DECLARE_LIGHT_COORDS(POST_NOVA_0)
    #endif

#elif defined(NOVA_SHADOW_CAST_PASS)
    #define NOVA_LIT_PASS_V2F_END
#elif defined(NOVA_LIT)
    #if defined(EDITOR_VISUALIZATION)
        #define NOVA_LIT_PASS_V2F_END \
            float3 tSpace0 : POST_NOVA_TEX(POST_NOVA_0) \
            float3 tSpace1 : POST_NOVA_TEX(POST_NOVA_1) \
            float3 tSpace2 : POST_NOVA_TEX(POST_NOVA_2) \
            float2 vizUV : POST_NOVA_TEX(POST_NOVA_3) \
            float4 lightCoord : POST_NOVA_TEX(POST_NOVA_4)
    #else
        #define NOVA_LIT_PASS_V2F_END \
            float3 tSpace0 : POST_NOVA_TEX(POST_NOVA_0) \
            float3 tSpace1 : POST_NOVA_TEX(POST_NOVA_1) \
            float3 tSpace2 : POST_NOVA_TEX(POST_NOVA_2)
    #endif
#endif

#if defined(NOVA_LIT)
    #define NOVA_LIT_V2F_END \
        NOVA_LIT_PASS_V2F_END \
        UNITY_VERTEX_OUTPUT_STEREO
#else
    #define NOVA_LIT_V2F_END UNITY_VERTEX_OUTPUT_STEREO
#endif

#if 1 ////////////////////////// LIGHTING MODELS ///////////////////////////////
    #if defined(NOVA_LAMBERT_LIGHTING)
        #define SurfaceOutputType SurfaceOutput

        #define NovaSetLitV2FParams(o, transformAndLighting)

        #define NovaSetSurfParams(surf, color, v2f) \
            NovaSurfSetAlbedo(surf, color);

    #elif defined(NOVA_BLINNPHONG_LIGHTING)
        #define SurfaceOutputType SurfaceOutput

        #define NovaSetLitV2FParams(o, transformAndLighting) \
            SetSpecular(o, transformAndLighting.Lighting.Specular); \
            SetGloss(o, transformAndLighting.Lighting.Gloss)

        #define NovaSetSurfParams(surf, color, v2f) \
            NovaSurfSetAlbedo(surf, color); \
            surf.Specular = GetSpecular(v2f); \
            surf.Gloss = GetGloss(v2f); \
            _SpecColor = 1;

    #elif defined(NOVA_STANDARD_LIGHTING)
        #define SurfaceOutputType SurfaceOutputStandard

        #define NovaSetLitV2FParams(o, transformAndLighting) \
            SetSmoothness(o, transformAndLighting.Lighting.Smoothness); \
            SetMetallic(o, transformAndLighting.Lighting.Metallic)

        #define NovaSetSurfParams(surf, color, v2f) \
            NovaSurfSetAlbedo(surf, color); \
            surf.Metallic = GetMetallic(i); \
            surf.Smoothness = GetSmoothness(i);

    #elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
        #define SurfaceOutputType SurfaceOutputStandardSpecular

        #define NovaSetLitV2FParams(o, transformAndLighting) \
            SetSpecularColor(o, UnpackColor(transformAndLighting.Lighting.SpecularColor)); \
            SetSmoothness(o, transformAndLighting.Lighting.Smoothness)

        #define NovaSetSurfParams(surf, color, v2f) \
            NovaSurfSetAlbedo(surf, color); \
            surf.Specular = GetSpecularColor(i); \
            surf.Smoothness = GetSmoothness(i);

    #endif
#endif

#if defined(NOVA_LIT)
    SurfaceOutputType NovaInitSurfType(fixed3 normalWorldVertex)
    {
        #ifdef UNITY_COMPILER_HLSL
            SurfaceOutputType o = (SurfaceOutputType)0;
        #else
            SurfaceOutputType o;
        #endif
        o.Albedo = 0.0;
        o.Emission = 0.0;
        o.Alpha = 0.0;
        o.Normal = normalWorldVertex;
        #if !defined(NOVA_STANDARD_LIGHTING)
            o.Specular = 0.0;
        #endif
        #if defined(NOVA_STANDARD_LIGHTING) || defined(NOVA_STANDARDSPECULAR_LIGHTING)
            o.Occlusion = 1.0;
        #else
            o.Gloss = 0.0;
        #endif
        return o;
    }

    #ifdef NOVA_ALPHA
        #define NovaSurfSetAlbedo(o, color) \
        o.Albedo = color; \
        o.Alpha = color.a
    #else
        #define NovaSurfSetAlbedo(o, color) \
        o.Albedo = color; \
        o.Alpha = 1;
    #endif
#endif


#endif