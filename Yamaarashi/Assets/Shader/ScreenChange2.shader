// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//シェーダーのPostEffectの欄にScreenChangeを追加する
Shader "PostEffect/ScreenChange2"
{
	Properties
	{
		//Graphics.Blit()によってレンダリング済の画像が送られてくる
		//名前は_MainTex固定
		_MainTex ("Texture", 2D) = "white" {}
		//percent("percent",Range(0.0,1.0))=0.5
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			uniform float _FadeCount;

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

			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}

			sampler2D _MainTex;

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				float2 r = 2.0 * (i.uv - 0.5);
				float aspectRatio = _ScreenParams.x / _ScreenParams.y;
				r.x *= aspectRatio;
				fixed4 bgCol = fixed4(0.0, 0.0, 0.0, 0.0);
	
				float hight = floor(r.y * 10) / 10 + 2;
				if (hight % 0.2 < 0.1)	
				{
					if (r.x < hight + _FadeCount * 6 - 5)
					{
						col = bgCol;
					}
				}
				else
				{
					if (r.x > -hight - _FadeCount * 6 + 5)
					{
						col = bgCol;
			
					}
				}
				return col;
			}
				ENDCG
		}
	}
}

