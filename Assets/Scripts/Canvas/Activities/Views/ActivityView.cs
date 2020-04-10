using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Signals;
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
            signalBus.Subscribe<OnStartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<OnEndDragCardSignal>(OnEndDragCard);
        }

        private void Start()
        {
            droppableView.OnCardDrop += () => { activityService.ShowPopup(droppableView.DropCardView, this); };
        }

        /// <summary>
        /// On end drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnEndDragCard(OnEndDragCardSignal obj)
        {
            borderImg.SetStatus(Status.Normal);
        }

        /// <summary>
        /// Start drag card
        /// </summary>
        /// <param name="obj"></param>
        private void OnStartDragCard(OnStartDragCardSignal obj)
        {
            FoundActivity = activityService.GetActivityByActivity(obj.BaseCard);
            if (FoundActivity != null)
                borderImg.SetStatus(Status.Highlighted);
            droppableView.SetDroppable(FoundActivity != null);
        }
    }
}