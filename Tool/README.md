# Tool: 汎用ツールタブプラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) のツールタブ（ドッキング可能パネル）プラグインを開発するためのテンプレートです。
WPFによるユーザーインターフェースを持ち、パネルの開閉状態や入力内容の自動保存・復元（`SaveState`/`LoadState`）に対応した文字数カウントツールのサンプル実装が含まれています。

## フォルダ構成
```text
Tool/
├── SampleTool.sln          # Visual Studio ソリューション
├── Directory.Build.props    # YMM4参照・配置設定
├── README.md                # 本ドキュメント
└── SampleTool/
    ├── SampleTool.csproj    # プロジェクトファイル (WPF有効)
    ├── ToolPlugin.cs        # ツールプラグイン定義 (IToolPlugin)
    ├── SampleToolViewModel.cs # ViewModel (IToolViewModel, 状態保存)
    ├── SampleToolView.xaml  # WPF UI 画面
    ├── SampleToolView.xaml.cs # View コードビハインド
    └── Properties/
        └── launchSettings.json # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleTool.sln` を Visual Studio で開きます。
2. `F5` キーでデバッグ実行すると、ビルドと YMM4 への配置が行われて YMM4 が起動します。
3. メイン画面上部メニューの「表示 > パネル」または「ツール」から「サンプル汎用ツール」を開いてパネルを表示できます。他のパネルと同様に自由にドッキング・フローティング配置が可能です。

## 改造のポイント
- **UI機能の実装**: `SampleToolView.xaml` にボタンや入力欄、リストビューなどを配置し、台本生成、外部API連携、メモ帳、辞書引きなど自由な補助ツール画面を作成できます。
- **状態の保存**: `SampleToolViewModel.cs` の `SaveState()` で文字列やオブジェクトを保存しておくと、YMM4 の終了・再起動時にも入力データが引き継がれます。
