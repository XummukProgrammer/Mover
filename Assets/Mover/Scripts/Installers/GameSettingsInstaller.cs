using UnityEngine;
using Zenject;

namespace Mover
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Mover/GameSettings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        public GameInstaller.Settings GameSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(GameSettings);
        }
    }
}
