using UnityEngine;

namespace MinigamesForever.Utils;

public class LoadMinigameFromResources
{
    public static void loadMinigame(string name)
    {
        Menu menu = Object.FindObjectOfType<Menu>(true);
        if (menu == null)
        {
            Plugin.Log.LogError("No menu found, can't load minigame");
            return;
        }
        menu.gameObject.active = false;
        
        Plugin.Log.LogInfo("Loading: " + name);
        GameObject minigameObjectResource = Resources.Load<GameObject>("MiniGames/Automate/" + name);
        GameObject minigameObject = Object.Instantiate(minigameObjectResource);
        Plugin.Log.LogInfo(minigameObject.name + " is loaded");
    }
}