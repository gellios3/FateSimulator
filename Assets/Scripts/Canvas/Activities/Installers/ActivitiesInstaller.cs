using Canvas.Activities.Services;
using Zenject;

namespace Canvas.Activities.Installers
{
    public class ActivitiesInstaller : MonoInstaller
    {
        // [Inject] private List<BaseCardObj> CardList { get; }
        
        public override void InstallBindings()
        {
            // Debug.LogError($"CardList {CardList.Count}");
            Container.Bind<ActivitiesService>().AsSingle();
        }

    }
}
