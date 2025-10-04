using Unity.VisualScripting;
using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpaceshipMovementSO _spaceshipMovementSO;
    private ISpaceshipMover _spaceshipMover;

    private float _currentAngularSpeed;
    private Vector2 _currentVelocity;

    private void Update()
    {
        UpdateVelocityAndRotation();
    }

    private void UpdateVelocityAndRotation()
    {
        float throttleValue = _spaceshipMover.GetThrottleValue();
        float turnDirectionValue = _spaceshipMover.GetTurnDirectionValue();

        if (throttleValue > 0)
        { 
        
        }
    }

    private void UpdateVelocity()
    {
        Vector2 rotation = new Vector2(transform.rotation.x, transform.rotation.y);
        _currentVelocity += rotation * _spaceshipMovementSO.Acceleration;
    }

    private void FixedUpdate()
    {
        ApplyNewPositionAndRotation();
    }

    private void ApplyNewPositionAndRotation()
    {
        float newRotation = _rigidbody.rotation + _currentAngularSpeed;
        Vector2 newPosition = _rigidbody.position + _currentVelocity;
        _rigidbody.MovePosition(newPosition);
        _rigidbody.MoveRotation(newRotation);
    }
}
