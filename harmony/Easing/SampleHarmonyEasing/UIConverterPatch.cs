using System;
using System.Globalization;
using HarmonyLib;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;

namespace SampleHarmonyEasing;

/// <summary>
/// アニメーションスライダーのボタン表示文字 (AnimationTypeToCharConverter) へのパッチ
/// </summary>
[HarmonyPatch(typeof(AnimationTypeToCharConverter), nameof(AnimationTypeToCharConverter.Convert), new[] { typeof(object), typeof(Type), typeof(object), typeof(CultureInfo) })]
public static class CharConverterPatch
{
    [HarmonyPrefix]
    public static bool Prefix(object value, ref object __result)
    {
        if (value is AnimationType animType)
        {
            int id = (int)animType;
            if (id == MenuPatch.CustomEasing_In || 
                id == MenuPatch.CustomEasing_Out || 
                id == MenuPatch.CustomEasing_InOut || 
                id == MenuPatch.CustomEasing_OutIn)
            {
                __result = "サ"; // 「サ」(サンプル) をスライダー横のボタンに表示
                return false;
            }
        }
        return true;
    }
}

/// <summary>
/// アニメーションスライダーのツールチップテキスト (AnimationTypeToToolTipConverter.ConvertText) へのパッチ
/// </summary>
[HarmonyPatch(typeof(AnimationTypeToToolTipConverter), nameof(AnimationTypeToToolTipConverter.ConvertText), new[] { typeof(AnimationType), typeof(bool) })]
public static class ToolTipConverterPatch
{
    [HarmonyPrefix]
    public static bool Prefix(AnimationType type, bool ignoreModes, ref string __result)
    {
        int id = (int)type;
        switch (id)
        {
            case MenuPatch.CustomEasing_In:
                __result = "サンプル / In (加速)";
                return false;
            case MenuPatch.CustomEasing_Out:
                __result = "サンプル / Out (減衰バウンス)";
                return false;
            case MenuPatch.CustomEasing_InOut:
                __result = "サンプル / InOut (加減速)";
                return false;
            case MenuPatch.CustomEasing_OutIn:
                __result = "サンプル / OutIn (減加速)";
                return false;
        }
        return true;
    }
}

/// <summary>
/// アニメーションスライダーのアクセスキー (AnimationTypeToToolTipConverter.ConvertToAccessKey) へのパッチ
/// </summary>
[HarmonyPatch(typeof(AnimationTypeToToolTipConverter), nameof(AnimationTypeToToolTipConverter.ConvertToAccessKey), new[] { typeof(AnimationType) })]
public static class AccessKeyConverterPatch
{
    [HarmonyPrefix]
    public static bool Prefix(AnimationType type, ref string __result)
    {
        int id = (int)type;
        switch (id)
        {
            case MenuPatch.CustomEasing_In:
                __result = "";
                return false;
            case MenuPatch.CustomEasing_Out:
                __result = "";
                return false;
            case MenuPatch.CustomEasing_InOut:
                __result = "";
                return false;
            case MenuPatch.CustomEasing_OutIn:
                __result = "";
                return false;
        }
        return true;
    }
}
