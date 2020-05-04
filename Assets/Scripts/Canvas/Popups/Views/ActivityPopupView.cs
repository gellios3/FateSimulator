using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using ScriptableObjects;
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
        #region Parameters

        [SerializeField] private ActivityPopupCardConditionsView conditionsView;
        [SerializeField] private Button closeBtn;
        [SerializeField] private CustomButton startActivityBtn;
        [SerializeField] private ActivityTimerView activityTimer;

        private SignalBus SignalBus { get; set; }
        private IBaseActivity BaseActivity { get; set; }
        [Inject] private AllItemsDataBase AllItemsDataBase { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            SignalBus.Subscribe<ShowActivityResultSignal>(ShowResultPopup);
            closeBtn.onClick.AddListener(OnClosePopup);
            startActivityBtn.onClick.AddListener(OnStartActivity);
            conditionsView.AllConditionsDone += OnAllConditionsDone;
        }

        /// <summary>
        /// Show result popup
        /// </summary>
        private void ShowResultPopup()
        {
            Show();
        }

        /// <summary>
        /// On start activity
        /// </summary>
        private void OnStartActivity()
        {
            SignalBus.Fire(new StartActivitySignal {ActivityId = BaseActivity.Id});
            conditionsView.HideDropCards();
            Hide();
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            SignalBus.Fire(new CloseActivityPopupSignal{ActivityId = BaseActivity.Id});
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
            startActivityBtn.Hide();
            BaseActivity = AllItemsDataBase.GetActivityById(obj.ActivityId);
            // Init conditions
            conditionsView.Init(BaseActivity, obj.StartActionCard);
            // Init timer
            activityTimer.Init(BaseActivity.ActivityDuration);
            activityTimer.Hide();
        }
    }
}