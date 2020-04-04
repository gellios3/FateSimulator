using Canvas.Aspects.Servises;
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
            
            Container.Bind<ShowAspectService>().AsSingle();
        }
    }
}