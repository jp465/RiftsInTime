Shader "Custom/CRTShader" {
	Properties{
		_MainTex("Base (RGB)", 2D) = "white" {}
		_MaskTex("Mask texture", 2D) = "white" {}
		_maskBlend("Mask blending", Float) = 0.5
		_maskSize("Mask Size", Float) = 1
	}
		SubShader{
			Pass{
				CGPROGRAM
				#pragma vertex vert_img
				#pragma fragment frag
				#include "UnityCG.cginc"

				uniform sampler2D _MainTex;
				uniform sampler2D _MaskTex;

				fixed _maskBlend;
				fixed _maskSize;
				float rand(float3 myVect) {
					return frac(sin(dot(myVect, float3(12.9898, 78.233, 45.5432)))*43758.5453);
				}

				fixed4 frag(v2f_img i) : COLOR{
					fixed4 mask = tex2D(_MaskTex, i.uv * _maskSize);
					fixed4 base = tex2D(_MainTex, i.uv);
					float3 timeOffset = float3(1, 1, 1)*_Time[0];
					float randval = rand(timeOffset*i.pos)*.5f+.5f;
					return lerp(base*randval, mask*randval, _maskBlend);
				}

				
				ENDCG
			}
		}
}
