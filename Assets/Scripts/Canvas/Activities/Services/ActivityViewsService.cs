using System.Collections.Generic;
using Canvas.Activities.Interfaces;
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

        [Inject]
        public void Construct(SignalBus signalBus)
        {
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
        /// Get activity view by Id
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public IActivityView GetActivityViewById(ushort activityId)
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