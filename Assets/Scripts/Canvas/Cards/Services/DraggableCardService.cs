using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Services;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Services
{
    public class DraggableCardService
    {
        private SignalBus SignalBus { get; }

        private List<ICardView> CardViews { get; set; } = new List<ICardView>();

        [Inject] private ConditionsService ConditionsService { get; }

        public DraggableCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;

            SignalBus.Subscribe<FindCardForActivitySignal>(TryFindCardForCondition);
        }

        private void TryFindCardForCondition(FindCardForActivitySignal obj)
        {
            foreach (var cardView in CardViews)
            {
                if (ConditionsService.CheckCondition(obj.Condition, cardView.BaseCard))
                {
                    cardView.HighlightCard();
                }
            }
        }

        public void AddCardView(ICardView cardView)
        {
            CardViews.Add(cardView);
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