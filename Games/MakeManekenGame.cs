using MinigamesForever.GameLoader;
using MinigamesForever.Utils;

namespace MinigamesForever.Games;

public class MakeManekenGame : IGame
{
    public string GetName()
    {
        return "Make Maneken";
    }

    public void StartGame()
    {
        LoadMinigameFromResources.loadMinigame("Minigame MakeManeken");
    }

    public void StopGame()
    {
        throw new System.NotImplementedException();
    }
}