using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SampleVideoEffectNormal;

/// <summary>
/// 標準映像エフェクトプラグインのパラメータ定義クラス
/// </summary>
[VideoEffect("サンプル映像エフェクト", [VideoEffectCategories.Filtering, "カスタム"], [], isEffectItemSupported: true)]
public class VideoEffectNormalPlugin : VideoEffectBase
{
    /// <summary>
    /// エフェクトの表示名
    /// </summary>
    public override string Label => "サンプル映像エフェクト";

    /// <summary>
    /// 不透明度パラメータ (0〜100%)
    /// </summary>
    [Display(Name = "不透明度", Description = "映像の不透明度を設定します")]
    [AnimationSlider("F0", "%", 0, 100)]
    public Animation Opacity { get; } = new Animation(100, 0, 100);

    /// <summary>
    /// エフェクトプロセッサ（描画ロジック）を生成します
    /// </summary>
    public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
    {
        return new VideoEffectNormalProcessor(devices, this);
    }

    /// <summary>
    /// AviUtl出力(exo)用のフィルタ定義
    /// </summary>
    public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
    {
        // AviUtl出力に対応しない場合は空配列を返す
        return [];
    }

    /// <summary>
    /// アニメーション可能なプロパティ一覧
    /// </summary>
    protected override IEnumerable<IAnimatable> GetAnimatables() => [Opacity];
}
