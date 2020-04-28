using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Popups.Signals.Activity;
using Canvas.Services;
using Interfaces.Cards;
using Zenject;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Draggable card service
    /// </summary>
    public class DraggableCardService
    {
        private SignalBus SignalBus { get; }
        private List<ICardView> CardViews { get; } = new List<ICardView>();
        [Inject] private ConditionsService ConditionsService { get; }

        public DraggableCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<FindCardForActivitySignal>(TryFindCardForCondition);
        }

        /// <summary>
        /// Try find card for canditions 
        /// </summary>
        /// <param name="obj"></param>
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

        /// <summary>
        /// Add card view
        /// </summary>
        /// <param name="cardView"></param>
        public void AddCardView(ICardView cardView)
        {
            CardViews.Add(cardView);
        }

        /// <summary>
        /// Start drag card
        /// </summary>
        /// <param name="baseCard"></param>
        public void StartDragCard(IBaseCard baseCard)
        {
            SignalBus.Fire(new StartDragCardSignal {BaseCard = baseCard});
        }

        /// <summary>
        /// End drag card
        /// </summary>
        /// <param name="baseCard"></param>
        public void EndDragCard(IBaseCard baseCard)
        {
            SignalBus.Fire(new EndDragCardSignal {BaseCard = baseCard});
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="baseCard"></param>
        public void ShowPopup(IBaseCard baseCard)
        {
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }
    }
}