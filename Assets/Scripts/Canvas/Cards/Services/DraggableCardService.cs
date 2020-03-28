using Canvas.Popups.Signals;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Services
{
    public class DraggableCardService 
    {
        private SignalBus SignalBus { get; }

        // public IBaseCard BaseCard { get; private set; }

        public DraggableCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void ShowPopup(IBaseCard baseCard)
        {
            Debug.LogError("Show popup");
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }
        
    }
}