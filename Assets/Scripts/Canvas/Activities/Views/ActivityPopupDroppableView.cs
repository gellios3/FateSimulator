using AbstractViews;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Enums;
using Interfaces.Cards;
using Interfaces.Conditions.Cards;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity popup Droppable Card View
    /// </summary>
    public class ActivityPopupDroppableView : DroppableView
    {
        [SerializeField] private TextMeshProUGUI title;

        private ICardCondition conditionObj;

        private SignalBus SignalBus { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            SignalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
            SignalBus.Subscribe<CloseActivityPopupSignal>(OnCloseActivityPopup);
        }

        private void OnCloseActivityPopup(CloseActivityPopupSignal obj)
        {
            if (DropCardView == null) 
                return;
            DropCardView.CanDraggable = true;
            DropCardView.ReturnBack();
            DropCardView = null;
            borderImg.SetStatus(Status.Normal);
        }

        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            DropCardView.CanDraggable = false;
        }

        private void OnEndDragCard(EndDragCardSignal obj)
        {
            if (conditionObj == null)
                return;
            borderImg.SetStatus(Status.Normal);
        }

        private void OnStartDragCard(StartDragCardSignal obj)
        {
            if (conditionObj == null)
                return;
            switch (conditionObj)
            {
                case ICharacteristicCardCondition charCondition when obj.BaseCard is ICharacteristicCard charCard:
                    SetDroppable(charCondition.CharacteristicType == charCard.CharacteristicType);
                    break;
                default:
                    SetDroppable(conditionObj.CardType == obj.BaseCard.Type);
                    break;
            }

            if (CanDropCard)
                borderImg.SetStatus(Status.Highlighted);
        }

        private void OnDisable()
        {
            conditionObj = null;
        }

        public void Init(ICardCondition cardConditionObj)
        {
            conditionObj = cardConditionObj;
            gameObject.SetActive(true);
            title.text = cardConditionObj.Title;

            if (DropCardView == null) 
                return;
            DropCardView.CanDraggable = false;
            DropCardView.SetPosition(transform.position);
        }
    }
}