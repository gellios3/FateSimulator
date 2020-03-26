using Canvas.Popups.Signals;
using Interfaces.Cards;
using Zenject;

namespace Canvas.Cards.Services
{
    public class DraggableCardService : IInitializable
    {
        private SignalBus SignalBus { get; }

        // public IBaseCard BaseCard { get; private set; }

        public DraggableCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void ShowPopup(IBaseCard baseCard)
        {
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }

        public void Initialize()
        {
        }
    }
}