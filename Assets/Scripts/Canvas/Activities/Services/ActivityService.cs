using System.Collections.Generic;
using System.Linq;
using Canvas.Activities.Views;
using Canvas.Cards.Models;
using Canvas.Cards.Views;
using Canvas.Popups.Signals;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    public class ActivityService
    {
        [Inject] private List<BaseActivityObj> possibleActivities;

        private readonly SignalBus signalBus;

        public ActivityService(SignalBus signalBus)
        {
            this.signalBus = signalBus;
        }

        public IBaseActivity GetActivityByActivity(IBaseCard startActivityCard)
        {
            return possibleActivities.FirstOrDefault(obj => ReferenceEquals(obj.StartActivityCard, startActivityCard));
        }

        public void ShowPopup(DraggableView draggableView, ActivityView activityView )
        {
            signalBus.Fire(new ShowActivityPopupSignal
            {
                StartActionCard = draggableView,
                SourceActivity = activityView
            });
        }
    }
}