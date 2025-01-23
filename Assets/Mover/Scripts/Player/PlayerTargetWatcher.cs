using System;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class PlayerTargetWatcher : IInitializable, IDisposable, ITickable
    {
        private GameCamera _camera;
        private IPlayerInput _input;
        private PlayerView _view;

        public ObjectUsed Target
        {
            get; private set;
        }

        [Inject]
        public PlayerTargetWatcher(
            GameCamera camera, 
            IPlayerInput input,
            PlayerView view)
        {
            _camera = camera;
            _input = input;
            _view = view;
        }

        public void Initialize()
        {
            _input.UsePressed += OnUsePressed;
        }

        public void Dispose()
        {
            _input.UsePressed -= OnUsePressed;
        }

        public void Tick()
        {
            Target = null;

            var ray = new Ray(_view.Head.position, _view.Head.forward);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out ObjectUsed used))
                {
                    Target = used;
                }
            }
        }

        private void OnUsePressed()
        {
            if (Target != null)
            {
                Target.Use();
            }
        }
    }
}
