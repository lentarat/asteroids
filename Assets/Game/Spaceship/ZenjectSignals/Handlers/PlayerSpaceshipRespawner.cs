using UnityEngine;
using Asteroids.Spaceship;
using Cysharp.Threading.Tasks;
using Zenject;
using Asteroids.Spaceship.Movement;

namespace Asteroids.Signals.Handlers
{
    public class PlayerSpaceshipRespawner
    {
        private int _respawnTimeMS = 3000;
        private Spaceship.Spaceship _playerSpaceship;
        private SignalBus _signalBus;

        public PlayerSpaceshipRespawner(SignalBus signalBus)
        {
            _signalBus = signalBus;
            SubscribeToSpaceshipDestroyed();
        }

        private void SubscribeToSpaceshipDestroyed()
        {
            _signalBus.Subscribe<SpaceshipDestroyedSignal>(HandlePlayerDestroyed);
        }

        public void HandlePlayerDestroyed(SpaceshipDestroyedSignal spaceshipDestroyedSignal)
        {
            SpaceshipType spaceshipType = spaceshipDestroyedSignal.Spaceship.SpaceshipType;
            if (spaceshipType != SpaceshipType.Player)
            {
                return;
            }

            _playerSpaceship = spaceshipDestroyedSignal.Spaceship;
            _playerSpaceship.gameObject.SetActive(false);

            SpaceshipMovement playerSpaceshipMovement = _playerSpaceship.SpaceshipMovement;
            playerSpaceshipMovement.SetToDefaultRigidbodyProperties();

            RespawnPlayerAsync().Forget();
        }

        private async UniTask RespawnPlayerAsync()
        { 
            await UniTask.Delay(_respawnTimeMS);

            _playerSpaceship.transform.position = Vector3.zero;
            _playerSpaceship.gameObject.SetActive(true);
        }

        ~PlayerSpaceshipRespawner()
        {
            UnsubscribeToSpaceshipDestroyed();
        }

        private void UnsubscribeToSpaceshipDestroyed()
        {
            _signalBus.Unsubscribe<SpaceshipDestroyedSignal>(HandlePlayerDestroyed);
        }
    }
}
