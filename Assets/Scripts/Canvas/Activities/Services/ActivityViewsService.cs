using System.Collections.Generic;
using Canvas.Activities.Interfaces;
using Canvas.Popups.Interfaces;
using Canvas.Popups.Signals.Activity;
using Canvas.Popups.Views.ActivityPopup;
using Zenject;

namespace Canvas.Activities.Services
{
    public class ActivityViewsService
    {
        /// <summary>
        /// Draggable card Views
        /// </summary>
        private List<(IActivityView, IActivityPopupView)> ActivityViews { get; } =
            new List<(IActivityView, IActivityPopupView)>();

        /// <summary>
        /// Get activity view by Id
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public IActivityView GetActivityViewById(ushort activityId)
        {
            return ActivityViews.Find(view => view.Item1.ActivityId == activityId).Item1;
        }

        /// <summary>
        /// Get Activity popup by Index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IActivityPopupView GetActivityPopupByIndex(int index)
        {
            return ActivityViews[index].Item2;
        }

        /// <summary>
        /// Add draggable view
        /// </summary>
        /// <param name="activityView"></param>
        /// <param name="popupView"></param>
        public void AddActivityView(IActivityView activityView, BaseActivityPopupView popupView)
        {
            ActivityViews.Add((activityView, popupView));
        }
    }
}