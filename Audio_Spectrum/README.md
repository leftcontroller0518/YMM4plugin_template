# Audio_Spectrum: 音声波形プラグイン テンプレート

ゆっくりMovieMaker4 (YMM4) の音声波形（オーディオスペクトラム）プラグインを開発するためのテンプレートです。
リアルタイムな周波数スペクトル振幅配列を受け取り、Direct2D1 でバー形状のイコライザー波形を描画する実装が含まれています。

## フォルダ構成
```text
Audio_Spectrum/
├── SampleAudioSpectrum.sln          # Visual Studio ソリューション
├── Directory.Build.props             # YMM4参照・配置設定
├── README.md                         # 本ドキュメント
└── SampleAudioSpectrum/
    ├── SampleAudioSpectrum.csproj    # プロジェクトファイル
    ├── AudioSpectrumPlugin.cs        # プラグイン定義 (IAudioSpectrumPlugin)
    ├── AudioSpectrumParameter.cs     # パラメータ・UI定義 (AudioSpectrumParameterBase)
    ├── AudioSpectrumSource.cs        # Direct2D1による波形描画処理 (IAudioSpectrumSource)
    └── Properties/
        └── launchSettings.json       # F5デバッグ起動設定
```

## 開発・デバッグ方法
1. `SampleAudioSpectrum.sln` を Visual Studio で開きます。
2. `F5` キーを押すとビルド＆DLL自動配置が行われ、YMM4 が起動します。
3. YMM4 の「音声波形」アイテムを追加し、波形の種類から「サンプル棒状波形」を選択して動作確認できます。

## 改造のポイント
- **描画スタイルの変更**: `AudioSpectrumSource.cs` 内の `Update` メソッドで、円形スペクトラム、折れ線波形、グラデーションバーなど多彩なDirect2D描画ロジックに差し替えることができます。
- **パラメータの追加**: `AudioSpectrumParameter.cs` に色やバーの本数、太さなどの設定プロパティを追加できます。
