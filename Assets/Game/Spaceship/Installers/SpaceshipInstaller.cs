using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public abstract class SpaceshipInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _spaceshipPrefab;
        [SerializeField] private Transform _spaceshipParent;

        protected abstract void BindSpaceshipMover();
        
        public override void InstallBindings()
        {
            BindFactory();
            BindSpaceshipMover();
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
