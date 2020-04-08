using System.Collections.Generic;
using System.Linq;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    public class ActivitiesService
    {
        
        [Inject] private List<BaseActivityObj> possibleActivities;
        
        public IBaseActivity GetActivityByActivity(IBaseCard startActivityCard)
        {
            return possibleActivities.FirstOrDefault(obj => ReferenceEquals(obj.StartActivityCard, startActivityCard));
        }

        public void ShowPopup()
        {
            Debug.LogError("Show popup");
        }
    }
}