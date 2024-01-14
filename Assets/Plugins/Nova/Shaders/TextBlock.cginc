#ifndef NOVA_TEXTBLOCK
#define NOVA_TEXTBLOCK

#define NOVA_PREMUL_COLORS

#if defined(OUTLINE_ON) || defined(UNDERLAY_INNER)
    #define USES_BIAS_OUT
#endif

#include "Nova.cginc"
#include "UnityUI.cginc"
#include "Generated/TextBlock.g.cginc"
#include "NovaTMPProperties.cginc"

NOVA_DECLARE_BUFFER(PerVertTextData, _NovaData);

v2f NovaVert(uint vertexID : SV_VertexID, uint instanceID : SV_InstanceID)
{
    NovaVertInit(instanceID, v2f, o);

    uint indexIntoIndexBuffer = InstanceIDToDataIndex(instanceID);
    NOVA_GET_BUFFER_ITEM_uint(offsetInstanceID, indexIntoIndexBuffer, _NovaDataIndices);

    uint vertDataIndex = 4u * offsetInstanceID + vertexID;
    NOVA_GET_BUFFER_ITEM_PerVertTextData(textData, vertDataIndex, _NovaData);
    NOVA_GET_BUFFER_ITEM_TransformAndLighting(transformAndLighting, textData.TransformIndex, _NovaTransformsAndLighting);

    float3 blockPos = textData.Position;
    blockPos.x += _VertexOffsetX;
    blockPos.y += _VertexOffsetY;

    float3 rootSpace = mul(transformAndLighting.RootFromBlock, float4(blockPos, 1)).xyz;
    float3 worldPos = NovaRootToWorldPos(rootSpace);
    o.pos = UnityWorldToClipPos(worldPos);

    float2 pixelSize = o.pos.w;
    pixelSize /= float2(_ScaleX, _ScaleY) * abs(mul((float2x2)UNITY_MATRIX_P, _ScreenParams.xy));

    float scale = rsqrt(dot(pixelSize, pixelSize));
    float texCoord1Y = textData.Texcoord1.y * textData.ScaleMultiplier;
    scale *= abs(texCoord1Y) * _GradientScale * (_Sharpness + 1);
    if (UNITY_MATRIX_P[3][3] == 0)
    {
        float lerpFrom = abs(scale) * (1 - _PerspectiveFilter);
        float lerpFactor = abs(dot(UnityObjectToWorldNormal(float3(0, 0, -1)), normalize(UnityWorldSpaceViewDir(worldPos))));
        scale = lerp(lerpFrom, scale, lerpFactor);
    }

    float bold = step(texCoord1Y, 0);
    float weight = lerp(_WeightNormal, _WeightBold, bold) / 4.0;
    weight = (weight + _FaceDilate) * _ScaleRatioA * 0.5;

    float layerScale = scale;
    scale /= 1 + (_OutlineSoftness * _ScaleRatioA * scale);
    float bias = (0.5 - weight) * scale - 0.5;
    float outline = _OutlineWidth * _ScaleRatioA * 0.5 * scale;

    fixed4 color = UnpackColor(textData.Color);
    fixed4 outlineColor = _OutlineColor;

    float opacity = color.a;
    #if (UNDERLAY_ON | UNDERLAY_INNER)
        opacity = 1.0;
    #endif

    fixed4 faceColor = fixed4(color.rgb, opacity) * _FaceColor;
    faceColor.rgb *= faceColor.a;

    outlineColor.a *= opacity;
    outlineColor.rgb *= outlineColor.a;
    outlineColor = lerp(faceColor, outlineColor, sqrt(min(1.0, (outline * 2))));

    #if (UNDERLAY_ON | UNDERLAY_INNER)
        layerScale /= 1 + ((_UnderlaySoftness * _ScaleRatioC) * layerScale);
        float layerBias = (.5 - weight) * layerScale - .5 - ((_UnderlayDilate * _ScaleRatioC) * .5 * layerScale);

        float x = - (_UnderlayOffsetX * _ScaleRatioC) * _GradientScale / _TextureWidth;
        float y = - (_UnderlayOffsetY * _ScaleRatioC) * _GradientScale / _TextureHeight;
        float2 layerOffset = float2(x, y);
    #endif

    SetFaceColor(o, faceColor);
    SetTextureUV(o, textData.Texcoord0.xy);
    SetScaleParam(o, scale);
    SetBiasParam(o, bias);

    #if defined(OUTLINE_ON)
        SetOutlineColor(o, outlineColor);
        float biasIn = bias - outline;
        SetBiasInParam(o, biasIn);
    #endif

    #if defined(OUTLINE_ON) || defined(UNDERLAY_INNER)
        float biasOut = bias + outline;
        SetBiasOutParam(o, biasOut);
    #endif

    #if defined(UNDERLAY_INNER) || defined(UNDERLAY_ON)
        float2 underlayUV = textData.Texcoord0 + layerOffset;
        SetUnderlayUV(o, underlayUV);
        SetUnderlayAlpha(o, color.a);
        SetUnderlayScale(o, layerScale);
        SetUnderlayBias(o, layerBias);
    #endif

    #if defined(NOVA_CLIPPING)
        SetRootPos(o, rootSpace);
    #endif

    #if defined(NOVA_LIT)
        NovaSetLitV2FParams(o, transformAndLighting);
        SetWorldPos(o, worldPos);
        float3 rootNormal = NovaRootFromBlockNormal(transformAndLighting.RootFromBlock, float3(0, 0, -1));
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

    float2 uv = GetTextureUV(i);
    #if NOVA_SUPER_SAMPLE
        float2 dx = ddx(uv) * 0.25; // horizontal offset
        float2 dy = ddy(uv) * 0.25; // vertical offset

        half4 distances = 0;
        distances.x = tex2D(_MainTex, uv + dx + dy).a;
        distances.y = tex2D(_MainTex, uv - dx + dy).a;
        distances.z = tex2D(_MainTex, uv + dx - dy).a;
        distances.w = tex2D(_MainTex, uv - dx - dy).a;
        half d = CSum4(distances) * .25;
    #else
        half d = tex2D(_MainTex, uv).a;
    #endif

    d *= GetScaleParam(i);
    half4 c = GetFaceColor(i) * saturate(d - GetBiasParam(i));

    #ifdef OUTLINE_ON
        c = lerp(GetOutlineColor(i), GetFaceColor(i), saturate(d - GetBiasOutParam(i)));
        c *= saturate(d - GetBiasInParam(i));
    #endif

    #if defined(UNDERLAY_ON) || defined(UNDERLAY_INNER)
        d = tex2D(_MainTex, GetUnderlayUV(i)).a * GetUnderlayScale(i);

        #if UNDERLAY_ON
            c += float4(_UnderlayColor.rgb * _UnderlayColor.a, _UnderlayColor.a) * saturate(d - GetUnderlayBias(i)) * (1 - c.a);
        #else
            half sd = saturate(d - GetBiasOutParam(i));
            c += float4(_UnderlayColor.rgb * _UnderlayColor.a, _UnderlayColor.a) * (1 - saturate(d - GetUnderlayBias(i))) * sd * (1 - c.a);
        #endif

        c *= GetUnderlayAlpha(i);
    #endif

    #if defined(NOVA_CLIP_RECT)
        c = ApplyGlobalColorModification(c);
    #elif defined(NOVA_CLIP_MASK)
        c = ApplyClipMaskAndColorModifiers(c, GetRootPos(i));
    #endif

    #if defined(NOVA_CLIPPING)
        c = ApplyVisualModiferClipping(c, GetRootPos(i));
    #endif

    #if defined(NOVA_LIT)
        #if defined(NOVA_SHADOW_CAST_PASS)
            // Don't assign back to color because the shadow caster pass just returns 0,
            // but we want to clip
            NovaDoLightingCalculations(i, c);
        #else
            c = NovaDoLightingCalculations(i, c);
        #endif
    #endif

    #if UNITY_UI_ALPHACLIP
        clip(c.a - 0.001);
    #endif

    #if defined(NOVA_LIT)
        clip(c.a - NOVA_EPSILON);
    #endif

    return c;
}

#endif