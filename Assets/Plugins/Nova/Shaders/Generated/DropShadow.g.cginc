#ifndef NOVA_DROPSHADOW_STRUCTURES
#define NOVA_DROPSHADOW_STRUCTURES

#include "../NovaPreV2F.cginc"

////////////////// BEGIN GENERATED //////////////////
#define GetNBlockPos(val) val.Packed0.xy
#define SetNBlockPos(val, toSet) val.Packed0.xy = toSet
#define GetNShadowPos(val) val.Packed0.zw
#define SetNShadowPos(val, toSet) val.Packed0.zw = toSet
#define GetNShadowRadius(val) val.Packed1.x
#define SetNShadowRadius(val, toSet) val.Packed1.x = toSet
#define GetNShadowBlur(val) val.Packed1.y
#define SetNShadowBlur(val, toSet) val.Packed1.y = toSet
#define GetNBlockOrigin(val) val.Packed1.zw
#define SetNBlockOrigin(val, toSet) val.Packed1.zw = toSet
#define GetColor(val) val.Color
#define SetColor(val, toSet) val.Color = toSet
#if defined(NOVA_RADIAL_FILL)
	#if defined(NOVA_CLIPPING)
		#if defined(NOVA_LIT)
			#define GetWorldNormal(val) val.Packed2.xyz
			#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
			#define GetNBlockRadius(val) val.Packed2.w
			#define SetNBlockRadius(val, toSet) val.Packed2.w = toSet
			#define GetRadialFillSinCos(val) val.Packed3.xy
			#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
			#define GetNShadowOrigin(val) val.Packed3.zw
			#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
			#if defined(NOVA_LAMBERT_LIGHTING)
				#define GetRootPos(val) val.Packed4.xyz
				#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
				#define GetWorldPos(val) val.Packed5.xyz
				#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
				#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
				#define GetRadialFillSpacePos(val) half2(val.Packed4.w, val.Packed5.w)
				#define SetRadialFillSpacePos(val, toSet) \
					val.Packed4.w = toSet.x; \
					val.Packed5.w = toSet.y;
				#define POST_NOVA_0 8
				#define POST_NOVA_1 9
				#define POST_NOVA_2 10
				#define POST_NOVA_3 11
				#define POST_NOVA_4 12
				#define POST_NOVA_5 13
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				#define GetRadialFillSpacePos(val) val.Packed4.xy
				#define SetRadialFillSpacePos(val, toSet) val.Packed4.xy = toSet
				#define GetSpecular(val) val.Packed4.z
				#define SetSpecular(val, toSet) val.Packed4.z = toSet
				#define GetGloss(val) val.Packed4.w
				#define SetGloss(val, toSet) val.Packed4.w = toSet
				#define GetRootPos(val) val.Packed5.xyz
				#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed5.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
				#define GetWorldPos(val) val.WorldPos
				#define SetWorldPos(val, toSet) val.WorldPos = toSet
				#define POST_NOVA_0 8
				#define POST_NOVA_1 9
				#define POST_NOVA_2 10
				#define POST_NOVA_3 11
				#define POST_NOVA_4 12
				#define POST_NOVA_5 13
			#elif defined(NOVA_STANDARD_LIGHTING)
				#define GetRadialFillSpacePos(val) val.Packed4.xy
				#define SetRadialFillSpacePos(val, toSet) val.Packed4.xy = toSet
				#define GetSmoothness(val) val.Packed4.z
				#define SetSmoothness(val, toSet) val.Packed4.z = toSet
				#define GetMetallic(val) val.Packed4.w
				#define SetMetallic(val, toSet) val.Packed4.w = toSet
				#define GetRootPos(val) val.Packed5.xyz
				#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed5.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
				#define GetWorldPos(val) val.WorldPos
				#define SetWorldPos(val, toSet) val.WorldPos = toSet
				#define POST_NOVA_0 8
				#define POST_NOVA_1 9
				#define POST_NOVA_2 10
				#define POST_NOVA_3 11
				#define POST_NOVA_4 12
				#define POST_NOVA_5 13
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				#define GetEdgeSoftenDisabled(val) val.Packed4.x
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
				#define GetSpecularColor(val) val.Packed4.yzw
				#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
				#define GetRootPos(val) val.Packed5.xyz
				#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
				#define GetWorldPos(val) val.Packed6.xyz
				#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
				#define GetSmoothness(val) val.Smoothness
				#define SetSmoothness(val, toSet) val.Smoothness = toSet
				#define GetRadialFillSpacePos(val) half2(val.Packed5.w, val.Packed6.w)
				#define SetRadialFillSpacePos(val, toSet) \
					val.Packed5.w = toSet.x; \
					val.Packed6.w = toSet.y;
				#define POST_NOVA_0 9
				#define POST_NOVA_1 10
				#define POST_NOVA_2 11
				#define POST_NOVA_3 12
				#define POST_NOVA_4 13
				#define POST_NOVA_5 14
			#endif
		#else
			#define GetRootPos(val) val.Packed2.xyz
			#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
			#define GetNShadowOrigin(val) val.Packed3.xy
			#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
			#define GetNBlockRadius(val) val.Packed3.w
			#define SetNBlockRadius(val, toSet) val.Packed3.w = toSet
			#define GetRadialFillSinCos(val) val.Packed4.xy
			#define SetRadialFillSinCos(val, toSet) val.Packed4.xy = toSet
			#define GetEdgeSoftenDisabled(val) val.Packed4.z
			#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
			#define GetRadialFillSpacePos(val) half2(val.Packed2.w, val.Packed3.z)
			#define SetRadialFillSpacePos(val, toSet) \
				val.Packed2.w = toSet.x; \
				val.Packed3.z = toSet.y;
		#endif
	#else
		#if defined(NOVA_LIT)
			#define GetWorldNormal(val) val.Packed2.xyz
			#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
			#define GetNBlockRadius(val) val.Packed2.w
			#define SetNBlockRadius(val, toSet) val.Packed2.w = toSet
			#define GetRadialFillSinCos(val) val.Packed3.xy
			#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
			#define GetNShadowOrigin(val) val.Packed3.zw
			#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
			#if defined(NOVA_LAMBERT_LIGHTING)
				#define GetWorldPos(val) val.Packed4.xyz
				#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed4.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
				#define GetRadialFillSpacePos(val) val.RadialFillSpacePos
				#define SetRadialFillSpacePos(val, toSet) val.RadialFillSpacePos = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				#define GetRadialFillSpacePos(val) val.Packed4.xy
				#define SetRadialFillSpacePos(val, toSet) val.Packed4.xy = toSet
				#define GetSpecular(val) val.Packed4.z
				#define SetSpecular(val, toSet) val.Packed4.z = toSet
				#define GetGloss(val) val.Packed4.w
				#define SetGloss(val, toSet) val.Packed4.w = toSet
				#define GetWorldPos(val) val.Packed5.xyz
				#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed5.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_STANDARD_LIGHTING)
				#define GetRadialFillSpacePos(val) val.Packed4.xy
				#define SetRadialFillSpacePos(val, toSet) val.Packed4.xy = toSet
				#define GetSmoothness(val) val.Packed4.z
				#define SetSmoothness(val, toSet) val.Packed4.z = toSet
				#define GetMetallic(val) val.Packed4.w
				#define SetMetallic(val, toSet) val.Packed4.w = toSet
				#define GetWorldPos(val) val.Packed5.xyz
				#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed5.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				#define GetEdgeSoftenDisabled(val) val.Packed4.x
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
				#define GetSpecularColor(val) val.Packed4.yzw
				#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
				#define GetWorldPos(val) val.Packed5.xyz
				#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
				#define GetSmoothness(val) val.Packed5.w
				#define SetSmoothness(val, toSet) val.Packed5.w = toSet
				#define GetRadialFillSpacePos(val) val.RadialFillSpacePos
				#define SetRadialFillSpacePos(val, toSet) val.RadialFillSpacePos = toSet
				#define POST_NOVA_0 8
				#define POST_NOVA_1 9
				#define POST_NOVA_2 10
				#define POST_NOVA_3 11
				#define POST_NOVA_4 12
				#define POST_NOVA_5 13
			#endif
		#else
			#define GetNShadowOrigin(val) val.Packed2.xy
			#define SetNShadowOrigin(val, toSet) val.Packed2.xy = toSet
			#define GetRadialFillSpacePos(val) val.Packed2.zw
			#define SetRadialFillSpacePos(val, toSet) val.Packed2.zw = toSet
			#define GetRadialFillSinCos(val) val.Packed3.xy
			#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
			#define GetNBlockRadius(val) val.Packed3.z
			#define SetNBlockRadius(val, toSet) val.Packed3.z = toSet
			#define GetEdgeSoftenDisabled(val) val.Packed3.w
			#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
		#endif
	#endif
#else
	#if defined(NOVA_CLIPPING)
		#if defined(NOVA_LIT)
			#define GetWorldNormal(val) val.Packed2.xyz
			#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
			#define GetNBlockRadius(val) val.Packed2.w
			#define SetNBlockRadius(val, toSet) val.Packed2.w = toSet
			#if defined(NOVA_LAMBERT_LIGHTING)
				#define GetRootPos(val) val.Packed3.xyz
				#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
				#define GetWorldPos(val) val.Packed4.xyz
				#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
				#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
				#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.w)
				#define SetNShadowOrigin(val, toSet) \
					val.Packed3.w = toSet.x; \
					val.Packed4.w = toSet.y;
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				#define GetNShadowOrigin(val) val.Packed3.xy
				#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
				#define GetSpecular(val) val.Packed3.z
				#define SetSpecular(val, toSet) val.Packed3.z = toSet
				#define GetGloss(val) val.Packed3.w
				#define SetGloss(val, toSet) val.Packed3.w = toSet
				#define GetRootPos(val) val.Packed4.xyz
				#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed4.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
				#define GetWorldPos(val) val.WorldPos
				#define SetWorldPos(val, toSet) val.WorldPos = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_STANDARD_LIGHTING)
				#define GetNShadowOrigin(val) val.Packed3.xy
				#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
				#define GetSmoothness(val) val.Packed3.z
				#define SetSmoothness(val, toSet) val.Packed3.z = toSet
				#define GetMetallic(val) val.Packed3.w
				#define SetMetallic(val, toSet) val.Packed3.w = toSet
				#define GetRootPos(val) val.Packed4.xyz
				#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed4.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
				#define GetWorldPos(val) val.WorldPos
				#define SetWorldPos(val, toSet) val.WorldPos = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				#define GetEdgeSoftenDisabled(val) val.Packed3.x
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
				#define GetSpecularColor(val) val.Packed3.yzw
				#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
				#define GetRootPos(val) val.Packed4.xyz
				#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
				#define GetWorldPos(val) val.Packed5.xyz
				#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
				#define GetSmoothness(val) val.Smoothness
				#define SetSmoothness(val, toSet) val.Smoothness = toSet
				#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.w)
				#define SetNShadowOrigin(val, toSet) \
					val.Packed4.w = toSet.x; \
					val.Packed5.w = toSet.y;
				#define POST_NOVA_0 8
				#define POST_NOVA_1 9
				#define POST_NOVA_2 10
				#define POST_NOVA_3 11
				#define POST_NOVA_4 12
				#define POST_NOVA_5 13
			#endif
		#else
			#define GetRootPos(val) val.Packed2.xyz
			#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
			#define GetNBlockRadius(val) val.Packed2.w
			#define SetNBlockRadius(val, toSet) val.Packed2.w = toSet
			#define GetNShadowOrigin(val) val.Packed3.xy
			#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
			#define GetEdgeSoftenDisabled(val) val.Packed3.z
			#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
		#endif
	#else
		#if defined(NOVA_LIT)
			#define GetWorldNormal(val) val.Packed2.xyz
			#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
			#define GetNBlockRadius(val) val.Packed2.w
			#define SetNBlockRadius(val, toSet) val.Packed2.w = toSet
			#if defined(NOVA_LAMBERT_LIGHTING)
				#define GetWorldPos(val) val.Packed3.xyz
				#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed3.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
				#define GetNShadowOrigin(val) val.NShadowOrigin
				#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
				#define POST_NOVA_0 6
				#define POST_NOVA_1 7
				#define POST_NOVA_2 8
				#define POST_NOVA_3 9
				#define POST_NOVA_4 10
				#define POST_NOVA_5 11
			#elif defined(NOVA_BLINNPHONG_LIGHTING)
				#define GetNShadowOrigin(val) val.Packed3.xy
				#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
				#define GetSpecular(val) val.Packed3.z
				#define SetSpecular(val, toSet) val.Packed3.z = toSet
				#define GetGloss(val) val.Packed3.w
				#define SetGloss(val, toSet) val.Packed3.w = toSet
				#define GetWorldPos(val) val.Packed4.xyz
				#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed4.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
				#define POST_NOVA_0 6
				#define POST_NOVA_1 7
				#define POST_NOVA_2 8
				#define POST_NOVA_3 9
				#define POST_NOVA_4 10
				#define POST_NOVA_5 11
			#elif defined(NOVA_STANDARD_LIGHTING)
				#define GetNShadowOrigin(val) val.Packed3.xy
				#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
				#define GetSmoothness(val) val.Packed3.z
				#define SetSmoothness(val, toSet) val.Packed3.z = toSet
				#define GetMetallic(val) val.Packed3.w
				#define SetMetallic(val, toSet) val.Packed3.w = toSet
				#define GetWorldPos(val) val.Packed4.xyz
				#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
				#define GetEdgeSoftenDisabled(val) val.Packed4.w
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
				#define POST_NOVA_0 6
				#define POST_NOVA_1 7
				#define POST_NOVA_2 8
				#define POST_NOVA_3 9
				#define POST_NOVA_4 10
				#define POST_NOVA_5 11
			#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
				#define GetEdgeSoftenDisabled(val) val.Packed3.x
				#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
				#define GetSpecularColor(val) val.Packed3.yzw
				#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
				#define GetWorldPos(val) val.Packed4.xyz
				#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
				#define GetSmoothness(val) val.Packed4.w
				#define SetSmoothness(val, toSet) val.Packed4.w = toSet
				#define GetNShadowOrigin(val) val.NShadowOrigin
				#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
				#define POST_NOVA_0 7
				#define POST_NOVA_1 8
				#define POST_NOVA_2 9
				#define POST_NOVA_3 10
				#define POST_NOVA_4 11
				#define POST_NOVA_5 12
			#endif
		#else
			#define GetNShadowOrigin(val) val.Packed2.xy
			#define SetNShadowOrigin(val, toSet) val.Packed2.xy = toSet
			#define GetNBlockRadius(val) val.Packed2.z
			#define SetNBlockRadius(val, toSet) val.Packed2.z = toSet
			#define GetEdgeSoftenDisabled(val) val.Packed2.w
			#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
		#endif
	#endif
#endif

struct v2f
{
	float4 pos : SV_POSITION;
	// xy: NBlockPos
	// zw: NShadowPos
	half4 Packed0 : TEXCOORD0;
	// x: NShadowRadius
	// y: NShadowBlur
	// zw: NBlockOrigin
	half4 Packed1 : TEXCOORD1;
	fixed4 Color : TEXCOORD2;
	#if defined(NOVA_RADIAL_FILL)
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_LIT)
				// xyz: WorldNormal
				// w: NBlockRadius
				half4 Packed2 : TEXCOORD3;
				// xy: RadialFillSinCos
				// zw: NShadowOrigin
				half4 Packed3 : TEXCOORD4;
				#if defined(NOVA_LAMBERT_LIGHTING)
					// xyz: RootPos
					// w: RadialFillSpacePos(x)
					float4 Packed4 : TEXCOORD5;
					// xyz: WorldPos
					// w: RadialFillSpacePos(y)
					float4 Packed5 : TEXCOORD6;
					fixed EdgeSoftenDisabled : TEXCOORD7;
				#elif defined(NOVA_BLINNPHONG_LIGHTING)
					// xy: RadialFillSpacePos
					// z: Specular
					// w: Gloss
					half4 Packed4 : TEXCOORD5;
					// xyz: RootPos
					// w: EdgeSoftenDisabled
					float4 Packed5 : TEXCOORD6;
					float3 WorldPos : TEXCOORD7;
				#elif defined(NOVA_STANDARD_LIGHTING)
					// xy: RadialFillSpacePos
					// z: Smoothness
					// w: Metallic
					half4 Packed4 : TEXCOORD5;
					// xyz: RootPos
					// w: EdgeSoftenDisabled
					float4 Packed5 : TEXCOORD6;
					float3 WorldPos : TEXCOORD7;
				#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
					// x: EdgeSoftenDisabled
					// yzw: SpecularColor
					fixed4 Packed4 : TEXCOORD5;
					// xyz: RootPos
					// w: RadialFillSpacePos(x)
					float4 Packed5 : TEXCOORD6;
					// xyz: WorldPos
					// w: RadialFillSpacePos(y)
					float4 Packed6 : TEXCOORD7;
					half Smoothness : TEXCOORD8;
				#endif
			#else
				// xyz: RootPos
				// w: RadialFillSpacePos(x)
				float4 Packed2 : TEXCOORD3;
				// xy: NShadowOrigin
				// z: RadialFillSpacePos(y)
				// w: NBlockRadius
				half4 Packed3 : TEXCOORD4;
				// xy: RadialFillSinCos
				// z: EdgeSoftenDisabled
				half3 Packed4 : TEXCOORD5;
			#endif
		#else
			#if defined(NOVA_LIT)
				// xyz: WorldNormal
				// w: NBlockRadius
				half4 Packed2 : TEXCOORD3;
				// xy: RadialFillSinCos
				// zw: NShadowOrigin
				half4 Packed3 : TEXCOORD4;
				#if defined(NOVA_LAMBERT_LIGHTING)
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed4 : TEXCOORD5;
					half2 RadialFillSpacePos : TEXCOORD6;
				#elif defined(NOVA_BLINNPHONG_LIGHTING)
					// xy: RadialFillSpacePos
					// z: Specular
					// w: Gloss
					half4 Packed4 : TEXCOORD5;
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed5 : TEXCOORD6;
				#elif defined(NOVA_STANDARD_LIGHTING)
					// xy: RadialFillSpacePos
					// z: Smoothness
					// w: Metallic
					half4 Packed4 : TEXCOORD5;
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed5 : TEXCOORD6;
				#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
					// x: EdgeSoftenDisabled
					// yzw: SpecularColor
					fixed4 Packed4 : TEXCOORD5;
					// xyz: WorldPos
					// w: Smoothness
					float4 Packed5 : TEXCOORD6;
					half2 RadialFillSpacePos : TEXCOORD7;
				#endif
			#else
				// xy: NShadowOrigin
				// zw: RadialFillSpacePos
				half4 Packed2 : TEXCOORD3;
				// xy: RadialFillSinCos
				// z: NBlockRadius
				// w: EdgeSoftenDisabled
				half4 Packed3 : TEXCOORD4;
			#endif
		#endif
	#else
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_LIT)
				// xyz: WorldNormal
				// w: NBlockRadius
				half4 Packed2 : TEXCOORD3;
				#if defined(NOVA_LAMBERT_LIGHTING)
					// xyz: RootPos
					// w: NShadowOrigin(x)
					float4 Packed3 : TEXCOORD4;
					// xyz: WorldPos
					// w: NShadowOrigin(y)
					float4 Packed4 : TEXCOORD5;
					fixed EdgeSoftenDisabled : TEXCOORD6;
				#elif defined(NOVA_BLINNPHONG_LIGHTING)
					// xy: NShadowOrigin
					// z: Specular
					// w: Gloss
					half4 Packed3 : TEXCOORD4;
					// xyz: RootPos
					// w: EdgeSoftenDisabled
					float4 Packed4 : TEXCOORD5;
					float3 WorldPos : TEXCOORD6;
				#elif defined(NOVA_STANDARD_LIGHTING)
					// xy: NShadowOrigin
					// z: Smoothness
					// w: Metallic
					half4 Packed3 : TEXCOORD4;
					// xyz: RootPos
					// w: EdgeSoftenDisabled
					float4 Packed4 : TEXCOORD5;
					float3 WorldPos : TEXCOORD6;
				#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
					// x: EdgeSoftenDisabled
					// yzw: SpecularColor
					fixed4 Packed3 : TEXCOORD4;
					// xyz: RootPos
					// w: NShadowOrigin(x)
					float4 Packed4 : TEXCOORD5;
					// xyz: WorldPos
					// w: NShadowOrigin(y)
					float4 Packed5 : TEXCOORD6;
					half Smoothness : TEXCOORD7;
				#endif
			#else
				// xyz: RootPos
				// w: NBlockRadius
				float4 Packed2 : TEXCOORD3;
				// xy: NShadowOrigin
				// z: EdgeSoftenDisabled
				half3 Packed3 : TEXCOORD4;
			#endif
		#else
			#if defined(NOVA_LIT)
				// xyz: WorldNormal
				// w: NBlockRadius
				half4 Packed2 : TEXCOORD3;
				#if defined(NOVA_LAMBERT_LIGHTING)
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed3 : TEXCOORD4;
					half2 NShadowOrigin : TEXCOORD5;
				#elif defined(NOVA_BLINNPHONG_LIGHTING)
					// xy: NShadowOrigin
					// z: Specular
					// w: Gloss
					half4 Packed3 : TEXCOORD4;
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed4 : TEXCOORD5;
				#elif defined(NOVA_STANDARD_LIGHTING)
					// xy: NShadowOrigin
					// z: Smoothness
					// w: Metallic
					half4 Packed3 : TEXCOORD4;
					// xyz: WorldPos
					// w: EdgeSoftenDisabled
					float4 Packed4 : TEXCOORD5;
				#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
					// x: EdgeSoftenDisabled
					// yzw: SpecularColor
					fixed4 Packed3 : TEXCOORD4;
					// xyz: WorldPos
					// w: Smoothness
					float4 Packed4 : TEXCOORD5;
					half2 NShadowOrigin : TEXCOORD6;
				#endif
			#else
				// xy: NShadowOrigin
				// z: NBlockRadius
				// w: EdgeSoftenDisabled
				half4 Packed2 : TEXCOORD3;
			#endif
		#endif
	#endif
	NOVA_LIT_V2F_END
};
////////////////// END GENERATED //////////////////

#include "../NovaPostV2F.cginc"

#endif