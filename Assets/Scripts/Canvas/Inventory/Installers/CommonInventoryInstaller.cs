using Canvas.Inventory.Services;
using Zenject;

namespace Canvas.Inventory.Installers
{
    public class CommonInventoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<CommonInventoryService>().AsSingle();
        }
    }
}