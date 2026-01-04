using UnityEngine;

namespace Asteroids.Spaceship
{
    public interface ISpaceship
    {
        void SetActiveAfterFixedUpdate(bool isActive);
        void ResetMovement();
        void Die();
    }
}