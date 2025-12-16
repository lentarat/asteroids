using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSignalBus();
            BindPlayerInputActions();
        }

        private void BindSignalBus()
        {
            SignalBusInstaller.Install(Container);
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