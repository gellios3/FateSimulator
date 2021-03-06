﻿using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Interfaces;
using Canvas.Cards.Interfaces;
using Canvas.Popups.Signals.Activity;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    /// <summary>
    /// Activities panel view
    /// </summary>
    public class ActivitiesPanelView : BaseView
    {
        [SerializeField] private StartActivityCardsView startActivityCardsView;
        [SerializeField] private ResultActivityCardsView resultActivityCardsView;

        private CustomButton StartActivityBtn { get; set; }
        private SignalBus SignalBus { get; set; }

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            startActivityCardsView.AllConditionsDone += OnAllCardsDone;
        }

        /// <summary>
        /// Init
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="card"></param>
        /// <param name="customButton"></param>
        public void Init(IBaseActivity baseActivity, ICardData card, CustomButton customButton)
        {
            StartActivityBtn = customButton;
            startActivityCardsView.Init(baseActivity, card);
        }

        public void OnClosePopup(ActivityStatus status)
        {
            Debug.LogError($"OnClosePopup {status}");
            startActivityCardsView.OnClosePopup(status);
            if (status == ActivityStatus.Finish)
            {
                resultActivityCardsView.ReturnAllCardToInventory();
            }
        }

        /// <summary>
        /// On all conditions done
        /// </summary>
        private void OnAllCardsDone()
        {
            StartActivityBtn.Show();
        }

        /// <summary>
        /// On start activity
        /// </summary>
        public void OnStartActivity(IActivityView activityView)
        {
            activityView.RunActivity(startActivityCardsView.DropCardViews);
        }

        /// <summary>
        /// Show start activity cards
        /// </summary>
        public void ShowStartActivityCards()
        {
            startActivityCardsView.Show();
            resultActivityCardsView.Hide();
        }

        /// <summary>
        /// Show result cards
        /// </summary>
        public void ShowResultCards(ushort ownerId, IEnumerable<IDraggableCardView> runCardViews,
            IEnumerable<ICardData> resultList)
        {
            startActivityCardsView.Hide();
            resultActivityCardsView.Show();
            StartActivityBtn.Hide();
            resultActivityCardsView.CreateResultCards(ownerId, runCardViews, resultList);
        }
    }
}