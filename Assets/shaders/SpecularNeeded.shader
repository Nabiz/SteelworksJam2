Shader "MainShader/SpecularNeeded"
{
	Properties{
		_Color("Color", Color) = (1.0,1.0,1.0)
		_SpecColor("Color", Color) = (1.0,1.0,1.0)
		_Shininess("Shininess", Float) = 10
		_LightPhase("Phase", float) = 0
		_MainTex("Texture", 2D) = "white" {}
		//_WorldPhase("WorldPhase", vector) = (1, 1, 1, 1)
	}

		SubShader{

			Pass
			{
				Tags {"LightMode" = "ForwardBase"}

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

	#include "UnityCG.cginc"
	#include "UsefulCalculations.cginc"

		// user defined variables
		uniform float4 _Color;
		uniform float4 _SpecColor;
		uniform float _Shininess;

		// unity defined variables
		uniform float4 _LightColor0;

		// structs
		/*
		struct vertexInput
{
float4 vertex : POSITION;
float3 normal : NORMAL;
};
*/

struct vtf
{
float2 uv : TEXCOORD0;
float4 pos : SV_POSITION;
float4 posWorld : TEXCOORD1;
float4 posObject : TEXCOORD2;
float3 normalDir : TEXCOORD3;
};

//vertex function
vtf vert(appdata_base v)
{
vtf o;
o.uv = v.texcoord;
o.posObject = v.vertex;
o.posWorld = mul(unity_ObjectToWorld, v.vertex);
o.normalDir = UnityObjectToWorldNormal(v.normal);
//o.normalDir *= GradientNoise(o.posWorld.xyz);
//o.normalDir = float3(0, 0, -1);
//o.normalDir = normalize(mul(float4(v.normal, 0.0), unity_WorldToObject)).xyz;

o.pos = UnityObjectToClipPos(v.vertex);
return o;
}

sampler2D _MainTex;
float _LightPhase;
uniform vector _WorldPhase;

// fragment fonction
float4 frag(vtf i) : COLOR
{
	float4 col = tex2D(_MainTex, i.uv) * _Color;
	// vectors
	i.posWorld += _WorldPhase;
	//float3 normalDirection = i.normalDir * GradientNoise(i.posWorld.xyz);
	float3 normalDirection = i.normalDir * MetalText(i.posWorld.xyz, float4(1, 1, 1, 1));
	float atten = 1.0;

	// lighting
	float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
	float3 diffuseReflection = atten * _LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection)) - _LightPhase / 10;

	// specular direction
	float3 lightReflectDirection = reflect(-lightDirection, normalDirection);
	float3 viewDirection = normalize(float3(float4(_WorldSpaceCameraPos.xyz, 1.0) - i.posWorld.xyz));
	float3 lightSeeDirection = max(0.0,dot(lightReflectDirection, viewDirection));
	float3 shininessPower = pow(lightSeeDirection, _Shininess);


	float3 specularReflection = atten * _SpecColor.rgb * shininessPower;
	float3 lightFinal = diffuseReflection + specularReflection + UNITY_LIGHTMODEL_AMBIENT;

	/*
	float lightMode = round(lightFinal * 32);
	lightMode *= MetalText(i.posWorld, float4(1, 1, 1, 1));
	lightMode = lightMode + 4;
	col.xyz *= lightFinal * MetalText(i.posWorld, float4(1, 1, 1, 1)) * 2;
	col = round(col * lightMode) / lightMode;
	*/
	//lightFinal = GradientNoise(lightFinal);
	col.xyz *= lightFinal;

	return col;
}


ENDCG
}
	}
}