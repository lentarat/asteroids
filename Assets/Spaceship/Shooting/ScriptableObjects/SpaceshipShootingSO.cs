using UnityEngine;

[CreateAssetMenu(fileName = "SpaceshipShootingSO", menuName = "ScriptableObjects/SpaceshipShootingSO")]
public class SpaceshipShootingSO : ScriptableObject
{
    [SerializeField] private float _interval;
    public float Interval => _interval;
    [SerializeField] private float _damage;
    public float Damage => _damage;
    [SerializeField] private Sprite _projectileSprite;
    public Sprite ProjectileSprite => _projectileSprite;
}
