using System;
using UnityEngine;
using Zenject;

namespace Mover
{
    public class PlayerDesktopInput : IPlayerInput, ITickable
    {
        public event Action<Vector2> MovePressed;
        public event Action<Vector2> RotatePressed;
        public event Action UsePressed;
        public event Action DropPressed;

        private float _time = 0f;

        public void Tick()
        {
            // At launch, it sends any nonsense that breaks the camera...
            if (_time < 1f)
            {
                _time += Time.deltaTime;
                return;
            }

            MovePressed?.Invoke(new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"))
            );

            RotatePressed?.Invoke(new Vector2(
                Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y"))
            );


            if (Input.GetKeyDown(KeyCode.E))
            {
                UsePressed?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.G))
            {
                DropPressed?.Invoke();
            }
        }
    }
}
