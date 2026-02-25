using Asteroids.Spaceship.Movement;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ThrottleStreamVisualizator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _streamSpriteRenderer;
    [SerializeField] private SpaceshipMovement _spaceshipMovement;

    private void Awake()
    {
        SubscribeToThrottleValueChanged();
    }

    private void SubscribeToThrottleValueChanged()
    {
        _spaceshipMovement.OnThrottleValueChanged += HandleThrottleValueChanged;
    }

    private void HandleThrottleValueChanged(float throttleValue)
    { 
        
    }

    private void ShowStream()
    {
        Color color = _streamSpriteRenderer.color;
    }

    private UniTask AlternateStreamLengthAsync()
    { 
        transform.DOScale
    }

    private void HideStream()
    {
        _streamSpriteRenderer.enabled = false;
    }

    private void OnDestroy()
    {
        UnsubscribeToThrottleValueChanged();
    }

    private void UnsubscribeToThrottleValueChanged()
    {
        _spaceshipMovement.OnThrottleValueChanged -= HandleThrottleValueChanged;
    }
}
