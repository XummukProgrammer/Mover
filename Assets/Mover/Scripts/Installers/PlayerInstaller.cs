using Zenject;

namespace Mover
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerDesktopInput>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<PlayerMoveHandler>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerRotateHandler>().AsSingle().NonLazy();
        }
    }
}
