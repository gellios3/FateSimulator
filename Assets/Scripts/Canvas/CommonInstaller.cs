using Canvas.Cards.Services;
using Canvas.Cards.Views;
using Canvas.Popups;
using Canvas.Popups.Signals;
using Zenject;

namespace Canvas
{
    public class CommonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<ShowCardPopupSignal>();

            // Container.BindInterfacesTo<DraggableCardService>().AsSingle();
            
            Container.Bind<CardShortDescriptionView>().AsSingle();
            Container.BindSignal<ShowCardPopupSignal>().ToMethod<CardShortDescriptionView>(
                x => x.ShowCardPopupSignal
            ).FromResolve();
        }
    }
}