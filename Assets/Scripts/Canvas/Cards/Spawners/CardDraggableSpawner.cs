using System.Collections.Generic;
using Canvas.Cards.Views;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Spawners
{
    /// <summary>
    /// Card draggable spawner
    /// </summary>
    public class CardDraggableSpawner : IInitializable
    {
        #region Parameters

        [Inject] private List<ICardData> CardList { get; }
        [Inject] private Transform CardParent { get; }
        [Inject] private CardViewSpawner CardViewSpawner { get; }

        private readonly DraggableCardView.Factory draggableCardFactory;

        #endregion

        public CardDraggableSpawner(DraggableCardView.Factory draggableCardFactory)
        {
            this.draggableCardFactory = draggableCardFactory;
        }

        public void Initialize()
        {
            foreach (var cardObj in CardList)
            {
                var topCard = CardViewSpawner.CreateViewCard(cardObj.BaseCard);
                var cardGameObject = draggableCardFactory.Create(cardObj.BaseCard, topCard);
                cardGameObject.SetStartPos(new Vector3(0, 0, -3), CardParent);
            }
        }

        /// <summary>
        /// Create result cards
        /// </summary>
        /// <param name="baseCard"></param>
        public DraggableCardView CreateResultCard(IBaseCard baseCard)
        {
            var topCard = CardViewSpawner.CreateViewCard(baseCard);
            var cardGameObject = draggableCardFactory.Create(baseCard, topCard);
            cardGameObject.SetStartPos(new Vector3(0, 0, -3), CardParent);
            return cardGameObject;
        }
    }
}