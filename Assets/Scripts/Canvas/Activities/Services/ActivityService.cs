using System.Collections.Generic;
using System.Linq;
using Canvas.Activities.Views;
using Canvas.Cards.Interfaces;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects.Activities;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Activity service
    /// </summary>
    public class ActivityService
    {
        [Inject] private List<BaseActivityObj> possibleActivities;

        private readonly SignalBus signalBus;

        public ActivityService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        /// <summary>
        /// Get activity card
        /// </summary>
        /// <param name="startActivityCard"></param>
        /// <returns></returns>
        public IBaseActivity GetActivityByActivity(IBaseCard startActivityCard)
        {
            return possibleActivities.FirstOrDefault(obj => ReferenceEquals(obj.StartActivityCard, startActivityCard));
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="draggableCardView"></param>
        /// <param name="activityView"></param>
        public void ShowPopup(IDraggableCardView draggableCardView, ActivityView activityView)
        {
            signalBus.Fire(new ShowActivityPopupSignal
            {
                StartActionCard = draggableCardView,
                SourceActivity = activityView
            });
        }

        /// <summary>
        /// Show result popup
        /// </summary>
        public void ShowResultPopup()
        {
            signalBus.Fire(new ShowActivityResultSignal());
        }
    }
}