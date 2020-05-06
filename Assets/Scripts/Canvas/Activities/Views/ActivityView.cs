using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Interfaces;
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
    public class ActivityView : BaseView
    {
        #region Parameters

        [SerializeField] private ActivityDroppableView droppableView;
        [SerializeField] private ColorsPresetImage borderImg;
        [SerializeField] private ActivityTimerView timerView;

         private IBaseActivity CurrentActivity { get; set; }

        [Inject] private ActivityService activityService;

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
            signalBus.Subscribe<ShowActivityPopupSignal>(() => SetStatus(Status.Normal));
            signalBus.Subscribe<StartActivitySignal>(RunCurrentActivity);
            signalBus.Subscribe<CloseActivityPopupSignal>(ReturnToNormalStatus);
        }

        private void Start()
        {
            droppableView.CardDrop += OnDropCard;
            timerView.TimeFinish += OnTimerFinish;
        }

        /// <summary>
        /// Run Current Activity
        /// </summary>
        /// <param name="obj"></param>
        private void RunCurrentActivity(StartActivitySignal obj)
        {
            if (CurrentActivity == null || obj.ActivityId != CurrentActivity.Id)
                return;
            SetStatus(Status.Normal);
            timerView.Init(CurrentActivity.ActivityDuration);
            timerView.Show();
        }

        /// <summary>
        /// Return activity to normal status
        /// </summary>
        private void ReturnToNormalStatus(CloseActivityPopupSignal obj)
        {
            if (CurrentActivity == null || obj.ActivityId != CurrentActivity.Id)
                return;
            droppableView.ReturnDropCard();
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
            activityService.ShowResultPopup();
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