using Canvas.Popups.Signals;
using Interfaces.Aspects;
using Zenject;

namespace Canvas.Aspects.Servises
{
    public class ShowAspectService
    {
        private SignalBus SignalBus { get; }

        public ShowAspectService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void ShowPopup(IBaseAspect baseCard)
        {
            SignalBus.Fire(new ShowAspectPopupSignal {BaseAspectObj = baseCard});
        }
    }
}