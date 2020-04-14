using System;
using System.Collections.Generic;
using Canvas.Activities.Views;
using Canvas.Cards.Views;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace Canvas.Popups.Views
{
    public class ActivityPopupCardConditionsView : MonoBehaviour
    {
        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;

        private byte needCardsCount;
        private byte dropCardsCount;

        private void Start()
        {
            foreach (var droppableView in droppableViews)
            {
                droppableView.OnCardDrop += () =>
                {
                    dropCardsCount++;
                    if (dropCardsCount == needCardsCount)
                    {
                        Debug.LogError("Show Start Activity");
                    }
                };
            }
        }

        public void Init(IBaseActivity baseActivity, DraggableView startActionCard)
        {
            var cardConditions = baseActivity.GetCardConditions();
            needCardsCount = (byte) cardConditions.Count;
            
            for (byte i = 0; i < needCardsCount; i++)
            {
                if (i == 0)
                {
                    dropCardsCount = 1;
                    droppableViews[i].DropCardView = startActionCard;
                }
                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }
        
        
    }
}