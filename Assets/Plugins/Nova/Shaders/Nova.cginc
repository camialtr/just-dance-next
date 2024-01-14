#ifndef NOVA_INCLUDED
#define NOVA_INCLUDED
#include "UnityCG.cginc"
#include "NovaMath.cginc"
#include "NovaDataStructures.cginc"

#if defined(_ALPHABLEND_ON) || defined(_ALPHAPREMULTIPLY_ON)
    #define NOVA_ALPHA
#endif

// Creates an instance of the specified type with the specified name
#define NovaInitInstance(type, var) \
    type var; \
    UNITY_INITIALIZE_OUTPUT(type, var);



#if 1 //////////////////////// TRANSFORMS ///////////////////////////////////

    NOVA_DECLARE_BUFFER(TransformAndLighting, _NovaTransformsAndLighting);
    float4x4 _NovaWorldFromLocal;
    float4x4 _NovaLocalFromWorld;

    // Need to do this for the various unity macros to work
    void UpdateMatrices()
    {
        unity_ObjectToWorld = _NovaWorldFromLocal;
        unity_WorldToObject = _NovaLocalFromWorld;
    }
#endif


#if 1 //////////////////////// INDEXING ///////////////////////////////////
    int _NovaFirstIndex;
    int _NovaLastIndex;
    int _NovaViewingFromBehind;

    // Annoyingly, UNITY_SETUP_INSTANCE_ID doesn't allow you to just pass in the instance ID,
    // it expects a struct with the instance ID stored in a member called "instanceID", so this
    // struct just wraps the instanceID so that Unity's macros are happy.
    struct InstanceIDWrapper
    {
        uint instanceID;
    };

    #if defined(UNITY_STEREO_INSTANCING_ENABLED)
        // Need to divide by 2 since we double the instance count, but don't
        // actually double the buffer sizes
        #define HandleStereoInstancingInstanceID(id) id /= 2
    #else
        #define HandleStereoInstancingInstanceID(id)
    #endif

    #define NovaVertInit(id, outputType, outputVar) \
        InstanceIDWrapper wrapper; \
        wrapper.instanceID = id; \
        UNITY_SETUP_INSTANCE_ID(wrapper); \
        UpdateMatrices(); \
        NovaInitInstance(outputType, outputVar); \
        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(outputVar); \
        HandleStereoInstancingInstanceID(id);


    #if defined(UNITY_STEREO_INSTANCING_ENABLED)
        #define NovaFragInit(v2f) UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(v2f);
    #else
        #define NovaFragInit(v2f)
    #endif


    // Converts the drawcall instance id to the data buffer index, taking
    // into account first/last index and whether or not the content is being viewed from
    // behind
    uint InstanceIDToDataIndex(uint instanceID)
    {
        uint fromFront = instanceID + (uint)_NovaFirstIndex;
        uint fromBack = (uint)_NovaLastIndex - instanceID;
        uint viewingFromFront = 1 - (uint)_NovaViewingFromBehind;
        return viewingFromFront * fromFront + _NovaViewingFromBehind * fromBack;
    }

    // Same as InstanceIDToDataIndex, but for vert index
    uint InstanceIDToVertIndex(uint instanceID, uint vid, uint vertsPerInstance)
    {
        uint fromFront = (uint)_NovaFirstIndex + instanceID * vertsPerInstance + vid;
        uint fromBack = (uint)_NovaLastIndex - instanceID * vertsPerInstance - (vertsPerInstance - 1u) + vid;
        uint viewingFromFront = 1 - (uint)_NovaViewingFromBehind;
        return viewingFromFront * fromFront + _NovaViewingFromBehind * fromBack;
    }

    #if !defined(NOVA_NO_INDEX_BUFFER)
        NOVA_DECLARE_BUFFER(float, _NovaDataIndices);
    #endif
#endif

#if 1 //////////////////////// VERT ///////////////////////////////////////
    #define NOVA_DUMMY_INSTANCE_SETUP void setup() { }
#endif

#if 1 ///////////////////////////// COLORS ////////////////////////////////////
    #if defined(NOVA_PREMUL_COLORS)
        #define NovaColorToV2F(colorName, v2f, novaColor) \
            fixed4 unpacked##colorName = UnpackColor(novaColor); \
            PremulColor(unpacked##colorName); \
            Set##colorName(v2f, unpacked##colorName);

    #else
        #define NovaColorToV2F(colorName, v2f, novaColor) \
            fixed4 unpacked##colorName = UnpackColor(novaColor); \
            Set##colorName(v2f, unpacked##colorName);
            
    #endif
#endif

#if 1 ///////////////////////////// Edge Softening ////////////////////////////////////

    half _NovaEdgeSoftenWidth;

    half GetSoftenWidth(half2 position)
    {
        float2 posAsFloat = position;
        float2 dx = abs(ddx(posAsFloat));
        float2 dy = abs(ddy(posAsFloat));
        half fw = sqrt(dot(dx, dy.yx));
        fw = max(_NovaEdgeSoftenWidth * fw, NOVA_EPSILON);
        return fw;
    }

    half2 GetSoftenWidth2(half4 position)
    {
        float4 posAsFloat = position;
        float4 dx = abs(ddx(posAsFloat));
        float4 dy = abs(ddy(posAsFloat));
        half2 fw = half2(dot(dx.xy, dy.yx), dot(dx.zw, dy.wz));
        fw = sqrt(fw);
        fw = max(_NovaEdgeSoftenWidth * fw, NOVA_EPSILON);
        return fw;
    }

    half GetSoftenWidthInverse(half2 position)
    {
        return 1.0 / GetSoftenWidth(position);
    }

    half2 GetSoftenWidthInverse2(half4 position)
    {
        return 1.0 / GetSoftenWidth2(position);
    }

    // Returns the clip weight based on distance and soften width
    // where negative is 1 and positive is 0
    #define GetClipWeight10(distanceOutside, softenInverse) 1.0 - saturate(distanceOutside * softenInverse)
    // Returns the clip weight based on distance and soften width
    // where negative is 0 and positive is 1
    #define GetClipWeight01(distanceOutside, softenInverse) saturate(distanceOutside * softenInverse)
#endif

#if 1 ///////////////////////////// RADIAL FILL ////////////////////////////////////
    #if defined(NOVA_RADIAL_FILL)

        // Returns radialFillSpacePos
        float2 RadialFillVert(float2 nPos, float2 radialFillCenter, float rotation, float fillAngle, float nFactor, out float2 sinCos)
        {
            sincos(rotation, sinCos.x, sinCos.y);
            float2 nRadialFillCenter = nFactor * radialFillCenter;
            float2 unrotatedRadialFillSpacePos = nPos - nRadialFillCenter;
            float2 radialFillSpacePos = Rotate2D(unrotatedRadialFillSpacePos, sinCos.x, sinCos.y);

            sincos(fillAngle, sinCos.x, sinCos.y);
            return radialFillSpacePos;
        }

        half GetRadialFillClipWeight(half2 radialFillSpacePos, half2 sinCos, half softenWidth, half softenInverse)
        {
            half2 radialFillSpacePos2 = Rotate2D(radialFillSpacePos, sinCos.x, sinCos.y);

            // The approach we take for the radial cutout is a "linearized" version of the naive
            // approach (i.e., just using angles) since the non-linear angle calculations don't play
            // well with fwidth and friends (so edge softening near the origin of the radial fill blows up
            // due to small positional changes between two pixels having large angle differences).
            // So the way we do the radial fill is by using two separate rotated spaces and then checking
            // the distance from the x-axis (i.e., y-value) and use that as the distance outside of the fill arc.
            // This makes fwidth change uniformly, but means we have to treat reflex angles differently than non-reflex
            // angles in the sense that for angles < 180, we default to not rendering and only render the part within
            // the fill while for angles > 180 we default to rendering and cutout the appropriate section.
            bool isReflexAngle = sinCos.x <= 0;

            half2 distancesOutsideRadialEdges = isReflexAngle ? half2(-radialFillSpacePos.y, radialFillSpacePos2.y) : half2(-radialFillSpacePos2.y, radialFillSpacePos.y);
            
            // If angle is less than 90, also check the x value to avoid very thin
            // triangles appearing due to edge softening
            distancesOutsideRadialEdges = sinCos.y > 0 ? max(distancesOutsideRadialEdges, -half2(radialFillSpacePos.x, radialFillSpacePos2.x)) : distancesOutsideRadialEdges;

            half distFromFurthestEdge = max(distancesOutsideRadialEdges.x, distancesOutsideRadialEdges.y);

            // If > 180, we add in the soften width so that there isn't a shift when the fill angle switches
            // from reflex to non-reflex
            distFromFurthestEdge += isReflexAngle ? softenWidth : 0;   

            float radialFillClipWeight = isReflexAngle ? GetClipWeight10(distFromFurthestEdge, softenInverse) : GetClipWeight01(distFromFurthestEdge, softenInverse);
            return radialFillClipWeight;
        }
    #endif
#endif

///////////////////////////// CLIP MASKS ////////////////////////////////////
#if defined(NOVA_CLIP_RECT) || defined(NOVA_CLIP_MASK)
    #define MAX_VISUAL_MODIFIERS 16
    uint _NovaVisualModifierCount;
    float4x4 _NovaVisualModifiersFromRoot[MAX_VISUAL_MODIFIERS];
    // xy -> nHalfSize
    // z -> nFactor
    // w -> nRadius
    float4 _NovaClipRectInfos[MAX_VISUAL_MODIFIERS];
    float4 _NovaGlobalColorModifiers[MAX_VISUAL_MODIFIERS];

    #if defined(NOVA_CLIP_RECT) || defined(NOVA_CLIP_MASK)
        #define NOVA_CLIPPING

        #define GetClipRectNHalfSize(info) info.xy
        #define GetClipRectNFactor(info) info.z
        #define GetClipRectNRadius(info) info.w
        #define GetClipRectNCornerOrigin(info) (GetClipRectNHalfSize(info) - GetClipRectNRadius(info))

        half GetTotalVisualModifierClipping(float3 rootPos)
        {
            half clipWeight = 1.0;
            for (uint i = 0; i < _NovaVisualModifierCount; ++i)
            {
                float2 visualModifierPos = mul(_NovaVisualModifiersFromRoot[i], float4(rootPos, 1.0)).xy;
                float4 clipRectInfo = _NovaClipRectInfos[i];
                float2 visualModifierNPos = visualModifierPos * GetClipRectNFactor(clipRectInfo);


                half2 clampedCornerSpace;
                half distanceOutsideBounds = DistanceFromCircleEdge(visualModifierNPos, GetClipRectNCornerOrigin(clipRectInfo), GetClipRectNRadius(clipRectInfo), clampedCornerSpace);
                
                half softenWidth = GetSoftenWidth(visualModifierNPos);
                half softenInverse = 1.0 / softenWidth;

                clipWeight *= GetClipWeight10(distanceOutsideBounds, softenInverse);
            }
            return clipWeight;
        }

        fixed4 ApplyVisualModiferClipping(fixed4 color, float3 rootPos)
        {
            for (uint i = 0; i < _NovaVisualModifierCount; ++i)
            {
                float2 visualModifierPos = mul(_NovaVisualModifiersFromRoot[i], float4(rootPos, 1.0)).xy;
                float4 clipRectInfo = _NovaClipRectInfos[i];
                float2 visualModifierNPos = visualModifierPos * GetClipRectNFactor(clipRectInfo);


                half2 clampedCornerSpace;
                half distanceOutsideBounds = DistanceFromCircleEdge(visualModifierNPos, GetClipRectNCornerOrigin(clipRectInfo), GetClipRectNRadius(clipRectInfo), clampedCornerSpace);
                
                half softenWidth = GetSoftenWidth(visualModifierNPos);
                half softenInverse = 1.0 / softenWidth;

                half clipWeight = GetClipWeight10(distanceOutsideBounds, softenInverse);
                color = ApplyClipWeight(color, clipWeight);
            }

            return color;
        }

        fixed4 ApplyGlobalColorModification(fixed4 color)
        {
            for (uint i = 0; i < _NovaVisualModifierCount; ++i)
            {
                color = ApplyColorTint(color, _NovaGlobalColorModifiers[i]);
            }
            #if !defined(NOVA_ALPHA)
                clip(color.a - NOVA_EPSILON);
            #endif
            return color;
        }
    #endif

    #if defined(NOVA_CLIP_MASK)
        // The index of the visual modifier corresponding to the clip mask
        uint _NovaClipMaskIndex;
        sampler2D _ClipMaskTex;

        fixed4 ApplyClipMaskAndColorModifiers(fixed4 color, float3 rootPos)
        {
            float4 clipMaskInfo = _NovaClipRectInfos[_NovaClipMaskIndex];

            float2 clipMaskPos = mul(_NovaVisualModifiersFromRoot[_NovaClipMaskIndex], float4(rootPos, 1.0)).xy;
            float2 clipMaskNPos = clipMaskPos * GetClipRectNFactor(clipMaskInfo);

            half2 novaUV = clipMaskNPos / GetClipRectNHalfSize(clipMaskInfo);
            half2 unityUV = ToUnityUV(novaUV);
            fixed4 clipMaskColor = tex2D(_ClipMaskTex, unityUV);
            // Clip mask
            color = ApplyColorTint(color, clipMaskColor);
            // Color Modifiers
            return ApplyGlobalColorModification(color);
        }
    #endif
#endif

#endif