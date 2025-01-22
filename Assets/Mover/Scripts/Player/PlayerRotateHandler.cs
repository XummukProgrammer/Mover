using System;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class PlayerRotateHandler : IInitializable, IDisposable
    {
        private Player _player;
        private IPlayerInput _input;

        [Inject]
        public void Construct(
            Player player,
            IPlayerInput input)
        {
            _player = player;
            _input = input;
        }

        public void Initialize()
        {
            _input.RotatePressed += OnRotatePressed;
        }

        public void Dispose()
        {
            _input.RotatePressed -= OnRotatePressed;
        }

        private void OnRotatePressed(Vector2 vec)
        {
            _player.RotateVector = vec;
        }
    }
}
