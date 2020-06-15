using System.Collections.Generic;
using AbstractViews;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Spawners;
using Enums;
using Interfaces.Cards;
using Serializable.Cards;
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
        /// <param name="ownerId"></param>
        /// <param name="runCardViews"></param>
        /// <param name="resultList"></param>
        public void CreateResultCards(ushort ownerId, IEnumerable<IDraggableCardView> runCardViews,
            IEnumerable<ICardData> resultList)
        {
            ResultViews.Clear();

            foreach (var cardView in runCardViews)
            {
                ResultViews.Add(cardView);
            }

            foreach (var baseCard in resultList)
            {
                baseCard.InventoryData = new CardInventoryData()
                {
                    inventoryPos = new InventoryPos {colIndex = 0, rowIndex = 0},
                    inventoryType = InventoryType.Personal,
                    OwnerId = ownerId
                };
                var resultCard = Spawner.CreateResultCard(baseCard);
                ResultViews.Add(resultCard);
            }

            Invoke(nameof(SetPosForResultCards), 0.05f);
        }

        public void ReturnAllCardToInventory()
        {
            foreach (var draggableCardView in ResultViews)
            {
                Spawner.SetToInventory(draggableCardView);
            }
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