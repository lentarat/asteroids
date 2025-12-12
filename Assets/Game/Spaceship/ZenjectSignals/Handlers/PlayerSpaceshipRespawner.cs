using UnityEngine;
using Asteroids.Spaceship;
using Cysharp.Threading.Tasks;
using Zenject;

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

        }

        private void SubscribeToSpaceshipDestroyed()
        { 
        
        }

        public void HandlePlayerDestroyed(SpaceshipDestroyedSignal playerDestroyedSignal)
        { 
            _playerSpaceship = playerDestroyedSignal.PlayerSpaceship;
            _playerSpaceship.gameObject.SetActive(false);
        }

        private async UniTask RespawnPlayerAsync()
        { 
            await UniTask.Delay(_respawnTimeMS);

            _playerSpaceship.transform.position = Vector3.zero;
            _playerSpaceship.gameObject.SetActive(true);
        }
    }
}
