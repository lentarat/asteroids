using Asteroids.Spaceship;
using Asteroids.Spaceship.Movement;
using UnityEngine;
using Zenject;

namespace Asteroids.Installers
{
    public class EnemySpaceshipInstaller : SpaceshipInstaller
    {
        protected override void BindSpaceshipMover()
        {
            Container.Bind<ISpaceshipMover>().To<EnemySpaceshipMover>();
        }
    }
}