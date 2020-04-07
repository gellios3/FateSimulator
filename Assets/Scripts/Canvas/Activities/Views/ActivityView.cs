using AbstractViews;
using Canvas.Activities.Services;
using Canvas.Cards.Signals;
using Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Activities.Views
{
    public class ActivityView : MonoBehaviour
    {
        [SerializeField] private DroppableView droppableView;

        [SerializeField] private ColorsPresetImage borderImg;

        [SerializeField] private GameObject timer;

        [Inject] private ActivitiesService activitiesService;

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<OnStartDragCardSignal>(OnStartDragCard);
            signalBus.Subscribe<OnEndDragCardSignal>(OnEndDragCard);
        }

        private void OnEndDragCard(OnEndDragCardSignal obj)
        {
            borderImg.SetStatus(Status.Normal);
        }

        private void OnStartDragCard(OnStartDragCardSignal obj)
        {
            borderImg.SetStatus(Status.Highlighted);
        }

        private void Start()
        {
            droppableView.OnCardDrop += cardData => { activitiesService.ShowPopup(); };
        }
    }
}