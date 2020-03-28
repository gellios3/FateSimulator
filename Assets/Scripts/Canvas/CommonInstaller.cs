using Canvas.Cards.Services;
using Canvas.Popups.Signals;
using UnityEngine;
using Zenject;

namespace Canvas
{
    public class CommonInstaller : MonoInstaller
    {
        [SerializeField] private GameObject shortDescription;
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<ShowCardPopupSignal>();

            // Container.InstantiateComponent<CardShortDescriptionView>(shortDescription);

            Container.Bind<DraggableCardService>().AsSingle();
        }
    }
}