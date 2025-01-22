using UnityEngine;

namespace Mover
{
    public class GameStateMoving : GameStates.IState
    {
        public GameStates.States NextState { get; private set; } = GameStates.States.None;

        public void OnEnter()
        {
            Debug.Log("GameStateMoving");
        }

        public void OnExit()
        {
        }

        public void OnTick()
        {
        }

        public void OnFixedTick()
        {
        }
    }
}
