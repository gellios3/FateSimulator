using System;
using System.Collections.Generic;
using System.Linq;
using AbstractViews;
using Canvas.Activities.Interfaces;
using Canvas.Activities.Services;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using Canvas.Common;
using Canvas.Inventory.Services;
using Enums;
using Interfaces.Activity;
using Services;
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
        [SerializeField] private ColorsPresetImageView borderImg;
        [SerializeField] private TimerView timerView;

        private IBaseActivity CurrentActivity { get; set; }

        private ushort RunOwnerId { get; set; }

        [Inject] private ActivityService ActivityService { get; }

        [Inject] private OwnersService OwnersService { get; }

        [Inject] private ConditionsService ConditionsService { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);

            droppableView.CardDrop += OnDropCard;
            timerView.TimeFinish += OnTimerFinish;

            RunTimer += OnRunTimer;
        }

        /// <summary>
        /// On run current activity
        /// </summary>
        /// <param name="dropCardViews"></param>
        public void RunActivity(IEnumerable<IDraggableCardView> dropCardViews)
        {
            if (CurrentActivity == null)
                return;
            RunOwnerId = droppableView.DropCard.InventoryData.OwnerId;
            OwnersService.AddRunOwner(RunOwnerId);
            ActivityService.RunActivity(CurrentActivity.Id, dropCardViews.ToList());
        }

        /// <summary>
        /// On refresh activity
        /// </summary>
        public void RefreshActivity()
        {
            droppableView.ReturnDropCard();
            SetStatus(Status.Normal);
            CurrentActivity = null;
        }

        public void OnFinishActivity()
        {
            ActivityService.OnFinishActivity();
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
            var condition = ConditionsService.TryFindConditionByCardId(droppableView.DropCard.BaseCard.Id);
            if (condition == null)
                return;
            CurrentActivity = ActivityService.GetActivityByStartConditionId(condition.Id);
            ActivityService.ShowPopup(transform.GetSiblingIndex(), CurrentActivity, droppableView.DropCard);
            SetStatus(Status.Normal);
        }

        /// <summary>
        /// On timer finish
        /// </summary>
        private void OnTimerFinish()
        {
            timerView.Hide();
            ActivityService.OnTimerFinish(transform.GetSiblingIndex(), CurrentActivity.Id);
            OwnersService.RemoveRunOwner(RunOwnerId);
            RunOwnerId = 0;
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
            if (OwnersService.HasRunOwner(obj.DraggableCardView.CardData.InventoryData.OwnerId))
                return;
            
            var condition = ConditionsService.TryFindConditionByCardId(obj.DraggableCardView.CardData.BaseCard.Id);
            if (condition == null)
            {
                droppableView.SetDroppable(false);
                return;
            }

            var canDrop = StatusHelper.IsUseableStatus(obj.DraggableCardView.TopCard.CurrentStatus.cardStatus) &&
                          ActivityService.GetActivityByStartConditionId(condition.Id) != null;
            if (canDrop)
            {
                borderImg.SetStatus(Status.Highlighted);
            }

            droppableView.SetDroppable(canDrop);
        }
    }
}