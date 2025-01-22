using UnityEngine;

namespace Mover
{
    public class GameStateWaitingToStart : GameStates.IState
    {
        public GameStates.States NextState { get; private set; } = GameStates.States.None;

        public void OnEnter()
        {
            Debug.Log("GameStateWaitingToStart");
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
