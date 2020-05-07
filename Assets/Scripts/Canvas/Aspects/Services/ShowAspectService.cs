using Canvas.Popups.Signals;
using Interfaces.Aspects;
using Zenject;

namespace Canvas.Aspects.Services
{
    /// <summary>
    /// Show aspect service
    /// </summary>
    public class ShowAspectService
    {
        private SignalBus SignalBus { get; }

        public ShowAspectService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="aspectId"></param>
        public void ShowPopup(ushort aspectId)
        {
            SignalBus.Fire(new ShowAspectPopupSignal {AspectId = aspectId});
        }
    }
}