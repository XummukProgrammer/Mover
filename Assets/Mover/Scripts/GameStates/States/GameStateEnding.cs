using UnityEngine;

namespace Mover
{
    public class GameStateEnding : GameStates.IState
    {
        public GameStates.States NextState { get; private set; } = GameStates.States.None;

        public void OnEnter()
        {
            Debug.Log("GameStateEnding");
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
