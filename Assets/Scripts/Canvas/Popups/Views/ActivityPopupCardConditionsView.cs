using System;
using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Cards.Services;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Card conditions view for Activity popup
    /// </summary>
    public class ActivityPopupCardConditionsView : BaseView
    {
        #region Parameters

        /// <summary>
        /// Droppable views
        /// </summary>
        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;

        [Inject] private CommonCardService CommonCardService { get; }

        private byte needCardsCount;
        private byte dropCardsCount;

        #endregion

        public event Action AllConditionsDone;

        private void Start()
        {
            foreach (var droppableView in droppableViews)
            {
                droppableView.CardDrop += () =>
                {
                    dropCardsCount++;
                    if (dropCardsCount == needCardsCount)
                    {
                        AllConditionsDone?.Invoke();
                    }
                };
            }
        }

        /// <summary>
        /// Hide drop cards
        /// </summary>
        public void HideDropCards()
        {
            foreach (var droppableView in droppableViews)
            {
                droppableView.DropCardCardView?.Hide();
            }
        }

        /// <summary>
        /// Init Card Conditions
        /// </summary>
        /// <param name="baseActivity"></param>
        public void Init(IBaseActivity baseActivity)
        {
            var cardConditions = baseActivity.GetCardConditions();
            needCardsCount = (byte) cardConditions.Count;

            for (byte i = 0; i < needCardsCount; i++)
            {
                if (i == 0)
                {
                    dropCardsCount = 1;
                    droppableViews[i].DropCardCardView = CommonCardService.GetDraggableCardById(
                        baseActivity.StartActivityCard.Id
                    );
                }

                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }
    }
}