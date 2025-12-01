using TMPro;
using UnityEngine;

public class SpaceshipProjectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Sprite _sprite;

    public void Init(Sprite sprite, Vector2 direction, float speed)
    {
        _sprite = sprite;
        transform.up = direction;
        _rigidbody.linearVelocity = direction * speed;
    }
}
