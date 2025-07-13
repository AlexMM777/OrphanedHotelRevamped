Shader "Custom/GrassTransparentShader" {
Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _WindStrength ("Wind Strength", Range(0, 1)) = 0.5
        _WindSpeed ("Wind Speed", Range(0, 1)) = 0.5
        _WindFrequency ("Wind Frequency", Range(0, 1)) = 0.5
        _TintColor ("Tint Color", Color) = (1,1,1,1)
    }
    SubShader {
        Tags {"Queue"="AlphaTest" "RenderType"="TransparentCutout" "IgnoreProjector"="True"}
        LOD 200

        CGPROGRAM
        #pragma surface surf Lambert alpha:clip vertex:vert addshadow

        sampler2D _MainTex;
        float _WindStrength;
        float _WindSpeed;
        float _WindFrequency;
        fixed4 _TintColor;

        struct Input {
            float2 uv_MainTex;
            float3 worldPos;
        };

        void vert (inout appdata_full v) {
            // Calculate wind influence, stronger at the top, zero at the base
            float heightFactor = v.vertex.y; // Assuming y is the height axis
            float wind = _WindStrength * heightFactor * sin(_WindFrequency * v.vertex.x + _WindSpeed * _Time.y);
            v.vertex.x += wind;
        }

        void surf (Input IN, inout SurfaceOutput o) {
            half4 c = tex2D(_MainTex, IN.uv_MainTex) * _TintColor;
            clip(c.a - 0.5); // Adjust the alpha threshold if needed
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}