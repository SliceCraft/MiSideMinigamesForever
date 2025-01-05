using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinigamesForever.Patches;

[HarmonyPatch(typeof(SteamManager))]
public class SteamManagerPatch
{
    public static bool PlayingHetoor = false;
    public static bool PlayingCarSpace = false;
    [HarmonyPatch(nameof(SteamManager.Update))]
    [HarmonyPrefix]
    public static void UpdatePatch()
    {
        if(!SceneManager.GetActiveScene().name.Equals("SceneMenu")) return;
        if (Input.GetKey(KeyCode.LeftAlt) &&
            Input.GetKeyDown(KeyCode.M))
        {
            PlayingHetoor = true;
            GlobalGame.LoadingLevel = "MinigameShooter";
            SceneManager.LoadScene("SceneLoading");            
        }
        if (Input.GetKey(KeyCode.LeftAlt) &&
            Input.GetKeyDown(KeyCode.N))
        {
            PlayingCarSpace = true;
            GlobalGame.LoadingLevel = "Scene 7 - Backrooms";
            SceneManager.LoadScene("SceneLoading");            
        }
    }
}