using Canvas.Activities.Services;
using Zenject;

namespace Canvas.Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<ActivityService>().AsTransient();
            Container.Bind<ActivityViewsService>().AsSingle();
            Container.Bind<RunActivityService>().AsSingle();
        }

    }
}
