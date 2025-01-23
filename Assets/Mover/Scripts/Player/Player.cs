using UnityEngine;
using Zenject;

namespace Mover
{
    public class Player : MonoBehaviour
    {
        private PlayerView _view;
        private GameCamera _camera;

        public Vector2 MoveVector
        {
            get; set;
        } = Vector2.zero;

        public Vector2 RotateVector
        {
            get; set;
        } = Vector2.zero;

        [Inject]
        public void Construct(
            PlayerView view,
            GameCamera camera)
        {
            _view = view;
            _camera = camera;
        }

        private void Start()
        {
            _camera.Target = _view.Head;
        }

        private void Update()
        {
            RotateLogic();
        }

        private void FixedUpdate()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            _view.AddForce(MoveVector);

            MoveVector = Vector2.zero;
        }

        private void RotateLogic()
        {
            _view.Rotate(RotateVector);

            RotateVector = Vector2.zero;
        }
    }
}
