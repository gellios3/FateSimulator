using Canvas.Activities.Services;
using Canvas.Activities.Views;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {

        public override void InstallBindings()
        {
            Container.Bind<ActivityService>().AsSingle();
        }

    }
}
