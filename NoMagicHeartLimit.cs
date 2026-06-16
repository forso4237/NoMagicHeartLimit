global using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper;
using HarmonyLib;
using Il2CppAssets.Scripts.Simulation;
using MelonLoader;
using NoMagicHeartLimit;

[assembly: MelonInfo(typeof(NoMagicHeartLimit.NoMagicHeartLimit), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6-Epic")]

namespace NoMagicHeartLimit;

public class NoMagicHeartLimit : BloonsTD6Mod
{
    public override void OnApplicationStart()
    {
        ModHelper.Msg<NoMagicHeartLimit>("NoMagicHeartLimit loaded! Mana Shield is now uncapped.");
    }
}

[HarmonyPatch(typeof(Simulation), nameof(Simulation.GetModifiedMaxShield))]
internal static class Simulation_GetModifiedMaxShield
{
    private const float UncappedShield = 1_000_000_000f;

    [HarmonyPostfix]
    private static void Postfix(ref float __result)
    {
        if (__result > 0f)
        {
            __result = UncappedShield;
        }
    }
}