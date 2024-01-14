#ifndef NOVA_UIBLOCK3D_STRUCTURES
#define NOVA_UIBLOCK3D_STRUCTURES

#include "../NovaPreV2F.cginc"

////////////////// BEGIN GENERATED //////////////////
#define GetColor(val) val.Color
#define SetColor(val, toSet) val.Color = toSet
#if defined(NOVA_CLIPPING)
	#if defined(NOVA_LIT)
		#if defined(NOVA_LAMBERT_LIGHTING)
			#define GetRootPos(val) val.RootPos
			#define SetRootPos(val, toSet) val.RootPos = toSet
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define GetWorldNormal(val) val.WorldNormal
			#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
			#define POST_NOVA_0 4
			#define POST_NOVA_1 5
			#define POST_NOVA_2 6
			#define POST_NOVA_3 7
			#define POST_NOVA_4 8
			#define POST_NOVA_5 9
		#elif defined(NOVA_BLINNPHONG_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSpecular(val) val.Packed0.w
			#define SetSpecular(val, toSet) val.Packed0.w = toSet
			#define GetRootPos(val) val.Packed1.xyz
			#define SetRootPos(val, toSet) val.Packed1.xyz = toSet
			#define GetGloss(val) val.Packed1.w
			#define SetGloss(val, toSet) val.Packed1.w = toSet
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define POST_NOVA_0 4
			#define POST_NOVA_1 5
			#define POST_NOVA_2 6
			#define POST_NOVA_3 7
			#define POST_NOVA_4 8
			#define POST_NOVA_5 9
		#elif defined(NOVA_STANDARD_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSmoothness(val) val.Packed0.w
			#define SetSmoothness(val, toSet) val.Packed0.w = toSet
			#define GetRootPos(val) val.Packed1.xyz
			#define SetRootPos(val, toSet) val.Packed1.xyz = toSet
			#define GetMetallic(val) val.Packed1.w
			#define SetMetallic(val, toSet) val.Packed1.w = toSet
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define POST_NOVA_0 4
			#define POST_NOVA_1 5
			#define POST_NOVA_2 6
			#define POST_NOVA_3 7
			#define POST_NOVA_4 8
			#define POST_NOVA_5 9
		#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSmoothness(val) val.Packed0.w
			#define SetSmoothness(val, toSet) val.Packed0.w = toSet
			#define GetRootPos(val) val.RootPos
			#define SetRootPos(val, toSet) val.RootPos = toSet
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define GetSpecularColor(val) val.SpecularColor
			#define SetSpecularColor(val, toSet) val.SpecularColor = toSet
			#define POST_NOVA_0 5
			#define POST_NOVA_1 6
			#define POST_NOVA_2 7
			#define POST_NOVA_3 8
			#define POST_NOVA_4 9
			#define POST_NOVA_5 10
		#endif
	#else
		#define GetRootPos(val) val.RootPos
		#define SetRootPos(val, toSet) val.RootPos = toSet
	#endif
#else
	#if defined(NOVA_LIT)
		#if defined(NOVA_LAMBERT_LIGHTING)
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define GetWorldNormal(val) val.WorldNormal
			#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
			#define POST_NOVA_0 3
			#define POST_NOVA_1 4
			#define POST_NOVA_2 5
			#define POST_NOVA_3 6
			#define POST_NOVA_4 7
			#define POST_NOVA_5 8
		#elif defined(NOVA_BLINNPHONG_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSpecular(val) val.Packed0.w
			#define SetSpecular(val, toSet) val.Packed0.w = toSet
			#define GetWorldPos(val) val.Packed1.xyz
			#define SetWorldPos(val, toSet) val.Packed1.xyz = toSet
			#define GetGloss(val) val.Packed1.w
			#define SetGloss(val, toSet) val.Packed1.w = toSet
			#define POST_NOVA_0 3
			#define POST_NOVA_1 4
			#define POST_NOVA_2 5
			#define POST_NOVA_3 6
			#define POST_NOVA_4 7
			#define POST_NOVA_5 8
		#elif defined(NOVA_STANDARD_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSmoothness(val) val.Packed0.w
			#define SetSmoothness(val, toSet) val.Packed0.w = toSet
			#define GetWorldPos(val) val.Packed1.xyz
			#define SetWorldPos(val, toSet) val.Packed1.xyz = toSet
			#define GetMetallic(val) val.Packed1.w
			#define SetMetallic(val, toSet) val.Packed1.w = toSet
			#define POST_NOVA_0 3
			#define POST_NOVA_1 4
			#define POST_NOVA_2 5
			#define POST_NOVA_3 6
			#define POST_NOVA_4 7
			#define POST_NOVA_5 8
		#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
			#define GetWorldNormal(val) val.Packed0.xyz
			#define SetWorldNormal(val, toSet) val.Packed0.xyz = toSet
			#define GetSmoothness(val) val.Packed0.w
			#define SetSmoothness(val, toSet) val.Packed0.w = toSet
			#define GetWorldPos(val) val.WorldPos
			#define SetWorldPos(val, toSet) val.WorldPos = toSet
			#define GetSpecularColor(val) val.SpecularColor
			#define SetSpecularColor(val, toSet) val.SpecularColor = toSet
			#define POST_NOVA_0 4
			#define POST_NOVA_1 5
			#define POST_NOVA_2 6
			#define POST_NOVA_3 7
			#define POST_NOVA_4 8
			#define POST_NOVA_5 9
		#endif
	#else
	#endif
#endif

struct v2f
{
	float4 pos : SV_POSITION;
	fixed4 Color : TEXCOORD0;
	#if defined(NOVA_CLIPPING)
		#if defined(NOVA_LIT)
			#if defined(NOVA_LAMBERT_LIGHTING)
				float3 RootPos : TEXCOORD1;
				float3 WorldPos : TEXCOORD2;
				half3 WorldNormal : TEXCOORD3;
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				// xyz: WorldNormal
				// w: Specular
				half4 Packed0 : TEXCOORD1;
				// xyz: RootPos
				// w: Gloss
				float4 Packed1 : TEXCOORD2;
				float3 WorldPos : TEXCOORD3;
			#elif defined(NOVA_STANDARD_LIGHTING)
				// xyz: WorldNormal
				// w: Smoothness
				half4 Packed0 : TEXCOORD1;
				// xyz: RootPos
				// w: Metallic
				float4 Packed1 : TEXCOORD2;
				float3 WorldPos : TEXCOORD3;
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				// xyz: WorldNormal
				// w: Smoothness
				half4 Packed0 : TEXCOORD1;
				float3 RootPos : TEXCOORD2;
				float3 WorldPos : TEXCOORD3;
				fixed3 SpecularColor : TEXCOORD4;
			#endif
		#else
			float3 RootPos : TEXCOORD1;
		#endif
	#else
		#if defined(NOVA_LIT)
			#if defined(NOVA_LAMBERT_LIGHTING)
				float3 WorldPos : TEXCOORD1;
				half3 WorldNormal : TEXCOORD2;
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				// xyz: WorldNormal
				// w: Specular
				half4 Packed0 : TEXCOORD1;
				// xyz: WorldPos
				// w: Gloss
				float4 Packed1 : TEXCOORD2;
			#elif defined(NOVA_STANDARD_LIGHTING)
				// xyz: WorldNormal
				// w: Smoothness
				half4 Packed0 : TEXCOORD1;
				// xyz: WorldPos
				// w: Metallic
				float4 Packed1 : TEXCOORD2;
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				// xyz: WorldNormal
				// w: Smoothness
				half4 Packed0 : TEXCOORD1;
				float3 WorldPos : TEXCOORD2;
				fixed3 SpecularColor : TEXCOORD3;
			#endif
		#else
		#endif
	#endif
	NOVA_LIT_V2F_END
};
////////////////// END GENERATED //////////////////

#include "../NovaPostV2F.cginc"

#endif