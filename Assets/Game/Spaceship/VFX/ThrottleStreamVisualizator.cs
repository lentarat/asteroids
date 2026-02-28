using Asteroids.Spaceship.Movement;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class ThrottleStreamVisualizator : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _streamSpriteRenderer;
    [SerializeField] private SpaceshipMovement _spaceshipMovement;
    [SerializeField] private float _minYScaleMultiplier;
    [SerializeField] private float _maxYScaleMultiplier;
    [SerializeField] private float _fluctuatingFrequency;

    private Tween _scaleTween;
    
    private void Awake()
    {
        SubscribeToThrottleValueChanged();
        AlternateStreamLengthAsync().Forget();
    }

    private async UniTask AlternateStreamLengthAsync()
    {
        while (true)
        {
            _scaleTween = transform.parent.DOScaleY(_minYScaleMultiplier, _fluctuatingFrequency);
            await _scaleTween;

            _scaleTween = transform.parent.DOScaleY(_maxYScaleMultiplier, _fluctuatingFrequency);
            await _scaleTween;
        }
    }

    private void SubscribeToThrottleValueChanged()
    {
        _spaceshipMovement.OnThrottleValueChanged += HandleThrottleValueChanged;
    }

    private void HandleThrottleValueChanged(float throttleValue)
    { 
        if(throttleValue > 0)
        {
            ShowStream();
        }
        else
        {
            HideStream();
        }
    }

    private void ShowStream()
    {
        Color color = _streamSpriteRenderer.color;
        color.a = 1f;
        _streamSpriteRenderer.color = color;
    }

    private void HideStream()
    {
        Color color = _streamSpriteRenderer.color;
        color.a = 0f;
        _streamSpriteRenderer.color = color;
    }

    private void OnDestroy()
    {
        UnsubscribeToThrottleValueChanged();
        KillTween();
    }

    private void UnsubscribeToThrottleValueChanged()
    {
        _spaceshipMovement.OnThrottleValueChanged -= HandleThrottleValueChanged;
    }

    private void KillTween()
    {
        _scaleTween?.Kill();
    }
}
