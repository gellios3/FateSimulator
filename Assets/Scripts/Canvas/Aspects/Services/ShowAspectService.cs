using Canvas.Popups.Signals;
using Interfaces.Aspects;
using Zenject;

namespace Canvas.Aspects.Services
{
    public class ShowAspectService
    {
        private SignalBus SignalBus { get; }

        public ShowAspectService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void ShowPopup(IBaseAspect baseAspect)
        {
            SignalBus.Fire(new ShowAspectPopupSignal {BaseAspectObj = baseAspect});
        }
    }
}