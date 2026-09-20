using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin;

namespace SampleTimelineTool;

/// <summary>
/// タイムライン操作ツールのViewModel
/// </summary>
public class TimelineToolViewModel : IToolViewModel, ITimelineToolViewModel, INotifyPropertyChanged
{
    private TimelineToolInfo? timelineToolInfo;
    private string statusMessage = "タイムライン未接続";

    public string Title => "タイムライン操作";

    public bool CanSuspend => true;

#pragma warning disable CS0067
    public event EventHandler<CreateNewToolViewRequestedEventArgs>? CreateNewToolViewRequested;
#pragma warning restore CS0067

    public string StatusMessage
    {
        get => statusMessage;
        set
        {
            if (statusMessage != value)
            {
                statusMessage = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand CheckTimelineCommand { get; }

    public TimelineToolViewModel()
    {
        CheckTimelineCommand = new ActionCommand(_ =>
        {
            if (timelineToolInfo?.Timeline != null)
            {
                var tl = timelineToolInfo.Timeline;
                int itemCount = tl.Items.Count;
                int currentFrame = tl.CurrentFrame;
                int maxLayer = tl.MaxLayer;
                int selectedCount = tl.SelectedItems.Count;
                StatusMessage = $"アイテム数: {itemCount}個 / 最大レイヤー: {maxLayer} / 現在フレーム: {currentFrame} / 選択中: {selectedCount}個";
            }
            else
            {
                StatusMessage = "タイムライン情報が取得できません";
            }
        });
    }

    public void SetTimelineToolInfo(TimelineToolInfo info)
    {
        timelineToolInfo = info;
        StatusMessage = "タイムラインに接続しました";
    }

    public ToolState SaveState()
    {
        return new ToolState { Title = Title };
    }

    public void LoadState(ToolState stateData)
    {
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

/// <summary>
/// 簡易ICommand実装
/// </summary>
public class ActionCommand : ICommand
{
    private readonly Action<object?> execute;
    private readonly Func<object?, bool>? canExecute;

    public ActionCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;
    public void Execute(object? parameter) => execute(parameter);
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}
