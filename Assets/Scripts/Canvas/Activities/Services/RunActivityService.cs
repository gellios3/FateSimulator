﻿using System.Collections.Generic;
using System.Linq;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals.Activity;
using Canvas.Services;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Services
{
    /// <summary>
    /// Run activity service
    /// </summary>
    public class RunActivityService
    {
        [Inject] private ActivityViewsService ActivityViewsService { get; }
        [Inject] private CardActionsService CardActionsService { get; }
        [Inject] private ActivityService ActivityService { get; }
        [Inject] private ResultsService ResultsService { get; }
        private List<IDraggableCardView> RunCardViews { get; set; } = new List<IDraggableCardView>();
        private ushort RunActivityId { get; set; }
        private SignalBus SignalBus { get; }

        public RunActivityService(SignalBus signalBus)
        {
            SignalBus = signalBus;
        }

        public void Init(ushort activityId)
        {
            RunActivityId = activityId;
        }

        public void Refresh()
        {
            RunActivityId = 0;
            RunCardViews.Clear();
        }

        /// <summary>
        /// On Finish activity
        /// </summary>
        public void OnFinishActivity()
        {
            ActivityService.ShowResultPopup(RunActivityId);
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.ShowCard(cardView);
            }

            var activity = ActivityService.GetActivityById(RunActivityId);
            var resultCards = new List<IBaseCard>();
            foreach (var resultObj in activity.ResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    resultCards.Add(findCard);
                }
            }

            foreach (var resultObj in activity.OptionalResultsList)
            {
                var findCard = ResultsService.TryFindCardByResultObj(resultObj);
                if (findCard != null)
                {
                    resultCards.Add(findCard);
                } 
            }

            Debug.LogError($"OnFinishActivity {resultCards.Count}");

            SignalBus.Fire(new CreateResultCardsForActivitySignal() {ResultList = resultCards});
        }

        /// <summary>
        /// On run current activity
        /// </summary>
        /// <param name="obj"></param>
        public void OnRunCurrentActivity(StartActivitySignal obj)
        {
            if (RunActivityId == 0)
                return;
            var activity = ActivityViewsService.GetActivityViewById(RunActivityId);
            if (activity == null)
                return;
            RunCardViews = obj.DropCardViews.ToList();
            foreach (var cardView in RunCardViews)
            {
                CardActionsService.HideCard(cardView);
            }

            activity.RunTimer.Invoke();
        }

        // private void TryConvert
    }
}