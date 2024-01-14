#ifndef NOVA_POST_V2F_INCLUDED
#define NOVA_POST_V2F_INCLUDED

////////////////////////// UNITY LIGHTING LOGIC //////////////////////////////
void NovaDoLitVert(inout v2f o, float3 worldPos, float3 worldNormal, appdata_full v)
{
    #if defined(NOVA_FORWARD_BASE_PASS)
        // TODO: lmap
        o.lmap = 0;
        

        #if !defined(LIGHTMAP_ON) && UNITY_SHOULD_SAMPLE_SH && !UNITY_SAMPLE_FULL_SH_PER_PIXEL
            o.sh = 0;
            #ifdef VERTEXLIGHT_ON
                o.sh += Shade4PointLights(
                    unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
                    unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
                    unity_4LightAtten0, worldPos, worldNormal);
            #endif
            o.sh = ShadeSHPerVertex(worldNormal, o.sh);
        #endif

        #if defined(NOVA_ALPHA)
            COMPUTE_LIGHT_COORDS(o);
        #else
            // TODO:
            UNITY_TRANSFER_LIGHTING(o, 0);
        #endif

    #elif defined(NOVA_FORWARD_ADD_PASS)
        #if defined(NOVA_ALPHA)
            COMPUTE_LIGHT_COORDS(o);
        #else
            // TODO:
            UNITY_TRANSFER_LIGHTING(o, 0);
        #endif
        
    #elif defined(NOVA_SHADOW_CAST_PASS)
        TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)

    #elif defined(UNITY_PASS_META)
        o.pos = UnityMetaVertexPosition(v.vertex, v.texcoord1.xy, v.texcoord2.xy, unity_LightmapST, unity_DynamicLightmapST);
        #ifdef EDITOR_VISUALIZATION
            o.vizUV = 0;
            o.lightCoord = 0;
            if (unity_VisualizationMode == EDITORVIZ_TEXTURE)
                o.vizUV = UnityMetaVizUV(unity_EditorViz_UVIndex, v.texcoord.xy, v.texcoord1.xy, v.texcoord2.xy, unity_EditorViz_Texture_ST);
            else if (unity_VisualizationMode == EDITORVIZ_SHOWLIGHTMASK)
            {
                o.vizUV = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                o.lightCoord = mul(unity_EditorViz_WorldToLight, mul(unity_ObjectToWorld, float4(v.vertex.xyz, 1)));
            }
        #endif
    #endif
}

#if defined(NOVA_LIT)
    fixed4 NovaDoLightingCalculations(v2f i, fixed4 color)
    {
        #if defined(NOVA_PREMUL_COLORS)
            // The lighting functions expect the color to not be premultiplied
            UnPremulColor(color);
        #endif

        float3 worldPos = GetWorldPos(i);
        half3 worldNormal = normalize(GetWorldNormal(i));
        SurfaceOutputType surf = NovaInitSurfType(worldNormal);
        NovaSetSurfParams(surf, color, i);

        #if defined(NOVA_FORWARD_BASE_PASS)
            UNITY_LIGHT_ATTENUATION(atten, i, worldPos)

            #ifndef USING_DIRECTIONAL_LIGHT
                fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
            #else
                fixed3 lightDir = _WorldSpaceLightPos0.xyz;
            #endif
            
            // Setup lighting environment
            UnityGI gi;
            UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
            gi.indirect.diffuse = 0;
            gi.indirect.specular = 0;
            gi.light.color = _LightColor0.rgb;
            gi.light.dir = lightDir;
            
            // Call GI (lightmaps/SH/reflections) lighting function
            UnityGIInput giInput;
            UNITY_INITIALIZE_OUTPUT(UnityGIInput, giInput);
            giInput.light = gi.light;
            giInput.worldPos = worldPos;

            #if !defined(NOVA_LAMBERT_LIGHTING)
                float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
                giInput.worldViewDir = worldViewDir;
            #endif

            giInput.atten = atten;
            giInput.lightmapUV = 0.0;

            #if UNITY_SHOULD_SAMPLE_SH && !UNITY_SAMPLE_FULL_SH_PER_PIXEL
                giInput.ambient = i.sh;
            #else
                giInput.ambient.rgb = 0.0;
            #endif

            giInput.probeHDR[0] = unity_SpecCube0_HDR;
            giInput.probeHDR[1] = unity_SpecCube1_HDR;
            #if defined(UNITY_SPECCUBE_BLENDING) || defined(UNITY_SPECCUBE_BOX_PROJECTION)
                giInput.boxMin[0] = unity_SpecCube0_BoxMin; // .w holds lerp value for blending
            #endif
            #ifdef UNITY_SPECCUBE_BOX_PROJECTION
                giInput.boxMax[0] = unity_SpecCube0_BoxMax;
                giInput.probePosition[0] = unity_SpecCube0_ProbePosition;
                giInput.boxMax[1] = unity_SpecCube1_BoxMax;
                giInput.boxMin[1] = unity_SpecCube1_BoxMin;
                giInput.probePosition[1] = unity_SpecCube1_ProbePosition;
            #endif

            fixed4 c = 0;
            #if defined(NOVA_LAMBERT_LIGHTING)
                LightingLambert_GI(surf, giInput, gi);

                // realtime lighting: call lighting function
                c += LightingLambert(surf, gi);
            #elif defined(NOVA_BLINNPHONG_LIGHTING)
                LightingBlinnPhong_GI(surf, giInput, gi);
                c += LightingBlinnPhong(surf, worldViewDir, gi);

            #elif defined(NOVA_STANDARD_LIGHTING)
                LightingStandard_GI(surf, giInput, gi);
                c += LightingStandard(surf, worldViewDir, gi);

            #elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
                LightingStandardSpecular_GI(surf, giInput, gi);
                c += LightingStandardSpecular(surf, worldViewDir, gi);

            #endif

            #if defined(NOVA_ALPHA)
                #if defined(NOVA_PREMUL_COLORS)
                    PremulColor(c);
                #endif
            #else
                UNITY_OPAQUE_ALPHA(c.a);
            #endif
            return c;

        #elif defined(NOVA_FORWARD_ADD_PASS)
            UNITY_LIGHT_ATTENUATION(atten, i, worldPos)

            #ifndef USING_DIRECTIONAL_LIGHT
                fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
            #else
                fixed3 lightDir = _WorldSpaceLightPos0.xyz;
            #endif

            // Setup lighting environment
            UnityGI gi;
            UNITY_INITIALIZE_OUTPUT(UnityGI, gi);
            gi.indirect.diffuse = 0;
            gi.indirect.specular = 0;
            gi.light.color = _LightColor0.rgb;
            gi.light.dir = lightDir;
            gi.light.color *= atten;
            #if !defined(NOVA_LAMBERT_LIGHTING)
                float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldPos));
            #endif

            fixed4 c = 0;
            #if defined(NOVA_LAMBERT_LIGHTING)
                c += LightingLambert(surf, gi);
            #elif defined(NOVA_BLINNPHONG_LIGHTING)
                c += LightingBlinnPhong(surf, worldViewDir, gi);
            #elif defined(NOVA_STANDARD_LIGHTING)
                c += LightingStandard(surf, worldViewDir, gi);
            #elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
                c += LightingStandardSpecular(surf, worldViewDir, gi);
            #endif

            #if defined(NOVA_ALPHA)
                #if defined(NOVA_PREMUL_COLORS)
                    PremulColor(c);
                #endif
            #else
                UNITY_OPAQUE_ALPHA(c.a);
            #endif
            return c;

        #elif defined(NOVA_SHADOW_CAST_PASS)
            #ifndef USING_DIRECTIONAL_LIGHT
                fixed3 lightDir = normalize(UnityWorldSpaceLightDir(worldPos));
            #else
                fixed3 lightDir = _WorldSpaceLightPos0.xyz;
            #endif

            SHADOW_CASTER_FRAGMENT(i)

        #elif defined(UNITY_PASS_META)
            UnityMetaInput metaIN;
            UNITY_INITIALIZE_OUTPUT(UnityMetaInput, metaIN);
            metaIN.Albedo = surf.Albedo;
            metaIN.Emission = surf.Emission;
            #if !defined(NOVA_STANDARD_LIGHTING)
                metaIN.SpecularColor = surf.Specular;
            #endif
            #ifdef EDITOR_VISUALIZATION
                metaIN.VizUV = i.vizUV;
                metaIN.LightCoord = i.lightCoord;
            #endif
            return UnityMetaFragment(metaIN);
        #endif
    }
#endif
#endif