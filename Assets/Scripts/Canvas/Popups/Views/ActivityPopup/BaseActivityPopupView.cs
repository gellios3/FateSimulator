using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Interfaces;
using Canvas.Cards.Interfaces;
using Canvas.Popups.Interfaces;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    /// <summary>
    /// Activity popup view
    /// </summary>
    public class BaseActivityPopupView : BaseView, IActivityPopupView
    {
        #region Parameters

        [SerializeField] private ActivitiesPanelView activitiesPanelView;
        [SerializeField] private ActivityDescriptionPopupView descriptionPopupView;

        [SerializeField] private Button closeBtn;
        [SerializeField] private CustomButton startActivityBtn;
        [SerializeField] private ActivityStatus activityStatus = ActivityStatus.Inactive;
        
        private IBaseActivity BaseActivity { get; set; }
        private IActivityView ActivityView { get; set; }

        #endregion

        [Inject]
        public void Construct(IActivityView activityView)
        {
            ActivityView = activityView;
            closeBtn.onClick.AddListener(OnClosePopup);
            startActivityBtn.onClick.AddListener(OnStartActivity);
        }

        public override void Show()
        {
            base.Show();
            activitiesPanelView.Show();
            descriptionPopupView.Show();
        }

        public override void Hide()
        {
            base.Hide();
            activitiesPanelView.Hide();
            descriptionPopupView.Hide();
        }

        /// <summary>
        /// Show result popup
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="runCardViews"></param>
        /// <param name="resultList"></param>
        public void ShowResultPopup(IBaseActivity baseActivity, IEnumerable<IDraggableCardView> runCardViews,
            IEnumerable<IBaseCard> resultList)
        {
            activityStatus = ActivityStatus.Finish;
            activitiesPanelView.ShowResultCards(runCardViews, resultList);
            BaseActivity = baseActivity;
            Show();
        }

        /// <summary>
        /// Show activity popup
        /// </summary>
        /// <param name="baseActivity"></param>
        /// <param name="cardId"></param>
        public void ShowActivityPopup(IBaseActivity baseActivity, ushort cardId)
        {
            activityStatus = ActivityStatus.Prepare;
            startActivityBtn.Hide();
            BaseActivity = baseActivity;
            activitiesPanelView.Init(BaseActivity, cardId, startActivityBtn);
            activitiesPanelView.ShowStartActivityCards();
            Show();
        }

        /// <summary>
        /// On start activity
        /// </summary>
        private void OnStartActivity()
        {
            activityStatus = ActivityStatus.Run;
            activitiesPanelView.OnStartActivity(ActivityView);
            Hide();
        }

        /// <summary>
        /// On close popup
        /// </summary>
        private void OnClosePopup()
        {
            activitiesPanelView.OnClosePopup(activityStatus);
            if(activityStatus == ActivityStatus.Finish)
                ActivityView.OnFinishActivity();
            ActivityView.RefreshActivity();
            Hide();
        }

        /// <summary>
        /// Zenject Factory for Instantiate
        /// </summary>
        public class Factory : PlaceholderFactory<IActivityView, BaseActivityPopupView>
        {
        }
    }
}