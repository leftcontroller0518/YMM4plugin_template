using System;
using YukkuriMovieMaker.Plugin;

namespace SampleTool;

/// <summary>
/// 汎用ツールタブプラグイン定義
/// </summary>
public class ToolPlugin : IToolPlugin
{
    public string Name => "サンプル汎用ツール";

    public Type ViewModelType => typeof(SampleToolViewModel);

    public Type ViewType => typeof(SampleToolView);

    public bool AllowMultipleInstances => false;

    public string DefaultGroupName => "カスタムツール";

    public int DefaultOrder => 0;
}
