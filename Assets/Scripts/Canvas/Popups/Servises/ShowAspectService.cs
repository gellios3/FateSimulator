using Canvas.Popups.Signals;
using Interfaces.Aspects;
using Interfaces.Cards;
using Zenject;

namespace Canvas.Popups.Servises
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