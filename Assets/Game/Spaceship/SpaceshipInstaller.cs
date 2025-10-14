using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

public class SpaceshipInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputActions>().AsSingle();
        Container.Bind<ISpaceshipMover>().To<PlayerSpaceshipMovementInputReader>();
    }
}
