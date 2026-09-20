using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SampleVideoEffectHLSL;

/// <summary>
/// HLSL映像エフェクトプラグインのパラメータ定義クラス
/// </summary>
[VideoEffect("サンプルHLSLエフェクト", [VideoEffectCategories.Filtering, "カスタム"], [], isEffectItemSupported: true)]
public class VideoEffectHLSLPlugin : VideoEffectBase
{
    /// <summary>
    /// エフェクトの表示名
    /// </summary>
    public override string Label => "サンプルHLSL色反転";

    /// <summary>
    /// 反転強度パラメータ (0〜100%)
    /// </summary>
    [Display(Name = "反転率", Description = "色の反転度合いを設定します")]
    [AnimationSlider("F0", "%", 0, 100)]
    public Animation InvertAmount { get; } = new Animation(100, 0, 100);

    /// <summary>
    /// エフェクトプロセッサ（描画ロジック）を生成します
    /// </summary>
    public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
    {
        return new VideoEffectHLSLProcessor(devices, this);
    }

    /// <summary>
    /// AviUtl出力(exo)用のフィルタ定義
    /// </summary>
    public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
    {
        return [];
    }

    /// <summary>
    /// アニメーション可能なプロパティ一覧
    /// </summary>
    protected override IEnumerable<IAnimatable> GetAnimatables() => [InvertAmount];
}
