using Zenject;

namespace Mover
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameStates();
            InstallMisc();
        }

        private void InstallGameStates()
        {
            Container.BindInterfacesAndSelfTo<GameStates>().AsSingle().NonLazy();

            Container.Bind<GameStateWaitingToStart>().AsSingle();
            Container.Bind<GameStateMoving>().AsSingle();
            Container.Bind<GameStateEnding>().AsSingle();
        }

        private void InstallMisc()
        {
            Container.BindInterfacesAndSelfTo<Inventory>().AsSingle().NonLazy();
        }

        [System.Serializable]
        public class Settings
        {
            public bool IsAndroid;
        }
    }
}
