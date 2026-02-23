using UnityEngine;

namespace Asteroids.Spaceship
{
    public interface ISpaceship
    {
        void SetStateAfterFixedUpdate(bool isActive);
        void ResetMovement();
        void Die();
    }
}