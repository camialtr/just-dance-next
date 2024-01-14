Shader "Hidden/NovaSamples/VisualEffects/BlurSinglePass"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags { "RenderType"="Transparent" }
		ZTest Off
		ZWrite Off
		Blend Off
		Cull Off

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
			#pragma exclude_renderers gles
			
			#pragma multi_compile_local __ COLOR_ADJUSTMENT_ON

			#include "UnityCG.cginc"
			#include "../BlurFilters.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _BlurBox;
			float4 _UVScale;
			float4 _ClipUVs;

			struct VertInput
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct FragInput
			{
				float4 position : POSITION;
				half2 uv : TEXCOORD0;
				half4x2 boxUVs : TEXCOORD1;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID 
				UNITY_VERTEX_OUTPUT_STEREO
			};

			FragInput vert(VertInput input)
			{
				FragInput output;

				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_INITIALIZE_OUTPUT(FragInput, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);				

				half2 uv = TRANSFORM_TEX(input.uv, _MainTex);
				half4x2 offsets = half4x2(_BlurBox.xy, _BlurBox.zy, _BlurBox.xw, _BlurBox.zw);
				
				output.position = UnityObjectToClipPos(input.vertex);
				output.uv = uv;
				output.boxUVs = half4x2(uv, uv, uv, uv) + offsets;

				return output;
			}

			half4 frag(FragInput input) : SV_Target
			{
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

				clip(float4(input.uv - _ClipUVs.xy, _ClipUVs.zw - input.uv));
				
				half4 color = BlurSample(_MainTex, input.boxUVs);

				return color;
			}
			ENDCG
		}

		Pass
		{
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
			#pragma exclude_renderers gles

			#pragma multi_compile_local __ COLOR_ADJUSTMENT_ON
			#pragma multi_compile_local __ GRAIN_ON

			#include "UnityCG.cginc"
			#include "../BlurFilters.cginc"

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _UVScale;
			float4 _ClipUVs;
			float4 _GrainUVs;

			struct VertInput
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;

				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct FragInput
			{
				float4 position : POSITION;
				half2 uv : TEXCOORD0;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID 
				UNITY_VERTEX_OUTPUT_STEREO
			};

			FragInput vert(VertInput input)
			{
				FragInput output;

				UNITY_SETUP_INSTANCE_ID(input);
				UNITY_INITIALIZE_OUTPUT(FragInput, output);
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(output);				
				
				output.position = UnityObjectToClipPos(input.vertex);
				output.uv = TRANSFORM_TEX(input.uv, _MainTex);

				return output;
			}

			half4 frag(FragInput input) : SV_Target
			{
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX(input);

				clip(float4(input.uv - _ClipUVs.xy, _ClipUVs.zw - input.uv));

				half4 color = tex2D(_MainTex, input.uv);

				#if defined(COLOR_ADJUSTMENT_ON)
				color = half4(ApplyColorAdjustments(color.xyz), color.w);
				#endif

				#if defined(GRAIN_ON)
				// grain origin at center of clip rect
				float2 coord = (input.uv - _GrainUVs.xy) * _UVScale.zw + _UVScale.zw;

				color.xyz = ApplyGrain(color.xyz, coord);
				#endif

				return color;
			}
			ENDCG
		}
	}
}