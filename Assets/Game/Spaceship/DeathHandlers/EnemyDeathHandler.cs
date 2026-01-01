using Asteroids.Signals;
using System.Transactions;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Death
{
    public class EnemyDeathHandler : IDeathHandler
    {
        void IDeathHandler.HandleDeath(Spaceship spaceship)
        {
            GameObject.Destroy(spaceship.gameObject);
        }
    }
}
