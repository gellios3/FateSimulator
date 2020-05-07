using System.Collections.Generic;
using Canvas.Activities.Interfaces;
using Canvas.Cards.Services;
using Canvas.Popups.Signals.Activity;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    public class ActivityViewsService
    {
        /// <summary>
        /// Draggable card Views
        /// </summary>
        private List<IActivityView> ActivityViews { get; } = new List<IActivityView>();
        
        [Inject] private CardActionsService CardActionsService { get; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartActivitySignal>(RunCurrentActivity);
        }

        private void RunCurrentActivity(StartActivitySignal obj)
        {
            var activity = GetActivityViewById(obj.ActivityId);
            if (activity == null)
                return;
            foreach (var cardView in obj.DropCardViews)
            {
                CardActionsService.HideCard(cardView);
            }
            activity.RunTimer.Invoke();
        }

        private IActivityView GetActivityViewById(ushort activityId)
        {
            return ActivityViews.Find(view => view.ActivityId == activityId);
        }

        /// <summary>
        /// Add draggable view
        /// </summary>
        /// <param name="activityView"></param>
        public void AddActivityView(IActivityView activityView)
        {
            ActivityViews.Add(activityView);
        }
    }
}