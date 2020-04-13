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
            Container.DeclareSignal<StartDragCardSignal>();
            Container.DeclareSignal<EndDragCardSignal>();
            Container.DeclareSignal<CloseActivityPopupSignal>();
            
            Container.Bind<ShowAspectService>().AsSingle();
        }
    }
}