using TMPro;
using UnityEngine;

namespace Asteroids.Spaceship.Shooting
{
    public class SpaceshipProjectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private float _damage;
        public Spaceship _parentSpaceship;

        public void Init(
            Spaceship parentSpaceship,
            Sprite sprite,
            Vector2 direction,
            float speed,
            float damage
            )
        {
            _parentSpaceship = parentSpaceship;
            _spriteRenderer.sprite = sprite;
            transform.up = direction;
            _rigidbody.linearVelocity = direction * speed;
            _damage = damage;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            Transform rootTransform = collider.transform.root;
            bool isCollidingWithDamageable =
                rootTransform.TryGetComponent<IDamageable>(out IDamageable damageable);

            Spaceship spaceship = damageable as Spaceship;

            if (isCollidingWithDamageable && spaceship != _parentSpaceship)
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }
}