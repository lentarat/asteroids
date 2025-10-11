using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Spaceship.Movement
{
    public class PlayerSpaceshipMovementInputReader : ISpaceshipMover
    {
        private PlayerInputActions _playerInputActions;

        public PlayerSpaceshipMovementInputReader()
        {
            _playerInputActions = new PlayerInputActions();
            _playerInputActions.Enable();
        }

        int ISpaceshipMover.GetThrottleValue()
        {
            int throttleValue = _playerInputActions.Spaceship.Move.ReadValue<int>();
            return throttleValue;
        }

        float ISpaceshipMover.GetTurnDirectionValue()
        {
            float turnDirectionValue = _playerInputActions.Spaceship.Move.ReadValue<float>();
            return turnDirectionValue;
        }

        ~PlayerSpaceshipMovementInputReader()
        {
            _playerInputActions.Disable();
            _playerInputActions.Dispose();
        }
    }
}