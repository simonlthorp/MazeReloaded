// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/DayNight" {
    SubShader
    {
        Pass
        {
            Tags{ "LightMode" = "ForwardBase" }
 
            CGPROGRAM
            #include "UnityCG.cginc"
 
            #pragma target 2.0
            #pragma vertex vertexShader
            #pragma fragment fragmentShader
 
            float4 _LightColor0;
 
            struct vsIn {
                float4 position : POSITION;
                float3 normal : NORMAL;
            };
 
            struct vsOut {
                float4 position : SV_POSITION;
                float3 normal : NORMAL;
            };
 
            vsOut vertexShader(vsIn v)
            {
                vsOut o;
                o.position = UnityObjectToClipPos(v.position);
                o.normal = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject).xyz);
 
                return o;
            }
 
            float4 fragmentShader(vsOut psIn) : SV_Target
            {
                float4 AmbientLight = UNITY_LIGHTMODEL_AMBIENT;
 
                float4 LightDirection = normalize(_WorldSpaceLightPos0);
 
                float4 diffuseTerm = saturate(dot(LightDirection, psIn.normal));
                float4 DiffuseLight = diffuseTerm * _LightColor0;
 
                return AmbientLight + DiffuseLight;
            }
 
            ENDCG
        }
    }

/*
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Pass
        {
            Tags {"LightMode"="ForwardBase"}
        
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0;
                float4 vertex : SV_POSITION;
				
            };

            v2f vert (appdata_base v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.texcoord;
                half3 worldNormal = UnityObjectToWorldNormal(v.normal);
                half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
                o.diff = nl * _LightColor0;

                // the only difference from previous shader:
                // in addition to the diffuse lighting from the main light,
                // add illumination from ambient or light probes
                // ShadeSH9 function from UnityCG.cginc evaluates it,
                // using world space normal
                o.diff.rgb += ShadeSH9(half4(worldNormal,1));
				
                return o;

            }
            
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 c;
                col *= i.diff;
				c.rgb = UNITY_LIGHTMODEL_AMBIENT.rgb * 2 * col.rgb;
                return col;
            }
            ENDCG
        }
    }
	*/
}
