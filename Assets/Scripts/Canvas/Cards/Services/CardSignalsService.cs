using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Canvas.Popups.Signals.Activity;
using Canvas.Services;
using ScriptableObjects;
using Zenject;

namespace Canvas.Cards.Services
{
    /// <summary>
    /// Common card service where we work with signals
    /// </summary>
    public class CardSignalsService
    {
        #region Parameters

        private SignalBus SignalBus { get; }
        [Inject] private ConditionsService ConditionsService { get; }
        [Inject] private AllItemsDataBase ItemsDataBase { get; }
        [Inject] private CardActionsService CardActionsService { get; }

        #endregion

        public CardSignalsService(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<FindCardForActivitySignal>(TryFindCardForCondition);
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
        /// <param name="cardId"></param>
        public void ShowPopup(ushort cardId)
        {
            SignalBus.Fire(new ShowCardPopupSignal {CardId = cardId});
        }

        /// <summary>
        /// Try find card for Conditions
        /// </summary>
        /// <param name="obj"></param>
        private void TryFindCardForCondition(FindCardForActivitySignal obj)
        {
            foreach (var cardObj in ItemsDataBase.allCards)
            {
                if (ConditionsService.CheckCondition(obj.ConditionId, cardObj.Id))
                {
                    CardActionsService.HighlightAllCardsById(cardObj.Id);
                }
            }
        }
    }
}