using Canvas.Aspects.Views;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects.Installers
{
    /// <summary>
    /// Aspect list installer
    /// </summary>
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