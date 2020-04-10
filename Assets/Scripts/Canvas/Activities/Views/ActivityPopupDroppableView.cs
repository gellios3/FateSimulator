using AbstractViews;
using Interfaces.Cards;
using Interfaces.Conditions.Cards;
using ScriptableObjects.Conditions.Requires;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Canvas.Activities.Views
{
    public class ActivityPopupDroppableView : DroppableView
    {
        [SerializeField] private TextMeshProUGUI title;

        private ICardCondition conditionObj;

        public void Init(ICardCondition cardConditionObj)
        {
            conditionObj = cardConditionObj;
            gameObject.SetActive(true);
            title.text = cardConditionObj.Title;
        }
    }
}