using AbstractViews;
using Canvas.Activities.Services;
using UnityEngine;
using Zenject;

namespace Canvas.Activities.Views
{
    public class ActivityView : MonoBehaviour
    {
        [SerializeField] private DroppableView droppableView;
        
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