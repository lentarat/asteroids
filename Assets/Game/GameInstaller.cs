using Asteroids.General.Audio;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioSourcePool _audioSourcePool;

        public override void InstallBindings()
        {
            BindSignalBus();
            BindPlayerInputActions();
            BindAudioSourcePool();
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

        private void BindAudioSourcePool()
        {
            Container.Bind<AudioSourcePool>().
                FromInstance(_audioSourcePool).
                AsSingle();
        }
    }
}