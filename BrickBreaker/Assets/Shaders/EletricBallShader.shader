Shader "Unlit/EletricBall"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            #define NUM_RAYS 13.

            #define VOLUMETRIC_STEPS 19

            #define MAX_ITER 35
            #define FAR 6.

            #define time iTime*1.1


            mat2 mm2(in float a){float c = cos(a), s = sin(a);return mat2(c,-s,s,c);}
            float noise( in float x ){return textureLod(iChannel0, float2(x*.01,1.),0.0).x;}

            float hash( float n ){return frac(sin(n)*43758.5453);}

            float noise(in float3 p)
            {
	            float3 ip = floor(p);
                float3 fp = frac(p);
	            fp = fp*fp*(3.0-2.0*fp);
	
	            float2 tap = (ip.xy+float2(37.0,17.0)*ip.z) + fp.xy;
	            float2 rg = textureLod( iChannel0, (tap + 0.5)/256.0, 0.0 ).yx;
	            return mix(rg.x, rg.y, fp.z);
            }

            mat3 m3 = mat3( 0.00,  0.80,  0.60,
                          -0.80,  0.36, -0.48,
                          -0.60, -0.48,  0.64 );


            float flow(in float3 p, in float t)
            {
	            float z=2.;
	            float rz = 0.;
	            float3 bp = p;
	            for (float i= 1.;i < 5.;i++ )
	            {
		            p += time*.1;
		            rz+= (sin(noise(p+t*0.8)*6.)*0.5+0.5) /z;
		            p = mix(bp,p,0.6);
		            z *= 2.;
		            p *= 2.01;
                    p*= m3;
	            }
	            return rz;	
            }

            //could be improved
            float sins(in float x)
            {
 	            float rz = 0.;
                float z = 2.;
                for (float i= 0.;i < 3.;i++ )
	            {
                    rz += abs(frac(x*1.4)-0.5)/z;
                    x *= 1.3;
                    z *= 1.15;
                    x -= time*.65*z;
                }
                return rz;
            }

            float segm( float3 p, float3 a, float3 b)
            {
                float3 pa = p - a;
	            float3 ba = b - a;
	            float h = clamp( dot(pa,ba)/dot(ba,ba), 0.0, 1. );	
	            return length( pa - ba*h )*.5;
            }

            float3 path(in float i, in float d)
            {
                float3 en = float3(0.,0.,1.);
                float sns2 = sins(d+i*0.5)*0.22;
                float sns = sins(d+i*.6)*0.21;
                en.xz *= mm2((hash(i*10.569)-.5)*6.2+sns2);
                en.xy *= mm2((hash(i*4.732)-.5)*6.2+sns);
                return en;
            }

            float2 map(float3 p, float i)
            {
	            float lp = length(p);
                float3 bg = float3(0.);   
                float3 en = path(i,lp);
    
                float ins = smoothstep(0.11,.46,lp);
                float outs = .15+smoothstep(.0,.15,abs(lp-1.));
                p *= ins*outs;
                float id = ins*outs;
    
                float rz = segm(p, bg, en)-0.011;
                return float2(rz,id);
            }

            float march(in float3 ro, in float3 rd, in float startf, in float maxd, in float j)
            {
	            float precis = 0.001;
                float h=0.5;
                float d = startf;
                for( int i=0; i<MAX_ITER; i++ )
                {
                    if( abs(h)<precis||d>maxd ) break;
                    d += h*1.2;
	                float res = map(ro+rd*d, j).x;
                    h = res;
                }
	            return d;
            }

            //volumetric marching
            float3 vmarch(in float3 ro, in float3 rd, in float j, in float3 orig)
            {   
                float3 p = ro;
                float2 r = float2(0.);
                float3 sum = float3(0);
                float w = 0.;
                for( int i=0; i<VOLUMETRIC_STEPS; i++ )
                {
                    r = map(p,j);
                    p += rd*.03;
                    float lp = length(p);
        
                    float3 col = sin(float3(1.05,2.5,1.52)*3.94+r.y)*.85+0.4;
                    col.rgb *= smoothstep(.0,.015,-r.x);
                    col *= smoothstep(0.04,.2,abs(lp-1.1));
                    col *= smoothstep(0.1,.34,lp);
                    sum += abs(col)*5. * (1.2-noise(lp*2.+j*13.+time*5.)*1.1) / (log(distance(p,orig)-2.)+.75);
                }
                return sum;
            }

            //returns both collision dists of unit sphere
            float2 iSphere2(in float3 ro, in float3 rd)
            {
                float3 oc = ro;
                float b = dot(oc, rd);
                float c = dot(oc,oc) - 1.;
                float h = b*b - c;
                if(h <0.0) return float2(-1.);
                else return float2((-b - sqrt(h)), (-b + sqrt(h)));
            }

            void mainImage( out float4 fragColor, in float2 fragCoord )
            {	
	            float2 p = fragCoord.xy/iResolution.xy-0.5;
	            p.x*=iResolution.x/iResolution.y;
	            float2 um = iMouse.xy / iResolution.xy-.5;
    
	            //camera
	            float3 ro = float3(0.,0.,5.);
                float3 rd = normalize(float3(p*.7,-1.5));
                mat2 mx = mm2(time*.4+um.x*6.);
                mat2 my = mm2(time*0.3+um.y*6.); 
                ro.xz *= mx;rd.xz *= mx;
                ro.xy *= my;rd.xy *= my;
    
                float3 bro = ro;
                float3 brd = rd;
	
                float3 col = float3(0.0125,0.,0.025);
                #if 1
                for (float j = 1.;j<NUM_RAYS+1.;j++)
                {
                    ro = bro;
                    rd = brd;
                    mat2 mm = mm2((time*0.1+((j+1.)*5.1))*j*0.25);
                    ro.xy *= mm;rd.xy *= mm;
                    ro.xz *= mm;rd.xz *= mm;
                    float rz = march(ro,rd,2.5,FAR,j);
		            if ( rz >= FAR)continue;
    	            float3 pos = ro+rz*rd;
    	            col = max(col,vmarch(pos,rd,j, bro));
                }
                #endif
    
                ro = bro;
                rd = brd;
                float2 sph = iSphere2(ro,rd);
    
                if (sph.x > 0.)
                {
                    float3 pos = ro+rd*sph.x;
                    float3 pos2 = ro+rd*sph.y;
                    float3 rf = reflect( rd, pos );
                    float3 rf2 = reflect( rd, pos2 );
                    float nz = (-log(abs(flow(rf*1.2,time)-.01)));
                    float nz2 = (-log(abs(flow(rf2*1.2,-time)-.01)));
                    col += (0.1*nz*nz* float3(0.12,0.12,.5) + 0.05*nz2*nz2*float3(0.55,0.2,.55))*0.8;
                }
    
	            fragColor = float4(col*1.3, 1.0);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
