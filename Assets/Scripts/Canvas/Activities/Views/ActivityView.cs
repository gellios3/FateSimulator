using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals.Activity;
using Enums;
using Interfaces.Activity;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity view
    /// </summary>
    public class ActivityView : BaseView
    {
        [SerializeField] private ActivityDroppableView droppableView;

        [SerializeField] private ColorsPresetImage borderImg;

        [SerializeField] private ActivityTimerView timerView;

        public IBaseActivity FoundActivity { get; private set; }

        [Inject] private ActivityService activityService;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<StartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<EndDragCardSignal>(OnEndDragCard);
            signalBus.Subscribe<ShowActivityPopupSignal>(() => ReturnToNormalStatus());
        }

        private void Start()
        {
            droppableView.CardDrop += () => { activityService.ShowPopup(droppableView.DropCardView, this); };
            timerView.TimeFinish += () =>
            {
                Debug.Log("TimeFinish !!!");
            };
        }

        /// <summary>
        /// Return activity to normal status
        /// </summary>
        /// <param name="returnCard"></param>
        public void ReturnToNormalStatus(bool returnCard = false)
        {
            if (returnCard)
            {
                droppableView.ReturnDropCard();
            }

            borderImg.SetStatus(Status.Normal);
        }

        /// <summary>
        /// Start activity
        /// </summary>
        /// <param name="duration"></param>
        public void StartActivity(ushort duration)
        {
            borderImg.SetStatus(Status.Normal);
            timerView.Init(duration);
            timerView.Show();
        }

        /// <summary>
        /// On end drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnEndDragCard(EndDragCardSignal obj)
        {
            ReturnToNormalStatus();
        }

        /// <summary>
        /// Start drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnStartDragCard(StartDragCardSignal obj)
        {
            FoundActivity = activityService.GetActivityByActivity(obj.BaseCard);
            if (FoundActivity != null)
                borderImg.SetStatus(Status.Highlighted);
            droppableView.SetDroppable(FoundActivity != null);
        }
    }
}