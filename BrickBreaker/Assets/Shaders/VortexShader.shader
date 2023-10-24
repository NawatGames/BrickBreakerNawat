Shader "Unlit/VortexShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
                float2 uv2 : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv2 = v.uv;
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv - .5;
                float t = _Time.y * .1 + ((.25 + .05 * sin(_Time.y * .1)) / (length(uv.xy) + .07)) * 2.2;
                float si = sin(t);
                float co = cos(t);
                float2x2 ma = float2x2(co, si, -si, co);

                float v1, v2, v3;
                v1 = v2 = v3 = 0.0;

                float s = 0.0;
                for (int j = 0; j < int(sin(_Time.y / 2.) * 75. + 100.); j++)
                {
                    float3 p = s * float3(uv, 0.0);
                    p.xy = mul(ma, p.xy);
                    p += float3(.22, .3, s - 1.5 - sin(_Time.y * .13) * .1);
                    for (int j = 0; j < 8; j++) p = abs(p) / dot(p, p) - 0.659;
                    v1 += dot(p, p) * .0015 * (1.8 + sin(length(uv.xy * 13.0) + .5 - _Time.y * .2));
                    v2 += dot(p, p) * .0013 * (1.5 + sin(length(uv.xy * 14.5) + 1.2 - _Time.y * .3));
                    v3 += length(p.xy * 10.) * .0003;
                    s += .095;
                }

                float len = length(uv);
                v1 *= smoothstep(.7, .0, len);
                v2 *= smoothstep(.5, .0, len);
                v3 *= smoothstep(.9, .0, len);

                float3 col = float3(v3 * (1.5 + sin(_Time.y * .2) * .4),
                        (v1 + v3) * .3,
                        v2) +
                    smoothstep(0.2, .0, len) * .85 + (smoothstep(0.075, .0, len) * sin(_Time.y * 0.03)) + smoothstep(
                        .0, .6, v3)
                    * (sin(_Time.y / 5.1) * 100. + 50.)
                    * .08;
                fixed4 color = tex2D(_MainTex, i.uv2);
                return float4(min(pow(abs(col), float3(1.2, 1.2, 1.2)), 1.0), color.a);
            }

            
            ENDCG
        }
    }
}