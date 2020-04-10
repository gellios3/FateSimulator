using Canvas.Aspects.Views;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects.Installers
{
    public class AspectListInstaller : MonoInstaller
    {
        [SerializeField] private GameObject aspectPrefab;
        
        public override void InstallBindings()
        {
            Container.BindInstance(transform).AsTransient().WhenInjectedInto<AspectsSpawner>();
            Container.Bind<AspectsSpawner>().AsSingle();

            Container.BindFactory<AspectIconView, AspectIconView.Factory>().FromComponentInNewPrefab(aspectPrefab).Lazy();
        }
    }
}