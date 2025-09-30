using UnityEngine;

public class SpaceshipMovement
{
    private SpaceshipMovementSO _spaceshipMovementSO;
    private ISpaceshipMover _spaceshipMover;

    public SpaceshipMovement(SpaceshipMovementSO spaceshipMovementSO, ISpaceshipMover spaceshipMover)
    { 
        _spaceshipMovementSO = spaceshipMovementSO;
        _spaceshipMover = spaceshipMover;

        SubscribeToMovementInput();    
    }

    private void SubscribeToMovementInput()
    {
        _spaceshipMover.OnMove += HandleSpaceshipMoved;
        _spaceshipMover.OnRotate += HandleSpaceshipRotated;
    }

    private void HandleSpaceshipMoved(float yLocal)
    {
        
    }

    private void HandleSpaceshipRotated(float zRotation)
    { 
        
    }

    private void Move()
    { 
        
    }
}
