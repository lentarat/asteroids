using Asteroids.Signals;
using Asteroids.Signals.Handlers;
using UnityEngine;
using Zenject;

public class SignalsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<SpaceshipDestroyedSignal>();
        Container.Bind<PlayerSpaceshipRespawner>()
            .AsSingle()
            .NonLazy();
    }
}
