using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    public class ResultActivityCardsView : BaseView
    {
        [SerializeField] private List<Transform> droppableViews;

        [Inject] private CardDraggableSpawner Spawner { get; }

        private readonly List<IDraggableCardView> resultViews = new List<IDraggableCardView>();

        [Inject]
        public void Construct(SignalBus signalBus)
        {
            signalBus.Subscribe<CreateResultCardsForActivitySignal>(CreateResultCards);
        }

        /// <summary>
        /// Create result cards
        /// </summary>
        /// <param name="obj"></param>
        private void CreateResultCards(CreateResultCardsForActivitySignal obj)
        {
            Debug.Log($"CreateResultCards {obj.RunCardViews.Count} {obj.ResultList.Count}");
            foreach (var cardView in obj.RunCardViews)
            {
                resultViews.Add(cardView);
            }

            foreach (var baseCard in obj.ResultList)
            {
                var resultCard = Spawner.CreateResultCard(baseCard);
                resultViews.Add(resultCard);
            }

            for (var i = 0; i < droppableViews.Count; i++)
            {
                if (i < resultViews.Count)
                {
                    Debug.Log($"pos {droppableViews[i].position}");
                    resultViews[i].OnSetPosition.Invoke(droppableViews[i].position);
                }
            }
        }
    }
}