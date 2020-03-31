using Canvas.Popups.Signals;
using Interfaces.Cards;
using Zenject;

namespace Canvas.Cards.Services
{
    public class DraggableCardService 
    {
        private SignalBus SignalBus { get; }

        public DraggableCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void ShowPopup(IBaseCard baseCard)
        {
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }
        
    }
}