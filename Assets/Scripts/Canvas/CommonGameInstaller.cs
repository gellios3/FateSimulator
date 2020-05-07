using Canvas.Aspects.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Popups.Signals.Activity;
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

            InitActivitySignals();

            Container.DeclareSignal<ShowCardPopupSignal>(); 
            Container.DeclareSignal<ShowAspectPopupSignal>();
            Container.DeclareSignal<StartDragCardSignal>();
            Container.DeclareSignal<EndDragCardSignal>();
            Container.DeclareSignal<ShowActivityResultSignal>();

            Container.Bind<ShowAspectService>().AsSingle();
            Container.Bind<ConditionsService>().AsSingle();
        }

        /// <summary>
        /// Init Activity signals
        /// </summary>
        private void InitActivitySignals()
        {
            Container.DeclareSignal<ShowActivityPopupSignal>(); 
            Container.DeclareSignal<FindCardForActivitySignal>(); 
            Container.DeclareSignal<CloseActivityPopupSignal>();  
            Container.DeclareSignal<StartActivitySignal>();
        }
    }
}