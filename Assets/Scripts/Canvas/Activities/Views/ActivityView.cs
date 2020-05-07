using System;
using AbstractViews;
using Canvas.Activities.Interfaces;
using Canvas.Activities.Services;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals.Activity;
using Canvas.Services;
using Enums;
using Interfaces.Activity;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity view
    /// </summary>
    public class ActivityView : BaseView, IActivityView
    {
        #region Parameters

        public ushort ActivityId => CurrentActivity?.Id ?? 0;
        public Action RunTimer { get; private set; }
        public Action RefreshActivity { get; private set; }

        [SerializeField] private ActivityDroppableView droppableView;
        [SerializeField] private ColorsPresetImage borderImg;
        [SerializeField] private ActivityTimerView timerView;

        private IBaseActivity CurrentActivity { get; set; }

        [Inject] private ActivityService ActivityService { get; }
        [Inject] private RunActivityService RunActivityService { get; }
        [Inject] private ActivityViewsService ActivityViewsService { get; }
        [Inject] private ConditionsService ConditionsService { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);

            signalBus.Subscribe<ShowActivityPopupSignal>(OnShowActivityPopup);
            signalBus.Subscribe<StartActivitySignal>(RunActivityService.OnRunCurrentActivity);

            droppableView.CardDrop += OnDropCard;
            timerView.TimeFinish += OnTimerFinish;

            RunTimer += OnRunTimer;
            RefreshActivity += OnRefreshActivity;
            ActivityViewsService.AddActivityView(this);
        }

        /// <summary>
        /// On refresh activity
        /// </summary>
        private void OnRefreshActivity()
        {
            droppableView.ReturnDropCard();
            SetStatus(Status.Normal);
            RunActivityService.Refresh();
            CurrentActivity = null;
        }

        /// <summary>
        /// Run activity timer
        /// </summary>
        private void OnRunTimer()
        {
            SetStatus(Status.Normal);
            timerView.Init(CurrentActivity.ActivityDuration);
            timerView.Show();
        }

        /// <summary>
        /// On show activity popup
        /// </summary>
        private void OnShowActivityPopup()
        {
            SetStatus(Status.Normal);
        }

        /// <summary>
        /// Set status 
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(Status status)
        {
            borderImg.SetStatus(status);
            droppableView.SetStatus(status);
        }

        /// <summary>
        /// On drop card
        /// </summary>
        private void OnDropCard(IDraggableCardView draggableCardView)
        {
            var condition = ConditionsService.TryFindConditionByCardId(droppableView.DropCardId);
            if (condition == null)
                return;
            CurrentActivity = ActivityService.GetActivityByStartConditionId(condition.Id);
            RunActivityService.Init(CurrentActivity.Id);
            ActivityService.ShowPopup(CurrentActivity.Id, droppableView.DropCardId);
        }

        /// <summary>
        /// On timer finish
        /// </summary>
        private void OnTimerFinish()
        {
            timerView.Hide();
            RunActivityService.OnFinishActivity();
            CurrentActivity = null;
        }

        /// <summary>
        /// On end drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnEndDragCard(EndDragCardSignal obj)
        {
            SetStatus(Status.Normal);
        }

        /// <summary>
        /// Start drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnStartDragCard(StartDragCardSignal obj)
        {
            var condition = ConditionsService.TryFindConditionByCardId(obj.CardId);
            if (condition == null)
                return;
            var foundActivityObj = ActivityService.GetActivityByStartConditionId(condition.Id);
            if (foundActivityObj != null)
                borderImg.SetStatus(Status.Highlighted);
            droppableView.SetDroppable(foundActivityObj != null);
        }
    }
}