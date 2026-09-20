using System;
using HarmonyLib;
using YukkuriMovieMaker.Commons;

namespace SampleHarmonyEasing;

/// <summary>
/// YMM4標準のイージング計算処理 (Easing.GetValue) へのHarmonyパッチクラス（既存計算の差し替え例）
/// </summary>
[HarmonyPatch(typeof(Easing), nameof(Easing.GetValue))]
public static class EasingPatch
{
    /// <summary>
    /// イージング計算実行前に割り込み (Prefix)
    /// </summary>
    /// <param name="type">イージングの種類 (Linear, Sine, Quad, Cubic, Elastic など)</param>
    /// <param name="mode">イージングのモード (In, Out, InOut, OutIn)</param>
    /// <param name="rate">進行度 (0.0 〜 1.0)</param>
    /// <param name="__result">メソッドの戻り値 (元の処理をスキップする場合に代入)</param>
    /// <returns>元のメソッドを実行する場合は true、スキップする場合は false</returns>
    [HarmonyPrefix]
    public static bool Prefix(EasingType type, EasingMode mode, double rate, ref double __result)
    {
        // 【既存イージングの改造例】
        // もし既存の「弾性 (Elastic)」の計算式を独自のものに置き換えたい場合などに使用します
        /*
        if (type == EasingType.Elastic && mode == EasingMode.Out)
        {
            __result = Math.Sin(rate * Math.PI * 4.5) * Math.Exp(-rate * 4.0) + 1.0;
            return false; // YMM4本来の計算をスキップしてカスタム結果を返す
        }
        */

        return true; // デフォルトでは通常の計算を実行
    }

    /// <summary>
    /// イージング計算実行後に割り込み (Postfix)
    /// </summary>
    [HarmonyPostfix]
    public static void Postfix(EasingType type, EasingMode mode, double rate, ref double __result)
    {
        // 必要に応じて戻り値の微調整・ロギング・クランプなどを実施可能
    }
}
