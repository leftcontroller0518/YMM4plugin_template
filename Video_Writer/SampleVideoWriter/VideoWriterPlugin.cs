using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileWriter;
using YukkuriMovieMaker.Project;

namespace SampleVideoWriter;

/// <summary>
/// 動画出力プラグイン定義クラス
/// </summary>
public class VideoWriterPlugin : IVideoFileWriterPlugin
{
    public string Name => "サンプル動画出力 (Raw RGBA)";

    /// <summary>
    /// 出力パスのモード (単一ファイル出力: File, ディレクトリ出力: Directory)
    /// </summary>
    public VideoFileWriterOutputPath OutputPathMode => VideoFileWriterOutputPath.File;

    /// <summary>
    /// 出力ファイルの拡張子
    /// </summary>
    public string GetFileExtention() => ".raw";

    /// <summary>
    /// 出力設定用UI
    /// </summary>
    public UIElement GetVideoConfigView(string projectName, VideoInfo videoInfo, int length) => new UserControl();

    /// <summary>
    /// 追加リソース (外部エンコーダ等) のダウンロードが必要かどうか
    /// </summary>
    public bool NeedDownloadResources() => false;

    /// <summary>
    /// 外部リソースダウンロード処理
    /// </summary>
    public Task DownloadResources(ProgressMessage progress, CancellationToken token) => Task.CompletedTask;

    /// <summary>
    /// ライターインスタンスの生成
    /// </summary>
    public IVideoFileWriter CreateVideoFileWriter(string path, VideoInfo videoInfo)
    {
        return new VideoWriterInstance(path, videoInfo);
    }
}
