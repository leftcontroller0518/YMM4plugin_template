# Shape: 図形プラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の図形アイテム拡張プラグインを開発するためのテンプレートです。
Direct2D1 のパスジオメトリ (`ID2D1PathGeometry`) を使用してベクター星形図形を描画する実装が含まれています。

## フォルダ構成
```text
Shape/
├── SampleShape.sln          # Visual Studio ソリューション
├── Directory.Build.props     # YMM4参照・配置設定
├── README.md                 # 本ドキュメント
└── SampleShape/
    ├── SampleShape.csproj    # プロジェクトファイル
    ├── ShapePlugin.cs        # 図形プラグイン定義 (IShapePlugin)
    ├── CustomShapeParameter.cs # 図形のサイズ等のプロパティ定義 (ShapeParameterBase)
    ├── CustomShapeSource.cs  # Direct2D1ジオメトリによるベクター描画 (IShapeSource)
    └── Properties/
        └── launchSettings.json # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleShape.sln` を Visual Studio で開きます。
2. `F5` キーでデバッグ実行すると、ビルドと YMM4 への配置が行われて YMM4 が起動します。
3. タイムラインの「図形」アイテムを追加し、図形の種類一覧から「サンプル星型」を選択して動作確認できます。

## 改造のポイント
- **形状のカスタマイズ**: `CustomShapeSource.cs` 内の `sink.BeginFigure` / `sink.AddLine` / `sink.AddBezier` 等を使って、多角形、ハート形、矢印、吹き出しなど任意のベクターシェイプを作成できます。
- **プロパティの拡張**: `CustomShapeParameter.cs` に頂点数や丸み、比率などのプロパティを追加できます。
