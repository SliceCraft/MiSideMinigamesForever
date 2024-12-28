using HarmonyLib;

namespace MinigamesForever.Patches;

[HarmonyPatch(typeof(GameController))]
public class GameControllerPatch
{
    [HarmonyPatch(nameof(GameController.ShowHint))]
    [HarmonyPrefix]
    public static bool ShowHintPatch()
    {
        return !(SteamManagerPatch.PlayingHetoor || SteamManagerPatch.PlayingCarSpace);
    }
}