using System;
using System.Reflection;
using System.Windows;
using HarmonyLib;
using YukkuriMovieMaker.Plugin;

namespace SampleHarmonyEasing;

/// <summary>
/// Harmonyによるイージング拡張プラグインのエントリポイント
/// </summary>
public class HarmonyEasingPlugin : IPlugin
{
    private static bool initialized;

    public string Name => "Harmonyイージング拡張サンプル";

    static HarmonyEasingPlugin()
    {
        Initialize();
    }

    public HarmonyEasingPlugin()
    {
        Initialize();
    }

    private static void Initialize()
    {
        if (initialized) return;
        try
        {
            var harmony = new Harmony("com.sample.ymm4.harmonyeasing");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            initialized = true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"イージング拡張パッチ適用エラー: {ex.Message}\n\n{ex.StackTrace}",
                "SampleHarmonyEasing Error",
                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
