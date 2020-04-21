using Canvas.Aspects.Servises;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Services;
using Zenject;

namespace Canvas
{
    /// <summary>
    /// Global common installer for game scene
    /// </summary>
    public class CommonGameInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<ShowCardPopupSignal>(); 
            Container.DeclareSignal<ShowAspectPopupSignal>(); 
            Container.DeclareSignal<ShowActivityPopupSignal>(); 
            Container.DeclareSignal<FindCardForActivitySignal>(); 
            Container.DeclareSignal<StartDragCardSignal>();
            Container.DeclareSignal<EndDragCardSignal>();
            Container.DeclareSignal<CloseActivityPopupSignal>();
            
            Container.Bind<ShowAspectService>().AsSingle();
            Container.Bind<ConditionsService>().AsSingle();
        }
    }
}