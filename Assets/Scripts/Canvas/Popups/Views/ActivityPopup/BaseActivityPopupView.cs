using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Popups.Signals.Activity;
using Interfaces.Activity;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    /// <summary>
    /// Activity popup view
    /// </summary>
    public class BaseActivityPopupView : BaseView
    {
        #region Parameters

        [SerializeField] private ActivitiesPanelView cardsPanel;
        [SerializeField] private Button closeBtn;
        [SerializeField] private CustomButton startActivityBtn;

        private SignalBus SignalBus { get; set; }
        private IBaseActivity BaseActivity { get; set; }
        [Inject] private ActivityService ActivityService { get; }

        #endregion

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            SignalBus = signalBus;
            SignalBus.Subscribe<ShowActivityPopupSignal>(ShowActivityPopup);
            SignalBus.Subscribe<ShowActivityResultSignal>(ShowResultPopup);
            closeBtn.onClick.AddListener(OnClosePopup);
            startActivityBtn.onClick.AddListener(OnStartActivity);
        }

        /// <summary>
        /// Show result popup
        /// </summary>
        private void ShowResultPopup(ShowActivityResultSignal obj)
        {
            cardsPanel.ShowResultCards();
            BaseActivity = ActivityService.GetActivityById(obj.ActivityId);
            Show();
        }

        /// <summary>
        /// Show activity popup
        /// </summary>
        /// <param name="obj"></param>
        private void ShowActivityPopup(ShowActivityPopupSignal obj)
        {
            startActivityBtn.Hide();
            BaseActivity = ActivityService.GetActivityById(obj.ActivityId);
            cardsPanel.Init(BaseActivity, obj.StartActivityCardId, startActivityBtn);
            cardsPanel.ShowStartActivityCards();
            Show();
        }

        /// <summary>
        /// On start activity
        /// </summary>
        private void OnStartActivity()
        {
            cardsPanel.OnStartActivity();
            Hide();
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            SignalBus.Fire(new CloseActivityPopupSignal {ActivityId = BaseActivity.Id});
            Hide();
        }
    }
}