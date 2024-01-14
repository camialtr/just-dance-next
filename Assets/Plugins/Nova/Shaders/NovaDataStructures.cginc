#ifndef NOVA_DATA_STRUCTURES
#define NOVA_DATA_STRUCTURES

struct NovaColor
{
    float4 Val;
};

fixed4 UnpackColor(NovaColor color)
{
    return color.Val;
}

#if defined(NOVA_FALLBACK_RENDERING)
    #define NOVA_DECLARE_BUFFER(type, name) \
        sampler2D name; \
        float4 name##_TexelSize;
#else
    #define NOVA_DECLARE_BUFFER(type, name) StructuredBuffer<type> name;
#endif

#if defined(NOVA_FALLBACK_RENDERING)
    #define MAX_TEXTURE_DIMENSION 16384u
    // Returns the UV into a texture buffer, given the index, float4s per instance,
    // and texelSize

    float4 GetTextureBufferUV(uint index, uint pixelsPerInstance, uint subIndex, float4 texelSize) // texelSize: (1/width, 1/height, width, height)
    {
        uint linearizedPixelIndex = index * pixelsPerInstance + subIndex;
        uint xIndex = linearizedPixelIndex % MAX_TEXTURE_DIMENSION;
        uint yIndex = linearizedPixelIndex / MAX_TEXTURE_DIMENSION;

        float2 halfPixelOffset = .5 * texelSize.xy;
        float xUV = xIndex * texelSize.x + halfPixelOffset.x;
        float yUV = yIndex * texelSize.y + halfPixelOffset.y;
        float4 uv = float4(xUV, yUV, 0, 0);
        return uv;
    }
#endif

#include "Generated/NovaDataTypes.g.cginc"

#if 1 //////////////////////// UIBlock2D ///////////////////////////////////
    struct NovaQuadVert
    {
        float3 Pos : POSITION;
        float3 Normal : NORMAL;
    };
#endif

#if 1 //////////////////////// UIBlock3D ///////////////////////////////////
    struct UIBlock3DVert
    {
        float3 Pos : POSITION;
        float3 Normal : NORMAL;
        float3 CornerOffsetDir : TEXCOORD0;
        float3 EdgeOffsetDir : TEXCOORD1;
    };
#endif

#if 1 //////////////////////// Lighting ///////////////////////////////////

    #define NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING 6
    struct TransformAndLighting
    {
        float4x4 RootFromBlock;
        #if defined(NOVA_BLINNPHONG_LIGHTING)
            BlinnPhongData Lighting;
        #elif defined(NOVA_STANDARD_LIGHTING)
            StandardData Lighting;
        #elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
            StandardSpecularData Lighting;
        #else
            float4 _padding;
            float4 _padding2;
        #endif
    };

    #if defined(NOVA_FALLBACK_RENDERING)

        #define NOVA_GET_BUFFER_ITEM_uint(name, index, bufferName) \
            float4 bufferName##_UV = GetTextureBufferUV(index, 1, 0, bufferName##_TexelSize); \
            float bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
            uint name = (uint)bufferName##_Temp;


        #if defined(NOVA_BLINNPHONG_LIGHTING)
            #define NOVA_GET_BUFFER_ITEM_TransformAndLighting(name, index, bufferName) \
                float4 bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 0, bufferName##_TexelSize); \
                TransformAndLighting name; \
                float4 bufferName##_Temp; \
                \
                bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][0] = bufferName##_Temp.x; \
                name.RootFromBlock[1][0] = bufferName##_Temp.y; \
                name.RootFromBlock[2][0] = bufferName##_Temp.z; \
                name.RootFromBlock[3][0] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][1] = bufferName##_Temp.x; \
                name.RootFromBlock[1][1] = bufferName##_Temp.y; \
                name.RootFromBlock[2][1] = bufferName##_Temp.z; \
                name.RootFromBlock[3][1] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][2] = bufferName##_Temp.x; \
                name.RootFromBlock[1][2] = bufferName##_Temp.y; \
                name.RootFromBlock[2][2] = bufferName##_Temp.z; \
                name.RootFromBlock[3][2] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][3] = bufferName##_Temp.x; \
                name.RootFromBlock[1][3] = bufferName##_Temp.y; \
                name.RootFromBlock[2][3] = bufferName##_Temp.z; \
                name.RootFromBlock[3][3] = bufferName##_Temp.w; \
                \
                bufferName##_UV.x += bufferName##_TexelSize.x; \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.Lighting.Specular = bufferName##_Temp.x; \
                name.Lighting.Gloss = bufferName##_Temp.y;

        #elif defined(NOVA_STANDARD_LIGHTING)
            #define NOVA_GET_BUFFER_ITEM_TransformAndLighting(name, index, bufferName) \
                float4 bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 0, bufferName##_TexelSize); \
                TransformAndLighting name; \
                float4 bufferName##_Temp; \
                \
                bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][0] = bufferName##_Temp.x; \
                name.RootFromBlock[1][0] = bufferName##_Temp.y; \
                name.RootFromBlock[2][0] = bufferName##_Temp.z; \
                name.RootFromBlock[3][0] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][1] = bufferName##_Temp.x; \
                name.RootFromBlock[1][1] = bufferName##_Temp.y; \
                name.RootFromBlock[2][1] = bufferName##_Temp.z; \
                name.RootFromBlock[3][1] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][2] = bufferName##_Temp.x; \
                name.RootFromBlock[1][2] = bufferName##_Temp.y; \
                name.RootFromBlock[2][2] = bufferName##_Temp.z; \
                name.RootFromBlock[3][2] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][3] = bufferName##_Temp.x; \
                name.RootFromBlock[1][3] = bufferName##_Temp.y; \
                name.RootFromBlock[2][3] = bufferName##_Temp.z; \
                name.RootFromBlock[3][3] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 4, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.Lighting.Smoothness = bufferName##_Temp.x; \
                name.Lighting.Metallic = bufferName##_Temp.y;

        #elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
            #define NOVA_GET_BUFFER_ITEM_TransformAndLighting(name, index, bufferName) \
                float4 bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 0, bufferName##_TexelSize); \
                TransformAndLighting name; \
                float4 bufferName##_Temp; \
                \
                bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][0] = bufferName##_Temp.x; \
                name.RootFromBlock[1][0] = bufferName##_Temp.y; \
                name.RootFromBlock[2][0] = bufferName##_Temp.z; \
                name.RootFromBlock[3][0] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][1] = bufferName##_Temp.x; \
                name.RootFromBlock[1][1] = bufferName##_Temp.y; \
                name.RootFromBlock[2][1] = bufferName##_Temp.z; \
                name.RootFromBlock[3][1] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][2] = bufferName##_Temp.x; \
                name.RootFromBlock[1][2] = bufferName##_Temp.y; \
                name.RootFromBlock[2][2] = bufferName##_Temp.z; \
                name.RootFromBlock[3][2] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][3] = bufferName##_Temp.x; \
                name.RootFromBlock[1][3] = bufferName##_Temp.y; \
                name.RootFromBlock[2][3] = bufferName##_Temp.z; \
                name.RootFromBlock[3][3] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 4, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.Lighting.Smoothness = bufferName##_Temp.x; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 5, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.Lighting.SpecularColor.Val = bufferName##_Temp; \

        #else
            #define NOVA_GET_BUFFER_ITEM_TransformAndLighting(name, index, bufferName) \
                float4 bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 0, bufferName##_TexelSize); \
                TransformAndLighting name; \
                float4 bufferName##_Temp; \
                \
                bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][0] = bufferName##_Temp.x; \
                name.RootFromBlock[1][0] = bufferName##_Temp.y; \
                name.RootFromBlock[2][0] = bufferName##_Temp.z; \
                name.RootFromBlock[3][0] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][1] = bufferName##_Temp.x; \
                name.RootFromBlock[1][1] = bufferName##_Temp.y; \
                name.RootFromBlock[2][1] = bufferName##_Temp.z; \
                name.RootFromBlock[3][1] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][2] = bufferName##_Temp.x; \
                name.RootFromBlock[1][2] = bufferName##_Temp.y; \
                name.RootFromBlock[2][2] = bufferName##_Temp.z; \
                name.RootFromBlock[3][2] = bufferName##_Temp.w; \
                \
                bufferName##_UV = GetTextureBufferUV(index, NOVA_FLOAT4S_PER_TRANSFORM_AND_LIGHTING, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
                name.RootFromBlock[0][3] = bufferName##_Temp.x; \
                name.RootFromBlock[1][3] = bufferName##_Temp.y; \
                name.RootFromBlock[2][3] = bufferName##_Temp.z; \
                name.RootFromBlock[3][3] = bufferName##_Temp.w;

        #endif

    #else
        #define NOVA_GET_BUFFER_ITEM_TransformAndLighting(name, index, bufferName) \
            TransformAndLighting name = bufferName[index];

        #define NOVA_GET_BUFFER_ITEM_uint(name, index, bufferName) \
            uint name = (uint)bufferName[index];
    #endif
#endif

#endif