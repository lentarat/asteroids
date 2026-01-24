//using UnityEngine;
//using Asteroids.Game.Event;
//using Asteroids.General.Audio;

//namespace Asteroids.Game.Event.Handlers
//{
//    public class AudioResponder : MonoBehaviour
//    {
//        [SerializeField] private GameplayEventDispatcher _gameplayEventDispatcher;

//        private void Awake()
//        {
//            if (_gameplayEventDispatcher == null)
//            {
//                _gameplayEventDispatcher = GetComponent<GameplayEventDispatcher>();
//            }
//        }
//        private void OnEnable()
//        {
//            _gameplayEventDispatcher.OnEvent += Handle;
//        }

//        private void OnDisable()
//        {
//            _gameplayEventDispatcher.OnEvent -= Handle;
//        }

//        private void Handle(GameplayEvent e)
//        {
//            if (e.GameplayEventType != GameplayEventType.Shot) return;
//            var gameObject = e.GameObject;
//            if (gameObject == null) return;

//            if (!gameObject.TryGetComponent<IAudioProvider>(out var audioProvider)) return;
//            var audioDefinition = audioProvider.GetAudioDefinition();
//            if (audioDefinition == null || audioDefinition.AudioClip == null) return;

//            var audioEmitter = gameObject.GetComponent<AudioEmitter>(); 
//            float pitch = Random.Range(1f - audioDefinition.RandomPitchDeviation, 1f + audioDefinition.RandomPitchDeviation);
//            audioEmitter?.PlaySound(audioDefinition.AudioClip, pitch);
//        }
//    }
//}