using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    [CreateAssetMenu(menuName = "ScriptableObjects/SpaceshipWeaponSO")]
    public class SpaceshipWeaponSO : ScriptableObject
    {
        [SerializeField] private float _interval;
        public float Interval => _interval;
        [SerializeField] private float _projectileSpeed;
        public float ProjectileSpeed => _projectileSpeed;
        [SerializeField] private float _projectileLifetime;
        private float ProjectileLifetime => _projectileLifetime;
    }
}