using System;
using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Views;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Card conditions view for Activity popup
    /// </summary>
    public class ActivityPopupCardConditionsView : BaseView
    {
        /// <summary>
        /// Droppable views
        /// </summary>
        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;

        private byte needCardsCount;
        private byte dropCardsCount;

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
                if (droppableView.DropCardCardView != null)
                {
                    droppableView.DropCardCardView.Hide();
                }
            }
        }

        /// <summary>
        /// Init Card Conditions
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="startActionCard"></param>
        public void Init(IBaseActivity baseActivity, IDraggableCardView startActionCard)
        {
            var cardConditions = baseActivity.GetCardConditions();
            needCardsCount = (byte) cardConditions.Count;

            for (byte i = 0; i < needCardsCount; i++)
            {
                if (i == 0)
                {
                    dropCardsCount = 1;
                    droppableViews[i].DropCardCardView = startActionCard;
                }

                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }
    }
}