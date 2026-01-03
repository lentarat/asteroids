using UnityEngine;

namespace Asteroids.Spaceship
{
    public interface ISpaceship
    {
        void SetActive(bool isActive);
        void ResetMovement();
        void Die();
    }
}