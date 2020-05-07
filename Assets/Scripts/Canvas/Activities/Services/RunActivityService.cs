using System.Collections.Generic;
using System.Linq;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Popups.Signals.Activity;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Run activity service
    /// </summary>
    public class RunActivityService
    {
        [Inject] private ActivityViewsService ActivityViewsService { get; }
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private ActivityService ActivityService { get; }
        private List<IDraggableCardView> RunCardViews { get; set; } = new List<IDraggableCardView>();
        private ushort RunActivityId { get; set; }

        public void Init(ushort activityId)
        {
            RunActivityId = activityId;
        }

        public void Refresh()
        {
            RunActivityId = 0;
            RunCardViews.Clear();
        }

        /// <summary>
        /// On Finish activity
        /// </summary>
        public void OnFinishActivity()
        {
            ActivityService.ShowResultPopup(RunActivityId);
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.ShowCard(cardView);
            }
        }

        /// <summary>
        /// On run current activity
        /// </summary>
        /// <param name="obj"></param>
        public void OnRunCurrentActivity(StartActivitySignal obj)
        {
            if (RunActivityId == 0)
                return;
            var activity = ActivityViewsService.GetActivityViewById(RunActivityId);
            if (activity == null)
                return;
            RunCardViews = obj.DropCardViews.ToList();
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.HideCard(cardView);
            }

            activity.RunTimer.Invoke();
        }
    }
}