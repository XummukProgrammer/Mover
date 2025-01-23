using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Mover
{
    public class Jostik : MonoBehaviour
    {
        [SerializeField]
        private JostikButton _moveForwardButton;

        [SerializeField]
        private JostikButton _moveLeftButton;

        [SerializeField]
        private JostikButton _moveRightButton;

        [SerializeField]
        private JostikButton _moveBackButton;

        [SerializeField]
        private JostikButton _rotateLeftButton;

        [SerializeField]
        private JostikButton _rotateRightButton;

        [SerializeField]
        private JostikButton _rotateUpButton;

        [SerializeField]
        private JostikButton _rotateDownButton;

        [SerializeField]
        private Button _useButton;

        private GameInstaller.Settings _gameSettings;

        public event Action<Vector2> MovePressed;
        public event Action<Vector2> RotatePressed;
        public event Action UsePressed;
        public event Action DropPressed;

        [Inject]
        public void Construct(GameInstaller.Settings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        private void Start()
        {
            if (!_gameSettings.IsAndroid)
            {
                gameObject.SetActive(false);
                return;
            }

            _useButton.onClick.AddListener(() =>
            {
                UsePressed?.Invoke();
            });

            _moveForwardButton.Clicking += OnMoveForwardClicking;
            _moveLeftButton.Clicking += OnMoveLeftClicking;
            _moveRightButton.Clicking += OnMoveRightClicking;
            _moveBackButton.Clicking += OnMoveBackClicking;

            _rotateLeftButton.Clicking += OnRotateLeftClicking;
            _rotateRightButton.Clicking += OnRotateRightClicking;
            _rotateUpButton.Clicking += OnRotateUpClicking;
            _rotateDownButton.Clicking += OnRotateDownClicking;
        }

        private void OnDestroy()
        {
            if (!_gameSettings.IsAndroid)
            {
                return;
            }

            _moveForwardButton.Clicking -= OnMoveForwardClicking;
            _moveLeftButton.Clicking -= OnMoveLeftClicking;
            _moveRightButton.Clicking -= OnMoveRightClicking;
            _moveBackButton.Clicking -= OnMoveBackClicking;

            _rotateLeftButton.Clicking -= OnRotateLeftClicking;
            _rotateRightButton.Clicking -= OnRotateRightClicking;
            _rotateUpButton.Clicking -= OnRotateUpClicking;
            _rotateDownButton.Clicking -= OnRotateDownClicking;
        }

        private void OnMoveForwardClicking()
        {
            MovePressed?.Invoke(new Vector2(0f, 1f));
        }

        private void OnMoveBackClicking()
        {
            MovePressed?.Invoke(new Vector2(0f, -1f));
        }

        private void OnMoveLeftClicking()
        {
            MovePressed?.Invoke(new Vector2(-1f, 0f));
        }

        private void OnMoveRightClicking()
        {
            MovePressed?.Invoke(new Vector2(1f, 0f));
        }

        private void OnRotateUpClicking()
        {
            RotatePressed?.Invoke(new Vector2(0f, 1f));
        }

        private void OnRotateDownClicking()
        {
            RotatePressed?.Invoke(new Vector2(0f, -1f));
        }

        private void OnRotateLeftClicking()
        {
            RotatePressed?.Invoke(new Vector2(-1f, 0f));
        }

        private void OnRotateRightClicking()
        {
            RotatePressed?.Invoke(new Vector2(1f, 0f));
        }
    }
}
