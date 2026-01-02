using Asteroids.Signals;
using System.Transactions;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Death
{
    public class EnemyDeathHandler : IDeathHandler
    {
        void IDeathHandler.HandleDeath(ISpaceship spaceship)
        {
            spaceship.Die();
        }
    }
}
