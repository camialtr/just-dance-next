#ifndef NOVA_DROPSHADOW_INCLUDED
#define NOVA_DROPSHADOW_INCLUDED

#include "Nova.cginc"
#include "Generated/DropShadow.g.cginc"

NOVA_DECLARE_BUFFER(PerQuadDropShadowShaderData, _NovaData);
NOVA_DECLARE_BUFFER(PerInstanceDropShadowShaderData, _NovaPerBlockData);

v2f NovaVert(NovaQuadVert v, uint instanceID : SV_InstanceID)
{
    NovaVertInit(instanceID, v2f, o);

    uint indexIntoIndexBuffer = InstanceIDToDataIndex(instanceID);
    NOVA_GET_BUFFER_ITEM_uint(perQuadDataIndex, indexIntoIndexBuffer, _NovaDataIndices);
    NOVA_GET_BUFFER_ITEM_PerQuadDropShadowShaderData(perQuadData, perQuadDataIndex, _NovaData);
    
    uint perBlockDataIndex = perQuadDataIndex / 8;
    NOVA_GET_BUFFER_ITEM_PerInstanceDropShadowShaderData(perBlockData, perBlockDataIndex, _NovaPerBlockData);
    NOVA_GET_BUFFER_ITEM_TransformAndLighting(transformAndLighting, perBlockData.TransformIndex, _NovaTransformsAndLighting);

    float2 blockPos = perQuadData.PositionInNode + perQuadData.QuadSize * v.Pos;
    float3 rootSpace = mul(transformAndLighting.RootFromBlock, float4(blockPos, 0, 1)).xyz;
    float3 worldPos = NovaRootToWorldPos(rootSpace);
    o.pos = UnityWorldToClipPos(worldPos);

    #if defined(NOVA_CLIPPING)
        SetRootPos(o, rootSpace);
    #endif
    
    NovaColorToV2F(Color, o, perBlockData.Color);

    float2 bodyCircleCenter = perBlockData.HalfBlockQuadSize - perBlockData.BlockClipRadius;
    half clipRadiusSign = sign(perBlockData.BlockClipRadius);
    float2 shadowCircleCenter = perBlockData.HalfBlockQuadSize + (1 - clipRadiusSign) * perBlockData.Width - perBlockData.BlockClipRadius;
    float shadowRadius = clipRadiusSign * (perBlockData.BlockClipRadius + perBlockData.Width);
    float blurToAdd = smoothstep(perBlockData.Blur, 0, shadowRadius) * perBlockData.Blur;
    shadowRadius += blurToAdd;
    shadowCircleCenter -= blurToAdd;

    float nFactor = GetNFactor(perBlockData.HalfBlockQuadSize);

    // Positions
    float2 nBlockPos = blockPos * nFactor;
    SetNBlockPos(o, nBlockPos);
    float2 shadowPos = blockPos - perBlockData.Offset;
    float2 nShadowPos = shadowPos * nFactor;
    SetNShadowPos(o, nShadowPos);

    // Radii
    float nBlockRadius = perBlockData.BlockClipRadius * nFactor;
    SetNBlockRadius(o, nBlockRadius);
    float nShadowRadius = shadowRadius * nFactor;
    SetNShadowRadius(o, nShadowRadius);

    // Origins
    float2 nCornerOrigin = bodyCircleCenter * nFactor;
    SetNBlockOrigin(o, nCornerOrigin);
    float2 nShadowOrigin = shadowCircleCenter * nFactor;
    SetNShadowOrigin(o, nShadowOrigin);

    float nShadowBlur = perBlockData.Blur * nFactor;
    SetNShadowBlur(o, nShadowBlur);

    SetEdgeSoftenDisabled(o, 1.0 - perBlockData.EdgeSoftenMask);

    #if defined(NOVA_RADIAL_FILL)
        float2 sinCos;
        float2 radialFillSpacePos = RadialFillVert(nBlockPos, perBlockData.RadialFillCenter, perBlockData.RadialFillRotation, perBlockData.RadialFillAngle, nFactor, sinCos);
        SetRadialFillSpacePos(o, radialFillSpacePos);
        SetRadialFillSinCos(o, sinCos);
    #endif

    #if defined(NOVA_LIT)
        NovaSetLitV2FParams(o, transformAndLighting);
        SetWorldPos(o, worldPos);
        float3 rootNormal = NovaRootFromBlockNormal(transformAndLighting.RootFromBlock, v.Normal);
        float3 worldNormal = UnityObjectToWorldNormal(rootNormal);
        SetWorldNormal(o, worldNormal);

        NovaInitInstance(appdata_full, appdata);
        appdata.vertex = float4(rootSpace, 1);
        appdata.normal = rootNormal;
        NovaDoLitVert(o, worldPos, worldNormal, appdata);
    #endif

    return o;
}

fixed4 NovaFrag(v2f i) : SV_Target
{
    NovaFragInit(i);

    half4 positions = half4(GetNBlockPos(i), GetNShadowPos(i));
    half4 origins = half4(GetNBlockOrigin(i), GetNShadowOrigin(i));
    half2 radii = half2(GetNBlockRadius(i), GetNShadowRadius(i));
    half2 distancesOutside = DistanceFromCircleEdge2(positions, origins, radii);

    half softenWidth = GetSoftenWidth(positions.xy);
    half softenInverse = 1.0 / softenWidth;
    half clipWeight = GetClipWeight10(distancesOutside.x, softenInverse);

    fixed4 color = GetColor(i);

    half gradientLerpVal = smoothstep(-GetNShadowBlur(i), GetNShadowBlur(i), distancesOutside.y);
    color = lerp(color, fixed4(color.xyz, 0), gradientLerpVal);

    #if defined(NOVA_CLIP_RECT)
        color = ApplyGlobalColorModification(color);
    #elif defined(NOVA_CLIP_MASK)
        color = ApplyClipMaskAndColorModifiers(color, GetRootPos(i));
    #endif

    #if defined(NOVA_LIT)
        #if defined(NOVA_SHADOW_CAST_PASS)
            // Don't assign back to color because the shadow caster pass just returns 0,
            // but we want to clip
            NovaDoLightingCalculations(i, color);
        #else
            color = NovaDoLightingCalculations(i, color);
        #endif
    #endif

    clipWeight *= step(GetEdgeSoftenDisabled(i), clipWeight);
    
    // Flip clip weight
    color = ApplyClipWeight(color, -clipWeight + 1.0);

    #if defined(NOVA_RADIAL_FILL)
        float radialFillClipWeight = GetRadialFillClipWeight(GetRadialFillSpacePos(i), GetRadialFillSinCos(i), softenWidth.x, softenInverse.x);
        color = ApplyClipWeight(color, radialFillClipWeight);
    #endif

    #if defined(NOVA_CLIPPING)
        color = ApplyVisualModiferClipping(color, GetRootPos(i));
    #endif

    #if defined(NOVA_LIT)
        clip(color.a - NOVA_EPSILON);
    #endif

    return color;
}

#endif