using System.Collections.Generic;
using System.Linq;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects;
using UnityEngine;

namespace Canvas.Activities.Views
{
    public class ActivitiesController : MonoBehaviour
    {
        [SerializeField] private List<BaseActivityObj> possibleActivities;

        private IEnumerable<BaseActivityObj> PossibleActivities => possibleActivities;

        [SerializeField] private List<ActivityView> activityViews;

        public List<ActivityView> ActivityViews => activityViews;

        public IBaseActivity GetActivityByActivity(IBaseCard startActivityCard)
        {
            return PossibleActivities.FirstOrDefault(obj => ReferenceEquals(obj.StartActivityCard, startActivityCard));
        }
    }
}