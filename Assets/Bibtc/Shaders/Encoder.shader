Shader "Bibtc/Barcode"
{
    CGINCLUDE

#include "UnityCG.cginc"

uint _Code1;
uint _Code2;

void Vertex(uint vid : SV_VertexID,
            out float4 outPosition : SV_Position,
            out float2 outTexCoord : TEXCOORD0)
{
    float u = vid & 1;
    float v = vid < 2 || vid == 5;

    float x = u * (_ScreenParams.z - 1) * 2;

    outPosition = float4(x, v, 1, 1) * 2 - 1;
    outTexCoord = float2(u, v);
}

float4 Fragment(float4 position : SV_Position,
                float2 texCoord : TEXCOORD0) : SV_Target
{
    float y = texCoord.y;
    uint bit = floor(y * 64);

    bool lo = (_Code1 >> (bit     )) & 1;
    bool hi = (_Code2 >> (bit - 32)) & 1;

    return bit < 32 ? lo : hi;
}

    ENDCG

    SubShader
    {
        Pass
        {
            ZTest Always ZWrite Off Cull Off
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}
