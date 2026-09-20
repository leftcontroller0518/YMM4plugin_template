# Timeline: タイムライン操作ツールプラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) のタイムライン情報を取得・操作するツールタブプラグインを開発するためのテンプレートです。
`ITimelineToolViewModel` を実装し、現在編集中のプロジェクトのタイムライン情報（アイテム一覧、選択中アイテム、現在のフレーム、レイヤー構成など）にアクセスするサンプルが含まれています。

## フォルダ構成
```text
Timeline/
├── SampleTimelineTool.sln          # Visual Studio ソリューション
├── Directory.Build.props            # YMM4参照・配置設定
├── README.md                        # 本ドキュメント
└── SampleTimelineTool/
    ├── SampleTimelineTool.csproj    # プロジェクトファイル (WPF有効)
    ├── TimelinePlugin.cs            # ツールプラグイン定義 (IToolPlugin)
    ├── TimelineToolViewModel.cs     # ViewModel (IToolViewModel, ITimelineToolViewModel)
    ├── TimelineToolView.xaml        # WPF UI 画面
    ├── TimelineToolView.xaml.cs     # View コードビハインド
    └── Properties/
        └── launchSettings.json      # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleTimelineTool.sln` を Visual Studio で開きます。
2. `F5` キーを押してデバッグ実行すると、ビルドと YMM4 への配置が行われて YMM4 が起動します。
3. YMM4 メイン画面の「表示 > パネル」または「ツール」メニューから「タイムライン操作サンプル」を開いて動作確認できます。

## 改造のポイント
- **タイムラインアイテムの操作**: `TimelineToolInfo.Timeline` から `Items` コレクションの列挙や、選択中アイテム (`SelectedItems`) の一括プロパティ変更・移動などが行えます。
- **アンドゥ・リドゥ連携**: `TimelineToolInfo.UndoRedoManager` を使うことで、独自操作の元に戻す・やり直しの履歴管理を YMM4 と統合できます。
