// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MK4/TV_noise_amplify"
{
	Properties
	{
		_Albedo("Albedo", 2D) = "gray" {}
		_MetallicGloss("Metallic Gloss", 2D) = "black" {}
		_AO("AO", 2D) = "white" {}
		_Emission("Emission", Range( 0 , 1)) = 0
		_AlbedoTVColor("Albedo TV Color", Color) = (0.6176471,0.6176471,0.6176471,0)
		_Noise("Noise", 2D) = "gray" {}
		[HDR]_Noise1("Noise1", Color) = (0.9502595,0.9558824,0.5482267,0)
		[HDR]_Noise2("Noise2", Color) = (0.4689737,0.5514706,0.3122297,0)
		[HDR]_Noise3("Noise3", Color) = (0.7352941,0.748073,1,0)
		[HDR]_Noise4("Noise4", Color) = (0.4117647,0.4645032,1,0)
		_TVShots("TV Shots", 2D) = "gray" {}
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform float4 _Noise1;
		uniform sampler2D _Noise;
		uniform float4 _Noise3;
		uniform float4 _Noise4;
		uniform float4 _Noise2;
		uniform float4 _AlbedoTVColor;
		uniform sampler2D _TVShots;
		uniform float _Emission;
		uniform sampler2D _MetallicGloss;
		uniform float4 _MetallicGloss_ST;
		uniform sampler2D _AO;
		uniform float4 _AO_ST;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			float4 tex2DNode2 = tex2D( _Albedo, uv_Albedo );
			float2 panner16 = ( 1.0 * _Time.y * float2( 1.6,5 ) + ( i.uv_texcoord * float2( 2,2 ) ));
			float2 panner25 = ( 1.0 * _Time.y * float2( -0.4,3 ) + ( i.uv_texcoord * float2( 1.5,1.5 ) ));
			float2 panner31 = ( 1.0 * _Time.y * float2( 0,2 ) + ( i.uv_texcoord * float2( 1.8,1.8 ) ));
			float2 panner21 = ( 1.0 * _Time.y * float2( 0,0.2 ) + ( i.uv_texcoord * float2( 1.5,1.5 ) ));
			float4 clampResult36 = clamp( ( ( _Noise1 * tex2D( _Noise, panner16 ).r ) + ( _Noise3 * tex2D( _Noise, panner25 ).b ) + ( _Noise4 * tex2D( _Noise, panner31 ).a ) + ( _Noise2 * tex2D( _Noise, panner21 ).g ) ) , float4( 0,0,0,0 ) , float4( 1,1,1,0 ) );
			float2 panner9 = ( 1.0 * _Time.y * float2( 1,0.7 ) + ( i.uv_texcoord * float2( 0.16,0.16 ) ));
			float4 temp_output_39_0 = ( clampResult36 + ( _AlbedoTVColor * tex2D( _TVShots, panner9 ) ) );
			float4 lerpResult10 = lerp( tex2DNode2 , temp_output_39_0 , tex2DNode2.a);
			o.Normal = lerpResult10.rgb;
			o.Albedo = lerpResult10.rgb;
			o.Emission = ( tex2DNode2.a * ( temp_output_39_0 * _Emission ) ).rgb;
			float2 uv_MetallicGloss = i.uv_texcoord * _MetallicGloss_ST.xy + _MetallicGloss_ST.zw;
			float4 tex2DNode4 = tex2D( _MetallicGloss, uv_MetallicGloss );
			o.Metallic = tex2DNode4.r;
			o.Smoothness = tex2DNode4.a;
			float2 uv_AO = i.uv_texcoord * _AO_ST.xy + _AO_ST.zw;
			o.Occlusion = tex2D( _AO, uv_AO ).r;
			o.Alpha = 1;
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=16100
149;436;1080;497;1726.247;101.371;1.93199;False;True
Node;AmplifyShaderEditor.TextureCoordinatesNode;8;-2262.785,491.5609;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;17;-1903.146,855.0701;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;2,2;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;32;-1976.216,1512.51;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;1.8,1.8;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;22;-1941.536,1075.363;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;1.5,1.5;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;26;-1962.628,1314.386;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;1.5,1.5;False;1;FLOAT2;0
Node;AmplifyShaderEditor.TexturePropertyNode;7;-2244.118,846.4308;Float;True;Property;_Noise;Noise;6;0;Create;True;0;0;False;0;None;12ed8b16dc2779f40aa90756c69ba2ca;False;gray;Auto;Texture2D;0;1;SAMPLER2D;0
Node;AmplifyShaderEditor.PannerNode;31;-1817.971,1516.58;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,2;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;16;-1759.226,849.5027;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1.6,5;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;25;-1802.258,1306.778;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;-0.4,3;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.PannerNode;21;-1781.166,1067.755;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;0,0.2;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;29;-1236.637,1188.963;Float;False;Property;_Noise3;Noise3;9;1;[HDR];Create;True;0;0;False;0;0.7352941,0.748073,1,0;0.2412935,0.2426471,0.1445177,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;24;-1236.196,972.5867;Float;False;Property;_Noise2;Noise2;8;1;[HDR];Create;True;0;0;False;0;0.4689737,0.5514706,0.3122297,0;0.3440203,0.4336371,0.4632353,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;13;-1787.481,518.322;Float;False;2;2;0;FLOAT2;0,0;False;1;FLOAT2;0.16,0.16;False;1;FLOAT2;0
Node;AmplifyShaderEditor.ColorNode;34;-1242.562,1413.081;Float;False;Property;_Noise4;Noise4;10;1;[HDR];Create;True;0;0;False;0;0.4117647,0.4645032,1,0;0.1854995,0.3455882,0.3257152,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;19;-1232.705,709.0067;Float;False;Property;_Noise1;Noise1;7;1;[HDR];Create;True;0;0;False;0;0.9502595,0.9558824,0.5482267,0;0.7426471,0.7426471,0.7426471,1;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;15;-1563.568,849.584;Float;True;Property;_TextureSample0;Texture Sample 0;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;30;-1594.336,1517.923;Float;True;Property;_TextureSample3;Texture Sample 3;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;27;-1575.606,1271.304;Float;True;Property;_TextureSample2;Texture Sample 2;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;20;-1559.88,1048.38;Float;True;Property;_TextureSample1;Texture Sample 1;6;0;Create;True;0;0;False;0;None;None;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;28;-993.706,1353.713;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.PannerNode;9;-1557.401,502.8004;Float;False;3;0;FLOAT2;0,0;False;2;FLOAT2;1,0.7;False;1;FLOAT;1;False;1;FLOAT2;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;33;-999.3108,1527.942;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;18;-979.0348,904.7964;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;23;-946.5693,1083.121;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;6;-1284.438,478.7228;Float;True;Property;_TVShots;TV Shots;11;0;Create;True;0;0;False;0;None;c29e7d0d1fff8c248b89f594df62fc43;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;41;-983.9185,432.3951;Float;False;Property;_AlbedoTVColor;Albedo TV Color;5;0;Create;True;0;0;False;0;0.6176471,0.6176471,0.6176471,0;0,0.2697769,0.2941176,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;35;-768.1953,980.9033;Float;False;4;4;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;0,0,0,0;False;3;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;40;-772.1203,462.7458;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.ClampOpNode;36;-630.5879,987.0248;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;COLOR;1,1,1,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;43;-580.533,443.8004;Float;False;Property;_Emission;Emission;4;0;Create;True;0;0;False;0;0;0.677;0;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.SimpleAddOpNode;39;-563.6796,582.1984;Float;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;2;-1271.745,-370.1591;Float;True;Property;_Albedo;Albedo;0;0;Create;True;0;0;False;0;None;67beba0b6d4081d43b33a48a5175a514;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;42;-333.6263,613.6364;Float;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;12;-121.3619,572.8199;Float;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;3;-1274.344,-167.9304;Float;True;Property;_Normalmap;Normalmap;1;0;Create;True;0;0;False;0;None;None;True;0;False;bump;Auto;True;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;FLOAT3;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;4;-1279.802,41.99916;Float;True;Property;_MetallicGloss;Metallic Gloss;2;0;Create;True;0;0;False;0;None;63b70faf7685291469698d578e385388;True;0;False;black;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SamplerNode;5;-1278.554,237.213;Float;True;Property;_AO;AO;3;0;Create;True;0;0;False;0;None;35ebc843ff69e9e4b9393b5dfc33ada2;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.LerpOp;10;-165.3802,-248.4042;Float;False;3;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;2;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;166.7151,301.2765;Float;False;True;2;Float;ASEMaterialInspector;0;0;Standard;MK4/TV_noise_amplify;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Opaque;0.5;True;True;0;False;Opaque;;Geometry;All;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;17;0;8;0
WireConnection;32;0;8;0
WireConnection;22;0;8;0
WireConnection;26;0;8;0
WireConnection;31;0;32;0
WireConnection;16;0;17;0
WireConnection;25;0;26;0
WireConnection;21;0;22;0
WireConnection;13;0;8;0
WireConnection;15;0;7;0
WireConnection;15;1;16;0
WireConnection;30;0;7;0
WireConnection;30;1;31;0
WireConnection;27;0;7;0
WireConnection;27;1;25;0
WireConnection;20;0;7;0
WireConnection;20;1;21;0
WireConnection;28;0;29;0
WireConnection;28;1;27;3
WireConnection;9;0;13;0
WireConnection;33;0;34;0
WireConnection;33;1;30;4
WireConnection;18;0;19;0
WireConnection;18;1;15;1
WireConnection;23;0;24;0
WireConnection;23;1;20;2
WireConnection;6;1;9;0
WireConnection;35;0;18;0
WireConnection;35;1;28;0
WireConnection;35;2;33;0
WireConnection;35;3;23;0
WireConnection;40;0;41;0
WireConnection;40;1;6;0
WireConnection;36;0;35;0
WireConnection;39;0;36;0
WireConnection;39;1;40;0
WireConnection;42;0;39;0
WireConnection;42;1;43;0
WireConnection;12;0;2;4
WireConnection;12;1;42;0
WireConnection;10;0;2;0
WireConnection;10;1;39;0
WireConnection;10;2;2;4
WireConnection;0;0;10;0
WireConnection;0;1;10;0
WireConnection;0;2;12;0
WireConnection;0;3;4;0
WireConnection;0;4;4;4
WireConnection;0;5;5;0
ASEEND*/
//CHKSM=0A36D72CCA60D776C479B495BF9F0479C7A47FE0