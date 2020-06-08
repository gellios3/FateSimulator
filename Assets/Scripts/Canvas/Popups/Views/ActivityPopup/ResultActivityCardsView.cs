using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Spawners;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Popups.Views.ActivityPopup
{
    /// <summary>
    /// Result cards for end activity 
    /// </summary>
    public class ResultActivityCardsView : BaseView
    {
        [SerializeField] private List<Transform> droppableViews;
        [Inject] private CardDraggableSpawner Spawner { get; }
        private List<IDraggableCardView> ResultViews { get; } = new List<IDraggableCardView>();

        /// <summary>
        /// Create result cards
        /// </summary>
        /// <param name="runCardViews"></param>
        /// <param name="resultList"></param>
        public void CreateResultCards(IEnumerable<IDraggableCardView> runCardViews, IEnumerable<IBaseCard> resultList)
        {
            ResultViews.Clear();
            
            foreach (var cardView in runCardViews)
            {
                ResultViews.Add(cardView);
            }

            foreach (var baseCard in resultList)
            {
                var resultCard = Spawner.CreateResultCard(baseCard);
                ResultViews.Add(resultCard);
            }

            Invoke(nameof(SetPosForResultCards), 0.05f);
        }

        /// <summary>
        /// Set new positions for result cards
        /// </summary>
        private void SetPosForResultCards()
        {
            for (var i = 0; i < droppableViews.Count; i++)
            {
                if (i < ResultViews.Count)
                    ResultViews[i].OnSetPosition.Invoke(droppableViews[i].position);
            }
        }
    }
}