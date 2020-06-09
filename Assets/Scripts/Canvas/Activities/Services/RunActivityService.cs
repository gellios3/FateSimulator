using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects.Cards;
using Serializable.Cards;
using Services;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Run activity service
    /// </summary>
    public class RunActivityService
    {
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private ResultsService ResultsService { get; }
        [Inject] private ActivityViewsService ActivityViewsService { get; }
        private List<ICardData> ResultCards { get; set; } = new List<ICardData>();
        private List<IDraggableCardView> RunCardViews { get; set; } = new List<IDraggableCardView>();

        public void Init(List<IDraggableCardView> runCardViews)
        {
            RunCardViews = runCardViews;
            HideDroppedCards();
        }

        public void Reset()
        {
            ResultCards.Clear();
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
        public void OnFinishActivity(int index, IBaseActivity activity)
        {
            ShowDroppedCards();
            ResultCards = new List<ICardData>();
            var activityPopup = ActivityViewsService.GetActivityPopupByIndex(index);

            foreach (var resultObj in activity.ResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    ResultCards.Add(new CardData
                    {
                        baseCard = findCard as BaseCardObj
                    });
                }
            }

            foreach (var resultObj in activity.OptionalResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    ResultCards.Add(new CardData
                    {
                        baseCard = findCard as BaseCardObj
                    });
                }
            }

            activityPopup.ShowResultPopup(activity, RunCardViews, ResultCards);
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