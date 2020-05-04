using System.Collections.Generic;
using System.Linq;
using Canvas.Cards.Interfaces;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using ScriptableObjects;
using ScriptableObjects.Activities;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Activity service
    /// </summary>
    public class ActivityService
    {
        // [Inject] private List<BaseActivityObj> possibleActivities;

        [Inject] private AllItemsDataBase ItemsDataBase { get; }

        private readonly SignalBus signalBus;

        public ActivityService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
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
        /// <param name="draggableCardView"></param>
        /// <param name="activityId"></param>
        public void ShowPopup(IDraggableCardView draggableCardView, ushort activityId)
        {
            signalBus.Fire(new ShowActivityPopupSignal
            {
                StartActionCard = draggableCardView,
                ActivityId = activityId
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