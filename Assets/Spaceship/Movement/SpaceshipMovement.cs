using UnityEngine;

public class SpaceshipMovement
{
    private Rigidbody2D _rigidbody;
    private SpaceshipMovementSO _spaceshipMovementSO;
    private ISpaceshipMover _spaceshipMover;

    private float _currentAngularSpeed;
    private Vector2 _currentVelocity;

    public SpaceshipMovement(SpaceshipMovementSO spaceshipMovementSO, ISpaceshipMover spaceshipMover)
    { 
        _spaceshipMovementSO = spaceshipMovementSO;
        _spaceshipMover = spaceshipMover;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float newRotation = _rigidbody.rotation + _currentAngularSpeed;
        Vector2 newPosition = _rigidbody.position + _currentVelocity;
        _rigidbody.MovePosition(newPosition);
        _rigidbody.MoveRotation(newRotation);
    }
}
