using UnityEngine;
using Zenject;

namespace Mover
{
    public class GameStateMoving : GameStates.IState
    {
        private UnloadingArea _unloadingArea;

        public GameStates.States NextState { get; private set; } = GameStates.States.None;

        [Inject]
        public GameStateMoving(UnloadingArea unloadingArea)
        {
            _unloadingArea = unloadingArea;
        }

        public void OnEnter()
        {
            Debug.Log("GameStateMoving");
        }

        public void OnExit()
        {
        }

        public void OnTick()
        {
            if (_unloadingArea.IsWin)
            {
                NextState = GameStates.States.Ending;
            }
        }

        public void OnFixedTick()
        {
        }
    }
}
