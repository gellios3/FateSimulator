using AbstractViews;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals.Activity;
using Canvas.Services;
using Enums;
using Interfaces.Conditions.Cards;
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

        private ICardCondition conditionObj;

        private SignalBus SignalBus { get; set; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            SignalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
            SignalBus.Subscribe<CloseActivityPopupSignal>(OnCloseActivityPopup);
        }

        /// <summary>
        /// On close popup 
        /// </summary>
        /// <param name="obj"></param>
        private void OnCloseActivityPopup(CloseActivityPopupSignal obj)
        {
            if (DropCardCardView == null)
                return;
            DropCardCardView.OnDropOnActivity?.Invoke(false);
            DropCardCardView.ReturnBack();
            DropCardCardView = null;
            borderImg.SetStatus(Status.Normal);
        }

        /// <summary>
        /// Override base on Drop
        /// </summary>
        /// <param name="eventData"></param>
        public override void OnDrop(PointerEventData eventData)
        {
            base.OnDrop(eventData);
            DropCardCardView?.OnDropOnActivity?.Invoke(true);
        }

        /// <summary>
        /// On end drag some card
        /// </summary>
        /// <param name="obj"></param>
        private void OnEndDragCard(EndDragCardSignal obj)
        {
            if (conditionObj == null)
                return;
            if (DropCardCardView == null)
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
            SetDroppable(ConditionsService.CheckCondition(conditionObj.Id, obj.CardId));
            if (CanDropCard)
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
            Show();
            title.text = cardConditionObj.Title;

            if (DropCardCardView == null)
                return;
            DropCardCardView?.OnDropOnActivity?.Invoke(true);
            DropCardCardView.SetPosition(transform.position);
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