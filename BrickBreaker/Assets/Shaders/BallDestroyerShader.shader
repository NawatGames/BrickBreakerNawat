Shader "Unlit/BallDestroyerShader"
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

            #define atan(x, y) (atan2(y, x))
            #define PI 3.14159265358979
            #define TAU 6.283185307179586
            


            fixed4 frag(v2f i) : SV_Target
            {
                float3 c = float3(0, 0, 0);
                float t = -.54 + (_Time.y * TAU) / 3600., // arc from time or mouse
                    n = (cos(t) > 0.) ? sin(t) : 1. / sin(t), // t to sin/csc
                    e = n * 2., // exponent
                    z = clamp(pow(500., n), 1e-16, 1e+18); // zoom
                float2 uv = i.uv;
                float2 u = uv * z; // coords with zoom
                float ro = -PI / 2., // rotation
                    cr = _Time.y * TAU / 5., // counter rotation
                    a = atan(u.y, u.x) - ro, // screen arc
                    ii = a / TAU, // arc to range between +/-0.5
                    r = exp(log(length(u)) / e), // radius | slightly faster than pow(length(u), 1./e)
                    sc = ceil(r - ii), // spiral contour
                    s = pow(sc + ii, 2.), // spiral gradient
                    vd = cos((sc * TAU + a) / n), // visual denominator
                    ts = cr + s / n * TAU; // segment with time
                c += sin(ts / 2.); // spiral 1
                c *= cos(ts); // spiral 2
                c *= pow(abs(sin((r - ii) * PI)), abs(e) + 5.); // smooth edges & thin near inf
                c *= .2 + abs(vd); // dark folds
                c = min(c, pow(length(u) / z, -1. / n)); // dark gradient
                float3 rgb = float3(vd + 1., abs(sin(t)), 1. - vd); // color
                fixed4 col = tex2D(_MainTex, i.uv2);
                c += (c * 2.) - (rgb * .5); // add color
                // return col;
                return float4(c, col.a);
            }
            ENDCG
        }
    }
}