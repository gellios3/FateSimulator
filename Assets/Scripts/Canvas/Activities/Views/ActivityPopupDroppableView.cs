using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Services;
using Canvas.Cards.Signals;
using Canvas.Common;
using Canvas.Popups.Signals.Activity;
using Enums;
using Interfaces.Conditions.Cards;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity popup Droppable Card container
    /// </summary>
    public class ActivityPopupDroppableView : DroppableView, IPointerDownHandler
    {
        #region Parameters

        [SerializeField] private TextMeshProUGUI title;

        [Inject] private ConditionsService ConditionsService { get; }
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private CardViewsService CardViewsService { get; }

        private ICardCondition conditionObj;
        private SignalBus SignalBus { get; set; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            SignalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
        }

        /// <summary>
        /// On close popup 
        /// </summary>
        public void OnCloseActivityPopup()
        {
            if (DropCard == null)
                return;
            CardActionsService.DropOnActivity(DropCardCardView, false);
            CardActionsService.ReturnBack(DropCardCardView);
            DropCard = null;
            borderImg.SetStatus(Status.Normal);
        }

        /// <summary>
        /// Override base on Drop
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            CardActionsService.DropOnActivity(DropCardCardView, true);
        }

        /// <summary>
        /// On end drag some card
        /// </summary>
        /// <param name="obj"></param>
        private void OnEndDragCard(EndDragCardSignal obj)
        {
            if (conditionObj == null)
                return;
            if (DropCard == null)
                SetDroppable(true);
            borderImg.SetStatus(Status.Normal);
        }

        /// <summary>
        /// On start drag some card
        /// </summary>
        /// <param name="obj"></param>
        private void OnStartDragCard(StartDragCardSignal obj)
        {
            if (conditionObj == null)
                return;
            var canDrop = ConditionsService.CheckCondition(conditionObj.Id, obj.DraggableCardView.CardData.BaseCard.Id) &&
                          StatusHelper.IsUseableStatus(obj.DraggableCardView.TopCard.CurrentStatus.cardStatus);
            SetDroppable(canDrop);
            if (canDrop)
                borderImg.SetStatus(Status.Highlighted);
        }

        /// <summary>
        /// On hide 
        /// </summary>
        private void OnDisable()
        {
            conditionObj = null;
        }

        /// <summary>
        /// Init popup
        /// </summary>
        /// <param name="cardConditionObj"></param>
        public void Init(ICardCondition cardConditionObj)
        {
            conditionObj = cardConditionObj;
            title.text = cardConditionObj.Title;

            if (DropCard == null)
                return;
            DropCardCardView = CardViewsService.GetDraggableCardById(DropCard.BaseCard.Id);
            CardActionsService.DropOnActivity(DropCardCardView, true);
            CardActionsService.SetCardPosition(DropCardCardView, transform.position);
            OnDrop();
        }

        /// <summary>
        /// On pointer down
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            SignalBus.Fire(new FindCardForActivitySignal {ConditionId = conditionObj.Id});
        }
    }
}