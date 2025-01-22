using Zenject;

namespace Mover
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameStates();
        }

        private void InstallGameStates()
        {
            Container.BindInterfacesAndSelfTo<GameStates>().AsSingle().NonLazy();

            Container.Bind<GameStateWaitingToStart>().AsSingle();
            Container.Bind<GameStateMoving>().AsSingle();
            Container.Bind<GameStateEnding>().AsSingle();
        }
    }
}
