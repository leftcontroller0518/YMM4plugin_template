using System;
using Vortice;
using Vortice.Direct2D1;
using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Shape;

namespace SampleAudioSpectrum;

/// <summary>
/// 音声波形の描画ソースクラス
/// </summary>
public class AudioSpectrumSource : IAudioSpectrumSource
{
    private readonly IGraphicsDevicesAndContext devices;
    private readonly AudioSpectrumParameter parameter;
    private ID2D1CommandList? commandList;
    private ID2D1SolidColorBrush? brush;

    public ID2D1Image Output => commandList!;

    public AudioSpectrumSource(IGraphicsDevicesAndContext devices, AudioSpectrumParameter parameter)
    {
        this.devices = devices;
        this.parameter = parameter;
        brush = devices.DeviceContext.CreateSolidColorBrush(new Color4(0.2f, 0.8f, 1.0f, 1.0f));
    }

    /// <summary>
    /// 各フレームの波形描画処理
    /// </summary>
    public void Update(TimelineItemSourceDescription description, float[] spectrum)
    {
        commandList?.Dispose();
        commandList = devices.DeviceContext.CreateCommandList();

        var oldTarget = devices.DeviceContext.Target;
        devices.DeviceContext.Target = commandList;
        try
        {
            devices.DeviceContext.BeginDraw();

            float width = (float)parameter.Width.GetValue(description.ItemPosition.Frame, description.ItemDuration.Frame, description.FPS);
            float maxHeight = (float)parameter.Height.GetValue(description.ItemPosition.Frame, description.ItemDuration.Frame, description.FPS);

            int count = Math.Min(spectrum.Length, 64);
            if (count > 0 && brush != null)
            {
                float barWidth = width / count;
                for (int i = 0; i < count; i++)
                {
                    float amplitude = Math.Clamp(spectrum[i], 0f, 1f);
                    float h = amplitude * maxHeight;
                    float x = i * barWidth - (width / 2f);
                    float y = (maxHeight / 2f) - h;

                    var rect = new RawRectF(x, y, x + barWidth - 2f, y + h);
                    devices.DeviceContext.FillRectangle(rect, brush);
                }
            }

            devices.DeviceContext.EndDraw();
        }
        finally
        {
            devices.DeviceContext.Target = oldTarget;
            commandList.Close();
        }
    }

    public void Dispose()
    {
        commandList?.Dispose();
        brush?.Dispose();
    }
}
