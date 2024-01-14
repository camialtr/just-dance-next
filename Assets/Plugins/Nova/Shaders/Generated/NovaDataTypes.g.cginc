#ifndef NOVA_SHADER_TYPES
#define NOVA_SHADER_TYPES
#if 1 //////////////////////// Types ////////////////////////
	#if 1 //////////////////////// UIBlock2D ////////////////////////
		struct SubQuadVert
		{
			float2 Pos;
			float BlockDataIndex;
			float EdgeSoftenMask;

			float2 UVZoom;
			float2 CenterUV;
		};

		struct UIBlock2DData
		{
			float2 QuadSize;
			float2 GradientCenter;

			float2 GradientSizeReciprocal;
			float2 GradientRotationSinCos;

			float2 ShadowOffset;
			float CornerRadius;
			float ShadowWidth;

			float TransformIndex;
			float TexturePackSlice;
			float BorderWidth;
			float ShadowBlur;

			float2 RadialFillCenter;
			float RadialFillRotation;
			float RadialFillAngle;

			NovaColor PrimaryColor;

			NovaColor GradientColor;

			NovaColor ShadowColor;

			NovaColor BorderColor;
		};

		struct PerInstanceDropShadowShaderData
		{
			float2 Offset;
			float2 HalfBlockQuadSize;

			float Width;
			float Blur;
			float BlockClipRadius;
			float RadialFillRotation;

			float TransformIndex;
			float EdgeSoftenMask;
			float2 RadialFillCenter;

			float RadialFillAngle;
			float3 _padding;

			NovaColor Color;
		};

		struct PerQuadDropShadowShaderData
		{
			float2 PositionInNode;
			float2 QuadSize;
		};
	#endif

	#if 1 //////////////////////// UIBlock3D ////////////////////////
		struct UIBlock3DData
		{
			float3 Size;
			float CornerRadius;

			float EdgeRadius;
			float TransformIndex;
			float2 _padding;

			NovaColor Color;
		};
	#endif

	#if 1 //////////////////////// TextBlock ////////////////////////
		struct PerVertTextData
		{
			float3 Position;
			float TransformIndex;

			float2 Texcoord0;
			float2 Texcoord1;

			float ScaleMultiplier;
			float3 _padding;

			NovaColor Color;
		};
	#endif

	#if 1 //////////////////////// Lighting ////////////////////////
		struct BlinnPhongData
		{
			float Specular;
			float Gloss;
			float2 _padding;

			float4 _padding2;
		};

		struct StandardData
		{
			float Smoothness;
			float Metallic;
			float2 _padding;

			float4 _padding2;
		};

		struct StandardSpecularData
		{
			float Smoothness;
			float3 _padding;

			NovaColor SpecularColor;
		};
	#endif
#endif


#if 1 //////////////////////// Access ////////////////////////
	#if defined(NOVA_FALLBACK_RENDERING)
		#if 1 //////////////////////// UIBlock2D ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_SubQuadVert(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 2, 0, bufferName##_TexelSize); \
				SubQuadVert name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Pos = bufferName##_Temp.xy; \
				name.BlockDataIndex = bufferName##_Temp.z; \
				name.EdgeSoftenMask = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 2, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.UVZoom = bufferName##_Temp.xy; \
				name.CenterUV = bufferName##_Temp.zw; 

			#define NOVA_GET_BUFFER_ITEM_UIBlock2DData(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 9, 0, bufferName##_TexelSize); \
				UIBlock2DData name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.QuadSize = bufferName##_Temp.xy; \
				name.GradientCenter = bufferName##_Temp.zw; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.GradientSizeReciprocal = bufferName##_Temp.xy; \
				name.GradientRotationSinCos = bufferName##_Temp.zw; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.ShadowOffset = bufferName##_Temp.xy; \
				name.CornerRadius = bufferName##_Temp.z; \
				name.ShadowWidth = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.TransformIndex = bufferName##_Temp.x; \
				name.TexturePackSlice = bufferName##_Temp.y; \
				name.BorderWidth = bufferName##_Temp.z; \
				name.ShadowBlur = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 4, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.RadialFillCenter = bufferName##_Temp.xy; \
				name.RadialFillRotation = bufferName##_Temp.z; \
				name.RadialFillAngle = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 5, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.PrimaryColor.Val = bufferName##_Temp; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 6, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.GradientColor.Val = bufferName##_Temp; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 7, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.ShadowColor.Val = bufferName##_Temp; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 9, 8, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.BorderColor.Val = bufferName##_Temp; 

			#define NOVA_GET_BUFFER_ITEM_PerInstanceDropShadowShaderData(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 5, 0, bufferName##_TexelSize); \
				PerInstanceDropShadowShaderData name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Offset = bufferName##_Temp.xy; \
				name.HalfBlockQuadSize = bufferName##_Temp.zw; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 5, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Width = bufferName##_Temp.x; \
				name.Blur = bufferName##_Temp.y; \
				name.BlockClipRadius = bufferName##_Temp.z; \
				name.RadialFillRotation = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 5, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.TransformIndex = bufferName##_Temp.x; \
				name.EdgeSoftenMask = bufferName##_Temp.y; \
				name.RadialFillCenter = bufferName##_Temp.zw; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 5, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.RadialFillAngle = bufferName##_Temp.x; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 5, 4, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Color.Val = bufferName##_Temp; 

			#define NOVA_GET_BUFFER_ITEM_PerQuadDropShadowShaderData(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 1, 0, bufferName##_TexelSize); \
				PerQuadDropShadowShaderData name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.PositionInNode = bufferName##_Temp.xy; \
				name.QuadSize = bufferName##_Temp.zw; 
		#endif

		#if 1 //////////////////////// UIBlock3D ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_UIBlock3DData(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 3, 0, bufferName##_TexelSize); \
				UIBlock3DData name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Size = bufferName##_Temp.xyz; \
				name.CornerRadius = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 3, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.EdgeRadius = bufferName##_Temp.x; \
				name.TransformIndex = bufferName##_Temp.y; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 3, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Color.Val = bufferName##_Temp; 
		#endif

		#if 1 //////////////////////// TextBlock ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_PerVertTextData(name, index, bufferName) \
				float4 bufferName##_UV = GetTextureBufferUV(index, 4, 0, bufferName##_TexelSize); \
				PerVertTextData name; \
				float4 bufferName##_Temp; \
				\
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Position = bufferName##_Temp.xyz; \
				name.TransformIndex = bufferName##_Temp.w; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 4, 1, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Texcoord0 = bufferName##_Temp.xy; \
				name.Texcoord1 = bufferName##_Temp.zw; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 4, 2, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.ScaleMultiplier = bufferName##_Temp.x; \
				\
				bufferName##_UV = GetTextureBufferUV(index, 4, 3, bufferName##_TexelSize); \
				bufferName##_Temp = tex2Dlod(bufferName, bufferName##_UV); \
				name.Color.Val = bufferName##_Temp; 
		#endif

		#if 1 //////////////////////// Lighting ////////////////////////


		#endif
	#else
		#if 1 //////////////////////// UIBlock2D ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_SubQuadVert(name, index, bufferName) \
				SubQuadVert name = bufferName[index];

			#define NOVA_GET_BUFFER_ITEM_UIBlock2DData(name, index, bufferName) \
				UIBlock2DData name = bufferName[index];

			#define NOVA_GET_BUFFER_ITEM_PerInstanceDropShadowShaderData(name, index, bufferName) \
				PerInstanceDropShadowShaderData name = bufferName[index];

			#define NOVA_GET_BUFFER_ITEM_PerQuadDropShadowShaderData(name, index, bufferName) \
				PerQuadDropShadowShaderData name = bufferName[index];
		#endif

		#if 1 //////////////////////// UIBlock3D ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_UIBlock3DData(name, index, bufferName) \
				UIBlock3DData name = bufferName[index];
		#endif

		#if 1 //////////////////////// TextBlock ////////////////////////
			#define NOVA_GET_BUFFER_ITEM_PerVertTextData(name, index, bufferName) \
				PerVertTextData name = bufferName[index];
		#endif

		#if 1 //////////////////////// Lighting ////////////////////////


		#endif
	#endif
#endif
#endif
