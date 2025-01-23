using Zenject;

namespace Mover
{
    public class PlayerInstaller : MonoInstaller
    {
        private GameInstaller.Settings _gameSettings;

        [Inject]
        public void Construct(GameInstaller.Settings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public override void InstallBindings()
        {
            if (!_gameSettings.IsAndroid)
            {
                Container.BindInterfacesAndSelfTo<PlayerDesktopInput>().AsSingle();
            }
            else
            {
                Container.BindInterfacesAndSelfTo<PlayerAndroidInput>().AsSingle();
            }

            Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerRotateHandler>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerTargetWatcher>().AsSingle().NonLazy();
        }
    }
}
