using UnityEngine.SceneManagement;

namespace MinigamesForever.GameLoader;

public interface ISceneGame : IGame
{
    public void OnSceneLoaded(Scene scene);
}