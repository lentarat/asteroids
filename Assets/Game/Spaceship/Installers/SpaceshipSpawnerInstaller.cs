using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class SpaceshipSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _spaceshipPrefab;
        [SerializeField] private Transform _spaceshipParent;
        
        public override void InstallBindings()
        {
            BindFactory();
            BindInputActions();
        }

        private void BindFactory()
        {
            Container.BindFactory<SpaceshipContext, Spaceship.Spaceship, SpaceshipFactory>()
                .FromComponentInNewPrefab(_spaceshipPrefab)
                .UnderTransform(_spaceshipParent)
                .AsSingle();
        }

        private void BindInputActions()
        {
            Container.Bind<PlayerInputActions>().AsSingle();
        }
    }
}
