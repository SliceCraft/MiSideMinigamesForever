using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinigamesForever.Patches;

[HarmonyPatch(typeof(MinigamesController))]
public class MinigamesControllerPatch
{
    [HarmonyPatch(nameof(MinigamesController.Awake))]
    [HarmonyPrefix]
    public static void AwakePatch(MinigamesController __instance)
    { 
        if (!SteamManagerPatch.PlayingHetoor) return;
        __instance.gameObject.SetActive(true);
    }
}