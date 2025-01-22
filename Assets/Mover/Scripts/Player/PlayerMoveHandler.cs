using System;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class PlayerMoveHandler : IInitializable, IDisposable
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
            _input.MovePressed += OnMovePressed;
        }

        public void Dispose()
        {
            _input.MovePressed -= OnMovePressed;
        }

        private void OnMovePressed(Vector2 vec)
        {
            _player.MoveVector = vec;
        }
    }
}
