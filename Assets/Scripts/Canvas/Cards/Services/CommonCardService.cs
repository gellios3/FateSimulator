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
    /// Common card service where we work with signals
    /// </summary>
    public class CommonCardService
    {
        #region Parameters

        private SignalBus SignalBus { get; }
        private List<ICardView> CardViews { get; } = new List<ICardView>();
        private List<IDraggableCardView> DraggableCardViews { get; } = new List<IDraggableCardView>();
        [Inject] private ConditionsService ConditionsService { get; }

        #endregion

        public CommonCardService(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<FindCardForActivitySignal>(TryFindCardForCondition);
        }

        /// <summary>
        /// Get draggable card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IDraggableCardView GetDraggableCardById(ushort id)
        {
            return DraggableCardViews.Find(view => view.CardId == id);
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
        /// Add draggable view
        /// </summary>
        /// <param name="draggableCardView"></param>
        public void AddDraggableView(IDraggableCardView draggableCardView)
        {
            DraggableCardViews.Add(draggableCardView);
        }

        /// <summary>
        /// Start drag card
        /// </summary>
        /// <param name="cardId"></param>
        public void StartDragCard(ushort cardId)
        {
            SignalBus.Fire(new StartDragCardSignal {CardId = cardId});
        }

        /// <summary>
        /// End drag card
        /// </summary>
        /// <param name="cardId"></param>
        public void EndDragCard(ushort cardId)
        {
            SignalBus.Fire(new EndDragCardSignal {CardId = cardId});
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="baseCard"></param>
        public void ShowPopup(IBaseCard baseCard)
        {
            SignalBus.Fire(new ShowCardPopupSignal {BaseCard = baseCard});
        }
        
        /// <summary>
        /// Try find card for canditions 
        /// </summary>
        /// <param name="obj"></param>
        private void TryFindCardForCondition(FindCardForActivitySignal obj)
        {
            foreach (var cardView in CardViews)
            {
                if (ConditionsService.CheckCondition(obj.Condition, cardView.BaseCard.Id))
                {
                    cardView.HighlightCard();
                }
            }
        }
    }
}