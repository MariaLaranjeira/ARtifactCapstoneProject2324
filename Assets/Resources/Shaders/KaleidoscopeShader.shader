Shader "Custom/KaleidoscopeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Segments ("Segments", Float) = 6
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Segments;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float angle = atan2(uv.y - 0.5, uv.x - 0.5);
                float radius = length(uv - 0.5);
                angle = fmod(angle * _Segments, 6.28318530718 / _Segments);
                uv = float2(cos(angle), sin(angle)) * radius + 0.5;
                fixed4 col = tex2D(_MainTex, uv);
                return col;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}
