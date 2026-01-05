using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Spaceship.Movement
{
    public class PlayerSpaceshipMovementInputReader : ISpaceshipMover
    {
        private PlayerInputActions _playerInputActions;

        public PlayerSpaceshipMovementInputReader(PlayerInputActions playerInputActions)
        {
            _playerInputActions = playerInputActions;
            _playerInputActions.Enable();
        }

        float ISpaceshipMover.GetThrottleValue()
        {
            float throttleValue = _playerInputActions.Spaceship.Move.ReadValue<float>();
            return throttleValue;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            float turnDirectionValue = _playerInputActions.Spaceship.Rotate.ReadValue<float>();
            return turnDirectionValue;
        }

        ~PlayerSpaceshipMovementInputReader()
        {
            _playerInputActions.Disable();
            _playerInputActions.Dispose();
        }
    }
}