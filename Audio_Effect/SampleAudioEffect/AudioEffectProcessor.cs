using System;
using YukkuriMovieMaker.Player.Audio.Effects;

namespace SampleAudioEffect;

/// <summary>
/// 音声エフェクトの処理プロセッサクラス
/// </summary>
public class AudioEffectProcessor : AudioEffectProcessorBase
{
    private readonly AudioEffectPlugin item;
    private readonly TimeSpan duration;

    public AudioEffectProcessor(AudioEffectPlugin item, TimeSpan duration)
    {
        this.item = item;
        this.duration = duration;
    }

    /// <summary>
    /// サンプリング周波数 (Hz)
    /// </summary>
    public override int Hz => Input?.Hz ?? 44100;

    /// <summary>
    /// 総サンプル数
    /// </summary>
    public override long Duration => Input?.Duration ?? 0;

    /// <summary>
    /// 音声サンプルデータを読み出し、エフェクト（音量ゲイン乗算）を適用します
    /// </summary>
    protected override int read(float[] destBuffer, int offset, int count)
    {
        if (Input == null) return 0;

        // 入力音声ストリームからサンプルを読み込み
        int readSamples = Input.Read(destBuffer, offset, count);
        if (readSamples == 0) return 0;

        // 現在の再生位置に基づいて音量値を取得 (0〜200% -> 0.0〜2.0)
        long currentFrame = (long)(PositionToTime(Position).TotalSeconds * 60);
        long totalFrame = (long)(duration.TotalSeconds * 60);
        float gain = (float)(item.Volume.GetValue(currentFrame, totalFrame, 60) / 100.0);

        // 各サンプルにゲインを乗算
        for (int i = 0; i < readSamples; i++)
        {
            destBuffer[offset + i] *= gain;
        }

        return readSamples;
    }

    /// <summary>
    /// 再生シーク処理
    /// </summary>
    protected override void seek(long position)
    {
        Input?.Seek(position);
    }
}
