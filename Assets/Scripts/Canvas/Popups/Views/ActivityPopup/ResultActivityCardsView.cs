using System.Collections.Generic;
using AbstractViews;
using Canvas.Activities.Views;
using Canvas.Cards;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    public class ResultActivityCardsView : BaseView
    {
        [SerializeField] private List<ActivityPopupDroppableView> droppableViews;
        
        [Inject] private CardDraggableSpawner Spawner { get; }
        
        private readonly List<ICardView> resultViews = new List<ICardView>();

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
            foreach (var baseCard in obj.ResultList)
            {
                var resultCard = Spawner.CreateResultCard(baseCard);
                resultViews.Add(resultCard);
            }
        }
    }
}