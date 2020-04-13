using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Signals;
using Canvas.Popups.Signals;
using Enums;
using Interfaces.Activity;
using Interfaces.Cards;
using ScriptableObjects.Conditions.Requires;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Activities.Views
{
    /// <summary>
    /// Activity view
    /// </summary>
    public class ActivityView : MonoBehaviour
    {
        [SerializeField] private ActivityDroppableView droppableView;

        [SerializeField] private ColorsPresetImage borderImg;

        [SerializeField] private GameObject timer;

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
            droppableView.OnCardDrop += () => { activityService.ShowPopup(droppableView.DropCardView, this); };
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