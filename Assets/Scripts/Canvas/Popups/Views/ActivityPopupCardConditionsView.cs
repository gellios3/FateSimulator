using System.Collections.Generic;
using Canvas.Activities.Views;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace Canvas.Popups.Views
{
    public class ActivityPopupCardConditionsView : MonoBehaviour
    {
        [SerializeField] private List<ActiveDroppableView> droppableViews;

        public void Init(IBaseActivity baseActivity)
        {
            var cardConditions = baseActivity.GetCardConditions();
            for (byte i = 0; i < cardConditions.Count; i++)
            {
                droppableViews[i].Init(cardConditions[i] as ICardCondition);
            }
        }
    }
}