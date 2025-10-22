using System;
using UnityEngine;
using Zenject;

namespace Asteroids
{
    public class InputBootstrapper : IInitializable, IDisposable
    {
        private readonly PlayerInputActions _playerInputActions;

        [Inject]
        public InputBootstrapper(PlayerInputActions playerInputActions)
        {
            _playerInputActions = playerInputActions;
        }

        void IInitializable.Initialize()
        {
            _playerInputActions.Enable();
        }

        void IDisposable.Dispose()
        {
            _playerInputActions.Disable();
        }
    }
}