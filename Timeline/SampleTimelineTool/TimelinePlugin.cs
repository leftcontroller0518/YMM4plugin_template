using System;
using YukkuriMovieMaker.Plugin;

namespace SampleTimelineTool;

/// <summary>
/// タイムライン操作ツールプラグイン定義
/// </summary>
public class TimelinePlugin : IToolPlugin
{
    public string Name => "タイムライン操作サンプル";

    public Type ViewModelType => typeof(TimelineToolViewModel);

    public Type ViewType => typeof(TimelineToolView);

    public bool AllowMultipleInstances => false;

    public string DefaultGroupName => "タイムライン";

    public int DefaultOrder => 0;
}
