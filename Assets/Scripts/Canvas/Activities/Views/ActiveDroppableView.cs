using AbstractViews;
using Interfaces.Cards;
using Interfaces.Conditions.Cards;
using ScriptableObjects.Conditions.Requires;
using TMPro;
using UnityEngine;

namespace Canvas.Activities.Views
{
    public class ActiveDroppableView : DroppableView
    {
        [SerializeField] private TextMeshProUGUI title;

        private ICardCondition conditionObj;

        public void Init(ICardCondition conditionObj)
        {
            gameObject.SetActive(true);
            title.text = conditionObj.CardType.ToString();
            Debug.LogError("ActiveDroppableView");
        }
    }
}