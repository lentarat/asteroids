using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class EnemySpaceshipInstaller : SpaceshipInstaller
    {
        [SerializeField] private GameObject _spaceshipPrefab;
        [SerializeField] private Transform _spaceshipParent;

        protected override void BindSpaceshipMover()
        {
            Container.Bind<ISpaceshipMover>().To<PlayerSpaceshipMovementInputReader>();
        }

        public override void InstallBindings()
        {
            BindFactory();
        }

        private void BindFactory()
        {
            Container.BindFactory<Spaceship.Spaceship, SpaceshipFactory>()
                .FromComponentInNewPrefab(_spaceshipPrefab)
                .UnderTransform(_spaceshipParent)
                .AsSingle();
        }
    }
}