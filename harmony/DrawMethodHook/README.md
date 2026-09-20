# harmony/DrawMethodHook: Harmonyによる描画メソッドフック テンプレート

Lib.Harmony (v2.4.2) を用いて、ゆっくりMovieMaker4 (YMM4) の内部描画パイプライン（`EffectedItemSource.Update`）を動的にフックするためのプラグインテンプレートです。

## フォルダ構成
```text
DrawMethodHook/
├── SampleHarmonyDrawHook.sln          # Visual Studio ソリューション
├── Directory.Build.props               # YMM4参照・配置設定
├── README.md                           # 本ドキュメント
└── SampleHarmonyDrawHook/
    ├── SampleHarmonyDrawHook.csproj    # プロジェクトファイル (Lib.Harmony NuGet内蔵)
    ├── HarmonyDrawHookPlugin.cs        # プラグイン起動時のHarmonyパッチ適用
    ├── DrawHookPatch.cs                # 描画メソッドへのPrefix/Postfixフック
    └── Properties/
        └── launchSettings.json         # F5デバッグ起動設定
```

## 描画フックの仕組み
- YMM4のアイテム描画処理クラス `EffectedItemSource` は `internal` として定義されています。
- Harmony では `[HarmonyTargetMethod]` 属性と `AccessTools.TypeByName` / `AccessTools.Method` を使用することで、非公開クラスの内部メソッドに対しても安全にパッチを適用できます。
- `DrawHookPatch.cs`:
  - `[HarmonyPrefix]`: 各アイテムの描画処理が実行される直前に割り込み、フレーム情報やアイテム位置情報を取得・検証できます。
  - `[HarmonyPostfix]`: 描画処理が完了した直後に割り込み、生成された出力（`DrawDescription` や `Output` 画像）へのアクセス・事後操作が可能です。

## 開発・デバッグ方法
1. `SampleHarmonyDrawHook.sln` を Visual Studio で開きます。
2. `F5` キーでデバッグ実行すると、ビルド後に DLL および `0Harmony.dll` が自動配置され、YMM4 が起動します。
3. プレビュー再生時に各アイテムの描画更新フックが呼び出されます。
