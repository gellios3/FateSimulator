using System;
using AbstractViews;
using Canvas.Activities.Interfaces;
using Canvas.Activities.Services;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals.Activity;
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

        [SerializeField] private ActivityDroppableView droppableView;
        [SerializeField] private ColorsPresetImage borderImg;
        [SerializeField] private ActivityTimerView timerView;

        private IBaseActivity CurrentActivity { get; set; }

        [Inject] private ActivityService activityService;
        [Inject] private ActivityViewsService ActivityViewsService { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
            
            signalBus.Subscribe<ShowActivityPopupSignal>(OnShowActivityPopup);
            signalBus.Subscribe<CloseActivityPopupSignal>(OnCloseActivityPopup);

            droppableView.CardDrop += OnDropCard;
            timerView.TimeFinish += OnTimerFinish;
            RunTimer += OnRunTimer;
            ActivityViewsService.AddActivityView(this);
        }

        private void OnRunTimer()
        {
            SetStatus(Status.Normal);
            timerView.Init(CurrentActivity.ActivityDuration);
            timerView.Show();
        }

        /// <summary>
        /// Return activity to normal status
        /// </summary>
        private void OnCloseActivityPopup(CloseActivityPopupSignal obj)
        {
            if (CurrentActivity == null || obj.ActivityId != CurrentActivity.Id)
                return;
            droppableView.ReturnDropCard();
            SetStatus(Status.Normal);
            CurrentActivity = null;
        }

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
            CurrentActivity = activityService.GetActivityByStartCardId(droppableView.DropCardId);
            activityService.ShowPopup(CurrentActivity.Id);
        }

        /// <summary>
        /// On timer finish
        /// </summary>
        private void OnTimerFinish()
        {
            timerView.Hide();
            activityService.ShowResultPopup(CurrentActivity.Id);
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
            var foundActivityObj = activityService.GetActivityByStartCardId(obj.CardId);
            if (foundActivityObj != null)
                borderImg.SetStatus(Status.Highlighted);
            droppableView.SetDroppable(foundActivityObj != null);
        }
    }
}