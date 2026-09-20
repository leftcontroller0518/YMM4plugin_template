// ============================================================
// Direct2D1 カスタムピクセルシェーダー
// サンプル: 色反転エフェクト
// ============================================================

#define D2D_INPUT_COUNT 1
#define D2D_INPUT0_SIMPLE

// 定数バッファ (定数データ)
cbuffer Constants : register(b0)
{
    float InvertAmount; // 反転率 (0.0 = 原画, 1.0 = 完全反転)
    float3 Padding;
};

Texture2D InputTexture : register(t0);
SamplerState InputSampler : register(s0);

float4 main(float4 pos : SV_POSITION, float4 posScene : SCENE_POSITION, float4 uv : TEXCOORD0) : SV_TARGET
{
    float4 color = InputTexture.Sample(InputSampler, uv.xy);
    
    // RGB反転処理
    float3 inverted = float3(1.0f - color.r, 1.0f - color.g, 1.0f - color.b);
    
    // 反転率に応じて線形補間
    color.rgb = lerp(color.rgb, inverted * color.a, InvertAmount);
    
    return color;
}
