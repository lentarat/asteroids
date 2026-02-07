using System;

namespace Asteroids.General.SceneManagement
{
    public interface ISceneLoader
    {
        event Action<SceneType> OnSceneChanged;
        void ReloadCurrentScene();
        void LoadScene(SceneType sceneType);
        SceneType GetCurrentSceneType();
    }
}