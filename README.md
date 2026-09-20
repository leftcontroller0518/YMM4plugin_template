# ゆっくりMovieMaker4 (YMM4) プラグイン開発テンプレート集

ゆっくりMovieMaker4 (YMM4) プラグイン開発用の汎用テンプレートリポジトリです。  
対応する全11種類のプラグイン種別ごとに独立したフォルダ・ソリューションで構成されており、Visual Studio ですぐに開いて開発・ビルド・デバッグが可能です。

---

## 収録テンプレート一覧

| 種類 | フォルダ | 説明 |
| :--- | :--- | :--- |
| **Video_Effect/Normal** | [`Video_Effect/Normal`](file:///d:/YMM4plugins/YMM4plugin_template/Video_Effect/Normal) | 標準映像エフェクト (Direct2D1 ColorMatrix 不透明度調整) |
| **Video_Effect/HLSL** | [`Video_Effect/HLSL`](file:///d:/YMM4plugins/YMM4plugin_template/Video_Effect/HLSL) | Direct2D1 カスタムピクセルシェーダー (HLSL色反転 & 自動コンパイル) |
| **Audio_Effect** | [`Audio_Effect`](file:///d:/YMM4plugins/YMM4plugin_template/Audio_Effect) | 音声エフェクト (音量ゲイン調整 & DSPサンプル処理) |
| **Audio_Spectrum** | [`Audio_Spectrum`](file:///d:/YMM4plugins/YMM4plugin_template/Audio_Spectrum) | 音声波形表示 (周波数スペクトル配列のDirect2Dバー描画) |
| **Video_Writer** | [`Video_Writer`](file:///d:/YMM4plugins/YMM4plugin_template/Video_Writer) | 動画出力 (生ピクセルRGBAバイト列 & 音声PCM出力) |
| **Shape** | [`Shape`](file:///d:/YMM4plugins/YMM4plugin_template/Shape) | 図形アイテム (Direct2D1 パスジオメトリによる星型描画) |
| **Timeline** | [`Timeline`](file:///d:/YMM4plugins/YMM4plugin_template/Timeline) | タイムライン操作 (アイテム一覧、選択中アイテム、フレーム情報取得) |
| **Tool** | [`Tool`](file:///d:/YMM4plugins/YMM4plugin_template/Tool) | 汎用ツールタブ (WPF UI & 状態の自動保存/復元) |
| **Setting** | [`Setting`](file:///d:/YMM4plugins/YMM4plugin_template/Setting) | 設定画面 (設定タブ追加 & JSON自動永続化) |
| **harmony/Easing** | [`harmony/Easing`](file:///d:/YMM4plugins/YMM4plugin_template/harmony/Easing) | Harmonyによるイージング計算フック (`Easing.GetValue`) |
| **harmony/DrawMethodHook** | [`harmony/DrawMethodHook`](file:///d:/YMM4plugins/YMM4plugin_template/harmony/DrawMethodHook) | Harmonyによる描画メソッドフック (`EffectedItemSource.Update`) |

---

## 全テンプレート共通の仕様

### 1. 共通設定ファイル (`Directory.Build.props`)
各テンプレートフォルダ内およびルートに `Directory.Build.props` を配置しています。
```xml
<Project>
  <PropertyGroup>
    <YMM4DirPath>C:\YMM4\</YMM4DirPath>
  </PropertyGroup>
</Project>
```
開発の際には、「C:\YMM4\」を皆様の環境の実際のYMM4フォルダパスに書き換えてください。

### 2. デバッグ実行 (`launchSettings.json`)
各プロジェクトの `Properties/launchSettings.json` に F5 デバッグ設定が含まれています。
Visual Studio で `F5` キーを押すと、自動的にビルド → プラグインフォルダへ DLL コピー → YMM4 の起動まで一気に行われます。

### 3. HLSL シェーダーの自動コンパイル
`Video_Effect/HLSL` では、Windows SDK の `fxc.exe` を使ってビルド前に `Shaders/Effect.hlsl` を `Shaders/Effect.cso` へ自動コンパイルし、DLL 内に埋め込みリソースとして自動同梱します。

---

## 使い方・始め方
1. 開発したい種別のフォルダ（例: `Video_Effect/Normal`）を開きます。
2. ソリューションファイル（例: `SampleVideoEffectNormal.sln`）を Visual Studio で開きます。
3. `F5` キーを押してビルド＆デバッグ起動します。
4. YMM4 上で作成したプラグインの動作を確認しながらコードを変更できます。