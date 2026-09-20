using YukkuriMovieMaker.Plugin;

namespace SampleSetting;

/// <summary>
/// プラグイン設定クラス
/// </summary>
public class SampleSettings : SettingsBase<SampleSettings>
{
    private string apiKey = "";
    private bool enableCustomFeature = true;
    private int timeoutSeconds = 30;

    /// <summary>
    /// 設定のカテゴリ (Other, Tool, VideoEffect 等)
    /// </summary>
    public override SettingsCategory Category => SettingsCategory.Other;

    /// <summary>
    /// 設定画面上の表示名
    /// </summary>
    public override string Name => "サンプルプラグイン設定";

    /// <summary>
    /// 設定画面UIを持つかどうか
    /// </summary>
    public override bool HasSettingView => true;

    /// <summary>
    /// 設定画面のViewインスタンス
    /// </summary>
    public override object SettingView => new SampleSettingView { DataContext = this };

    /// <summary>
    /// APIキー設定
    /// </summary>
    public string ApiKey
    {
        get => apiKey;
        set => Set(ref apiKey, value);
    }

    /// <summary>
    /// カスタム機能の有効/無効
    /// </summary>
    public bool EnableCustomFeature
    {
        get => enableCustomFeature;
        set => Set(ref enableCustomFeature, value);
    }

    /// <summary>
    /// タイムアウト秒数
    /// </summary>
    public int TimeoutSeconds
    {
        get => timeoutSeconds;
        set => Set(ref timeoutSeconds, value);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    public override void Initialize()
    {
    }
}
