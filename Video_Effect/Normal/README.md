# Video_Effect/Normal: 標準映像エフェクトプラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の標準映像エフェクトを開発するためのテンプレートです。
Direct2D1 のカラーマトリクスエフェクトを使用した不透明度調整のサンプル実装が含まれています。

## フォルダ構成
```text
Normal/
├── SampleVideoEffectNormal.sln          # Visual Studio ソリューション
├── Directory.Build.props                 # YMM4インストール先や共通参照設定
├── README.md                             # 本ドキュメント
└── SampleVideoEffectNormal/
    ├── SampleVideoEffectNormal.csproj    # プロジェクトファイル
    ├── VideoEffectNormalPlugin.cs        # エフェクトのパラメータ・UI定義
    ├── VideoEffectNormalProcessor.cs     # フレーム毎の描画処理 (Direct2D1)
    └── Properties/
        └── launchSettings.json           # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleVideoEffectNormal.sln` を Visual Studio で開きます。
2. 必要に応じて `Directory.Build.props` 内の `<YMM4DirPath>` をお使いの YMM4 インストール先に変更します（デフォルト: `C:\YMM4\`）。
3. Visual Studio で `F5` キーを押すか、デバッグ実行を開始すると、プロジェクトがビルドされ、自動的に YMM4 の `user\plugin\SampleVideoEffectNormal\` フォルダに出力 DLL が配置されて YMM4 が起動します。
4. YMM4 のアイテム（画像・動画・テキスト等）のエフェクト追加メニューから「カスタム > サンプル映像エフェクト」を選択して動作確認できます。

## 改造のポイント
- **パラメータの追加**: `VideoEffectNormalPlugin.cs` にプロパティを追加し、`[Display]` や `[AnimationSlider]` などの属性を付与します。
- **描画処理の変更**: `VideoEffectNormalProcessor.cs` で Direct2D1 の各種エフェクト（ブラー、色調補正、変形など）を組み合わせてチェーンを構築します。
