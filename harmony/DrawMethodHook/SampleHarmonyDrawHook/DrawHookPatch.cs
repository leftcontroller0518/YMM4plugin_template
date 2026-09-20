using System;
using System.Reflection;
using HarmonyLib;
using YukkuriMovieMaker.Player.Video;

namespace SampleHarmonyDrawHook;

/// <summary>
/// YMM4のアイテム描画更新処理 (EffectedItemSource.Update) へのHarmonyパッチ
/// internalクラスのメソッドを HarmonyTargetMethod / AccessTools で動的に特定してフックします
/// </summary>
[HarmonyPatch]
public static class DrawHookPatch
{
    /// <summary>
    /// フック対象のメソッドを動的に取得
    /// </summary>
    [HarmonyTargetMethod]
    public static MethodBase? TargetMethod()
    {
        var targetType = AccessTools.TypeByName("YukkuriMovieMaker.Player.Video.EffectedItemSource");
        if (targetType == null) return null;
        return AccessTools.Method(targetType, "Update", [typeof(TimelineItemSourceDescription)]);
    }

    /// <summary>
    /// アイテム描画更新処理の直前に割り込み (Prefix)
    /// </summary>
    /// <param name="__instance">描画対象のEffectedItemSourceインスタンス (internalのためobject型で受領)</param>
    /// <param name="timelineItemSourceDescription">現在のフレームやアイテム時間情報</param>
    /// <returns>元のメソッドを実行する場合は true、スキップする場合は false</returns>
    [HarmonyPrefix]
    public static bool Prefix(object __instance, TimelineItemSourceDescription timelineItemSourceDescription)
    {
        // 【改造例】描画更新前の前処理やパラメータ検査
        // 例: 現在のアイテムフレーム番号を取得
        long currentFrame = timelineItemSourceDescription.ItemPosition.Frame;

        // 元のUpdate処理を実行
        return true;
    }

    /// <summary>
    /// アイテム描画更新処理の完了後に割り込み (Postfix)
    /// </summary>
    /// <param name="__instance">描画完了後のEffectedItemSourceインスタンス</param>
    /// <param name="timelineItemSourceDescription">描画情報</param>
    [HarmonyPostfix]
    public static void Postfix(object __instance, TimelineItemSourceDescription timelineItemSourceDescription)
    {
        // 【改造例】描画更新後の処理
        // AccessTools.Property(type, "DrawDescription").GetValue(__instance) などで内部プロパティにアクセス可能
    }
}
