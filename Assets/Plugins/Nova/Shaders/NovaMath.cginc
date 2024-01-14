#ifndef NOVA_MATH_INCLUDED
#define NOVA_MATH_INCLUDED

#define NOVA_EPSILON .0001

#define CSum4(val) (val.x + val.y + val.z + val.w)
#define CMax2(val) max(val.x, val.y)

#define ClampPositive(f) max(f, 0)
#define ClampNegative(f) min(f, 0)

// Prevents division by zero. Assumes denominator is positive
#define SafeDividePositive(n, d) (n / max(d, NOVA_EPSILON))
#define SafeDivideSigned(n, d) (n / (sign(d) * max(abs(d), NOVA_EPSILON)))

// Unity UVs go (0,0) -> (1,1) (depending on d3d or opengl conventions), but it's often more
// convenient for calculations to have (0,0) be in the center. So "Nova" conventions are (0, 0) in the center
// and the extents go to .5
#define ToUnityUV(uv) (0.5 * (uv + 1.0))
#define ToNovaUV(uv) (2 * uv - 1.0)

float GetNFactor(float2 halfSize)
{
    float maxHalfDim = CMax2(halfSize);
    return maxHalfDim > NOVA_EPSILON ? 1.0 / maxHalfDim : 0.0;
}

void PremulColor(inout fixed4 col)
{
    col.rgb *= col.a;
}

void UnPremulColor(inout fixed4 col)
{
    col.rgb /= col.a > 0 ? col.a : 1;
}

#if defined(NOVA_PREMUL_COLORS)
    // Assumes base is premul, tint is not
    fixed4 ApplyColorTint(fixed4 base, fixed4 tint)
    {
        tint.rgb *= tint.a;
        return base * tint;
    }

    fixed4 ApplyClipWeight(fixed4 color, half clipWeight)
    {
        return color * clipWeight;
    }
#else
    fixed4 ApplyColorTint(fixed4 base, fixed4 tint)
    {
        return base * tint;
    }

    fixed4 ApplyClipWeight(fixed4 color, half clipWeight)
    {
        return fixed4(color.rgb, color.a * clipWeight);
    }
#endif

// Takes a 4D vec which represents two 2D vectors and returns their lengths
half2 Length4To2(half4 vec)
{
    half4 vecSq = vec * vec;
    return sqrt(half2(vecSq.x + vecSq.y, vecSq.z + vecSq.w));
}

#if 1 // Distance Calculations

    // Returns the distance from p0 to p1, in quadrant 1 of p0.
    half Q1Distance(half2 p0, half2 p1)
    {
        half2 positionInP0Space = p1 - p0;
        return length(ClampPositive(positionInP0Space));
    }

    half DistanceOutsideCircleEdge(half2 pos, half2 cornerOrigin, half cornerRadius)
    {
        half2 absPos = abs(pos);
        half2 cornerSpace = absPos - cornerOrigin;
        half2 clampedCornerSpace = ClampPositive(cornerSpace);
        half distFromOrigin = length(clampedCornerSpace);
        return distFromOrigin - cornerRadius;
    }

    // Outward is positive, inward is negative
    half DistanceFromCircleEdge(half2 pos, half2 cornerOrigin, half cornerRadius, out half2 clampedCornerSpace)
    {
        half2 absPos = abs(pos);
        half2 cornerSpace = absPos - cornerOrigin;
        clampedCornerSpace = ClampPositive(cornerSpace);
        half distFromOrigin = length(clampedCornerSpace);
        half distanceOutsideBounds = distFromOrigin - cornerRadius;

        // Add in Q3
        cornerSpace = ClampNegative(cornerSpace);
        distanceOutsideBounds += CMax2(cornerSpace);
        return distanceOutsideBounds;
    }

    // Outward is positive, inward is negative
    half2 DistanceFromCircleEdge2(half4 pos, half4 cornerOrigin, half2 cornerRadius, out half4 clampedCornerSpace)
    {
        half4 absPos = abs(pos);
        half4 cornerSpace = absPos - cornerOrigin;
        clampedCornerSpace = ClampPositive(cornerSpace);
        half2 distFromOrigin = Length4To2(clampedCornerSpace);
        half2 distanceOutsideBounds = distFromOrigin - cornerRadius;

        // Add in Q3
        cornerSpace = min(0, cornerSpace);
        distanceOutsideBounds += max(cornerSpace.xz, cornerSpace.yw);
        return distanceOutsideBounds;
    }

    // Outward is positive, inward is negative
    half DistanceFromCircleEdge(half2 pos, half2 cornerOrigin, half cornerRadius)
    {
        half2 clampedCornerSpace;
        return DistanceFromCircleEdge(pos, cornerOrigin, cornerRadius, clampedCornerSpace);
    }

    // Outward is positive, inward is negative
    half2 DistanceFromCircleEdge2(half4 pos, half4 cornerOrigin, half2 cornerRadius)
    {
        half4 clampedCornerSpace;
        return DistanceFromCircleEdge2(pos, cornerOrigin, cornerRadius, clampedCornerSpace);
    }
#endif

// NOTE: This does not account for non uniform scale
// If we had the blockFromRoot matrix, we could account for non-uniform scale via:
// normalize(mul(transpose((float3x3)blockFromRoot), blockNormal));
float3 NovaRootFromBlockNormal(float4x4 rootFromBlock, float3 blockNormal)
{
    return normalize(mul((float3x3)rootFromBlock, blockNormal));
}

float4 NovaBlockToClipPos(float4 blockPos, float4x4 rootFromBlock)
{
    float3 rootPos = mul(rootFromBlock, blockPos).xyz;
    return UnityObjectToClipPos(rootPos);
}

float3 NovaRootToWorldPos(float3 pos)
{
    return mul(unity_ObjectToWorld, float4(pos, 1.0)).xyz;
}

fixed CombineAlphas(fixed bottom, fixed top)
{
    return bottom + top - bottom * top;
}

fixed4 BlendPremul(fixed4 bottom, fixed4 top)
{
    return fixed4(top.rgb + bottom.rgb * (1 - top.a), CombineAlphas(bottom.a, top.a));
}

half2 Rotate2D(half2 unrotated, half s, half c)
{
    half2 toRet = 0;
    toRet.x = unrotated.x * c - unrotated.y * s;
    toRet.y = unrotated.x * s + unrotated.y * c;
    return toRet;
}

#endif