using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Signals;
using Canvas.Services;
using Enums;
using Interfaces.Cards;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Run activity service
    /// </summary>
    public class RunActivityService
    {
        [Inject] private ActivityViewsService ActivityViewsService { get; }
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private ActivityService ActivityService { get; }
        [Inject] private ResultsService ResultsService { get; }
        private List<IBaseCard> ResultCards { get; set; } = new List<IBaseCard>();
        private List<IDraggableCardView> RunCardViews { get; set; } = new List<IDraggableCardView>();
        private SignalBus SignalBus { get; }

        public RunActivityService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void Init(List<IDraggableCardView> runCardViews)
        {
            RunCardViews = runCardViews;
            HideDroppedCards();
        }

        public void Refresh()
        {
            RunCardViews.Clear();
        }

        /// <summary>
        /// Hide dropped cards
        /// </summary>
        private void HideDroppedCards()
        {
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.HideCard(cardView);
            }
        }

        /// <summary>
        /// On Finish activity
        /// </summary>
        public void OnFinishActivity(ushort runActivityId)
        {
            ActivityService.ShowResultPopup(runActivityId);
            ShowDroppedCards();

            var activity = ActivityService.GetActivityById(runActivityId);
            ResultCards = new List<IBaseCard>();

            foreach (var resultObj in activity.ResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    ResultCards.Add(findCard);
                }
            }

            foreach (var resultObj in activity.OptionalResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    ResultCards.Add(findCard);
                }
            }
            
            SignalBus.Fire(new CreateResultCardsForActivitySignal
            {
                RunCardViews = RunCardViews,
                ResultList = ResultCards
            });
        }

        /// <summary>
        /// Set status to Dropped cards
        /// </summary>
        /// <param name="status"></param>
        public void SetStatusToDroppedCards(CardStatus status)
        {
            foreach (var cardView in RunCardViews)
            {
                cardView.OnChangeStatus.Invoke(status);
            }
        }

        /// <summary>
        /// Show dropped cards
        /// </summary>
        private void ShowDroppedCards()
        {
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.ShowCard(cardView);
            }
        }
    }
}