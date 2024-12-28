using UnityEngine;

namespace MinigamesForever.Utils;

/*
 * When loading the car game it currently loads the scene where the game is stored and then loads the actual minigame.
 * Since we don't want the player to do anything while this is happening the methods made available in the below class
 * will unload enough of the game world so the player isn't able to do anything yet the minigame can still load.
 * It would be nice if in the future the game can be loaded without using this approach.
 */
public class PrepareCarGame
{
    public static void Prepare(MinigamesAutomate gameAutomate)
    {
        GameObject backrooms = AttemptGetBackroomsFetch(gameAutomate.gameObject);
        if (backrooms == null)
        {
            Plugin.Log.LogInfo("Unable to find backrooms, world will not be unloaded.");
            return;
        }
        SetNonGameObjectsToInactive(backrooms);
        GameObject house = AttemptGetHouseFetch(backrooms);
        if (house == null)
        {
            Plugin.Log.LogInfo("Unable to find house, house will not be unloaded.");
            return;
        }
        SetNonGameObjectsToInactive(house);
        SetInnerGameAutomateObjectsToInactive(gameAutomate.gameObject);
    }

    private static GameObject AttemptGetBackroomsFetch(GameObject gameObject)
    {
        if (gameObject == null || // GameAutomate
            gameObject.transform.parent == null || 
            gameObject.transform.parent.gameObject == null || // Game SpaceCar
            gameObject.transform.parent.gameObject.transform.parent == null ||
            gameObject.transform.parent.gameObject.transform.parent.gameObject == null ||
            !gameObject.transform.parent.gameObject.transform.parent.gameObject.name.Equals("Backrooms First")) return null; // Backrooms First
        return gameObject.transform.parent.gameObject.transform.parent.gameObject;
    }
    
    private static GameObject AttemptGetHouseFetch(GameObject gameObject)
    {
        if (gameObject == null || // Backrooms First
            gameObject.transform.parent == null || 
            gameObject.transform.parent.gameObject == null ||
            !gameObject.transform.parent.gameObject.name.Equals("House")) return null; // House
        return gameObject.transform.parent.gameObject;
    }

    private static void SetInnerGameAutomateObjectsToInactive(GameObject gameObject)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject obj = gameObject.transform.GetChild(i).gameObject;
            obj.SetActive(false);
        }
    }

    private static void SetNonGameObjectsToInactive(GameObject backrooms)
    {
        for (int i = 0; i < backrooms.transform.childCount; i++)
        {
            GameObject obj = backrooms.transform.GetChild(i).gameObject;
            if(obj.name.Equals("Game SpaceCar") || obj.name.Equals("Backrooms First")) continue;
            obj.SetActive(false);
        }
    }

    private static GameObject AttemptGetPlayerFetch(GameObject playerCameraObject)
    {
        if (playerCameraObject == null || // MainCamera
            playerCameraObject.transform.parent == null || 
            playerCameraObject.transform.parent.gameObject == null || // HeadPlayer
            playerCameraObject.transform.parent.gameObject.transform.parent == null ||
            playerCameraObject.transform.parent.gameObject.transform.parent.gameObject == null ||
            !playerCameraObject.transform.parent.gameObject.transform.parent.gameObject.name.Equals("Player")) return null; // Player
        return playerCameraObject.transform.parent.gameObject.transform.parent.gameObject;
    }

    public static void TogglePlayerStatus(bool enable)
    {
        PlayerCameraEffects pce = Object.FindObjectOfType<PlayerCameraEffects>(true);
        if (pce == null)
        {
            Plugin.Log.LogInfo("Unable to find player camera effects, player will not be changed.");
            return;
        }
        GameObject playerObject = AttemptGetPlayerFetch(pce.gameObject);
        if (playerObject == null)
        {
            Plugin.Log.LogInfo("Unable to find player, player will not be changed.");
            return;
        }
        playerObject.SetActive(enable);
    }
}