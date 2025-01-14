namespace MinigamesForever.GameLoader;

public interface IGame
{
    public string GetName();
    
    public void StartGame();
    public void StopGame();
}