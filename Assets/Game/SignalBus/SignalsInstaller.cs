using Asteroids.Signals;
using Asteroids.Signals.Handlers;
using UnityEngine;
using Zenject;

public class SignalsInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.DeclareSignal<PlayerDestroyedSignal>();
        Container.BindInterfacesTo<PlayerSpaceshipRespawner>()
            .AsSingle()
            .NonLazy();
    }
}
