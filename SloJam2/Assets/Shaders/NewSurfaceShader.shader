Shader "Custom/Character"
{
    Properties
    {
        _Normal1Tex ("Texture", 2D) = "white" {}
        _Normal2Tex ("Texture", 2D) = "white" {}
        _Speed1("Normal 1 Speed", Float) = 1
        _Speed2("Normal 2 Speed", Float) = 1

        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType" = "Transparent" "Queue" = "Transparent" }
        

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_Normal1Tex;
            float2 uv_Normal2Tex;
            float2 uv_MainTex;
        };

        sampler2D _Normal1Tex;
        sampler2D _Normal2Tex;
        float _Speed1;
        float _Speed2;
        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            _Speed1 *= _Time;
            _Speed2 *= _Time;

            fixed4 normal1 = tex2D(_Normal1Tex, IN.uv_Normal1Tex + _Speed1);
            fixed4 normal2 = tex2D(_Normal2Tex, IN.uv_Normal2Tex + _Speed2);

            normal1 += normal2;

            // Albedo comes from a texture tinted by color
            //fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = _Color * normal1;
            //o.Normal = normal1;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = _Color.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
