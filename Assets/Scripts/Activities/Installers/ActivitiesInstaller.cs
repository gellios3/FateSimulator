using Activities.Services;
using Zenject;

namespace Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        // Start is called before the first frame update
        void Start()
        {
            Container.Bind<string>().FromInstance("Hello World!");
            Container.Bind<ActivitiesService>().AsSingle().NonLazy();
        }

    }
}
