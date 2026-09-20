using System;
using HarmonyLib;
using YukkuriMovieMaker.Commons;

namespace SampleHarmonyEasing;

/// <summary>
/// アニメーションのイージング進行度計算 (Animation.GetEasingRate) へのパッチクラス
/// </summary>
[HarmonyPatch(typeof(Animation), "GetEasingRate")]
public static class AnimationPatch
{
    [HarmonyPrefix]
    public static bool Prefix(Animation __instance, double rate, ref double __result)
    {
        int animType = (int)__instance.AnimationType;

        switch (animType)
        {
            case MenuPatch.CustomEasing_In:
                // 【サンプルIn】少しバックしてから急加速するカーブ
                __result = CalculateCustomIn(rate);
                return false;

            case MenuPatch.CustomEasing_Out:
                // 【サンプルOut】行き過ぎてから減衰しながらピタッと止まるバウンスカーブ
                __result = CalculateCustomOut(rate);
                return false;

            case MenuPatch.CustomEasing_InOut:
                // 【サンプルInOut】緩急を極端に強調したS字カーブ
                __result = CalculateCustomInOut(rate);
                return false;

            case MenuPatch.CustomEasing_OutIn:
                // 【サンプルOutIn】中間で一瞬減速する反転カーブ
                __result = CalculateCustomOutIn(rate);
                return false;
        }

        // カスタムID以外は標準の計算を実行
        return true;
    }

    private static double CalculateCustomIn(double t)
    {
        const double c1 = 1.70158;
        const double c3 = c1 + 1.0;
        return c3 * t * t * t - c1 * t * t;
    }

    private static double CalculateCustomOut(double t)
    {
        // 減衰振動 (Elastic Out風)
        if (t <= 0.0) return 0.0;
        if (t >= 1.0) return 1.0;
        return Math.Pow(2.0, -10.0 * t) * Math.Sin((t * 10.0 - 0.75) * ((2.0 * Math.PI) / 3.0)) + 1.0;
    }

    private static double CalculateCustomInOut(double t)
    {
        // 五次カーブ (Quint InOut)
        return t < 0.5 
            ? 16.0 * t * t * t * t * t 
            : 1.0 - Math.Pow(-2.0 * t + 2.0, 5.0) / 2.0;
    }

    private static double CalculateCustomOutIn(double t)
    {
        // 中間でゆったりするOutInカーブ
        if (t < 0.5)
        {
            double sub = 1.0 - 2.0 * t;
            return 0.5 * (1.0 - sub * sub);
        }
        else
        {
            double sub = 2.0 * (t - 0.5);
            return 0.5 + 0.5 * (sub * sub);
        }
    }
}
