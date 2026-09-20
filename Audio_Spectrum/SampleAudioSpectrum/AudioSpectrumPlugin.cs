using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleAudioSpectrum;

/// <summary>
/// 音声波形プラグイン定義
/// </summary>
public class AudioSpectrumPlugin : IAudioSpectrumPlugin
{
    public string Name => "サンプル棒状波形";

    public bool IsExoShapeSupported => false;

    public bool IsExoMaskSupported => false;

    public IAudioSpectrumParameter CreateAudioSpectrumParameter(SharedDataStore? sharedData)
    {
        return new AudioSpectrumParameter(sharedData);
    }
}
