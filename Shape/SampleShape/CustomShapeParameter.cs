using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleShape;

/// <summary>
/// 図形パラメータ定義クラス
/// </summary>
public class CustomShapeParameter : ShapeParameterBase
{
    public CustomShapeParameter(SharedDataStore? sharedData) : base(sharedData)
    {
    }

    /// <summary>
    /// 星のサイズ (半径)
    /// </summary>
    [Display(Name = "半径", Description = "星形の外半径")]
    [AnimationSlider("F0", "px", 10, 1000)]
    public Animation Radius { get; } = new Animation(150, 10, 1000);

    public override IShapeSource CreateShapeSource(IGraphicsDevicesAndContext devices)
    {
        return new CustomShapeSource(devices, this);
    }

    public override IEnumerable<string> CreateShapeItemExoFilter(int keyFrameIndex, ExoOutputDescription desc)
    {
        return [];
    }

    public override IEnumerable<string> CreateMaskExoFilter(int keyFrameIndex, ExoOutputDescription desc, ShapeMaskExoOutputDescription shapeMaskParameters)
    {
        return [];
    }

    protected override void LoadSharedData(SharedDataStore store)
    {
    }

    protected override void SaveSharedData(SharedDataStore store)
    {
    }

    protected override IEnumerable<IAnimatable> GetAnimatables() => [Radius];
}
