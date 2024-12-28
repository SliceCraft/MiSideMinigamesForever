using MinigamesForever.Patches;
using MinigamesForever.Utils;
using UnityEngine.SceneManagement;

namespace MinigamesForever.Events;

public class SceneLoadedEvent
{
    public static void RegisterEvent()
    {
        SceneManager.sceneLoaded += (UnityEngine.Events.UnityAction<Scene, LoadSceneMode>)OnSceneLoaded;
    }

    private static void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Plugin.Log.LogInfo($"Scene {scene.name} is loaded");
        if (SteamManagerPatch.PlayingHetoor)
        {
            MinigamesController mgc = UnityEngine.Object.FindObjectOfType<MinigamesController>(true);
            if (mgc == null)
            {
                Plugin.Log.LogInfo("No MGC found");
                return;
            }
            Plugin.Log.LogInfo("MGC found, activating rn");
            mgc.gameObject.SetActive(true);            
        }

        if (SteamManagerPatch.PlayingCarSpace)
        {
            MinigamesAutomate minigamesAutomate = UnityEngine.Object.FindObjectOfType<MinigamesAutomate>(true);
            if(minigamesAutomate == null)
            {
                Plugin.Log.LogInfo("No minigamesAutomate found");
                return;
            }
            Plugin.Log.LogInfo("minigamesAutomate found, activating rn");
            if (minigamesAutomate.gameObject.transform.parent == null ||
                minigamesAutomate.gameObject.transform.parent.gameObject == null)
            {
                Plugin.Log.LogInfo("No parent to minigamesAutomate found, how?");
                return;                
            }
            minigamesAutomate.gameObject.transform.parent.gameObject.SetActive(true);
            MinigamesAutomatePatch.startWait = 1;
            PrepareCarGame.Prepare(minigamesAutomate);
        }

        if (scene.name == "SceneMenu")
        {
            InsertSettingsIntoMenu.Insert();
        }
    }
}