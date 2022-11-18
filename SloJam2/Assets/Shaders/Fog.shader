Shader "VFX/FogCard"
{
	Properties
	{
        _Normal1Tex ("Texture", 2D) = "white" {}
        _Normal2Tex ("Texture", 2D) = "white" {}
        _Speed1("Normal 1 Speed", Float) = 1
        _Speed2("Normal 2 Speed", Float) = 1

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
                float2 uv_Normal1Tex;
                float2 uv_Normal2Tex;
				float4 screenPos;
				float3 worldPos;
				float3 viewDir;
			};

            sampler2D _Normal1Tex;
            sampler2D _Normal2Tex;
            float _Speed1;
            float _Speed2;
			fixed4 _Color;
			fixed4 _FogColor;
			float _FogThreshold;
			sampler2D _RenderTexture;
			sampler2D _CameraDepthTexture;

			void surf(Input IN, inout SurfaceOutputStandard o)
			{
                _Speed1 *= _Time;
                _Speed2 *= _Time;

                fixed4 normal1 = tex2D(_Normal1Tex, IN.uv_Normal1Tex + _Speed1);
                fixed4 normal2 = tex2D(_Normal2Tex, IN.uv_Normal2Tex + _Speed2);

                normal1 += normal2;

				float depth = LinearEyeDepth(tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos)));
				float fogDiff = saturate((depth - IN.screenPos.w) / (_FogThreshold * 10000));
				
				fixed4 c = lerp(_Color, _FogColor, fogDiff);

				o.Albedo = normal1 * c.rgb;
				// o.Normal = normal1 * tex2Dproj(_CameraDepthTexture, UNITY_PROJ_COORD(IN.screenPos));
                o.Normal = normal1;
				o.Alpha = lerp(c.a, _FogColor.a, fogDiff);
			}
			ENDCG
		}
			FallBack "Diffuse"
}