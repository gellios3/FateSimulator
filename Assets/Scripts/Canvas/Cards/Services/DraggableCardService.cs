using Canvas.Cards.Signals;
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

        public void StartDragCard(IBaseCard baseCard)
        {
            SignalBus.Fire(new StartDragCardSignal {BaseCard = baseCard});
        } 
        
        public void EndDragCard(IBaseCard baseCard)
        {
            SignalBus.Fire(new EndDragCardSignal {BaseCard = baseCard});
        }

        public void ShowPopup(IBaseCard baseCard)
        {
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }
    }
}