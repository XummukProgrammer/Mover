using UnityEngine;

namespace Mover
{
    public interface IPlayerInput
    {
        public event System.Action<Vector2> MovePressed;
        public event System.Action<Vector2> RotatePressed;

        public event System.Action UsePressed;
        public event System.Action DropPressed;
    }
}
