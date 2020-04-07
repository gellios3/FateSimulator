using Canvas.Aspects.Servises;
using Canvas.Cards.Signals;
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
            Container.DeclareSignal<ShowAspectPopupSignal>(); 
            Container.DeclareSignal<ShowActivityPopupSignal>(); 
            Container.DeclareSignal<OnStartDragCardSignal>();
            Container.DeclareSignal<OnEndDragCardSignal>();
            
            Container.Bind<ShowAspectService>().AsSingle();
        }
    }
}