Shader "Hidden/Fade"
{
	    Properties {
        _MainTex ("Source", 2D) = "white" {}
        _Size ("Size", Float) = 1
    }
    SubShader {
        ZTest Always
        Cull Off
        ZWrite Off
        Fog { Mode Off }

        Pass{
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert(appdata_img v) {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = MultiplyUV(UNITY_MATRIX_TEXTURE0, v.texcoord.xy);
                return o;
            }

            sampler2D _MainTex;
            float _color;

            fixed4 frag(v2f i) : SV_TARGET {
                //float2 delta = 1 / _ScreenParams.xy
               fixed4 c = tex2D(_MainTex, i.uv);
               c.rgb += fixed3(_color/100,_color/100,_color/100);
                return c;
            }
            ENDCG
        }
    }
    FallBack Off
}