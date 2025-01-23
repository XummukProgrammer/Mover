using Zenject;

namespace Mover
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerDesktopInput>().AsSingle();

            Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerRotateHandler>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerTargetWatcher>().AsSingle().NonLazy();
        }
    }
}
