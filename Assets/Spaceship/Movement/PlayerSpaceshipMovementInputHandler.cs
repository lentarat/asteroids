using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSpaceshipMovementInputHandler : ISpaceshipMover
{
    private PlayerInputActions _playerInputActions;

    public PlayerSpaceshipMovementInputHandler()
    {
        _playerInputActions = new PlayerInputActions();

        _playerInputActions.Spaceship.Move.started += HandleSpaceshipMove;
    }

    private void HandleSpaceshipMove(InputAction.CallbackContext context)
    {

    }

    event Action<float> ISpaceshipMover.OnMove
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    event Action<float> ISpaceshipMover.OnRotate
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }
}
