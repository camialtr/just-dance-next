#ifndef NOVA_UIBLOCK2D_STRUCTURES
#define NOVA_UIBLOCK2D_STRUCTURES

#include "../NovaPreV2F.cginc"

////////////////// BEGIN GENERATED //////////////////
#define GetGradientSpaceUV(val) val.Packed0.xy
#define SetGradientSpaceUV(val, toSet) val.Packed0.xy = toSet
#define GetNPos(val) val.Packed0.zw
#define SetNPos(val, toSet) val.Packed0.zw = toSet
#define GetColor(val) val.Color
#define SetColor(val, toSet) val.Color = toSet
#define GetGradientColor(val) val.GradientColor
#define SetGradientColor(val, toSet) val.GradientColor = toSet
#if defined(NOVA_DYNAMIC_IMAGE)
	#if defined(NOVA_RADIAL_FILL)
		#define GetRadialFillSpacePos(val) val.Packed1.xy
		#define SetRadialFillSpacePos(val, toSet) val.Packed1.xy = toSet
		#define GetNCornerOrigin(val) val.Packed1.zw
		#define SetNCornerOrigin(val, toSet) val.Packed1.zw = toSet
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetRadialFillSinCos(val) val.Packed2.xy
				#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
				#define GetNCornerRadius(val) val.Packed2.z
				#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
				#define GetBorderNWidth(val) val.Packed2.w
				#define SetBorderNWidth(val, toSet) val.Packed2.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldNormal(val) val.Packed7.xyz
							#define SetWorldNormal(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.w = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldNormal(val) val.Packed7.xyz
							#define SetWorldNormal(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.w = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 13
							#define POST_NOVA_1 14
							#define POST_NOVA_2 15
							#define POST_NOVA_3 16
							#define POST_NOVA_4 17
							#define POST_NOVA_5 18
						#endif
					#else
						#define GetRootPos(val) val.Packed4.xyz
						#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
						#define GetImageUV(val) val.Packed5.xy
						#define SetImageUV(val, toSet) val.Packed5.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed5.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
						#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed4.w = toSet.x; \
							val.Packed5.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetGloss(val) val.Packed6.x
							#define SetGloss(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetMetallic(val) val.Packed6.x
							#define SetMetallic(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
						#define GetImageUV(val) val.ImageUV
						#define SetImageUV(val, toSet) val.ImageUV = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetRadialFillSinCos(val) val.Packed2.xy
					#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
					#define GetNCornerRadius(val) val.Packed2.z
					#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed4.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed4.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetSpecular(val) val.Packed7.x
							#define SetSpecular(val, toSet) val.Packed7.x = toSet
							#define GetGloss(val) val.Packed7.y
							#define SetGloss(val, toSet) val.Packed7.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.z = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetSmoothness(val) val.Packed7.x
							#define SetSmoothness(val, toSet) val.Packed7.x = toSet
							#define GetMetallic(val) val.Packed7.y
							#define SetMetallic(val, toSet) val.Packed7.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.z = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetSmoothness(val) val.Smoothness
							#define SetSmoothness(val, toSet) val.Smoothness = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowBlur(val) val.Packed4.w
						#define SetNShadowBlur(val, toSet) val.Packed4.w = toSet
						#define GetNShadowOrigin(val) val.Packed5.xy
						#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed5.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
						#define GetNShadowSpacePos(val) half2(val.Packed3.w, val.Packed4.z)
						#define SetNShadowSpacePos(val, toSet) \
							val.Packed3.w = toSet.x; \
							val.Packed4.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetRadialFillSinCos(val) val.Packed5.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetRadialFillSinCos(val) val.Packed6.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed6.xy = toSet
							#define GetSmoothness(val) val.Packed6.z
							#define SetSmoothness(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
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
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNCornerRadius(val) val.Packed3.w
						#define SetNCornerRadius(val, toSet) val.Packed3.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetRadialFillSinCos(val) half2(val.Packed2.w, val.Packed3.z)
						#define SetRadialFillSinCos(val, toSet) \
							val.Packed2.w = toSet.x; \
							val.Packed3.z = toSet.y;
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetRadialFillSinCos(val) val.Packed2.xy
				#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
				#define GetNCornerRadius(val) val.Packed2.z
				#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
				#define GetBorderNWidth(val) val.Packed2.w
				#define SetBorderNWidth(val, toSet) val.Packed2.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetNShadowOrigin(val) val.Packed6.xy
							#define SetNShadowOrigin(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed5.w, val.Packed6.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.zw = toSet.yz;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed5.w, val.Packed6.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.zw = toSet.yz;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetImageUV(val) val.Packed7.xy
							#define SetImageUV(val, toSet) val.Packed7.xy = toSet
							#define GetNShadowOrigin(val) half2(val.Packed6.w, val.Packed7.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.z = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowOrigin(val) val.Packed4.zw
						#define SetNShadowOrigin(val, toSet) val.Packed4.zw = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed3.w, val.Packed4.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.zw = toSet.yz;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetRadialFillSinCos(val) val.Packed2.xy
					#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
					#define GetNCornerRadius(val) val.Packed2.z
					#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed4.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed4.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSpecular(val) val.Packed5.w
							#define SetSpecular(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetGloss(val) val.Packed6.z
							#define SetGloss(val, toSet) val.Packed6.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetMetallic(val) val.Packed6.z
							#define SetMetallic(val, toSet) val.Packed6.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetSmoothness(val) val.Packed6.w
							#define SetSmoothness(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed3.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowBlur(val) val.Packed4.z
						#define SetNShadowBlur(val, toSet) val.Packed4.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetRadialFillSinCos(val) half2(val.Packed3.w, val.Packed4.z)
							#define SetRadialFillSinCos(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.z = toSet.y;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetRadialFillSinCos(val) half2(val.Packed4.w, val.Packed5.z)
							#define SetRadialFillSinCos(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.z = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetRadialFillSinCos(val) val.Packed2.zw
						#define SetRadialFillSinCos(val, toSet) val.Packed2.zw = toSet
						#define GetNCornerRadius(val) val.Packed3.x
						#define SetNCornerRadius(val, toSet) val.Packed3.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.y = toSet
					#endif
				#endif
			#endif
		#endif
	#else
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetNCornerOrigin(val) val.Packed1.xy
				#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
				#define GetNCornerRadius(val) val.Packed1.z
				#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
				#define GetBorderNWidth(val) val.Packed1.w
				#define SetBorderNWidth(val, toSet) val.Packed1.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
						#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed3.w = toSet.x; \
							val.Packed4.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed2.xyz
							#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) float2(val.Packed2.w, val.Packed3.w)
							#define SetImageUV(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed5.x
							#define SetGloss(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed5.x
							#define SetMetallic(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
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
						#define GetEdgeSoftenDisabled(val) val.Packed2.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
						#define GetImageUV(val) val.ImageUV
						#define SetImageUV(val, toSet) val.ImageUV = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNCornerOrigin(val) val.Packed1.xy
					#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
					#define GetNCornerRadius(val) val.Packed1.z
					#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
					#define GetNShadowRadius(val) val.Packed1.w
					#define SetNShadowRadius(val, toSet) val.Packed1.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNShadowBlur(val) val.Packed2.w
						#define SetNShadowBlur(val, toSet) val.Packed2.w = toSet
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed3.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSpecular(val) val.Packed6.x
							#define SetSpecular(val, toSet) val.Packed6.x = toSet
							#define GetGloss(val) val.Packed6.y
							#define SetGloss(val, toSet) val.Packed6.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed6.x
							#define SetSmoothness(val, toSet) val.Packed6.x = toSet
							#define GetMetallic(val) val.Packed6.y
							#define SetMetallic(val, toSet) val.Packed6.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
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
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetRootPos(val) val.Packed2.xyz
						#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
						#define GetNShadowSpacePos(val) half2(val.Packed2.w, val.Packed3.z)
						#define SetNShadowSpacePos(val, toSet) \
							val.Packed2.w = toSet.x; \
							val.Packed3.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed1.xyz
						#define SetWorldNormal(val, toSet) val.Packed1.xyz = toSet
						#define GetNCornerRadius(val) val.Packed1.w
						#define SetNCornerRadius(val, toSet) val.Packed1.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed2.xyz
							#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetNCornerOrigin(val) val.Packed4.xy
							#define SetNCornerOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
							#define GetImageUV(val) float2(val.Packed2.w, val.Packed3.w)
							#define SetImageUV(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.w = toSet.y;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSpecular(val) val.Packed2.z
							#define SetSpecular(val, toSet) val.Packed2.z = toSet
							#define GetGloss(val) val.Packed2.w
							#define SetGloss(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSmoothness(val) val.Packed2.z
							#define SetSmoothness(val, toSet) val.Packed2.z = toSet
							#define GetMetallic(val) val.Packed2.w
							#define SetMetallic(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed2.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.x = toSet
							#define GetSpecularColor(val) val.Packed2.yzw
							#define SetSpecularColor(val, toSet) val.Packed2.yzw = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetNCornerOrigin(val) val.Packed5.xy
							#define SetNCornerOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetSmoothness(val) val.Packed5.z
							#define SetSmoothness(val, toSet) val.Packed5.z = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetRootPos(val) val.Packed1.xyz
						#define SetRootPos(val, toSet) val.Packed1.xyz = toSet
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetNCornerOrigin(val) half2(val.Packed1.w, val.Packed2.z)
						#define SetNCornerOrigin(val, toSet) \
							val.Packed1.w = toSet.x; \
							val.Packed2.z = toSet.y;
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetNCornerOrigin(val) val.Packed1.xy
				#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
				#define GetNCornerRadius(val) val.Packed1.z
				#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
				#define GetBorderNWidth(val) val.Packed1.w
				#define SetBorderNWidth(val, toSet) val.Packed1.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define GetWorldNormal(val) half3(val.Packed3.w, val.Packed4.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.zw = toSet.yz;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetNShadowOrigin(val) half2(val.Packed5.w, val.Packed6.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.z = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowOrigin(val) val.Packed3.zw
						#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed2.xyz
							#define SetWorldPos(val, toSet) val.Packed2.xyz = toSet
							#define GetImageUV(val) val.Packed3.xy
							#define SetImageUV(val, toSet) val.Packed3.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed2.w, val.Packed3.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.zw = toSet.yz;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#endif
					#else
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.z = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNCornerOrigin(val) val.Packed1.xy
					#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
					#define GetNCornerRadius(val) val.Packed1.z
					#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
					#define GetNShadowRadius(val) val.Packed1.w
					#define SetNShadowRadius(val, toSet) val.Packed1.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNShadowBlur(val) val.Packed2.w
						#define SetNShadowBlur(val, toSet) val.Packed2.w = toSet
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed3.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSpecular(val) val.Packed4.w
							#define SetSpecular(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetGloss(val) val.Packed5.z
							#define SetGloss(val, toSet) val.Packed5.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetMetallic(val) val.Packed5.z
							#define SetMetallic(val, toSet) val.Packed5.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed2.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowBlur(val) val.Packed3.z
						#define SetNShadowBlur(val, toSet) val.Packed3.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed1.xyz
						#define SetWorldNormal(val, toSet) val.Packed1.xyz = toSet
						#define GetNCornerRadius(val) val.Packed1.w
						#define SetNCornerRadius(val, toSet) val.Packed1.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed2.xyz
							#define SetWorldPos(val, toSet) val.Packed2.xyz = toSet
							#define GetImageUV(val) val.Packed3.xy
							#define SetImageUV(val, toSet) val.Packed3.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetNCornerOrigin(val) half2(val.Packed2.w, val.Packed3.z)
							#define SetNCornerOrigin(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.z = toSet.y;
							#define POST_NOVA_0 6
							#define POST_NOVA_1 7
							#define POST_NOVA_2 8
							#define POST_NOVA_3 9
							#define POST_NOVA_4 10
							#define POST_NOVA_5 11
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSpecular(val) val.Packed2.z
							#define SetSpecular(val, toSet) val.Packed2.z = toSet
							#define GetGloss(val) val.Packed2.w
							#define SetGloss(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSmoothness(val) val.Packed2.z
							#define SetSmoothness(val, toSet) val.Packed2.z = toSet
							#define GetMetallic(val) val.Packed2.w
							#define SetMetallic(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed2.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.x = toSet
							#define GetSpecularColor(val) val.Packed2.yzw
							#define SetSpecularColor(val, toSet) val.Packed2.yzw = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetNCornerOrigin(val) half2(val.Packed3.w, val.Packed4.z)
							#define SetNCornerOrigin(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.z = toSet.y;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#endif
					#else
						#define GetImageUV(val) val.Packed1.xy
						#define SetImageUV(val, toSet) val.Packed1.xy = toSet
						#define GetNCornerOrigin(val) val.Packed1.zw
						#define SetNCornerOrigin(val, toSet) val.Packed1.zw = toSet
						#define GetNCornerRadius(val) val.Packed2.x
						#define SetNCornerRadius(val, toSet) val.Packed2.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.y = toSet
					#endif
				#endif
			#endif
		#endif
	#endif
#elif defined(NOVA_STATIC_IMAGE)
	#define GetNCornerOrigin(val) val.Packed1.xy
	#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
	#define GetNCornerRadius(val) val.Packed1.z
	#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
	#define GetTextureBufferIndex(val) val.Packed1.w
	#define SetTextureBufferIndex(val, toSet) val.Packed1.w = toSet
	#if defined(NOVA_RADIAL_FILL)
		#define GetRadialFillSpacePos(val) val.Packed2.xy
		#define SetRadialFillSpacePos(val, toSet) val.Packed2.xy = toSet
		#define GetRadialFillSinCos(val) val.Packed2.zw
		#define SetRadialFillSinCos(val, toSet) val.Packed2.zw = toSet
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowSpacePos(val) val.Packed3.xy
					#define SetNShadowSpacePos(val, toSet) val.Packed3.xy = toSet
					#define GetBorderNWidth(val) val.Packed3.z
					#define SetBorderNWidth(val, toSet) val.Packed3.z = toSet
					#define GetNShadowRadius(val) val.Packed3.w
					#define SetNShadowRadius(val, toSet) val.Packed3.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed4.xyz
						#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
						#define GetNShadowBlur(val) val.Packed4.w
						#define SetNShadowBlur(val, toSet) val.Packed4.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetNShadowOrigin(val) val.Packed7.xy
							#define SetNShadowOrigin(val, toSet) val.Packed7.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.z = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetSpecular(val) val.Packed5.z
							#define SetSpecular(val, toSet) val.Packed5.z = toSet
							#define GetGloss(val) val.Packed5.w
							#define SetGloss(val, toSet) val.Packed5.w = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 13
							#define POST_NOVA_1 14
							#define POST_NOVA_2 15
							#define POST_NOVA_3 16
							#define POST_NOVA_4 17
							#define POST_NOVA_5 18
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetSmoothness(val) val.Packed5.z
							#define SetSmoothness(val, toSet) val.Packed5.z = toSet
							#define GetMetallic(val) val.Packed5.w
							#define SetMetallic(val, toSet) val.Packed5.w = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 13
							#define POST_NOVA_1 14
							#define POST_NOVA_2 15
							#define POST_NOVA_3 16
							#define POST_NOVA_4 17
							#define POST_NOVA_5 18
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetNShadowOrigin(val) val.Packed8.xy
							#define SetNShadowOrigin(val, toSet) val.Packed8.xy = toSet
							#define GetSmoothness(val) val.Packed8.z
							#define SetSmoothness(val, toSet) val.Packed8.z = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 13
							#define POST_NOVA_1 14
							#define POST_NOVA_2 15
							#define POST_NOVA_3 16
							#define POST_NOVA_4 17
							#define POST_NOVA_5 18
						#endif
					#else
						#define GetRootPos(val) val.Packed4.xyz
						#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
						#define GetImageUV(val) val.Packed5.xy
						#define SetImageUV(val, toSet) val.Packed5.xy = toSet
						#define GetNShadowBlur(val) val.Packed5.w
						#define SetNShadowBlur(val, toSet) val.Packed5.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed4.w = toSet.x; \
							val.Packed5.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetBorderNWidth(val) val.Packed3.x
						#define SetBorderNWidth(val, toSet) val.Packed3.x = toSet
						#define GetWorldNormal(val) val.Packed3.yzw
						#define SetWorldNormal(val, toSet) val.Packed3.yzw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSpecular(val) val.Packed6.x
							#define SetSpecular(val, toSet) val.Packed6.x = toSet
							#define GetGloss(val) val.Packed6.y
							#define SetGloss(val, toSet) val.Packed6.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed6.x
							#define SetSmoothness(val, toSet) val.Packed6.x = toSet
							#define GetMetallic(val) val.Packed6.y
							#define SetMetallic(val, toSet) val.Packed6.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
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
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetBorderNWidth(val) val.Packed3.w
						#define SetBorderNWidth(val, toSet) val.Packed3.w = toSet
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldNormal(val) val.Packed7.xyz
							#define SetWorldNormal(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.w = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldNormal(val) val.Packed7.xyz
							#define SetWorldNormal(val, toSet) val.Packed7.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed7.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed7.w = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed6.w, val.Packed7.w)
							#define SetImageUV(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetRootPos(val) val.Packed4.xyz
						#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
						#define GetImageUV(val) val.Packed5.xy
						#define SetImageUV(val, toSet) val.Packed5.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed5.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
						#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed4.w = toSet.x; \
							val.Packed5.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetGloss(val) val.Packed6.x
							#define SetGloss(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetMetallic(val) val.Packed6.x
							#define SetMetallic(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
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
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
						#define GetImageUV(val) val.ImageUV
						#define SetImageUV(val, toSet) val.ImageUV = toSet
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowSpacePos(val) val.Packed3.xy
					#define SetNShadowSpacePos(val, toSet) val.Packed3.xy = toSet
					#define GetBorderNWidth(val) val.Packed3.z
					#define SetBorderNWidth(val, toSet) val.Packed3.z = toSet
					#define GetNShadowRadius(val) val.Packed3.w
					#define SetNShadowRadius(val, toSet) val.Packed3.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed4.xyz
						#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
						#define GetNShadowBlur(val) val.Packed4.w
						#define SetNShadowBlur(val, toSet) val.Packed4.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed5.w, val.Packed6.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.z = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetSpecular(val) val.Packed5.z
							#define SetSpecular(val, toSet) val.Packed5.z = toSet
							#define GetGloss(val) val.Packed5.w
							#define SetGloss(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetSmoothness(val) val.Packed5.z
							#define SetSmoothness(val, toSet) val.Packed5.z = toSet
							#define GetMetallic(val) val.Packed5.w
							#define SetMetallic(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetImageUV(val) val.Packed7.xy
							#define SetImageUV(val, toSet) val.Packed7.xy = toSet
							#define GetSmoothness(val) val.Packed7.w
							#define SetSmoothness(val, toSet) val.Packed7.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed6.w, val.Packed7.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.z = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowOrigin(val) val.Packed4.zw
						#define SetNShadowOrigin(val, toSet) val.Packed4.zw = toSet
						#define GetNShadowBlur(val) val.Packed5.x
						#define SetNShadowBlur(val, toSet) val.Packed5.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed5.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetBorderNWidth(val) val.Packed3.x
						#define SetBorderNWidth(val, toSet) val.Packed3.x = toSet
						#define GetWorldNormal(val) val.Packed3.yzw
						#define SetWorldNormal(val, toSet) val.Packed3.yzw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSpecular(val) val.Packed4.w
							#define SetSpecular(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetGloss(val) val.Packed5.z
							#define SetGloss(val, toSet) val.Packed5.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetMetallic(val) val.Packed5.z
							#define SetMetallic(val, toSet) val.Packed5.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetBorderNWidth(val) val.Packed3.z
						#define SetBorderNWidth(val, toSet) val.Packed3.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetNShadowOrigin(val) val.Packed6.xy
							#define SetNShadowOrigin(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed5.w, val.Packed6.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.zw = toSet.yz;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed5.w, val.Packed6.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.zw = toSet.yz;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetImageUV(val) val.Packed7.xy
							#define SetImageUV(val, toSet) val.Packed7.xy = toSet
							#define GetNShadowOrigin(val) half2(val.Packed6.w, val.Packed7.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.z = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowOrigin(val) val.Packed4.zw
						#define SetNShadowOrigin(val, toSet) val.Packed4.zw = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed3.w, val.Packed4.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.zw = toSet.yz;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
					#endif
				#endif
			#endif
		#endif
	#else
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowSpacePos(val) val.Packed2.xy
					#define SetNShadowSpacePos(val, toSet) val.Packed2.xy = toSet
					#define GetBorderNWidth(val) val.Packed2.z
					#define SetBorderNWidth(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetNShadowOrigin(val) val.Packed6.xy
							#define SetNShadowOrigin(val, toSet) val.Packed6.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.z = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetNShadowOrigin(val) val.Packed7.xy
							#define SetNShadowOrigin(val, toSet) val.Packed7.xy = toSet
							#define GetSmoothness(val) val.Packed7.z
							#define SetSmoothness(val, toSet) val.Packed7.z = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowBlur(val) val.Packed4.w
						#define SetNShadowBlur(val, toSet) val.Packed4.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed3.w = toSet.x; \
							val.Packed4.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetBorderNWidth(val) val.Packed2.x
						#define SetBorderNWidth(val, toSet) val.Packed2.x = toSet
						#define GetWorldNormal(val) val.Packed2.yzw
						#define SetWorldNormal(val, toSet) val.Packed2.yzw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSpecular(val) val.Packed5.x
							#define SetSpecular(val, toSet) val.Packed5.x = toSet
							#define GetGloss(val) val.Packed5.y
							#define SetGloss(val, toSet) val.Packed5.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed5.x
							#define SetSmoothness(val, toSet) val.Packed5.x = toSet
							#define GetMetallic(val) val.Packed5.y
							#define SetMetallic(val, toSet) val.Packed5.y = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
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
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetRootPos(val) val.Packed2.xyz
						#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
						#define GetBorderNWidth(val) val.Packed2.w
						#define SetBorderNWidth(val, toSet) val.Packed2.w = toSet
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define GetImageUV(val) float2(val.Packed5.w, val.Packed6.w)
							#define SetImageUV(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetImageUV(val) val.Packed4.xy
						#define SetImageUV(val, toSet) val.Packed4.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
						#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed3.w = toSet.x; \
							val.Packed4.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed2.xyz
							#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) float2(val.Packed2.w, val.Packed3.w)
							#define SetImageUV(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.w = toSet.y;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed5.x
							#define SetGloss(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed5.x
							#define SetMetallic(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define GetImageUV(val) float2(val.Packed3.w, val.Packed4.w)
							#define SetImageUV(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) float2(val.Packed4.w, val.Packed5.w)
							#define SetImageUV(val, toSet) \
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
						#define GetEdgeSoftenDisabled(val) val.Packed2.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
						#define GetImageUV(val) val.ImageUV
						#define SetImageUV(val, toSet) val.ImageUV = toSet
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowSpacePos(val) val.Packed2.xy
					#define SetNShadowSpacePos(val, toSet) val.Packed2.xy = toSet
					#define GetBorderNWidth(val) val.Packed2.z
					#define SetBorderNWidth(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.z = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetSmoothness(val) val.Packed6.w
							#define SetSmoothness(val, toSet) val.Packed6.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed5.w, val.Packed6.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.z = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowOrigin(val) val.Packed3.zw
						#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
						#define GetNShadowBlur(val) val.Packed4.x
						#define SetNShadowBlur(val, toSet) val.Packed4.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.y = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetBorderNWidth(val) val.Packed2.x
						#define SetBorderNWidth(val, toSet) val.Packed2.x = toSet
						#define GetWorldNormal(val) val.Packed2.yzw
						#define SetWorldNormal(val, toSet) val.Packed2.yzw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetGloss(val) val.Packed4.z
							#define SetGloss(val, toSet) val.Packed4.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetMetallic(val) val.Packed4.z
							#define SetMetallic(val, toSet) val.Packed4.z = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#endif
					#else
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetBorderNWidth(val) val.Packed2.z
						#define SetBorderNWidth(val, toSet) val.Packed2.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetNShadowOrigin(val) val.Packed5.xy
							#define SetNShadowOrigin(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.z = toSet
							#define GetWorldNormal(val) half3(val.Packed3.w, val.Packed4.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.zw = toSet.yz;
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed3.xy
							#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetImageUV(val) val.Packed5.xy
							#define SetImageUV(val, toSet) val.Packed5.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed4.w, val.Packed5.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.zw = toSet.yz;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetImageUV(val) val.Packed6.xy
							#define SetImageUV(val, toSet) val.Packed6.xy = toSet
							#define GetNShadowOrigin(val) half2(val.Packed5.w, val.Packed6.z)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.z = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetImageUV(val) val.Packed3.xy
						#define SetImageUV(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowOrigin(val) val.Packed3.zw
						#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed2.xyz
							#define SetWorldPos(val, toSet) val.Packed2.xyz = toSet
							#define GetImageUV(val) val.Packed3.xy
							#define SetImageUV(val, toSet) val.Packed3.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetWorldNormal(val) half3(val.Packed2.w, val.Packed3.zw)
							#define SetWorldNormal(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.zw = toSet.yz;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetImageUV(val) val.Packed4.xy
							#define SetImageUV(val, toSet) val.Packed4.xy = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.z
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetImageUV(val) val.ImageUV
							#define SetImageUV(val, toSet) val.ImageUV = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetImageUV(val) val.Packed2.xy
						#define SetImageUV(val, toSet) val.Packed2.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.z = toSet
					#endif
				#endif
			#endif
		#endif
	#endif
#else
	#if defined(NOVA_RADIAL_FILL)
		#define GetRadialFillSpacePos(val) val.Packed1.xy
		#define SetRadialFillSpacePos(val, toSet) val.Packed1.xy = toSet
		#define GetNCornerOrigin(val) val.Packed1.zw
		#define SetNCornerOrigin(val, toSet) val.Packed1.zw = toSet
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetRadialFillSinCos(val) val.Packed2.xy
				#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
				#define GetNCornerRadius(val) val.Packed2.z
				#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
				#define GetBorderNWidth(val) val.Packed2.w
				#define SetBorderNWidth(val, toSet) val.Packed2.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldNormal(val) val.Packed6.xyz
							#define SetWorldNormal(val, toSet) val.Packed6.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetWorldPos(val) val.Packed7.xyz
							#define SetWorldPos(val, toSet) val.Packed7.xyz = toSet
							#define GetNShadowOrigin(val) half2(val.Packed6.w, val.Packed7.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed6.w = toSet.x; \
								val.Packed7.w = toSet.y;
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetRootPos(val) val.Packed4.xyz
						#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
						#define GetNShadowOrigin(val) val.NShadowOrigin
						#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.RootPos
							#define SetRootPos(val, toSet) val.RootPos = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetRadialFillSinCos(val) val.Packed2.xy
					#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
					#define GetNCornerRadius(val) val.Packed2.z
					#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed4.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed4.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSpecular(val) val.Packed5.w
							#define SetSpecular(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetGloss(val) val.Packed6.w
							#define SetGloss(val, toSet) val.Packed6.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetMetallic(val) val.Packed6.w
							#define SetMetallic(val, toSet) val.Packed6.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetRootPos(val) val.Packed6.xyz
							#define SetRootPos(val, toSet) val.Packed6.xyz = toSet
							#define GetSmoothness(val) val.Packed6.w
							#define SetSmoothness(val, toSet) val.Packed6.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowSpacePos(val) val.Packed4.xy
						#define SetNShadowSpacePos(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowBlur(val) val.Packed4.w
						#define SetNShadowBlur(val, toSet) val.Packed4.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed3.w = toSet.x; \
							val.Packed4.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetRadialFillSinCos(val) half2(val.Packed3.w, val.Packed4.w)
							#define SetRadialFillSinCos(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
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
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
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
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
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
							#define GetRadialFillSinCos(val) half2(val.Packed4.w, val.Packed5.w)
							#define SetRadialFillSinCos(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
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
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#define GetRadialFillSinCos(val) val.Packed3.xy
						#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetRadialFillSinCos(val) val.Packed2.xy
				#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
				#define GetNCornerRadius(val) val.Packed2.z
				#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
				#define GetBorderNWidth(val) val.Packed2.w
				#define SetBorderNWidth(val, toSet) val.Packed2.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed3.x
					#define SetNShadowRadius(val, toSet) val.Packed3.x = toSet
					#define GetNShadowBlur(val) val.Packed3.y
					#define SetNShadowBlur(val, toSet) val.Packed3.y = toSet
					#define GetNShadowSpacePos(val) val.Packed3.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetNShadowOrigin(val) half2(val.Packed4.w, val.Packed5.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed4.w = toSet.x; \
								val.Packed5.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSpecular(val) val.Packed4.z
							#define SetSpecular(val, toSet) val.Packed4.z = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNShadowOrigin(val) val.Packed4.xy
							#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
							#define GetSmoothness(val) val.Packed4.z
							#define SetSmoothness(val, toSet) val.Packed4.z = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define POST_NOVA_0 12
							#define POST_NOVA_1 13
							#define POST_NOVA_2 14
							#define POST_NOVA_3 15
							#define POST_NOVA_4 16
							#define POST_NOVA_5 17
						#endif
					#else
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.z = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSpecular(val) val.Packed3.w
							#define SetSpecular(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetGloss(val) val.Packed4.w
							#define SetGloss(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetMetallic(val) val.Packed4.w
							#define SetMetallic(val, toSet) val.Packed4.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#endif
					#else
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetRadialFillSinCos(val) val.Packed2.xy
					#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
					#define GetNCornerRadius(val) val.Packed2.z
					#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
					#define GetNShadowRadius(val) val.Packed2.w
					#define SetNShadowRadius(val, toSet) val.Packed2.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed3.xyz
						#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.Packed4.xy
						#define SetNShadowOrigin(val, toSet) val.Packed4.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed4.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed4.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSpecular(val) val.Packed5.w
							#define SetSpecular(val, toSet) val.Packed5.w = toSet
							#define GetGloss(val) val.Packed6.x
							#define SetGloss(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetMetallic(val) val.Packed6.x
							#define SetMetallic(val, toSet) val.Packed6.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed6.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed6.y = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed5.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.x = toSet
							#define GetSpecularColor(val) val.Packed5.yzw
							#define SetSpecularColor(val, toSet) val.Packed5.yzw = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetSmoothness(val) val.Packed6.w
							#define SetSmoothness(val, toSet) val.Packed6.w = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetNShadowSpacePos(val) val.Packed3.xy
						#define SetNShadowSpacePos(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowOrigin(val) val.Packed3.zw
						#define SetNShadowOrigin(val, toSet) val.Packed3.zw = toSet
						#define GetNShadowBlur(val) val.Packed4.x
						#define SetNShadowBlur(val, toSet) val.Packed4.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed4.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.y = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNCornerRadius(val) val.Packed2.w
						#define SetNCornerRadius(val, toSet) val.Packed2.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetRadialFillSinCos(val) val.RadialFillSinCos
							#define SetRadialFillSinCos(val, toSet) val.RadialFillSinCos = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSpecular(val) val.Packed3.z
							#define SetSpecular(val, toSet) val.Packed3.z = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRadialFillSinCos(val) val.Packed3.xy
							#define SetRadialFillSinCos(val, toSet) val.Packed3.xy = toSet
							#define GetSmoothness(val) val.Packed3.z
							#define SetSmoothness(val, toSet) val.Packed3.z = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
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
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetRadialFillSinCos(val) val.RadialFillSinCos
							#define SetRadialFillSinCos(val, toSet) val.RadialFillSinCos = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetRadialFillSinCos(val) val.Packed2.xy
						#define SetRadialFillSinCos(val, toSet) val.Packed2.xy = toSet
						#define GetNCornerRadius(val) val.Packed2.z
						#define SetNCornerRadius(val, toSet) val.Packed2.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
					#endif
				#endif
			#endif
		#endif
	#else
		#if defined(NOVA_CLIPPING)
			#if defined(NOVA_BORDER)
				#define GetNCornerOrigin(val) val.Packed1.xy
				#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
				#define GetNCornerRadius(val) val.Packed1.z
				#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
				#define GetBorderNWidth(val) val.Packed1.w
				#define SetBorderNWidth(val, toSet) val.Packed1.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetWorldNormal(val) val.Packed5.xyz
							#define SetWorldNormal(val, toSet) val.Packed5.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.w = toSet
							#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetWorldPos(val) val.Packed6.xyz
							#define SetWorldPos(val, toSet) val.Packed6.xyz = toSet
							#define GetNShadowOrigin(val) half2(val.Packed5.w, val.Packed6.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed5.w = toSet.x; \
								val.Packed6.w = toSet.y;
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetRootPos(val) val.Packed3.xyz
						#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
						#define GetNShadowOrigin(val) val.NShadowOrigin
						#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed2.xyz
							#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed2.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetRootPos(val) val.RootPos
							#define SetRootPos(val, toSet) val.RootPos = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
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
						#define GetEdgeSoftenDisabled(val) val.Packed2.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNCornerOrigin(val) val.Packed1.xy
					#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
					#define GetNCornerRadius(val) val.Packed1.z
					#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
					#define GetNShadowRadius(val) val.Packed1.w
					#define SetNShadowRadius(val, toSet) val.Packed1.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNShadowBlur(val) val.Packed2.w
						#define SetNShadowBlur(val, toSet) val.Packed2.w = toSet
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed3.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSpecular(val) val.Packed4.w
							#define SetSpecular(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetGloss(val) val.Packed5.w
							#define SetGloss(val, toSet) val.Packed5.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetRootPos(val) val.Packed4.xyz
							#define SetRootPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetMetallic(val) val.Packed5.w
							#define SetMetallic(val, toSet) val.Packed5.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetRootPos(val) val.Packed5.xyz
							#define SetRootPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#endif
					#else
						#define GetRootPos(val) val.Packed2.xyz
						#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
						#define GetNShadowSpacePos(val) val.Packed3.xy
						#define SetNShadowSpacePos(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowBlur(val) val.Packed3.w
						#define SetNShadowBlur(val, toSet) val.Packed3.w = toSet
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
						#define GetNShadowOrigin(val) half2(val.Packed2.w, val.Packed3.z)
						#define SetNShadowOrigin(val, toSet) \
							val.Packed2.w = toSet.x; \
							val.Packed3.z = toSet.y;
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed1.xyz
						#define SetWorldNormal(val, toSet) val.Packed1.xyz = toSet
						#define GetNCornerRadius(val) val.Packed1.w
						#define SetNCornerRadius(val, toSet) val.Packed1.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetRootPos(val) val.Packed2.xyz
							#define SetRootPos(val, toSet) val.Packed2.xyz = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetNCornerOrigin(val) half2(val.Packed2.w, val.Packed3.w)
							#define SetNCornerOrigin(val, toSet) \
								val.Packed2.w = toSet.x; \
								val.Packed3.w = toSet.y;
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSpecular(val) val.Packed2.z
							#define SetSpecular(val, toSet) val.Packed2.z = toSet
							#define GetGloss(val) val.Packed2.w
							#define SetGloss(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSmoothness(val) val.Packed2.z
							#define SetSmoothness(val, toSet) val.Packed2.z = toSet
							#define GetMetallic(val) val.Packed2.w
							#define SetMetallic(val, toSet) val.Packed2.w = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed2.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.x = toSet
							#define GetSpecularColor(val) val.Packed2.yzw
							#define SetSpecularColor(val, toSet) val.Packed2.yzw = toSet
							#define GetRootPos(val) val.Packed3.xyz
							#define SetRootPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Smoothness
							#define SetSmoothness(val, toSet) val.Smoothness = toSet
							#define GetNCornerOrigin(val) half2(val.Packed3.w, val.Packed4.w)
							#define SetNCornerOrigin(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetRootPos(val) val.Packed1.xyz
						#define SetRootPos(val, toSet) val.Packed1.xyz = toSet
						#define GetNCornerRadius(val) val.Packed1.w
						#define SetNCornerRadius(val, toSet) val.Packed1.w = toSet
						#define GetNCornerOrigin(val) val.Packed2.xy
						#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed2.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.z = toSet
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_BORDER)
				#define GetNCornerOrigin(val) val.Packed1.xy
				#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
				#define GetNCornerRadius(val) val.Packed1.z
				#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
				#define GetBorderNWidth(val) val.Packed1.w
				#define SetBorderNWidth(val, toSet) val.Packed1.w = toSet
				#define GetBorderColor(val) val.BorderColor
				#define SetBorderColor(val, toSet) val.BorderColor = toSet
				#if defined(NOVA_INNER_SHADOW)
					#define GetNShadowRadius(val) val.Packed2.x
					#define SetNShadowRadius(val, toSet) val.Packed2.x = toSet
					#define GetNShadowBlur(val) val.Packed2.y
					#define SetNShadowBlur(val, toSet) val.Packed2.y = toSet
					#define GetNShadowSpacePos(val) val.Packed2.zw
					#define SetNShadowSpacePos(val, toSet) val.Packed2.zw = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetWorldNormal(val) val.Packed4.xyz
							#define SetWorldNormal(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define GetNShadowOrigin(val) half2(val.Packed3.w, val.Packed4.w)
							#define SetNShadowOrigin(val, toSet) \
								val.Packed3.w = toSet.x; \
								val.Packed4.w = toSet.y;
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
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
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 10
							#define POST_NOVA_1 11
							#define POST_NOVA_2 12
							#define POST_NOVA_3 13
							#define POST_NOVA_4 14
							#define POST_NOVA_5 15
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed3.xyz
							#define SetWorldNormal(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define GetNShadowOrigin(val) val.NShadowOrigin
							#define SetNShadowOrigin(val, toSet) val.NShadowOrigin = toSet
							#define POST_NOVA_0 11
							#define POST_NOVA_1 12
							#define POST_NOVA_2 13
							#define POST_NOVA_3 14
							#define POST_NOVA_4 15
							#define POST_NOVA_5 16
						#endif
					#else
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.z
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.z = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed2.xyz
							#define SetWorldPos(val, toSet) val.Packed2.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed2.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
							#define GetWorldNormal(val) val.WorldNormal
							#define SetWorldNormal(val, toSet) val.WorldNormal = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSpecular(val) val.Packed2.w
							#define SetSpecular(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetGloss(val) val.Packed3.w
							#define SetGloss(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetMetallic(val) val.Packed3.w
							#define SetMetallic(val, toSet) val.Packed3.w = toSet
							#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
							#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetWorldNormal(val) val.Packed2.xyz
							#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
							#define GetSmoothness(val) val.Packed2.w
							#define SetSmoothness(val, toSet) val.Packed2.w = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.x = toSet
							#define GetSpecularColor(val) val.Packed3.yzw
							#define SetSpecularColor(val, toSet) val.Packed3.yzw = toSet
							#define GetWorldPos(val) val.WorldPos
							#define SetWorldPos(val, toSet) val.WorldPos = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#endif
					#else
						#define GetEdgeSoftenDisabled(val) val.EdgeSoftenDisabled
						#define SetEdgeSoftenDisabled(val, toSet) val.EdgeSoftenDisabled = toSet
					#endif
				#endif
			#else
				#if defined(NOVA_INNER_SHADOW)
					#define GetNCornerOrigin(val) val.Packed1.xy
					#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
					#define GetNCornerRadius(val) val.Packed1.z
					#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
					#define GetNShadowRadius(val) val.Packed1.w
					#define SetNShadowRadius(val, toSet) val.Packed1.w = toSet
					#define GetShadowColor(val) val.ShadowColor
					#define SetShadowColor(val, toSet) val.ShadowColor = toSet
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed2.xyz
						#define SetWorldNormal(val, toSet) val.Packed2.xyz = toSet
						#define GetNShadowBlur(val) val.Packed2.w
						#define SetNShadowBlur(val, toSet) val.Packed2.w = toSet
						#define GetNShadowOrigin(val) val.Packed3.xy
						#define SetNShadowOrigin(val, toSet) val.Packed3.xy = toSet
						#define GetNShadowSpacePos(val) val.Packed3.zw
						#define SetNShadowSpacePos(val, toSet) val.Packed3.zw = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed4.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.w = toSet
							#define POST_NOVA_0 8
							#define POST_NOVA_1 9
							#define POST_NOVA_2 10
							#define POST_NOVA_3 11
							#define POST_NOVA_4 12
							#define POST_NOVA_5 13
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSpecular(val) val.Packed4.w
							#define SetSpecular(val, toSet) val.Packed4.w = toSet
							#define GetGloss(val) val.Packed5.x
							#define SetGloss(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetWorldPos(val) val.Packed4.xyz
							#define SetWorldPos(val, toSet) val.Packed4.xyz = toSet
							#define GetSmoothness(val) val.Packed4.w
							#define SetSmoothness(val, toSet) val.Packed4.w = toSet
							#define GetMetallic(val) val.Packed5.x
							#define SetMetallic(val, toSet) val.Packed5.x = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed5.y
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed5.y = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed4.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed4.x = toSet
							#define GetSpecularColor(val) val.Packed4.yzw
							#define SetSpecularColor(val, toSet) val.Packed4.yzw = toSet
							#define GetWorldPos(val) val.Packed5.xyz
							#define SetWorldPos(val, toSet) val.Packed5.xyz = toSet
							#define GetSmoothness(val) val.Packed5.w
							#define SetSmoothness(val, toSet) val.Packed5.w = toSet
							#define POST_NOVA_0 9
							#define POST_NOVA_1 10
							#define POST_NOVA_2 11
							#define POST_NOVA_3 12
							#define POST_NOVA_4 13
							#define POST_NOVA_5 14
						#endif
					#else
						#define GetNShadowSpacePos(val) val.Packed2.xy
						#define SetNShadowSpacePos(val, toSet) val.Packed2.xy = toSet
						#define GetNShadowOrigin(val) val.Packed2.zw
						#define SetNShadowOrigin(val, toSet) val.Packed2.zw = toSet
						#define GetNShadowBlur(val) val.Packed3.x
						#define SetNShadowBlur(val, toSet) val.Packed3.x = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed3.y
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.y = toSet
					#endif
				#else
					#if defined(NOVA_LIT)
						#define GetWorldNormal(val) val.Packed1.xyz
						#define SetWorldNormal(val, toSet) val.Packed1.xyz = toSet
						#define GetNCornerRadius(val) val.Packed1.w
						#define SetNCornerRadius(val, toSet) val.Packed1.w = toSet
						#if defined(NOVA_LAMBERT_LIGHTING)
							#define GetWorldPos(val) val.Packed2.xyz
							#define SetWorldPos(val, toSet) val.Packed2.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed2.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.w = toSet
							#define GetNCornerOrigin(val) val.NCornerOrigin
							#define SetNCornerOrigin(val, toSet) val.NCornerOrigin = toSet
							#define POST_NOVA_0 6
							#define POST_NOVA_1 7
							#define POST_NOVA_2 8
							#define POST_NOVA_3 9
							#define POST_NOVA_4 10
							#define POST_NOVA_5 11
						#elif defined(NOVA_BLINNPHONG_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSpecular(val) val.Packed2.z
							#define SetSpecular(val, toSet) val.Packed2.z = toSet
							#define GetGloss(val) val.Packed2.w
							#define SetGloss(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define POST_NOVA_0 6
							#define POST_NOVA_1 7
							#define POST_NOVA_2 8
							#define POST_NOVA_3 9
							#define POST_NOVA_4 10
							#define POST_NOVA_5 11
						#elif defined(NOVA_STANDARD_LIGHTING)
							#define GetNCornerOrigin(val) val.Packed2.xy
							#define SetNCornerOrigin(val, toSet) val.Packed2.xy = toSet
							#define GetSmoothness(val) val.Packed2.z
							#define SetSmoothness(val, toSet) val.Packed2.z = toSet
							#define GetMetallic(val) val.Packed2.w
							#define SetMetallic(val, toSet) val.Packed2.w = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetEdgeSoftenDisabled(val) val.Packed3.w
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed3.w = toSet
							#define POST_NOVA_0 6
							#define POST_NOVA_1 7
							#define POST_NOVA_2 8
							#define POST_NOVA_3 9
							#define POST_NOVA_4 10
							#define POST_NOVA_5 11
						#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
							#define GetEdgeSoftenDisabled(val) val.Packed2.x
							#define SetEdgeSoftenDisabled(val, toSet) val.Packed2.x = toSet
							#define GetSpecularColor(val) val.Packed2.yzw
							#define SetSpecularColor(val, toSet) val.Packed2.yzw = toSet
							#define GetWorldPos(val) val.Packed3.xyz
							#define SetWorldPos(val, toSet) val.Packed3.xyz = toSet
							#define GetSmoothness(val) val.Packed3.w
							#define SetSmoothness(val, toSet) val.Packed3.w = toSet
							#define GetNCornerOrigin(val) val.NCornerOrigin
							#define SetNCornerOrigin(val, toSet) val.NCornerOrigin = toSet
							#define POST_NOVA_0 7
							#define POST_NOVA_1 8
							#define POST_NOVA_2 9
							#define POST_NOVA_3 10
							#define POST_NOVA_4 11
							#define POST_NOVA_5 12
						#endif
					#else
						#define GetNCornerOrigin(val) val.Packed1.xy
						#define SetNCornerOrigin(val, toSet) val.Packed1.xy = toSet
						#define GetNCornerRadius(val) val.Packed1.z
						#define SetNCornerRadius(val, toSet) val.Packed1.z = toSet
						#define GetEdgeSoftenDisabled(val) val.Packed1.w
						#define SetEdgeSoftenDisabled(val, toSet) val.Packed1.w = toSet
					#endif
				#endif
			#endif
		#endif
	#endif
#endif

struct v2f
{
	float4 pos : SV_POSITION;
	// xy: GradientSpaceUV
	// zw: NPos
	half4 Packed0 : TEXCOORD0;
	fixed4 Color : TEXCOORD1;
	fixed4 GradientColor : TEXCOORD2;
	#if defined(NOVA_DYNAMIC_IMAGE)
		#if defined(NOVA_RADIAL_FILL)
			// xy: RadialFillSpacePos
			// zw: NCornerOrigin
			half4 Packed1 : TEXCOORD3;
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					// xy: RadialFillSinCos
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed2 : TEXCOORD4;
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD10;
								half2 NShadowOrigin : TEXCOORD11;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed7 : TEXCOORD11;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed7 : TEXCOORD11;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD8;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD11;
								half2 NShadowOrigin : TEXCOORD12;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed4 : TEXCOORD8;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: EdgeSoftenDisabled
							float4 Packed5 : TEXCOORD9;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed3 : TEXCOORD6;
							float2 ImageUV : TEXCOORD7;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: RadialFillSinCos
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed4 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								// x: Specular
								// y: Gloss
								// z: EdgeSoftenDisabled
								half3 Packed7 : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								// x: Smoothness
								// y: Metallic
								// z: EdgeSoftenDisabled
								half3 Packed7 : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD10;
								half Smoothness : TEXCOORD11;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowSpacePos(x)
							float4 Packed3 : TEXCOORD6;
							// xy: ImageUV
							// z: NShadowSpacePos(y)
							// w: NShadowBlur
							float4 Packed4 : TEXCOORD7;
							// xy: NShadowOrigin
							// z: EdgeSoftenDisabled
							half3 Packed5 : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed2 : TEXCOORD4;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								// xy: RadialFillSinCos
								// z: EdgeSoftenDisabled
								half3 Packed5 : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: RadialFillSinCos
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: RadialFillSinCos
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
								// xy: RadialFillSinCos
								// z: Smoothness
								half3 Packed6 : TEXCOORD8;
							#endif
						#else
							// xyz: RootPos
							// w: RadialFillSinCos(x)
							float4 Packed2 : TEXCOORD4;
							// xy: ImageUV
							// z: RadialFillSinCos(y)
							// w: NCornerRadius
							float4 Packed3 : TEXCOORD5;
							fixed EdgeSoftenDisabled : TEXCOORD6;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					// xy: RadialFillSinCos
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed2 : TEXCOORD4;
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD8;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD9;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed5 : TEXCOORD9;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed6 : TEXCOORD10;
								fixed EdgeSoftenDisabled : TEXCOORD11;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed5 : TEXCOORD9;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed6 : TEXCOORD10;
								fixed EdgeSoftenDisabled : TEXCOORD11;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD8;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed6 : TEXCOORD10;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								float3 Packed7 : TEXCOORD11;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed4 : TEXCOORD8;
							fixed EdgeSoftenDisabled : TEXCOORD9;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed4 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								float3 WorldPos : TEXCOORD8;
								float2 ImageUV : TEXCOORD9;
							#endif
						#else
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed3 : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: RadialFillSinCos
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed4 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
								float2 ImageUV : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed5 : TEXCOORD8;
								// xy: ImageUV
								// z: Gloss
								// w: EdgeSoftenDisabled
								float4 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								// xy: ImageUV
								// z: Metallic
								// w: EdgeSoftenDisabled
								float4 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed6 : TEXCOORD9;
								float2 ImageUV : TEXCOORD10;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowSpacePos
							float4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// z: NShadowBlur
							// w: EdgeSoftenDisabled
							half4 Packed4 : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed2 : TEXCOORD4;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: RadialFillSinCos(x)
								float4 Packed3 : TEXCOORD5;
								// xy: ImageUV
								// z: RadialFillSinCos(y)
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: RadialFillSinCos
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
								float2 ImageUV : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: RadialFillSinCos
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
								float2 ImageUV : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: RadialFillSinCos(x)
								float4 Packed4 : TEXCOORD6;
								// xy: ImageUV
								// z: RadialFillSinCos(y)
								// w: Smoothness
								float4 Packed5 : TEXCOORD7;
							#endif
						#else
							// xy: ImageUV
							// zw: RadialFillSinCos
							float4 Packed2 : TEXCOORD4;
							// x: NCornerRadius
							// y: EdgeSoftenDisabled
							half2 Packed3 : TEXCOORD5;
						#endif
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					// xy: NCornerOrigin
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed1 : TEXCOORD3;
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed5 : TEXCOORD9;
								half2 NShadowOrigin : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								half2 NShadowOrigin : TEXCOORD11;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed3 : TEXCOORD7;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: EdgeSoftenDisabled
							float4 Packed4 : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed2 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed2 : TEXCOORD5;
							float2 ImageUV : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: NCornerOrigin
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed1 : TEXCOORD3;
						fixed4 ShadowColor : TEXCOORD4;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed2 : TEXCOORD5;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Specular
								// y: Gloss
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Smoothness
								// y: Metallic
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								half Smoothness : TEXCOORD10;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowSpacePos(x)
							float4 Packed2 : TEXCOORD5;
							// xy: ImageUV
							// z: NShadowSpacePos(y)
							// w: NShadowBlur
							float4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// z: EdgeSoftenDisabled
							half3 Packed4 : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed1 : TEXCOORD3;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed3 : TEXCOORD5;
								// xy: NCornerOrigin
								// z: EdgeSoftenDisabled
								half3 Packed4 : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NCornerOrigin
								// z: Specular
								// w: Gloss
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NCornerOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								// xy: NCornerOrigin
								// z: Smoothness
								half3 Packed5 : TEXCOORD7;
							#endif
						#else
							// xyz: RootPos
							// w: NCornerOrigin(x)
							float4 Packed1 : TEXCOORD3;
							// xy: ImageUV
							// z: NCornerOrigin(y)
							// w: NCornerRadius
							float4 Packed2 : TEXCOORD4;
							fixed EdgeSoftenDisabled : TEXCOORD5;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					// xy: NCornerOrigin
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed1 : TEXCOORD3;
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed3 : TEXCOORD7;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed4 : TEXCOORD8;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed5 : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD8;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD8;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed5 : TEXCOORD9;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								float3 Packed6 : TEXCOORD10;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed3 : TEXCOORD7;
							fixed EdgeSoftenDisabled : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed2 : TEXCOORD5;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed3 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD5;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
								float2 ImageUV : TEXCOORD8;
							#endif
						#else
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed2 : TEXCOORD5;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: NCornerOrigin
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed1 : TEXCOORD3;
						fixed4 ShadowColor : TEXCOORD4;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed2 : TEXCOORD5;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
								float2 ImageUV : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: Gloss
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: Metallic
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								float2 ImageUV : TEXCOORD9;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowSpacePos
							float4 Packed2 : TEXCOORD5;
							// xy: NShadowOrigin
							// z: NShadowBlur
							// w: EdgeSoftenDisabled
							half4 Packed3 : TEXCOORD6;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed1 : TEXCOORD3;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: NCornerOrigin(x)
								float4 Packed2 : TEXCOORD4;
								// xy: ImageUV
								// z: NCornerOrigin(y)
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NCornerOrigin
								// z: Specular
								// w: Gloss
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
								float2 ImageUV : TEXCOORD6;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NCornerOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
								float2 ImageUV : TEXCOORD6;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: NCornerOrigin(x)
								float4 Packed3 : TEXCOORD5;
								// xy: ImageUV
								// z: NCornerOrigin(y)
								// w: Smoothness
								float4 Packed4 : TEXCOORD6;
							#endif
						#else
							// xy: ImageUV
							// zw: NCornerOrigin
							float4 Packed1 : TEXCOORD3;
							// x: NCornerRadius
							// y: EdgeSoftenDisabled
							half2 Packed2 : TEXCOORD4;
						#endif
					#endif
				#endif
			#endif
		#endif
	#elif defined(NOVA_STATIC_IMAGE)
		// xy: NCornerOrigin
		// z: NCornerRadius
		// w: TextureBufferIndex
		half4 Packed1 : TEXCOORD3;
		#if defined(NOVA_RADIAL_FILL)
			// xy: RadialFillSpacePos
			// zw: RadialFillSinCos
			half4 Packed2 : TEXCOORD4;
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// xy: NShadowSpacePos
						// z: BorderNWidth
						// w: NShadowRadius
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed4 : TEXCOORD8;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed7 : TEXCOORD11;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed5 : TEXCOORD9;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD11;
								fixed EdgeSoftenDisabled : TEXCOORD12;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed5 : TEXCOORD9;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD11;
								fixed EdgeSoftenDisabled : TEXCOORD12;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD11;
								// xy: NShadowOrigin
								// z: Smoothness
								half3 Packed8 : TEXCOORD12;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed4 : TEXCOORD8;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: NShadowBlur
							float4 Packed5 : TEXCOORD9;
							fixed EdgeSoftenDisabled : TEXCOORD10;
						#endif
					#else
						#if defined(NOVA_LIT)
							// x: BorderNWidth
							// yzw: WorldNormal
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Specular
								// y: Gloss
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// x: Smoothness
								// y: Metallic
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								half Smoothness : TEXCOORD10;
							#endif
						#else
							// xyz: RootPos
							// w: BorderNWidth
							float4 Packed3 : TEXCOORD6;
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed4 : TEXCOORD7;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD9;
								half2 NShadowOrigin : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed7 : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed7 : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed6 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed7 : TEXCOORD10;
								half2 NShadowOrigin : TEXCOORD11;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed4 : TEXCOORD7;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: EdgeSoftenDisabled
							float4 Packed5 : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed5 : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD8;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed3 : TEXCOORD5;
							float2 ImageUV : TEXCOORD6;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// xy: NShadowSpacePos
						// z: BorderNWidth
						// w: NShadowRadius
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed4 : TEXCOORD8;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed5 : TEXCOORD9;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								// w: EdgeSoftenDisabled
								float4 Packed6 : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed6 : TEXCOORD10;
								float2 ImageUV : TEXCOORD11;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed6 : TEXCOORD10;
								float2 ImageUV : TEXCOORD11;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed6 : TEXCOORD10;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								// w: Smoothness
								float4 Packed7 : TEXCOORD11;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed4 : TEXCOORD8;
							// x: NShadowBlur
							// y: EdgeSoftenDisabled
							half2 Packed5 : TEXCOORD9;
						#endif
					#else
						#if defined(NOVA_LIT)
							// x: BorderNWidth
							// yzw: WorldNormal
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
								float2 ImageUV : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: Gloss
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// z: Metallic
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								float2 ImageUV : TEXCOORD9;
							#endif
						#else
							// xy: ImageUV
							// z: BorderNWidth
							// w: EdgeSoftenDisabled
							float4 Packed3 : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD8;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed5 : TEXCOORD8;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed6 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed5 : TEXCOORD8;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed6 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed6 : TEXCOORD9;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								float3 Packed7 : TEXCOORD10;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed4 : TEXCOORD7;
							fixed EdgeSoftenDisabled : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed3 : TEXCOORD5;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed4 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed4 : TEXCOORD6;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed5 : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed4 : TEXCOORD6;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed5 : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
								float2 ImageUV : TEXCOORD8;
							#endif
						#else
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed3 : TEXCOORD5;
						#endif
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// xy: NShadowSpacePos
						// z: BorderNWidth
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD9;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed6 : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								fixed EdgeSoftenDisabled : TEXCOORD11;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								fixed EdgeSoftenDisabled : TEXCOORD11;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD10;
								// xy: NShadowOrigin
								// z: Smoothness
								half3 Packed7 : TEXCOORD11;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed3 : TEXCOORD7;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: NShadowBlur
							float4 Packed4 : TEXCOORD8;
							fixed EdgeSoftenDisabled : TEXCOORD9;
						#endif
					#else
						#if defined(NOVA_LIT)
							// x: BorderNWidth
							// yzw: WorldNormal
							half4 Packed2 : TEXCOORD5;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// x: Specular
								// y: Gloss
								// z: EdgeSoftenDisabled
								half3 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// x: Smoothness
								// y: Metallic
								// z: EdgeSoftenDisabled
								half3 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								half Smoothness : TEXCOORD9;
							#endif
						#else
							// xyz: RootPos
							// w: BorderNWidth
							float4 Packed2 : TEXCOORD5;
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed3 : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed5 : TEXCOORD8;
								half2 NShadowOrigin : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed6 : TEXCOORD9;
								half2 NShadowOrigin : TEXCOORD10;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed3 : TEXCOORD6;
							// xy: ImageUV
							// z: NShadowOrigin(y)
							// w: EdgeSoftenDisabled
							float4 Packed4 : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed4 : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed4 : TEXCOORD6;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD4;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: ImageUV(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: ImageUV(y)
								float4 Packed5 : TEXCOORD7;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed2 : TEXCOORD4;
							float2 ImageUV : TEXCOORD5;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// xy: NShadowSpacePos
						// z: BorderNWidth
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed4 : TEXCOORD8;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								float2 ImageUV : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								float2 ImageUV : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed5 : TEXCOORD9;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								// w: Smoothness
								float4 Packed6 : TEXCOORD10;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed3 : TEXCOORD7;
							// x: NShadowBlur
							// y: EdgeSoftenDisabled
							half2 Packed4 : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							// x: BorderNWidth
							// yzw: WorldNormal
							half4 Packed2 : TEXCOORD5;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD6;
								float2 ImageUV : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// z: Gloss
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// z: Metallic
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD7;
								float2 ImageUV : TEXCOORD8;
							#endif
						#else
							// xy: ImageUV
							// z: BorderNWidth
							// w: EdgeSoftenDisabled
							float4 Packed2 : TEXCOORD5;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed3 : TEXCOORD6;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed4 : TEXCOORD7;
								// xy: NShadowOrigin
								// z: EdgeSoftenDisabled
								half3 Packed5 : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed4 : TEXCOORD7;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed5 : TEXCOORD8;
								// xy: ImageUV
								// z: NShadowOrigin(y)
								float3 Packed6 : TEXCOORD9;
							#endif
						#else
							// xy: ImageUV
							// zw: NShadowOrigin
							float4 Packed3 : TEXCOORD6;
							fixed EdgeSoftenDisabled : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: WorldNormal(x)
								float4 Packed2 : TEXCOORD4;
								// xy: ImageUV
								// zw: WorldNormal(yz)
								float4 Packed3 : TEXCOORD5;
								fixed EdgeSoftenDisabled : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed3 : TEXCOORD5;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed4 : TEXCOORD6;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed3 : TEXCOORD5;
								// xy: ImageUV
								// z: EdgeSoftenDisabled
								float3 Packed4 : TEXCOORD6;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD4;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								float3 WorldPos : TEXCOORD6;
								float2 ImageUV : TEXCOORD7;
							#endif
						#else
							// xy: ImageUV
							// z: EdgeSoftenDisabled
							float3 Packed2 : TEXCOORD4;
						#endif
					#endif
				#endif
			#endif
		#endif
	#else
		#if defined(NOVA_RADIAL_FILL)
			// xy: RadialFillSpacePos
			// zw: NCornerOrigin
			half4 Packed1 : TEXCOORD3;
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					// xy: RadialFillSinCos
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed2 : TEXCOORD4;
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: NShadowOrigin(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: NShadowOrigin(y)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed6 : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								float3 WorldPos : TEXCOORD10;
								half3 WorldNormal : TEXCOORD11;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								float3 WorldPos : TEXCOORD10;
								half3 WorldNormal : TEXCOORD11;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD8;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								// xyz: RootPos
								// w: NShadowOrigin(x)
								float4 Packed6 : TEXCOORD10;
								// xyz: WorldPos
								// w: NShadowOrigin(y)
								float4 Packed7 : TEXCOORD11;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed4 : TEXCOORD8;
							half2 NShadowOrigin : TEXCOORD9;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
								half3 WorldNormal : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: Gloss
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// xyz: RootPos
								// w: Metallic
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								float3 RootPos : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed3 : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: RadialFillSinCos
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed4 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: Specular
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed6 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed6 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: RootPos
								// w: Smoothness
								float4 Packed6 : TEXCOORD9;
								float3 WorldPos : TEXCOORD10;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed3 : TEXCOORD6;
							// xy: NShadowSpacePos
							// z: NShadowOrigin(y)
							// w: NShadowBlur
							half4 Packed4 : TEXCOORD7;
							fixed EdgeSoftenDisabled : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed2 : TEXCOORD4;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: RadialFillSinCos(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: RadialFillSinCos(y)
								float4 Packed4 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: RadialFillSinCos
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: RadialFillSinCos
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								// xyz: RootPos
								// w: RadialFillSinCos(x)
								float4 Packed4 : TEXCOORD6;
								// xyz: WorldPos
								// w: RadialFillSinCos(y)
								float4 Packed5 : TEXCOORD7;
								half Smoothness : TEXCOORD8;
							#endif
						#else
							// xyz: RootPos
							// w: NCornerRadius
							float4 Packed2 : TEXCOORD4;
							// xy: RadialFillSinCos
							// z: EdgeSoftenDisabled
							half3 Packed3 : TEXCOORD5;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					// xy: RadialFillSinCos
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed2 : TEXCOORD4;
					fixed4 BorderColor : TEXCOORD5;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed3 : TEXCOORD6;
						fixed4 ShadowColor : TEXCOORD7;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldNormal
								// w: NShadowOrigin(y)
								half4 Packed5 : TEXCOORD9;
								fixed EdgeSoftenDisabled : TEXCOORD10;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								half3 WorldNormal : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed4 : TEXCOORD8;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD9;
								half3 WorldNormal : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed4 : TEXCOORD8;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD9;
								float3 WorldPos : TEXCOORD10;
								half2 NShadowOrigin : TEXCOORD11;
							#endif
						#else
							// xy: NShadowOrigin
							// z: EdgeSoftenDisabled
							half3 Packed4 : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD6;
								half3 WorldNormal : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed4 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed4 : TEXCOORD7;
								fixed EdgeSoftenDisabled : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD6;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								float3 WorldPos : TEXCOORD8;
							#endif
						#else
							fixed EdgeSoftenDisabled : TEXCOORD6;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: RadialFillSinCos
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed2 : TEXCOORD4;
						fixed4 ShadowColor : TEXCOORD5;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD6;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed4 : TEXCOORD7;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed5 : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed5 : TEXCOORD8;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed6 : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed5 : TEXCOORD8;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed6 : TEXCOORD9;
							#endif
						#else
							// xy: NShadowSpacePos
							// zw: NShadowOrigin
							half4 Packed3 : TEXCOORD6;
							// x: NShadowBlur
							// y: EdgeSoftenDisabled
							half2 Packed4 : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed2 : TEXCOORD4;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
								half2 RadialFillSinCos : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: RadialFillSinCos
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: RadialFillSinCos
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD6;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD6;
								half2 RadialFillSinCos : TEXCOORD7;
							#endif
						#else
							// xy: RadialFillSinCos
							// z: NCornerRadius
							// w: EdgeSoftenDisabled
							half4 Packed2 : TEXCOORD4;
						#endif
					#endif
				#endif
			#endif
		#else
			#if defined(NOVA_CLIPPING)
				#if defined(NOVA_BORDER)
					// xy: NCornerOrigin
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed1 : TEXCOORD3;
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: NShadowOrigin(x)
								float4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: NShadowOrigin(y)
								float4 Packed4 : TEXCOORD8;
								// xyz: WorldNormal
								// w: EdgeSoftenDisabled
								half4 Packed5 : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD7;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
								half3 WorldNormal : TEXCOORD10;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD7;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
								half3 WorldNormal : TEXCOORD10;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								// xyz: RootPos
								// w: NShadowOrigin(x)
								float4 Packed5 : TEXCOORD9;
								// xyz: WorldPos
								// w: NShadowOrigin(y)
								float4 Packed6 : TEXCOORD10;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed3 : TEXCOORD7;
							half2 NShadowOrigin : TEXCOORD8;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed2 : TEXCOORD5;
								float3 WorldPos : TEXCOORD6;
								half3 WorldNormal : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD5;
								// xyz: RootPos
								// w: Gloss
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// xyz: RootPos
								// w: Metallic
								float4 Packed3 : TEXCOORD6;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								float3 RootPos : TEXCOORD7;
								float3 WorldPos : TEXCOORD8;
							#endif
						#else
							// xyz: RootPos
							// w: EdgeSoftenDisabled
							float4 Packed2 : TEXCOORD5;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: NCornerOrigin
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed1 : TEXCOORD3;
						fixed4 ShadowColor : TEXCOORD4;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed2 : TEXCOORD5;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
								float3 WorldPos : TEXCOORD8;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: RootPos
								// w: Specular
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: RootPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed5 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: RootPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
							#endif
						#else
							// xyz: RootPos
							// w: NShadowOrigin(x)
							float4 Packed2 : TEXCOORD5;
							// xy: NShadowSpacePos
							// z: NShadowOrigin(y)
							// w: NShadowBlur
							half4 Packed3 : TEXCOORD6;
							fixed EdgeSoftenDisabled : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed1 : TEXCOORD3;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: RootPos
								// w: NCornerOrigin(x)
								float4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: NCornerOrigin(y)
								float4 Packed3 : TEXCOORD5;
								fixed EdgeSoftenDisabled : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NCornerOrigin
								// z: Specular
								// w: Gloss
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
								float3 WorldPos : TEXCOORD6;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NCornerOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
								float3 WorldPos : TEXCOORD6;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed2 : TEXCOORD4;
								// xyz: RootPos
								// w: NCornerOrigin(x)
								float4 Packed3 : TEXCOORD5;
								// xyz: WorldPos
								// w: NCornerOrigin(y)
								float4 Packed4 : TEXCOORD6;
								half Smoothness : TEXCOORD7;
							#endif
						#else
							// xyz: RootPos
							// w: NCornerRadius
							float4 Packed1 : TEXCOORD3;
							// xy: NCornerOrigin
							// z: EdgeSoftenDisabled
							half3 Packed2 : TEXCOORD4;
						#endif
					#endif
				#endif
			#else
				#if defined(NOVA_BORDER)
					// xy: NCornerOrigin
					// z: NCornerRadius
					// w: BorderNWidth
					half4 Packed1 : TEXCOORD3;
					fixed4 BorderColor : TEXCOORD4;
					#if defined(NOVA_INNER_SHADOW)
						// x: NShadowRadius
						// y: NShadowBlur
						// zw: NShadowSpacePos
						half4 Packed2 : TEXCOORD5;
						fixed4 ShadowColor : TEXCOORD6;
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: NShadowOrigin(x)
								float4 Packed3 : TEXCOORD7;
								// xyz: WorldNormal
								// w: NShadowOrigin(y)
								half4 Packed4 : TEXCOORD8;
								fixed EdgeSoftenDisabled : TEXCOORD9;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NShadowOrigin
								// z: Specular
								// w: Gloss
								half4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD8;
								half3 WorldNormal : TEXCOORD9;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NShadowOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed3 : TEXCOORD7;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD8;
								half3 WorldNormal : TEXCOORD9;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed3 : TEXCOORD7;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD8;
								float3 WorldPos : TEXCOORD9;
								half2 NShadowOrigin : TEXCOORD10;
							#endif
						#else
							// xy: NShadowOrigin
							// z: EdgeSoftenDisabled
							half3 Packed3 : TEXCOORD7;
						#endif
					#else
						#if defined(NOVA_LIT)
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed2 : TEXCOORD5;
								half3 WorldNormal : TEXCOORD6;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldNormal
								// w: Specular
								half4 Packed2 : TEXCOORD5;
								// xyz: WorldPos
								// w: Gloss
								float4 Packed3 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// xyz: WorldPos
								// w: Metallic
								float4 Packed3 : TEXCOORD6;
								fixed EdgeSoftenDisabled : TEXCOORD7;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// xyz: WorldNormal
								// w: Smoothness
								half4 Packed2 : TEXCOORD5;
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed3 : TEXCOORD6;
								float3 WorldPos : TEXCOORD7;
							#endif
						#else
							fixed EdgeSoftenDisabled : TEXCOORD5;
						#endif
					#endif
				#else
					#if defined(NOVA_INNER_SHADOW)
						// xy: NCornerOrigin
						// z: NCornerRadius
						// w: NShadowRadius
						half4 Packed1 : TEXCOORD3;
						fixed4 ShadowColor : TEXCOORD4;
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NShadowBlur
							half4 Packed2 : TEXCOORD5;
							// xy: NShadowOrigin
							// zw: NShadowSpacePos
							half4 Packed3 : TEXCOORD6;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed4 : TEXCOORD7;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xyz: WorldPos
								// w: Specular
								float4 Packed4 : TEXCOORD7;
								// x: Gloss
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed4 : TEXCOORD7;
								// x: Metallic
								// y: EdgeSoftenDisabled
								half2 Packed5 : TEXCOORD8;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed4 : TEXCOORD7;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed5 : TEXCOORD8;
							#endif
						#else
							// xy: NShadowSpacePos
							// zw: NShadowOrigin
							half4 Packed2 : TEXCOORD5;
							// x: NShadowBlur
							// y: EdgeSoftenDisabled
							half2 Packed3 : TEXCOORD6;
						#endif
					#else
						#if defined(NOVA_LIT)
							// xyz: WorldNormal
							// w: NCornerRadius
							half4 Packed1 : TEXCOORD3;
							#if defined(NOVA_LAMBERT_LIGHTING)
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed2 : TEXCOORD4;
								half2 NCornerOrigin : TEXCOORD5;
							#elif defined(NOVA_BLINNPHONG_LIGHTING)
								// xy: NCornerOrigin
								// z: Specular
								// w: Gloss
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
							#elif defined(NOVA_STANDARD_LIGHTING)
								// xy: NCornerOrigin
								// z: Smoothness
								// w: Metallic
								half4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: EdgeSoftenDisabled
								float4 Packed3 : TEXCOORD5;
							#elif defined(NOVA_STANDARDSPECULAR_LIGHTING)
								// x: EdgeSoftenDisabled
								// yzw: SpecularColor
								fixed4 Packed2 : TEXCOORD4;
								// xyz: WorldPos
								// w: Smoothness
								float4 Packed3 : TEXCOORD5;
								half2 NCornerOrigin : TEXCOORD6;
							#endif
						#else
							// xy: NCornerOrigin
							// z: NCornerRadius
							// w: EdgeSoftenDisabled
							half4 Packed1 : TEXCOORD3;
						#endif
					#endif
				#endif
			#endif
		#endif
	#endif
	NOVA_LIT_V2F_END
};
////////////////// END GENERATED //////////////////

#include "../NovaPostV2F.cginc"

#endif