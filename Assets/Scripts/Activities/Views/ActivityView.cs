using AbstractViews;
using Activities.Services;
using UnityEngine;
using Zenject;

namespace Activities.Views
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