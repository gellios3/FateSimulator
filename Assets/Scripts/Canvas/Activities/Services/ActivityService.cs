using Canvas.Popups.Signals.Activity;
using Enums;
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
        /// Get activity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IBaseActivity GetActivityById(ushort id)
        {
            return ItemsDataBase.GetActivityById(id);
        }

        /// <summary>
        /// Get Activity by condition Id
        /// </summary>
        /// <param name="startConditionId"></param>
        /// <returns></returns>
        public IBaseActivity GetActivityByStartConditionId(ushort startConditionId)
        {
            var condition = ItemsDataBase.allConditions.Find(obj => obj.Id == startConditionId);
            return ItemsDataBase.allActivities.Find(obj =>
                obj.RequiredList.Find(conditionObj => conditionObj == condition) != null
            );
        }

        /// <summary>
        /// Show popup
        /// </summary>
        /// <param name="activityId"></param>
        /// <param name="cardId"></param>
        public void ShowPopup(ushort activityId, ushort cardId)
        {
            SignalBus.Fire(new ShowActivityPopupSignal
            {
                ActivityId = activityId,
                StartActivityCardId = cardId
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