using UnityEngine;

[CreateAssetMenu(
    fileName = "SpaceshipProjectileSO",
    menuName = "ScriptableObjects/SpaceshipProjectileSO")]
public class SpaceshipProjectileSO : ScriptableObject
{
    [SerializeField] private float _damage;
    public float Damage => _damage;
    [SerializeField] private Sprite _projectileSprite;
    public Sprite ProjectileSprite => _projectileSprite;
}
