using Activities.Services;
using Zenject;

namespace Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ActivitiesService>().AsSingle();
        }

    }
}
