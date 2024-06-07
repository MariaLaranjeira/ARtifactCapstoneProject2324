Shader "Custom/FisheyeShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Strength ("Strength", Range(0, 2)) = 1.0 // Increased maximum strength
        _Radius ("Radius", Range(0, 1)) = 0.5
        _EffectRadius ("Effect Radius", Range(0, 1)) = 0.5
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

            struct appdata
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
            float4 _MainTex_ST;
            float _Strength;
            float _Radius;
            float _EffectRadius;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float2 center = float2(0.5, 0.5);
                float2 uv = i.uv - center;

                // Adjust uv for aspect ratio
                float aspectRatio = _ScreenParams.x / _ScreenParams.y;
                uv.x *= aspectRatio;

                float dist = length(uv);

                // Check if within effect radius
                if (dist < _EffectRadius)
                {
                    float strength = _Strength * (1.0 - smoothstep(0.0, _Radius, dist)) * 2.0; // Amplified distortion
                    uv = uv * (1.0 - strength * dist);
                    uv.x /= aspectRatio;
                    uv += center;

                    return tex2D(_MainTex, uv);
                }
                else
                {
                    // Return black color outside the effect radius
                    return fixed4(0, 0, 0, 1);
                }
            }
            ENDCG
        }
    }
}
