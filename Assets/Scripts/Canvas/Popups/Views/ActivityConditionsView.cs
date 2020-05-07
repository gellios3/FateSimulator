﻿using System;
using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Cards.Interfaces;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Card conditions view for Activity popup
    /// </summary>
    public class ActivityConditionsView : BaseView
    {
        #region Parameters

        public event Action AllConditionsDone;
        public List<IDraggableCardView> DropCardViews { get; } = new List<IDraggableCardView>();
        
        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;

        private byte needCardsCount;

        #endregion

        [Inject]
        public void Construct()
        {
            foreach (var droppableView in droppableViews)
            {
                droppableView.CardDrop += OnCardDrop;
            }
        }

        /// <summary>
        /// Init Card Conditions
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="showActivityCardId"></param>
        public void Init(IBaseActivity baseActivity, ushort showActivityCardId)
        {
            var cardConditions = baseActivity.GetCardConditions();
            needCardsCount = (byte) cardConditions.Count;

            for (byte i = 0; i < needCardsCount; i++)
            {
                if (i == 0)
                {
                    droppableViews[i].DropCardId = showActivityCardId;
                }

                droppableViews[i].Show();
                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }

        private void OnDisable()
        {
            DropCardViews.Clear();
        }

        /// <summary>
        /// On card drop
        /// </summary>
        private void OnCardDrop(IDraggableCardView draggableCardView)
        {
            DropCardViews.Add(draggableCardView);
            if (DropCardViews.Count == needCardsCount)
            {
                AllConditionsDone?.Invoke();
            }
        }
    }
}