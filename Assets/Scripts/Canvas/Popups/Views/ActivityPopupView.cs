﻿using Canvas.Activities.Views;
using Canvas.Popups.Signals;
using Canvas.Popups.Signals.Activity;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Activity popup view
    /// </summary>
    public class ActivityPopupView : MonoBehaviour
    {
        [SerializeField] private ActivityPopupCardConditionsView conditionsView;
        [SerializeField] private Button closeBtn;
        [SerializeField] private Button startActivityBtn;

        private SignalBus SignalBus { get; set; }

        private ActivityView sourceActivityView;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            closeBtn.onClick.AddListener(OnClosePopup);
            startActivityBtn.gameObject.SetActive(true);
            startActivityBtn.onClick.AddListener(OnStartActivity);

            conditionsView.AllConditionsDone += OnAllConditionsDone;
        }

        /// <summary>
        /// On start activity
        /// </summary>
        private void OnStartActivity()
        {
            gameObject.SetActive(false);
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            sourceActivityView.ReturnToNormalStatus(true);
            SignalBus.Fire(new CloseActivityPopupSignal());
            gameObject.SetActive(false);
        }
        
        /// <summary>
        /// On all conditions done
        /// </summary>
        private void OnAllConditionsDone()
        {
            startActivityBtn.gameObject.SetActive(true);
        }

        /// <summary>
        /// Show activity popup
        /// </summary>
        /// <param name="obj"></param>
        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            gameObject.SetActive(true);
            sourceActivityView = obj.SourceActivity;
            startActivityBtn.gameObject.SetActive(false);
            conditionsView.Init(sourceActivityView.FoundActivity, obj.StartActionCard);
        }
    }
}