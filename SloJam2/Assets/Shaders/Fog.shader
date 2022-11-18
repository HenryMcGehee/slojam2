Shader "VFX/FogCard"
{
	Properties
	{
		_Color("Color", Color) = (1,1,1,1)
		_FogColor("Fog Color", Color) = (1,1,1,1)
		_FogThreshold("Fog threshold", Range(0,100)) = 0
	}
		SubShader
		{
			Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha
			ZWrite Off
			LOD 200

			CGPROGRAM
			#pragma surface surf Standard fullforwardshadows alpha:fade
			#pragma target 3.0

			struct Input
			{
				float4 screenPos;
				float3 worldPos;
				float3 viewDir;
			};

			fixed4 _Color;
			fixed4 _FogColor;
			float _FogThreshold;
			sampler2D _RenderTexture;
			sampler2D _CameraDepthTexture;

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
				float depth = LinearEyeDepth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos)));
				float fogDiff = saturate((depth - IN.screenPos.w) / (_FogThreshold * 10000));
				
				fixed4 c = lerp(_Color, _FogColor, fogDiff);

				o.Albedo = c.rgb;
				o.Alpha = lerp(c.a, _FogColor.a, fogDiff);
			}
			ENDCG
		}
			FallBack "Diffuse"
}