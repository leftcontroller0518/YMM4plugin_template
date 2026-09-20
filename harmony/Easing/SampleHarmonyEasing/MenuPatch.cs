using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using HarmonyLib;

namespace SampleHarmonyEasing;

/// <summary>
/// アニメーションスライダーの右クリックメニュー (ContextMenu) にカスタムイージングを追加するパッチ
/// </summary>
[HarmonyPatch]
public static class MenuPatch
{
    // カスタムイージング用の独自AnimationType ID定義 (YMM4標準は 10001〜10908, 100000 など)
    public const int CustomEasing_In = 99101;
    public const int CustomEasing_Out = 99102;
    public const int CustomEasing_InOut = 99103;
    public const int CustomEasing_OutIn = 99104;

    [HarmonyTargetMethod]
    public static MethodBase? TargetMethod()
    {
        // AnimationSliderMenuFactory は internal なので文字列リフレクションで取得
        return AccessTools.Method("YukkuriMovieMaker.Controls.AnimationSliderMenuFactory:Create");
    }

    [HarmonyPostfix]
    public static void Postfix(ContextMenu __result, FrameworkElement resourceOwner)
    {
        if (__result == null) return;

        try
        {
            // 区切り線を追加
            __result.Items.Add(new Separator());

            // カスタムイージングの親メニューを作成
            var parentItem = new MenuItem
            {
                Header = "サンプルイージング (Custom)"
            };

            // 各イージングモードのサブメニュー項目を作成して追加
            // Tag に数値文字列を代入することで、YMM4標準のクリックハンドラが自動的に AnimationType を設定します
            var inItem = new MenuItem
            {
                Header = "サンプル / In (オーバーシュート加速)",
                Tag = CustomEasing_In.ToString()
            };

            var outItem = new MenuItem
            {
                Header = "サンプル / Out (減衰振動バウンス)",
                Tag = CustomEasing_Out.ToString()
            };

            var inOutItem = new MenuItem
            {
                Header = "サンプル / InOut (強調S字カーブ)",
                Tag = CustomEasing_InOut.ToString()
            };

            var outInItem = new MenuItem
            {
                Header = "サンプル / OutIn (反転S字カーブ)",
                Tag = CustomEasing_OutIn.ToString()
            };

            parentItem.Items.Add(inItem);
            parentItem.Items.Add(outItem);
            parentItem.Items.Add(inOutItem);
            parentItem.Items.Add(outInItem);

            __result.Items.Add(parentItem);
        }
        catch
        {
            // メニュー追加時の例外を安全に握りつぶしてクラッシュを防止
        }
    }
}
