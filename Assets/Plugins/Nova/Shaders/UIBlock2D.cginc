#ifndef NOVA_UIBLOCK_2D
#define NOVA_UIBLOCK_2D

#if defined(NOVA_OUTER_BORDER) || defined(NOVA_INNER_BORDER) || defined(NOVA_CENTER_BORDER)
    #define NOVA_BORDER 1
#endif

#define NOVA_NO_INDEX_BUFFER 1
#define NOVA_PREMUL_COLORS

#include "Nova.cginc"
#include "Generated/UIBlock2D.g.cginc"

NOVA_DECLARE_BUFFER(SubQuadVert, _NovaSubQuadVerts);

#if defined(NOVA_DYNAMIC_IMAGE)
    #define NOVA_IMAGE 1
    sampler2D _NovaDynamicTexture;
    
#elif defined(NOVA_STATIC_IMAGE)
    #define NOVA_IMAGE 1
    UNITY_DECLARE_TEX2DARRAY(_NovaTextureArray);
#endif

NOVA_DECLARE_BUFFER(UIBlock2DData, _NovaData);

// In order to avoid matrix mul, we just transform the axes using the matrices in several steps
float2 GetBlockFromViewScale(float4x4 rootFromBlock)
{
    float3 blockSpaceX = mul(rootFromBlock, float4(1, 0, 0, 1)).xyz;
    float3 blockSpaceY = mul(rootFromBlock, float4(0, 1, 0, 1)).xyz;
    float3 blockSpaceRoot = rootFromBlock._m03_m13_m23;

    float3 viewSpaceRoot = UnityObjectToViewPos(blockSpaceRoot);

    float2 scale;
    scale.x = length(UnityObjectToViewPos(blockSpaceX) - viewSpaceRoot);
    scale.y = length(UnityObjectToViewPos(blockSpaceY) - viewSpaceRoot);
    return abs(scale) > NOVA_EPSILON ? 1.0 / scale : 0;
}

v2f NovaVert(NovaQuadVert v, uint instanceID : SV_InstanceID, uint vid : SV_VERTEXID)
{
    NovaVertInit(instanceID, v2f, o);

    uint vertIndex = InstanceIDToVertIndex(instanceID, vid, 4u);

    NOVA_GET_BUFFER_ITEM_SubQuadVert(vert, vertIndex, _NovaSubQuadVerts);
    NOVA_GET_BUFFER_ITEM_UIBlock2DData(shaderData, vert.BlockDataIndex, _NovaData);

    NOVA_GET_BUFFER_ITEM_TransformAndLighting(transformAndLighting, shaderData.TransformIndex, _NovaTransformsAndLighting);

    float2 blockPos = vert.Pos;

    float3 rootSpace = mul(transformAndLighting.RootFromBlock, float4(blockPos, 0, 1)).xyz;
    float2 halfBlockSize = .5 * shaderData.QuadSize;

    // Bump up the size so we have space to soften the edges
    float3 viewSpaceVertPos = UnityObjectToViewPos(rootSpace);
    float minScreenDimension = min(_ScreenParams.x, _ScreenParams.y);
    float sizeIncreaseAmount = 1.5 * _NovaEdgeSoftenWidth * abs(viewSpaceVertPos.z) / minScreenDimension;

    float2 borderedHalfSize = halfBlockSize;
    #if defined(NOVA_OUTER_BORDER)
        borderedHalfSize += shaderData.BorderWidth;
    #elif defined(NOVA_CENTER_BORDER)
        borderedHalfSize += .5 * shaderData.BorderWidth;
    #endif
    
    float2 epsilon = .001 * borderedHalfSize;
    float2 sizeIncreaseMask = step(abs(borderedHalfSize - abs(blockPos)), epsilon);
    sizeIncreaseMask *= vert.EdgeSoftenMask;
    float2 scale = GetBlockFromViewScale(transformAndLighting.RootFromBlock);
    blockPos += sign(blockPos) * sizeIncreaseMask * sizeIncreaseAmount * scale;
    rootSpace = mul(transformAndLighting.RootFromBlock, float4(blockPos, 0, 1)).xyz;

    float nFactor = GetNFactor(halfBlockSize);
    float2 nHalfSize = halfBlockSize * nFactor;

    float2 nPos = blockPos * nFactor;
    SetNPos(o, nPos);

    float nCornerRadius = shaderData.CornerRadius * nFactor;
    SetNCornerRadius(o, nCornerRadius);
    float2 nCornerOrigin = nHalfSize - nCornerRadius;
    SetNCornerOrigin(o, nCornerOrigin);


    float3 worldPos = NovaRootToWorldPos(rootSpace);
    o.pos = UnityWorldToClipPos(worldPos);
    
    SetEdgeSoftenDisabled(o, 1.0 - vert.EdgeSoftenMask);

    NovaColorToV2F(Color, o, shaderData.PrimaryColor);
    NovaColorToV2F(GradientColor, o, shaderData.GradientColor);

    float2 unrotatedGradientSpacePos = blockPos - shaderData.GradientCenter;
    float2 gradientSpacePos = 0;
    gradientSpacePos.x = unrotatedGradientSpacePos.x * shaderData.GradientRotationSinCos.y + unrotatedGradientSpacePos.y * shaderData.GradientRotationSinCos.x;
    gradientSpacePos.y = unrotatedGradientSpacePos.x * shaderData.GradientRotationSinCos.x - unrotatedGradientSpacePos.y * shaderData.GradientRotationSinCos.y;
    float2 gradientUV = gradientSpacePos * shaderData.GradientSizeReciprocal;
    SetGradientSpaceUV(o, gradientUV);

    #if defined(NOVA_RADIAL_FILL)
        float2 sinCos;
        float2 radialFillSpacePos = RadialFillVert(nPos, shaderData.RadialFillCenter, shaderData.RadialFillRotation, shaderData.RadialFillAngle, nFactor, sinCos);
        SetRadialFillSpacePos(o, radialFillSpacePos);
        SetRadialFillSinCos(o, sinCos);
    #endif
    
    #if defined(NOVA_IMAGE)
        float2 uv = SafeDividePositive(blockPos, halfBlockSize);
        float2 imageUV = uv * vert.UVZoom + vert.CenterUV;
        SetImageUV(o, imageUV);
    #endif

    #if defined(NOVA_CLIPPING)
        SetRootPos(o, rootSpace);
    #endif

    #if defined(NOVA_STATIC_IMAGE)
        float packSlice = (float)shaderData.TexturePackSlice;
        SetTextureBufferIndex(o, packSlice);
    #endif

    #if defined(NOVA_BORDER)
        NovaColorToV2F(BorderColor, o, shaderData.BorderColor);
        float borderNWidth = shaderData.BorderWidth * nFactor;
        #if defined(NOVA_CENTER_BORDER)
            // Store half width to avoid doing it in frag
            float halfBorderNWidth = .5 * borderNWidth;
            SetBorderNWidth(o, halfBorderNWidth);
        #else
            SetBorderNWidth(o, borderNWidth);
        #endif
    #endif

    #if defined(NOVA_INNER_SHADOW)
        NovaColorToV2F(ShadowColor, o, shaderData.ShadowColor);
        float2 nShadowOffset = shaderData.ShadowOffset * nFactor;
        float2 nShadowSpacePos = nPos - nShadowOffset;
        SetNShadowSpacePos(o, nShadowSpacePos);

        float shadowRadius = max(shaderData.ShadowBlur, shaderData.CornerRadius - shaderData.ShadowWidth);
        float nShadowRadius = shadowRadius * nFactor;
        SetNShadowRadius(o, nShadowRadius);
        float nShadowBlur = shaderData.ShadowBlur * nFactor;
        SetNShadowBlur(o, nShadowBlur);

        float nShadowWidth = shaderData.ShadowWidth * nFactor;
        float2 nShadowOrigin = ClampPositive(nHalfSize - nShadowWidth - nShadowRadius);
        SetNShadowOrigin(o, nShadowOrigin);
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

    half2 gradientSpaceUV = GetGradientSpaceUV(i);
    half gradientLerpVal = length(gradientSpaceUV);
    fixed4 color = lerp(GetGradientColor(i), GetColor(i), min(1.0, gradientLerpVal));

    #if defined(NOVA_DYNAMIC_IMAGE)
        fixed4 texColor = tex2D(_NovaDynamicTexture, ToUnityUV(GetImageUV(i)));
        color = ApplyColorTint(color, texColor);

    #elif defined(NOVA_STATIC_IMAGE)
        fixed4 texColor = UNITY_SAMPLE_TEX2DARRAY(_NovaTextureArray, float3(ToUnityUV(GetImageUV(i)), GetTextureBufferIndex(i)));
        color = ApplyColorTint(color, texColor);
    #endif

    half2 clampedCornerSpace;
    half distanceOutsideBounds = DistanceFromCircleEdge(GetNPos(i), GetNCornerOrigin(i), GetNCornerRadius(i), clampedCornerSpace);
    half softenWidth = GetSoftenWidth(GetNPos(i));
    half softenInverse = 1.0 / softenWidth;
    half clipWeight = GetClipWeight10(distanceOutsideBounds, softenInverse);

    #if defined(NOVA_INNER_SHADOW)
        half distFromShadowOrigin = Q1Distance(GetNShadowOrigin(i), abs(GetNShadowSpacePos(i)));
        half distFromShadowEdge = distFromShadowOrigin - GetNShadowRadius(i);

        // This is mathematically equivalent to smoothstep(-GetShadowBlur(i), GetShadowBlur(i), distanceFromShadowEdge)
        half t = saturate((.5 * distFromShadowEdge) / GetNShadowBlur(i) + .5);
        half shadowWeight = t * t * (3.0 - 2.0 * t);

        fixed4 shadowColor = GetShadowColor(i);
        shadowColor *= shadowWeight;
        color = BlendPremul(color, shadowColor);
    #endif

    #if NOVA_BORDER
        // Need to correct the weight for when the border is very thin or has zero width
        fixed4 borderColor = lerp(color, GetBorderColor(i), saturate(GetBorderNWidth(i) * softenInverse.x));
    #endif

    #if defined(NOVA_OUTER_BORDER)
        // We want the border to have a sharp corner when the body does
        half distanceOutsideBorder = GetNCornerRadius(i) < NOVA_EPSILON ? CMax2(clampedCornerSpace) : distanceOutsideBounds.x;
        distanceOutsideBorder -= GetBorderNWidth(i);

        // x => borderSoften
        // y => body to border transition weight
        half2 borderWeights = GetClipWeight10(half2(distanceOutsideBorder, distanceOutsideBounds.x), softenInverse.xx);

        // Transition to border color
        color = lerp(borderColor, color, borderWeights.y);
        // Replace clipweight with outer edge clip
        clipWeight = borderWeights.x;

    #elif defined(NOVA_CENTER_BORDER)
        // Apply the clip weight to the body, since the border may be transparent
        color = ApplyClipWeight(color, clipWeight);

        // We want the border to have a sharp corner when the body does
        // x => inner edge
        // y => outer edge
        half2 dists = half2(distanceOutsideBounds.x, GetNCornerRadius(i) < NOVA_EPSILON ? CMax2(clampedCornerSpace) : distanceOutsideBounds.x);
        // For center borders, we actually store half width
        half2 distancesOutsideBorderEdges = dists + half2(GetBorderNWidth(i), -GetBorderNWidth(i));
        half2 borderWeights = GetClipWeight01(distancesOutsideBorderEdges, softenInverse.x);
        borderWeights.y = 1.0 - borderWeights.y;

        borderColor *= borderWeights.x;
        color = BlendPremul(color, borderColor);
        clipWeight = borderWeights.y;

    #elif defined(NOVA_INNER_BORDER)
        half distanceOutsideInnerBorderEdge = distanceOutsideBounds.x + GetBorderNWidth(i);
        half borderWeight = GetClipWeight01(distanceOutsideInnerBorderEdge, softenInverse.x);
        fixed4 blended = BlendPremul(color, borderColor);
        color = lerp(color, blended, borderWeight);
    #endif

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
    color = ApplyClipWeight(color, clipWeight);

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