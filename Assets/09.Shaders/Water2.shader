Shader "Custom/Water2" {
	Properties{
		_Bumpmap("NormalMap", 2D) = "bump" {}
		_Cube("Cube", Cube) = "" {}
	}
	SubShader{
		//Tags { "RenderType"="Transparent"  "Queue"="Transparent"}
		Tags { "RenderType" = "Opaque" }

		CGPROGRAM
		#pragma surface surf Lambert

		samplerCUBE _Cube;
		sampler2D _Bumpmap;

		struct Input {
			float2 uv_Bumpmap;
			float3 worldRefl;
			INTERNAL_DATA
		};

		void surf(Input IN, inout SurfaceOutput o) {
			float3 normal1 = UnpackNormal(tex2D(_Bumpmap, IN.uv_Bumpmap + _Time.x * 0.1));
			float3 normal2 = UnpackNormal(tex2D(_Bumpmap, IN.uv_Bumpmap - _Time.x * 0.1));

			o.Normal = (normal1 + normal2) / 2;

			float3 refcolor = texCUBE(_Cube, WorldReflectionVector(IN,o.Normal));

			o.Emission = refcolor;
			o.Alpha = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
