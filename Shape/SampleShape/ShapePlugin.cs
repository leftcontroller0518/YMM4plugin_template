using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleShape;

/// <summary>
/// 図形プラグイン定義クラス
/// </summary>
public class ShapePlugin : IShapePlugin
{
    public string Name => "サンプル星型";

    public bool IsExoShapeSupported => false;

    public bool IsExoMaskSupported => false;

    public string DefaultGroupName => "カスタム";

    public int DefaultOrder => 0;

    public IShapeParameter CreateShapeParameter(SharedDataStore? sharedData)
    {
        return new CustomShapeParameter(sharedData);
    }
}
