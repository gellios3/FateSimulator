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
        }
    }
}