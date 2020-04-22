using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
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
        private IBaseActivity BaseActivity { get; set; }
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
            SignalBus.Fire(new StartActivitySignal {BaseActivity = BaseActivity});
            conditionsView.HideDropCards();
            sourceActivityView.StartActivity(BaseActivity.ActivityDuration);
            Hide();
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            SignalBus.Fire(new CloseActivityPopupSignal());
            sourceActivityView.ReturnToNormalStatus(true);
            Hide();
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
            BaseActivity = sourceActivityView.FoundActivity;
            // Init conditions
            conditionsView.Init(BaseActivity, obj.StartActionCard);
            // Init timer
            activityTimer.Init(BaseActivity.ActivityDuration);
            activityTimer.Hide();
        }
    }
}