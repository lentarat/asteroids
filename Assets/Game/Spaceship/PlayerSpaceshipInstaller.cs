using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class PlayerSpaceshipInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _spaceshipPrefab;
        [SerializeField] private Transform _spaceshipParent;

        public override void InstallBindings()
        {
            Container.BindFactory<Spaceship.Spaceship, SpaceshipFactory>()
                .FromComponentInNewPrefab(_spaceshipPrefab)
                .UnderTransform(_spaceshipParent);

            Container.Bind<ISpaceshipMover>().To<PlayerSpaceshipMovementInputReader>();
        }
    }
}
