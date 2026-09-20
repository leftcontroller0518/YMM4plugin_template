# Audio_Effect: 音声エフェクトプラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の音声エフェクトプラグインを開発するためのテンプレートです。
音声ストリームからサンプルを読み出し、波形データの振幅（音量ゲイン）を変更するサンプル実装が含まれています。

## フォルダ構成
```text
Audio_Effect/
├── SampleAudioEffect.sln          # Visual Studio ソリューション
├── Directory.Build.props           # YMM4参照・配置設定
├── README.md                       # 本ドキュメント
└── SampleAudioEffect/
    ├── SampleAudioEffect.csproj    # プロジェクトファイル
    ├── AudioEffectPlugin.cs        # 音声エフェクトのパラメータ・UI定義
    ├── AudioEffectProcessor.cs     # 音声サンプルの処理プロセッサ (AudioEffectProcessorBase)
    └── Properties/
        └── launchSettings.json     # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleAudioEffect.sln` を Visual Studio で開きます。
2. `F5` キーを押すとビルドと YMM4 への DLL 配置が行われ、YMM4 が起動します。
3. 音声アイテム（ボイスやBGM・SE等）の音声エフェクト追加メニューから「カスタム > サンプル音量調整」を追加してテストできます。

## 改造のポイント
- **DSP処理の実装**: `AudioEffectProcessor.cs` の `read` メソッド内で、渡された `float[] destBuffer` のサンプル配列に対してフィルター（ローパス・ハイパス・ピッチシフト・ディレイ・リバーブなど）の計算を実装します。
- **パラメータの追加**: `AudioEffectPlugin.cs` に `Animation` プロパティを追加し、UI上でキーフレームアニメーション可能な設定項目を増やせます。
