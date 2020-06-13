using Canvas.Inventory.Services;
using Zenject;

namespace Canvas.Inventory.Installers
{
    public class PersonalInventoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PersonalInventoryService>().AsTransient().Lazy();
        }
    }
}