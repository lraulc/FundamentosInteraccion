Shader "Unlit/pixelDotAA"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Spacing ("Spacing", Range(0,1)) = 0.25
        _SolidColor ("ScreenColor", Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off
        
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };
            
            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };
            
            sampler2D _MainTex;
            float4 _SolidColor;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;
            float _Spacing;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }
            
            fixed4 frag (v2f i) : SV_Target
            {
                // uvs * texture resolution
                float2 texelUV = i.uv * _MainTex_TexelSize.zw;
                
                // set texture to point filtering, sample normally
                fixed4 col = tex2D(_MainTex, i.uv) * _SolidColor;
                
                // optional force texture to be sampled as if it's using point filtering
                // float2 pointUVs = (floor(texelUV) + 0.5) * _MainTex_TexelSize.xy;
                // fixed4 col = tex2D(_MainTex, pointUVs);
                
                // rescale each texel to a -1 to 1 range, then get the absolute of that.
                // this gets a distance from the center of the "pixel", where the edges are 1
                // and the center is 0.
                float2 pixelUV = frac(texelUV) * 2.0 - 1.0;
                
                // get the max distance for a square dot
                float pixelCenterDist = max(abs(pixelUV.x), abs(pixelUV.y));
                
                // alternative if you want round dots, scaled so a spacing of 0 has no holes
                // float pixelCenterDist = length(pixelUV) * 0.70716;
                
                // get screen space derivatives of the pixel center distance
                float derivDist = fwidth(pixelCenterDist);

                // use derivatives to sharpen edge
                col.a *= smoothstep(_Spacing - derivDist * 0.5, _Spacing + derivDist * 0.5, 1 - pixelCenterDist);
                
                return col;
            }
            ENDCG
        }
    }
}