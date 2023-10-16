Shader "Unlit/RainbowTileShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Scale ("Scale", Float) = 1
        _CustomTime ("CustomTime", Float) = 1
        _Background_color ("Background_color", Color) = (0,0,0)
    }
    SubShader
    {
         Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="False"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend One OneMinusSrcAlpha

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

            float _Scale;
            float _CustomTime;
            float3 _Background_color;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f input) : SV_Target
            {
                //GET COLOR FROM THE MAIN TEXTURE
                fixed4 col = tex2D(_MainTex, input.uv);
                
                float3 c = _Background_color;
                // float t = _Time.y;
                float t = _CustomTime;
                float l,z= t;
                for(int i=0;i<3;i++) {
                    float2 p= input.uv;//*//2.-0.5;
                    float2 uv=p;
                    p-=.5;
                    p/= _Scale;
                    // p.x*= _ScreenParams.x/_ScreenParams.y;
                    z+=.07;
                    l=length(p);
                    uv+=p/l*(sin(z)+1.)*abs(sin(l*9-z-z));
                    // c = float3(uv,0.0);
                    c[i] +=.01/length(fmod(abs(uv),float2(1.0,1.0))-0.5);
                }
                fixed4 fragColor=float4(c/l,1.0);
                // fragColor.a = (-step(length(col.a),0.5f) + 1).x;
                float mask = (-step(length(col.a),0.5f) + 1).x;
                return fragColor * mask;
            }
            ENDCG
        }
    }
}