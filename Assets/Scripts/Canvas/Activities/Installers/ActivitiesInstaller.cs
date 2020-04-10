using Canvas.Activities.Services;
using Canvas.Activities.Views;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        // [Inject] private List<BaseCardObj> CardList { get; }

        [SerializeField] private GameObject activitiesController;
        
        public override void InstallBindings()
        {
            // Debug.LogError($"CardList {CardList.Count}");
            Container.Bind<ActivityService>().AsSingle();
            // Container.Bind<ActivitiesController>().FromComponentOn(activitiesController).AsSingle();
        }

    }
}
