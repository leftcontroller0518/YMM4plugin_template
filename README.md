# YMM4plugin_template
[![License](https://img.shields.io/badge/license-MIT-blue.svg)](#)
[![.NET](https://img.shields.io/badge/.NET-10.0-blue.svg)](#)
[![C#](https://shields.io/badge/lang-CSharp-blue.svg)](#)
[![Downloads](https://img.shields.io/github/downloads/leftcontroller0518/YMM4plugin_template/total)](https://github.com/leftcontroller0518/YMM4plugin_template/releases/latest)

## 概要
当リポジトリは私左コントローラーが作成したYMM4プラグインのテンプレートです。

MITライセンスを採用しているためライセンスの許容範囲内でならご自由にお使いいただけます。

> [!warning]
> 本リポジトリはC#に関する知識をお持ちの方を対象としています。

## 使い方
1. releaseから[最新のリリース](https://github.com/leftcontroller0518/YMM4plugin_template/releases/latest)にアクセス
2. 「ymm4plugin_template.zip」をダウンロード
3. ダウンロードしたzipファイルを展開
4. フォルダ分けされているため、使いたいテンプレートに対応するフォルダをコピーする。
5. コードを自由に編集する。
> [!tip]
> フォルダごとの対応表は[こちら](#対応表)を、
> 
> ファイル構成は[こちら](#ファイル構成)をご参照ください。

## 対応表
|フォルダ|できること|
|-|-|
|``Video_Effect/Nomal``|映像エフェクト|
|``Video_Effect/HLSL``|HLSLを使用した映像エフェクト|
|``Audio_Effect``|音声エフェクト|
|``Audio_Spectrum``|波形|
|``Video_Writer``|動画出力|
|``Shape``|図形を追加|
|``Timeline|タイムライン操作|
|``Tool``|ツールタブ関連|
|``Setting``|設定に項目を追加|
|``harmony/Easing``|harmonyライブラリを使用してイージングを拡張|
|``harmony/DrawMethodHook``|harmonyライブラリを使用して描画メソッドをフック|

## ファイル構成
ほとんどのフォルダ内のファイル構成は以下のようになっています。

例外はありますがほとんどがこの形です。

また、先述の通り本リポジトリはC#に関する知識をお持ちの方を対象としています。予めご了承ください。
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
フォルダ内のファイルやコードで不明な点などがあれば対象フォルダのREADME.mdをご参照ください。

## ライセンス (License)
このプロジェクトは [MIT License](LICENSE) の下で公開されています。

## コードについて
- 制作にはClaude、ChatGPT、GeminiなどのAIを使用しています。予めご了承ください。
- すべてのコードは、アップデート時に毎回Windows11環境でビルド成功およびYMM4側での動作を検証済みのため、安心してご使用ください。
- Issues、PRも大歓迎です。
- 本リポジトリは[Harmonyライブラリ](https://github.com/pardeike/harmony)を使用しています。

## 更新履歴
|日時|ver|内容|修正|
|-|-|-|-|
|2026/09/??|v1.0.0|公開|-|

### 【予定しているアップデート】
- 多言語対応
- 立ち絵プラグインサンプルの作成
- サンプル使用例の同梱
