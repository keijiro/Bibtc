Shader "Bibtc/Barcode"
{
    CGINCLUDE

#include "UnityCG.cginc"

uint _Code1;
uint _Code2;

void Vertex(float4 position : POSITION,
            float2 texCoord : TEXCOORD0,
            out float4 outPosition : SV_Position,
            out float2 outTexCoord : TEXCOORD0)
{
    outPosition = UnityObjectToClipPos(position);
    outTexCoord = texCoord;
}

float4 Fragment(float4 position : SV_Position,
                float2 texCoord : TEXCOORD0) : SV_Target
{
    uint code1 = _Code1;
    uint code2 = _Code2;

    float y = texCoord.y;
    uint bit = floor(y * 64);

    return texCoord.x < 0.5 ?
    (bit & 1) :
    (bit < 32 ? ((code1 >> bit) & 1) : ((code2 >> (bit - 32)) & 1));
}

    ENDCG

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex Vertex
            #pragma fragment Fragment
            ENDCG
        }
    }
}
