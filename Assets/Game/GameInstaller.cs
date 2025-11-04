using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerInputActions();
        }

        private void BindPlayerInputActions()
        {
            Container.Bind<PlayerInputActions>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<InputBootstrapper>()
                .AsSingle()
                .NonLazy();
        }
    }
}