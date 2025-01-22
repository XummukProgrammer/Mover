using System.Collections.Generic;
using Zenject;

namespace Mover
{
    public class GameStates : IInitializable, ITickable, IFixedTickable
    {
        private List<IState> _states = new();

        public IState CurrentStateHandler
        {
            get; private set;
        }

        public States CurrentState
        {
            get; private set;
        } = States.None;

        [Inject]
        public void Construct(
            GameStateWaitingToStart waitingToStateState,
            GameStateMoving movingState,
            GameStateEnding endingState)
        {
            _states = new List<IState>
            {
                waitingToStateState,
                movingState,
                endingState
            };
        }

        public void Initialize()
        {
            ChangeState(States.WaitingToStart);
        }

        public void Tick()
        {
            CurrentStateHandler.OnTick();
            TryChangeState();
        }

        public void FixedTick()
        {
            CurrentStateHandler.OnFixedTick();
        }

        public void ChangeState(States state)
        {
            if (CurrentState == state)
            {
                return;
            }

            if (CurrentStateHandler != null)
            {
                CurrentStateHandler.OnExit();
                CurrentStateHandler = null;
            }

            CurrentState = state;
            CurrentStateHandler = _states[(int)state];
            CurrentStateHandler.OnEnter();
        }

        private void TryChangeState()
        {
            if (CurrentStateHandler.NextState != States.None)
            {
                ChangeState(CurrentStateHandler.NextState);
            }
        }

        public interface IState
        {
            public States NextState { get; }

            public void OnEnter();
            public void OnExit();
            public void OnTick();
            public void OnFixedTick();
        }

        public enum States
        {
            WaitingToStart,
            Moving,
            Ending,
            None
        }
    }
}
