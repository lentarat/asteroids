using TMPro;
using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    public class SpaceshipProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _damage;

        public void Init(Sprite sprite, Vector2 direction, float speed, float damage)
        {
            _spriteRenderer.sprite = sprite;
            transform.up = direction;
            _rigidbody.linearVelocity = direction * speed;
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            bool isCollidingWithDamageable =
                collider2D.TryGetComponent<IDamageable>(out IDamageable damageable);

            if (isCollidingWithDamageable)
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }
}