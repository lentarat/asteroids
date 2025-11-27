using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Spaceship.Shooting
{
    public class PlayerSpaceshipShootingReader : ISpaceshipShooter
    {
        private bool _isShooting;
        private PlayerInputActions _playerInputActions;

        public PlayerSpaceshipShootingReader(PlayerInputActions playerInputActions)
        {
            _playerInputActions = playerInputActions;
            SubscribeToShooting();
        }

        private void SubscribeToShooting()
        {
            _playerInputActions.Spaceship.Shoot.started += HandleShootingStarted;
            _playerInputActions.Spaceship.Shoot.canceled += HandleShootingCanceled;
        }

        ~PlayerSpaceshipShootingReader()
        {
            UnsubscribeToShooting();
        }

        private void UnsubscribeToShooting()
        {
            _playerInputActions.Spaceship.Shoot.started -= HandleShootingStarted;
            _playerInputActions.Spaceship.Shoot.canceled -= HandleShootingCanceled;
        }

        private void HandleShootingStarted(InputAction.CallbackContext context)
        {
            _isShooting = true;
        }

        private void HandleShootingCanceled(InputAction.CallbackContext context)
        {
            _isShooting = false;
        }

        bool ISpaceshipShooter.ShouldShoot()
        {
            return _isShooting;
        }
    }
}
