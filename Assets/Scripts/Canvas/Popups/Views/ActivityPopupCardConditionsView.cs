using System;
using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Cards.Interfaces;
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

        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private CommonCardService CommonCardService { get; }

        private byte needCardsCount;

        private readonly List<IDraggableCardView> dropCardViews = new List<IDraggableCardView>();

        #endregion

        public event Action AllConditionsDone;

        private void Awake()
        {
            foreach (var droppableView in droppableViews)
            {
                droppableView.CardDrop += OnCardDrop;
            }
        }

        private void OnDisable()
        {
            dropCardViews.Clear();
            Debug.LogError($"OnDisable {dropCardViews.Count}");
        }

        /// <summary>
        /// On card drop
        /// </summary>
        private void OnCardDrop(IDraggableCardView draggableCardView)
        {
            dropCardViews.Add(draggableCardView);
            if (dropCardViews.Count == needCardsCount)
            {
                AllConditionsDone?.Invoke();
            }
        }

        /// <summary>
        /// Hide drop cards
        /// </summary>
        public void HideDropCards()
        {
            foreach (var droppableView in dropCardViews)
            {
                CardActionsService.HideCardById(droppableView);
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
                    droppableViews[i].DropCardId = baseActivity.StartActivityCard.Id;
                }

                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }
    }
}