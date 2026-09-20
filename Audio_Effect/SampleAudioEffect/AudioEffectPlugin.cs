using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Audio.Effects;
using YukkuriMovieMaker.Plugin.Effects;

namespace SampleAudioEffect;

/// <summary>
/// 音声エフェクトプラグインのパラメータ定義クラス
/// </summary>
[AudioEffect("サンプル音声ゲイン", [AudioEffectCategories.Effect, "カスタム"], [])]
public class AudioEffectPlugin : AudioEffectBase
{
    /// <summary>
    /// エフェクト表示名
    /// </summary>
    public override string Label => "サンプル音量調整";

    /// <summary>
    /// 音量パラメータ (0〜200%)
    /// </summary>
    [Display(Name = "音量ゲイン", Description = "出力音量の倍率を設定します")]
    [AnimationSlider("F0", "%", 0, 200)]
    public Animation Volume { get; } = new Animation(100, 0, 200);

    /// <summary>
    /// 音声エフェクトプロセッサを生成します
    /// </summary>
    public override IAudioEffectProcessor CreateAudioEffect(TimeSpan duration)
    {
        return new AudioEffectProcessor(this, duration);
    }

    /// <summary>
    /// AviUtl出力(exo)用の音声フィルタ定義
    /// </summary>
    public override IEnumerable<string> CreateExoAudioFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
    {
        return [];
    }

    /// <summary>
    /// アニメーション可能なプロパティ一覧
    /// </summary>
    protected override IEnumerable<IAnimatable> GetAnimatables() => [Volume];
}
