# harmony/Easing: Harmonyによるイージング拡張プラグイン テンプレート

Lib.Harmony (v2.4.2) を用いて、ゆっくりMovieMaker4 (YMM4) のイージングメニューおよびイージング計算処理をランタイムでフック・拡張するためのプラグインテンプレートです。

## フォルダ構成
```text
Easing/
├── SampleHarmonyEasing.sln          # Visual Studio ソリューション
├── Directory.Build.props             # YMM4参照設定
├── README.md                         # 本ドキュメント
└── SampleHarmonyEasing/
    ├── SampleHarmonyEasing.csproj    # プロジェクトファイル (Lib.Harmony NuGet内蔵)
    ├── HarmonyEasingPlugin.cs        # プラグイン起動時のHarmonyパッチ適用エントリポイント
    ├── MenuPatch.cs                  # アニメーションスライダー右クリックメニューへの項目追加
    ├── AnimationPatch.cs             # Animation.GetEasingRate でのカスタムイージング計算
    ├── UIConverterPatch.cs           # ボタン略称文字 ("サ") やツールチップの表示定義
    ├── EasingPatch.cs                # Easing.GetValue へのPrefix/Postfixフック（既存計算上書き例）
    └── Properties/
        └── launchSettings.json       # F5デバッグ起動設定
```

## 実装されている拡張機能
1. **メニュー項目への追加 (`MenuPatch.cs`)**:
   - アニメーションスライダーの右クリックメニュー内に「サンプルイージング (Custom)」グループを追加。
   - `In` / `Out` / `InOut` / `OutIn` の4モードを選択可能。
2. **カスタムイージングの計算 (`AnimationPatch.cs`)**:
   - `In`: オーバーシュート加速
   - `Out`: 減衰振動バウンス
   - `InOut`: 強調S字カーブ
   - `OutIn`: 反転S字カーブ
3. **UI表示 (`UIConverterPatch.cs`)**:
   - スライダー横のボタンに略称「サ」を表示し、マウスホバー時に適切なツールチップを表示。
4. **標準イージングの改造 (`EasingPatch.cs`)**:
   - YMM4組み込みの `Easing.GetValue` をフックして既存のイージング挙動を上書きするサンプルコード。

## 使い方・確認手順
1. ソリューションをビルドすると、DLLが自動的に `$(YMM4DirPath)user\plugin\SampleHarmonyEasing\` に配置されます。
2. YMM4 を起動します。
3. アイテム（図形・テキスト・画像など）のプロパティ（「X座標」「拡大率」などのアニメーションスライダー）の右端またはスライダー上を **右クリック** します。
4. メニュー下部に **「サンプルイージング (Custom)」** が追加されているので、お好みのモード（In / Out / InOut / OutIn）を選択します。
5. タイムラインを再生すると、独自のイージングカーブでアニメーションします。
