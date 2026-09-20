using System;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Player.Video.Effects;

namespace SampleVideoEffectHLSL;

/// <summary>
/// HLSL映像エフェクトの描画プロセッサ
/// </summary>
public class VideoEffectHLSLProcessor : VideoEffectProcessorBase
{
    private readonly VideoEffectHLSLPlugin item;
    private EffectShader? shaderEffect;

    public VideoEffectHLSLProcessor(IGraphicsDevicesAndContext devices, VideoEffectHLSLPlugin item) : base(devices)
    {
        this.item = item;
    }

    protected override ID2D1Image CreateEffect(IGraphicsDevicesAndContext devices)
    {
        shaderEffect = new EffectShader(devices);
        return shaderEffect.Output;
    }

    protected override void setInput(ID2D1Image? input)
    {
        shaderEffect?.SetInput(0, input, true);
    }

    protected override void ClearEffectChain()
    {
        shaderEffect?.SetInput(0, null, true);
    }

    public override DrawDescription Update(EffectDescription effectDescription)
    {
        if (shaderEffect == null) return effectDescription.DrawDescription;

        float invert = (float)(item.InvertAmount.GetValue(
            effectDescription.ItemPosition.Frame,
            effectDescription.ItemDuration.Frame,
            effectDescription.FPS) / 100.0);

        shaderEffect.InvertAmount = Math.Clamp(invert, 0f, 1f);

        return effectDescription.DrawDescription;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            shaderEffect?.Dispose();
        }
        base.Dispose(disposing);
    }
}
