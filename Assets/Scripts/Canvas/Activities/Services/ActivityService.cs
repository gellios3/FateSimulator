using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Activity service
    /// </summary>
    public class ActivityService
    {
        [Inject] private AllItemsDataBase ItemsDataBase { get; }

        [Inject] private ActivityViewsService ActivityViewsService { get; }

        [Inject] private RunActivityService RunActivityService { get; }

       

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
        /// <param name="index"></param>
        /// <param name="activityId"></param>
        /// <param name="cardId"></param>
        public void ShowPopup(int index, ushort activityId, ICardData cardData)
        {
            var activityPopup = ActivityViewsService.GetActivityPopupByIndex(index);
            var activity = GetActivityById(activityId);
            activityPopup.ShowActivityPopup(activity, cardData);
        }

        /// <summary>
        /// Run Activity
        /// </summary>
        /// <param name="currentActivityId"></param>
        /// <param name="dropCardViews"></param>
        public void RunActivity(ushort currentActivityId, List<IDraggableCardView> dropCardViews)
        {
            var activity = ActivityViewsService.GetActivityViewById(currentActivityId);
            if (activity == null)
                return;
            RunActivityService.Init(dropCardViews);
            activity.RunTimer.Invoke();
        }

        public void OnFinishActivity()
        {
            RunActivityService.SetStatusToDroppedCards(CardStatus.Distress);
            RunActivityService.Reset();
        }

        public void OnTimerFinish(int index, ushort activityId)
        {
            var activity = GetActivityById(activityId);
            RunActivityService.OnFinishActivity(index,activity);
        }
        
        /// <summary>
        /// Get activity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private IBaseActivity GetActivityById(ushort id)
        {
            return ItemsDataBase.GetActivityById(id);
        }
    }
}