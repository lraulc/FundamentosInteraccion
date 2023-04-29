// Shader "Unlit/LPNorm3D"
// {
    //     Properties
    //     {
        //         _MainTex ("Texture", 2D) = "white" {}
        //         _P ("Exponencial", float) = 1
    //     }
    //     SubShader
    //     {
        //         Tags { "RenderType"="Opaque" }
        //         LOD 100

        //         Pass
        //         {
            //             CGPROGRAM
            //             #pragma vertex vert
            //             #pragma fragment frag
            //             // make fog work
            //             #pragma multi_compile_fog

            //             #include "UnityCG.cginc"

            //             struct appdata
            //             {
                //                 float4 vertex : POSITION;
                //                 float2 uv : TEXCOORD0;
            //             };

            //             struct v2f
            //             {
                //                 float2 uv : TEXCOORD0;
                //                 UNITY_FOG_COORDS(1)
                //                 float4 vertex : SV_POSITION;
            //             };

            //             sampler2D _MainTex;
            //             float4 _MainTex_ST;
            //             float _P;

            //             v2f vert (appdata v)
            //             {
                //                 v2f o;
                //                 o.vertex = UnityObjectToClipPos(v.vertex);
                //                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //                 UNITY_TRANSFER_FOG(o,o.vertex);
                //                 return o;
            //             }

            //             float4 lpNormColor(v2f i, float p)
            //             {
                //                 float3 point = float3(0,0,0); // The point we want to measure distance from
                //                 float3 pixel = float3( i.uv,0); // The current pixel

                //                 float distance = pow(pow(abs(pixel.x - point.x), p) + pow(abs(pixel.y - point.y), p) + pow(abs(pixel.z - point.z), p), 1/p); // Calculate the distance using Euclidean distance (p=2)

                //                 float4 color = float4(0, 0, 0, 1); // Default color is black

                //                 if (distance < 0.1) {
                    //                     color = float4(1, 0, 0, 1); // If the distance is less than 0.1, color the pixel red
                    //                     } else if (distance < 0.2) {
                    //                     color = float4(0, 1, 0, 1); // If the distance is between 0.1 and 0.2, color the pixel green
                    //                     } else if (distance < 0.3) {
                    //                     color = float4(0, 0, 1, 1); // If the distance is between 0.2 and 0.3, color the pixel blue
                //                 }

                //                 return color;
            //             }

            //             fixed4 frag (v2f i) : SV_Target
            //             {
                //                 // sample the texture
                //                 // fixed4 col = tex2D(_MainTex, i.uv);
                //                 fixed4 col = lpNormColor(i.uv, _P);

                //                 // apply fog
                //                 UNITY_APPLY_FOG(i.fogCoord, col);
                //                 return col;
            //             }
            //             ENDCG
        //         }
    //     }
// }
