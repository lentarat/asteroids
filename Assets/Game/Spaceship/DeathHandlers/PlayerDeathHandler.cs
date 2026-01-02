using Asteroids.Signals;
using System.Transactions;
using UnityEngine;
using Zenject;

namespace Asteroids.Spaceship.Death
{
    public class PlayerDeathHandler : IDeathHandler
    {
        private SignalBus _signalBus;

        public PlayerDeathHandler(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void IDeathHandler.HandleDeath(ISpaceship spaceship)
        {
            PlayerDestroyedSignal spaceshipDestroyedSignal = new PlayerDestroyedSignal(spaceship);
            _signalBus.Fire(spaceshipDestroyedSignal);
        }
    }
}
