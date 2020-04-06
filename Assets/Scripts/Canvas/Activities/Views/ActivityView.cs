using AbstractViews;
using Canvas.Activities.Services;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Views
{
    public class ActivityView : MonoBehaviour
    {
        [SerializeField] private DroppableView droppableView;

        [SerializeField] private GameObject timer;
        
        [Inject] private ActivitiesService activitiesService;

        private void Start()
        {
            droppableView.OnCardDrop += cardData =>
            {
                activitiesService.ShowPopup();
            };
        }
    }
}