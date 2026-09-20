# Setting: 設定画面プラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の設定画面プラグインを開発するためのテンプレートです。
`SettingsBase<T>` を継承し、YMM4 の「設定」画面内に独自の設定タブを追加して設定値の自動永続化（JSON保存・復元）を行う実装が含まれています。

## フォルダ構成
```text
Setting/
├── SampleSetting.sln          # Visual Studio ソリューション
├── Directory.Build.props       # YMM4参照・配置設定
├── README.md                   # 本ドキュメント
└── SampleSetting/
    ├── SampleSetting.csproj    # プロジェクトファイル (WPF有効)
    ├── SampleSettings.cs       # 設定データモデル & プロパティ定義 (SettingsBase<T>)
    ├── SampleSettingView.xaml  # WPF UI 画面
    ├── SampleSettingView.xaml.cs # View コードビハインド
    └── Properties/
        └── launchSettings.json # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleSetting.sln` を Visual Studio で開きます。
2. `F5` キーでデバッグ実行すると、ビルドと YMM4 への配置が行われて YMM4 が起動します。
3. YMM4 メイン画面の「ファイル > 設定」を開くと、一覧に「サンプルプラグイン設定」が追加されていることを確認できます。

## 改造のポイント
- **設定値の追加**: `SampleSettings.cs` にプロパティを追加し、getter/setter で `Set(ref field, value)` を呼び出すだけで、値の変更検知および自動保存が行われます。
- **他のプラグインからの参照**: 他のクラスや別プロジェクトから設定値を読み書きしたい場合、`SampleSettings.Default.ApiKey` のようにシングルトンプロパティ `Default` 経由でどこからでも直接アクセス可能です。
