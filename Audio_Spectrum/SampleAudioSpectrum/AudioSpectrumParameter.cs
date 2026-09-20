using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleAudioSpectrum;

/// <summary>
/// 音声波形パラメータ定義クラス
/// </summary>
public class AudioSpectrumParameter : AudioSpectrumParameterBase
{
    public AudioSpectrumParameter(SharedDataStore? sharedData) : base(sharedData)
    {
    }

    /// <summary>
    /// 波形の幅
    /// </summary>
    [Display(Name = "全体の幅", Description = "波形描画領域の横幅")]
    [AnimationSlider("F0", "px", 10, 1920)]
    public Animation Width { get; } = new Animation(400, 10, 1920);

    /// <summary>
    /// 波形の高さ
    /// </summary>
    [Display(Name = "最大の高さ", Description = "波形バーの最大高さ")]
    [AnimationSlider("F0", "px", 10, 1080)]
    public Animation Height { get; } = new Animation(200, 10, 1080);

    /// <summary>
    /// 描画ソースを生成します
    /// </summary>
    public override IAudioSpectrumSource CreateShapeSource(IGraphicsDevicesAndContext devices)
    {
        return new AudioSpectrumSource(devices, this);
    }

    public override IEnumerable<string> CreateShapeItemExoFilter(int keyFrameIndex, ExoOutputDescription desc, AudioSpectrumExoOutputDescription spectrumParameters)
    {
        return [];
    }

    public override IEnumerable<string> CreateMaskExoFilter(int keyFrameIndex, ExoOutputDescription desc, ShapeMaskExoOutputDescription shapeMaskParameters, AudioSpectrumExoOutputDescription spectrumParameters)
    {
        return [];
    }

    protected override void LoadSharedData(SharedDataStore store)
    {
    }

    protected override void SaveSharedData(SharedDataStore store)
    {
    }

    protected override IEnumerable<IAnimatable> GetAnimatables() => [Width, Height];
}
