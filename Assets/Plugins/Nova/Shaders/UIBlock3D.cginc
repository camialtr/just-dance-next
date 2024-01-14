#ifndef NOVA_UIBLOCK_3D
#define NOVA_UIBLOCK_3D

#include "Nova.cginc"
#include "Generated/UIBlock3D.g.cginc"

NOVA_DECLARE_BUFFER(UIBlock3DData, _NovaData);

v2f NovaVert(UIBlock3DVert v, uint instanceID : SV_InstanceID)
{
    NovaVertInit(instanceID, v2f, o);

    uint indexIntoIndexBuffer = InstanceIDToDataIndex(instanceID);
    NOVA_GET_BUFFER_ITEM_uint(index, indexIntoIndexBuffer, _NovaDataIndices);
    NOVA_GET_BUFFER_ITEM_UIBlock3DData(shaderData, index, _NovaData);

    float3 vertNodePos = v.Pos * shaderData.Size + v.CornerOffsetDir * shaderData.CornerRadius + v.EdgeOffsetDir * shaderData.EdgeRadius;

    NOVA_GET_BUFFER_ITEM_TransformAndLighting(transformAndLighting, shaderData.TransformIndex, _NovaTransformsAndLighting);
    float3 rootSpace = mul(transformAndLighting.RootFromBlock, float4(vertNodePos, 1)).xyz;
    float3 worldPos = NovaRootToWorldPos(rootSpace);
    o.pos = UnityWorldToClipPos(worldPos);

    #if defined(NOVA_CLIPPING)
        SetRootPos(o, rootSpace);
    #endif

    NovaColorToV2F(Color, o, shaderData.Color);

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

    fixed4 color = GetColor(i);

    #if defined(NOVA_CLIPPING)
        half clipWeight = GetTotalVisualModifierClipping(GetRootPos(i));
        // NOTE: We don't soften here, just clip
        clip(clipWeight - 1.0);
    #endif
    
    #if defined(NOVA_CLIP_RECT)
        color = ApplyGlobalColorModification(color);
    #elif defined(NOVA_CLIP_MASK)
        color = ApplyClipMaskAndColorModifiers(color, GetRootPos(i));
    #endif

    #if defined(NOVA_LIT)
        color = NovaDoLightingCalculations(i, color);
    #endif

    return color;
}

#endif