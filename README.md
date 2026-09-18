# YMM4plugin_template
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](#)
[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](#)
[![Downloads](https://img.shields.io/github/downloads/leftcontroller0518/YMM4plugin_template/total)](https://github.com/leftcontroller0518/YMM4plugin_template/releases/latest)

## 概要
当リポジトリは私左コントローラーが作成したYMM4プラグインのテンプレートです。

MITライセンスを採用しているためライセンスの許容範囲内でならご自由にお使いいただけます。

## 使い方
1. releaseから[最新のリリース](https://github.com/leftcontroller0518/YMM4plugin_template/releases/latest)にアクセス
2. 「ymm4plugin_template.zip」をダウンロード
3. ダウンロードしたzipファイルを展開
4. フォルダ分けされているため、使いたいテンプレートに対応するフォルダをコピーする。

**対応表**
|フォルダ|できること|
|-|-|
|``video_effect/nomal``|映像エフェクト|
|``video_effect/HLSL_video_effect``|HLSLを使用した映像エフェクト|
|``audio_effect``|音声エフェクト|
|``audio_spectrum``|波形|
|``video_writer``|動画出力|
|``shape``|図形を追加|
|``timeline``|タイムライン操作|
|``tool``|ツールタブ関連|
|``setting``|設定に項目を追加|
|``harmony/easing``|harmonyライブラリを使用してイージングを拡張|
|``harmony/coloepicker``|harmonyライブラリを使用してカラーピッカーを拡張|

5. コードを自由に編集する。

## ファイル構成
ほとんどのフォルダ内のファイル構成は以下のようになっています。
```
plugin/
├── plugin.sln                   …ソリューションファイル
├── plugin/                      …プラグインのプロジェクトフォルダ
│   ├── plugin.csproj            …プロジェクトファイル
│   ├── pluginMain.cs            …プラグインのメイン処理・エントリポイント
│   ├── pluginParameter.cs       …エフェクトなどのパラメータ・設定用クラス
│   ├── Shaders/                 …（映像エフェクトなどの場合）HLSLシェーダーファイル
│   │   └── Effect.hlsl
│   └── Properties/              …アセンブリ情報など
|       └── LaunchSetting.json
├── Directory.Build.props        …YMM4のインストールパスを指定する設定ファイル
└── README.md                    …説明書・ドキュメント
```
不明な点などがあれば対象フォルダのREADME.mdをご参照ください。

## コードについて
- ライセンスはMIT LICENSEを採用しています。
- 制作にはClaude、ChatGPT、GeminiなどのAIを使用しています。予めご了承ください。
- すべてのコードは、アップデート時に毎回Windows11環境でビルド成功およびYMM4側での動作を検証済みのため、安心してご使用ください。

当リポジトリの最終更新日: <!-- last-updated -->2026-01-01<!-- /last-updated -->
