using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Services;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using UnityEngine;
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
        private List<IBaseCard> ResultCards { get; set; } = new List<IBaseCard>();
        private List<IDraggableCardView> RunCardViews { get; set; } = new List<IDraggableCardView>();

        public void Init(List<IDraggableCardView> runCardViews)
        {
            RunCardViews = runCardViews;
            HideDroppedCards();
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
            ResultCards = new List<IBaseCard>();
            var activityPopup = ActivityViewsService.GetActivityPopupByIndex(index);

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

            Debug.LogError($"RunCardViews {RunCardViews.Count} ResultCards {ResultCards.Count}");
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