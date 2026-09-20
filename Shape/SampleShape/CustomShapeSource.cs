using System;
using System.Numerics;
using Vortice.Direct2D1;
using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleShape;

/// <summary>
/// 図形描画ソースクラス (Direct2D1による星型描画)
/// </summary>
public class CustomShapeSource : IShapeSource
{
    private readonly IGraphicsDevicesAndContext devices;
    private readonly CustomShapeParameter parameter;
    private ID2D1CommandList? commandList;
    private ID2D1SolidColorBrush? brush;

    public ID2D1Image Output => commandList!;

    public CustomShapeSource(IGraphicsDevicesAndContext devices, CustomShapeParameter parameter)
    {
        this.devices = devices;
        this.parameter = parameter;
        // 明るい黄色のブラシ
        brush = devices.DeviceContext.CreateSolidColorBrush(new Color4(1.0f, 0.84f, 0.0f, 1.0f));
    }

    public void Update(TimelineItemSourceDescription description)
    {
        commandList?.Dispose();
        commandList = devices.DeviceContext.CreateCommandList();

        var oldTarget = devices.DeviceContext.Target;
        devices.DeviceContext.Target = commandList;
        try
        {
            devices.DeviceContext.BeginDraw();

            float outerR = (float)parameter.Radius.GetValue(description.ItemPosition.Frame, description.ItemDuration.Frame, description.FPS);
            float innerR = outerR * 0.4f;

            if (outerR > 0 && brush != null)
            {
                using var geometry = devices.DeviceContext.Factory.CreatePathGeometry();
                using (var sink = geometry.Open())
                {
                    // 五芒星 (10頂点) の座標計算
                    int points = 5;
                    for (int i = 0; i < points * 2; i++)
                    {
                        double angle = -Math.PI / 2.0 + (i * Math.PI / points);
                        float r = (i % 2 == 0) ? outerR : innerR;
                        var pt = new Vector2((float)(Math.Cos(angle) * r), (float)(Math.Sin(angle) * r));

                        if (i == 0)
                        {
                            sink.BeginFigure(pt, FigureBegin.Filled);
                        }
                        else
                        {
                            sink.AddLine(pt);
                        }
                    }
                    sink.EndFigure(FigureEnd.Closed);
                    sink.Close();
                }

                devices.DeviceContext.FillGeometry(geometry, brush);
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
