using System;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class PlayerAndroidInput : IPlayerInput, IInitializable, IDisposable
    {
        public event Action<Vector2> MovePressed;
        public event Action<Vector2> RotatePressed;
        public event Action UsePressed;
        public event Action DropPressed;

        private Jostik _jostik;

        [Inject]
        public PlayerAndroidInput(Jostik jostik)
        {
            _jostik = jostik;
        }

        public void Initialize()
        {
            _jostik.MovePressed += OnMovePressed;
            _jostik.RotatePressed += OnRotatePressed;
            _jostik.UsePressed += OnUsePressed;
            _jostik.DropPressed += OnDropPressed;
        }

        public void Dispose()
        {
            _jostik.MovePressed -= OnMovePressed;
            _jostik.RotatePressed -= OnRotatePressed;
            _jostik.UsePressed -= OnUsePressed;
            _jostik.DropPressed -= OnDropPressed;
        }

        private void OnMovePressed(Vector2 vec)
        {
            MovePressed?.Invoke(vec);
        }

        private void OnRotatePressed(Vector2 vec)
        {
            RotatePressed?.Invoke(vec);
        }

        private void OnUsePressed()
        {
            UsePressed?.Invoke();
        }

        private void OnDropPressed()
        {
            DropPressed?.Invoke();
        }
    }
}
