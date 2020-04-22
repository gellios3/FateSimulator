using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Popups.Signals.Activity;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    /// <summary>
    /// Activity popup view
    /// </summary>
    public class ActivityPopupView : BaseView
    {
        [SerializeField] private ActivityPopupCardConditionsView conditionsView;
        [SerializeField] private Button closeBtn;
        [SerializeField] private CustomButton startActivityBtn;
        [SerializeField] private ActivityTimerView activityTimer;

        private SignalBus SignalBus { get; set; }

        private ActivityView sourceActivityView;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            closeBtn.onClick.AddListener(OnClosePopup);
            startActivityBtn.onClick.AddListener(OnStartActivity);
            conditionsView.AllConditionsDone += OnAllConditionsDone;
        }

        /// <summary>
        /// On start activity
        /// </summary>
        private void OnStartActivity()
        {
            Hide();
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            SignalBus.Fire(new CloseActivityPopupSignal());
            Hide();
        }

        /// <summary>
        /// Hide popup
        /// </summary>
        public override void Hide()
        {
            base.Hide();
            if (sourceActivityView != null)
                sourceActivityView.ReturnToNormalStatus(true);
        }

        /// <summary>
        /// On all conditions done
        /// </summary>
        private void OnAllConditionsDone()
        {
            startActivityBtn.Show();
        }

        /// <summary>
        /// Show activity popup
        /// </summary>
        /// <param name="obj"></param>
        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            Show();
            sourceActivityView = obj.SourceActivity;
            startActivityBtn.Hide();
            // Init conditions
            conditionsView.Init(sourceActivityView.FoundActivity, obj.StartActionCard);
            // Init timer
            activityTimer.Init(sourceActivityView.FoundActivity.ActivityDuration);
            activityTimer.Hide();
        }
    }
}