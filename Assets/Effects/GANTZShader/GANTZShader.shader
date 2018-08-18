Shader "Unlit/GANTZShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_threshold("Threshold", float) = 2.0
		_lazerWidth("LazerWidth", float) = 0.05
		_lazerTex("LazerTexture", 2D) = "white"{}
		[Toggle] _AppearOn("_AppearOn", int) = 0
		[Toggle] _DisappearOn("_DisappearOn", int) = 0
		_StartTime("_StartTime", float) = 0
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "IgnoreProjector"="True" "Queue"="Transparent"}
		LOD 100
		Cull off
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
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
				
				float4 wPos : TEXCOORD1;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _threshold;
			float _lazerWidth;
			sampler2D _lazerTex;
			int _AppearOn;
			int _DisappearOn;
			float _StartTime;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.wPos = mul(UNITY_MATRIX_M, v.vertex);
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
			    
				fixed4 col = tex2D(_MainTex, i.uv);
			    _threshold = 2.0 - (_Time.y - _StartTime)/2;
			    
			    if(_AppearOn == 1){
			        clip(i.wPos.y - _threshold);
			        
			        if(_lazerWidth > i.wPos.y - _threshold){
				    fixed4 lazerCol = tex2D(_lazerTex, (i.wPos.y - _threshold) / _lazerWidth);
                        if(lazerCol.a == 1){
                            col = lazerCol;
                        } else {
                            col += lazerCol;
                        }
				    }
			        
			    } else if(_DisappearOn == 1){
			        clip(_threshold - i.wPos.y);
			        
			        if(_lazerWidth > _threshold - i.wPos.y){
				    fixed4 lazerCol = tex2D(_lazerTex, (_threshold - i.wPos.y) / _lazerWidth);
                        if(lazerCol.a == 1){
                            col = lazerCol;
                        } else {
                            col += lazerCol;
				        }
				    }
			    }
				return col;
			}
			ENDCG
		}
	}
}
