using System;
using System.IO;
using YukkuriMovieMaker.Plugin.FileWriter;
using YukkuriMovieMaker.Project;

namespace SampleVideoWriter;

/// <summary>
/// 動画出力ライター実装クラス
/// </summary>
public class VideoWriterInstance : IVideoFileWriter
{
    private readonly string path;
    private readonly VideoInfo videoInfo;
    private readonly FileStream fileStream;

    /// <summary>
    /// 対応しているストリーム (映像、音声、または両方)
    /// </summary>
    public VideoFileWriterSupportedStreams SupportedStreams =>
        VideoFileWriterSupportedStreams.Video | VideoFileWriterSupportedStreams.Audio;

    public VideoWriterInstance(string path, VideoInfo videoInfo)
    {
        this.path = path;
        this.videoInfo = videoInfo;
        fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
    }

    /// <summary>
    /// 1フレーム分の映像データ (BGRA / RGBA生バイト列) の書き込み
    /// </summary>
    public void WriteVideo(byte[] frame)
    {
        fileStream.Write(frame, 0, frame.Length);
    }

    /// <summary>
    /// 音声サンプルデータ (32bit float PCM) の書き込み
    /// </summary>
    public void WriteAudio(float[] samples)
    {
        var byteBuffer = new byte[samples.Length * sizeof(float)];
        Buffer.BlockCopy(samples, 0, byteBuffer, 0, byteBuffer.Length);
        fileStream.Write(byteBuffer, 0, byteBuffer.Length);
    }

    public void Dispose()
    {
        fileStream.Flush();
        fileStream.Dispose();
    }
}
