# Video_Writer: 動画出力プラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の動画出力（エクスポート）プラグインを開発するためのテンプレートです。
レンダリングされた各フレームの生ピクセルデータ（BGRAバイト列）および音声サンプル（32bit float PCM）を直接ファイルに出力する実装が含まれています。

## フォルダ構成
```text
Video_Writer/
├── SampleVideoWriter.sln          # Visual Studio ソリューション
├── Directory.Build.props           # YMM4参照・配置設定
├── README.md                       # 本ドキュメント
└── SampleVideoWriter/
    ├── SampleVideoWriter.csproj    # プロジェクトファイル
    ├── VideoWriterPlugin.cs        # 出力プラグイン定義 (IVideoFileWriterPlugin)
    ├── VideoWriterInstance.cs      # 出力ストリーム書き込み処理 (IVideoFileWriter)
    └── Properties/
        └── launchSettings.json     # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleVideoWriter.sln` を Visual Studio で開きます。
2. `F5` キーでデバッグ実行すると、ビルド後に YMM4 が起動します。
3. YMM4 の「ファイル > 動画出力」画面の出力形式一覧から「サンプル動画出力 (Raw RGBA)」を選択して出力テストを行えます。

## 改造のポイント
- **エンコーダの統合**: `VideoWriterInstance.cs` の `WriteVideo` および `WriteAudio` メソッド内で、FFmpeg / MediaFoundation / 独自の画像エンコーダ（PNG, WebP, GIF, MP4等）へフレームデータを送り込みます。
- **設定UIの追加**: `VideoWriterPlugin.cs` の `GetVideoConfigView` で WPF UserControl を返すことで、ビットレートやコーデック選択などのカスタム設定画面を動画出力ダイアログ内に表示できます。
