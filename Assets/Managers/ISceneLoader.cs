using System;

namespace Asteroids.General.Scene
{
    public interface ISceneLoader
    {
        event Action<SceneType> OnSceneChanged;
        void ReloadCurrentScene();
        void LoadScene(SceneType sceneType);
        SceneType GetCurrentSceneType();
    }
}