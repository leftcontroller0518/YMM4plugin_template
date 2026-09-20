# Video_Effect/HLSL: HLSLピクセルシェーダー映像エフェクト テンプレート

ゆっくりMovieMaker4 (YMM4) の Direct2D カスタムピクセルシェーダー (HLSL) による映像エフェクト開発テンプレートです。
色反転シェーダーと定数バッファによるパラメータ渡し、およびビルド時の自動シェーダーコンパイル環境が含まれています。

## フォルダ構成
```text
HLSL/
├── SampleVideoEffectHLSL.sln          # Visual Studio ソリューション
├── Directory.Build.props               # YMM4参照・配置設定
├── README.md                           # 本ドキュメント
└── SampleVideoEffectHLSL/
    ├── SampleVideoEffectHLSL.csproj    # プロジェクトファイル (HLSL自動コンパイル設定内蔵)
    ├── VideoEffectHLSLPlugin.cs        # エフェクトのパラメータ・UI定義
    ├── VideoEffectHLSLProcessor.cs     # 描画プロセッサ
    ├── EffectShader.cs                 # Direct2D1カスタムシェーダー実装 (D2D1CustomShaderEffectBase)
    ├── Shaders/
    │   ├── Effect.hlsl                 # HLSLピクセルシェーダーソースコード
    │   └── Effect.cso                  # コンパイル済みシェーダーバイナリ
    └── Properties/
        └── launchSettings.json         # F5デバッグ起動設定
```

## HLSLシェーダーのコンパイルについて
- プロジェクトファイル (`SampleVideoEffectHLSL.csproj`) には、ビルド時に Windows SDK の `fxc.exe` を使って `Effect.hlsl` を `Effect.cso` に自動コンパイルするターゲットが含まれています。
- `Effect.cso` は埋め込みリソースとして DLL 内に同梱されるため、シェーダーバイナリ単体を別途配置する必要はありません。
- 初期状態でビルド済みの `Effect.cso` も同梱されているため、環境に `fxc.exe` がない場合でもそのままビルド可能です。

## 開発・デバッグ方法
1. `SampleVideoEffectHLSL.sln` を Visual Studio で開きます。
2. `F5` キーを押してデバッグ起動すると、自動的にビルド＆配置され YMM4 が起動します。
3. エフェクト追加メニューから「カスタム > サンプルHLSL色反転」を追加して動作確認できます。

## 改造のポイント
- **シェーダー処理の変更**: `Shaders/Effect.hlsl` のピクセルシェーダーロジックを変更します（色調補正、歪み、ノイズ、ブラー等）。
- **定数バッファの追加**: `Effect.hlsl` の `cbuffer` と `EffectShader.cs` の `ShaderConstants` 構造体、および `EffectImpl` のプロパティを対応させて拡張します。
