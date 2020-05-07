using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using ScriptableObjects;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Activity service
    /// </summary>
    public class ActivityService
    {
        [Inject] private AllItemsDataBase ItemsDataBase { get; }
        
        

        private SignalBus SignalBus { get; }

        public ActivityService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        /// <summary>
        /// Get activity card
        /// </summary>
        /// <param name="startActivityCardId"></param>
        /// <returns></returns>
        public IBaseActivity GetActivityByStartCardId(ushort startActivityCardId)
        {
            return ItemsDataBase.allActivities.Find(obj =>
                obj.startActivityCard != null && obj.startActivityCard.Id == startActivityCardId
            );
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="activityId"></param>
        public void ShowPopup(ushort activityId)
        {
            SignalBus.Fire(new ShowActivityPopupSignal
            {
                ActivityId = activityId
            });
        }

        /// <summary>
        /// Show result popup
        /// </summary>
        public void ShowResultPopup(ushort activityId)
        {
            SignalBus.Fire(new ShowActivityResultSignal {ActivityId = activityId});
        }
    }
}