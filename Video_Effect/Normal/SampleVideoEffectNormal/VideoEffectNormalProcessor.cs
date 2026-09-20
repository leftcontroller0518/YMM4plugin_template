using System;
using Vortice.Direct2D1;
using Vortice.Direct2D1.Effects;
using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Player.Video.Effects;

namespace SampleVideoEffectNormal;

/// <summary>
/// 標準映像エフェクトの描画処理クラス
/// </summary>
public class VideoEffectNormalProcessor : VideoEffectProcessorBase
{
    private readonly VideoEffectNormalPlugin item;
    private ColorMatrix? colorMatrixEffect;

    public VideoEffectNormalProcessor(IGraphicsDevicesAndContext devices, VideoEffectNormalPlugin item) : base(devices)
    {
        this.item = item;
    }

    /// <summary>
    /// エフェクトチェーンの末端（出力画像）を返します
    /// </summary>
    protected override ID2D1Image CreateEffect(IGraphicsDevicesAndContext devices)
    {
        colorMatrixEffect = new ColorMatrix(devices.DeviceContext);
        return colorMatrixEffect.Output;
    }

    /// <summary>
    /// 入力画像を設定します
    /// </summary>
    protected override void setInput(ID2D1Image? input)
    {
        colorMatrixEffect?.SetInput(0, input, true);
    }

    /// <summary>
    /// 描画状態をクリアします
    /// </summary>
    protected override void ClearEffectChain()
    {
        colorMatrixEffect?.SetInput(0, null, true);
    }

    /// <summary>
    /// フレームごとの更新処理
    /// </summary>
    public override DrawDescription Update(EffectDescription effectDescription)
    {
        if (colorMatrixEffect == null) return effectDescription.DrawDescription;

        // 現在のフレームにおける不透明度パラメータの値を取得 (0〜100 -> 0.0〜1.0)
        float opacity = (float)(item.Opacity.GetValue(
            effectDescription.ItemPosition.Frame,
            effectDescription.ItemDuration.Frame,
            effectDescription.FPS) / 100.0);

        // カラーマトリクスでアルファ値を乗算
        var matrix = new Matrix5x4
        {
            M11 = 1f,
            M22 = 1f,
            M33 = 1f,
            M44 = Math.Clamp(opacity, 0f, 1f)
        };
        colorMatrixEffect.Matrix = matrix;

        return effectDescription.DrawDescription;
    }

    /// <summary>
    /// リソース解放
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            colorMatrixEffect?.Dispose();
        }
        base.Dispose(disposing);
    }
}
