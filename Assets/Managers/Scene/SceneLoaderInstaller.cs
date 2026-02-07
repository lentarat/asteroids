using Asteroids.General.SceneManagement;
using Zenject;

namespace Asteroids.Installers.Managers.Scene
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}