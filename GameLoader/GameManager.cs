using System.Collections.Generic;

namespace MinigamesForever.GameLoader;

public static class GameManager
{
    private static List<IGame> games = [];
    
    public static void RegisterGame(IGame game)
    {
        games.Add(game);
    }

    public static void LoadGame(string name)
    {
        IGame game = null;
        foreach (var potentialGame in games)
        {
            if (potentialGame.GetName().Equals(name))
            {
                game = potentialGame;
                break;
            }
        }
        
        game?.StartGame();
    }
}