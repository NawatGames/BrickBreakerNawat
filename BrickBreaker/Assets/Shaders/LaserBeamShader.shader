Shader "Unlit/LaserBeamShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _iResolution ("Resolution", Vector) = (0, 0, 0, 0)
        _SpeedMultiplier ("Speed", Float) = 1.0
    }
    SubShader
    {
        Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _iResolution;
            float _SpeedMultiplier = 1;
            

            #define mod(x, y) (x - y * floor(x / y))
            #define atan(x, y) (atan2(y,x))

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            float4 Strand(in float2 fragCoord, in float3 color, in float hoffset, in float hscale, in float vscale,
                in float timescale)
            {
                float glow = 0.06 * _iResolution.y;
                float twopi = 6.28318530718;
                float curve = 1.0 - abs(
                    fragCoord.y - (sin(mod(
                        fragCoord.x * hscale / 100.0 / _iResolution.x * 1000.0 + _Time.y * _SpeedMultiplier * timescale + hoffset,
                        twopi)) * _iResolution.y * 0.25 * vscale + _iResolution.y / 2.0));
                float i = clamp(curve, 0.0, 1.0);
                i += clamp((glow + curve) / glow, 0.0, 1.0) * 0.4;
                //return i * color;
                return float4(i*color, i);
            }
            

            fixed4 frag(v2f i) : SV_Target
            {
                i.uv.x = 1 - i.uv.x;
                float2 fragCoord = i.uv * _iResolution;
                float timescale = 4.0;
                float4 c = float4(0, 0, 0, 0);
                c += Strand(fragCoord, float3(1.0, 0, 0), 0.7934 + 1.0 + _Time.y, 1.0, 0.16, 10.0 * timescale);
                c += Strand(fragCoord, float3(0.0, 1.0, 0.0), 0.645 + 1.0 + _Time.y , 1.5, 0.2,
                    10.3 * timescale);
                c += Strand(fragCoord, float3(0.0, 0.0, 1.0), 0.735 + 1.0 + _Time.y , 1.3, 0.19,
                    8.0 * timescale);
                c += Strand(fragCoord, float3(1.0, 1.0, 0.0), 0.9245 + 1.0 + _Time.y , 1.6, 0.14,
                    12.0 * timescale);
                c += Strand(fragCoord, float3(0.0, 1.0, 1.0), 0.7234 + 1.0 + _Time.y , 1.9, 0.23,
                    14.0 * timescale);
                c += Strand(fragCoord, float3(1.0, 0.0, 1.0), 0.84525 + 1.0 + _Time.y , 1.2, 0.18,
                            9.0 * timescale);
                // c += clamp(Muzzle(fragCoord, timescale), 0.0, 1.0);
                return float4(c.rgba);
            }
            
            ENDCG
        }
    }
}