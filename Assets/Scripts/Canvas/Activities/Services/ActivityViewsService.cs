using System.Collections.Generic;
using Canvas.Activities.Interfaces;
using Canvas.Cards.Services;
using Canvas.Popups.Signals.Activity;
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
            signalBus.Subscribe<StartActivitySignal>(OnRunCurrentActivity);
            signalBus.Subscribe<CloseActivityPopupSignal>(OnCloseActivityPopup);
        }

        /// <summary>
        /// On close activity popup
        /// </summary>
        /// <param name="obj"></param>
        private void OnCloseActivityPopup(CloseActivityPopupSignal obj)
        {
            var activity = GetActivityViewById(obj.ActivityId);
            activity?.RefreshActivity();
        }

        /// <summary>
        /// On run current activity
        /// </summary>
        /// <param name="obj"></param>
        private void OnRunCurrentActivity(StartActivitySignal obj)
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

        /// <summary>
        /// Get activity view by Id
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
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