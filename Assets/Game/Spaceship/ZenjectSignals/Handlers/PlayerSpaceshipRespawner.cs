using UnityEngine;
using Asteroids.Spaceship;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;
using System;

namespace Asteroids.Signals.Handlers
{
    public class PlayerSpaceshipRespawner : IInitializable, IDisposable
    {
        private int _respawnTimeMS = 3000;
        private ISpaceship _playerSpaceship;
        private SignalBus _signalBus;

        public PlayerSpaceshipRespawner(SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        void IInitializable.Initialize()
        {
            SubscribeToSpaceshipDestroyed();
        }

        private void SubscribeToSpaceshipDestroyed()
        {
            _signalBus.Subscribe<PlayerDestroyedSignal>(HandlePlayerDestroyed);
        }

        private void HandlePlayerDestroyed(PlayerDestroyedSignal spaceshipDestroyedSignal)
        {
            _playerSpaceship = spaceshipDestroyedSignal.Spaceship;
            _playerSpaceship.SetActiveAfterFixedUpdate(false);

            RespawnPlayerAsync().Forget();
        }

        private async UniTask RespawnPlayerAsync()
        {
            await UniTask.Delay(_respawnTimeMS);

            _playerSpaceship.ResetMovement();
            _playerSpaceship.SetActiveAfterFixedUpdate(true);
        }

        void IDisposable.Dispose()
        {
            UnsubscribeToSpaceshipDestroyed();
        }

        private void UnsubscribeToSpaceshipDestroyed()
        {
            _signalBus.Unsubscribe<PlayerDestroyedSignal>(HandlePlayerDestroyed);
        }
    }
}
