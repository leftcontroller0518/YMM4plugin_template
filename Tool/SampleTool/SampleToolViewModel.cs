using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YukkuriMovieMaker.Plugin;

namespace SampleTool;

/// <summary>
/// 汎用ツールタブのViewModel
/// </summary>
public class SampleToolViewModel : IToolViewModel, INotifyPropertyChanged
{
    private string inputText = "";
    private int characterCount = 0;

    public string Title => "文字数チェッカー";

    public bool CanSuspend => true;

#pragma warning disable CS0067
    public event EventHandler<CreateNewToolViewRequestedEventArgs>? CreateNewToolViewRequested;
#pragma warning restore CS0067

    public string InputText
    {
        get => inputText;
        set
        {
            if (inputText != value)
            {
                inputText = value;
                CharacterCount = value.Length;
                OnPropertyChanged();
            }
        }
    }

    public int CharacterCount
    {
        get => characterCount;
        private set
        {
            if (characterCount != value)
            {
                characterCount = value;
                OnPropertyChanged();
            }
        }
    }

    public ToolState SaveState()
    {
        return new ToolState
        {
            Title = Title,
            SavedState = InputText
        };
    }

    public void LoadState(ToolState stateData)
    {
        if (!string.IsNullOrEmpty(stateData.SavedState))
        {
            InputText = stateData.SavedState;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
