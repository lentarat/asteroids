using Cysharp.Threading.Tasks;
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
            float damage,
            int lifetimeMS
            )
        {
            _parentSpaceship = parentSpaceship;
            _spriteRenderer.sprite = sprite;
            transform.up = direction;
            _rigidbody.linearVelocity = direction * speed;
            _damage = damage;
            DestroyAfterAsync(lifetimeMS).Forget();
        }

        private async UniTask DestroyAfterAsync(int lifetimeMS)
        {
            await UniTask.Delay(lifetimeMS);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            IDamageable damageable = collider.GetComponentInParent<IDamageable>();
            Spaceship spaceship = damageable as Spaceship;

            if (damageable != null && spaceship != _parentSpaceship)
            {
                damageable.ApplyDamage(_damage);
            }
        }
    }
}