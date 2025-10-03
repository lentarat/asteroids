using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceshipMovementInputReader : MonoBehaviour, ISpaceshipMover
{
    private PlayerInputActions _playerInputActions;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Enable();
    }

    float ISpaceshipMover.GetThrottleValue()
    {
        float throttleValue = _playerInputActions.Spaceship.Move.ReadValue<float>();
        return throttleValue;
    }

    float ISpaceshipMover.GetTurnDirectionValue()
    {
        float turnDirectionValue = _playerInputActions.Spaceship.Move.ReadValue<float>();
        return turnDirectionValue;
    }

    private void OnDestroy()
    {
        _playerInputActions.Disable();
        _playerInputActions.Dispose();
    }
}
