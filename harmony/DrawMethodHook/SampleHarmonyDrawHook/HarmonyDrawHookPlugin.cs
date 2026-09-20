using System;
using System.Reflection;
using System.Windows;
using HarmonyLib;
using YukkuriMovieMaker.Plugin;

namespace SampleHarmonyDrawHook;

/// <summary>
/// Harmonyによる描画メソッドフックプラグインのエントリポイント
/// </summary>
public class HarmonyDrawHookPlugin : IPlugin
{
    private static bool initialized;

    public string Name => "Harmony描画フック拡張サンプル";

    static HarmonyDrawHookPlugin()
    {
        if (initialized) return;
        Initialize();
        initialized = true;
    }

    private static void Initialize()
    {
        try
        {
            var harmony = new Harmony("com.sample.ymm4.harmonydrawhook");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"描画フックパッチ適用エラー: {ex.Message}\n\n{ex.StackTrace}",
                "SampleHarmonyDrawHook Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
