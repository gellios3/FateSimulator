using System.Collections.Generic;
using Canvas.Cards.Views;
using Interfaces.Cards;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards
{
    /// <summary>
    /// Card draggable spawner
    /// </summary>
    public class CardDraggableSpawner : IInitializable
    {
        #region Parameters

        [Inject] private List<BaseCardObj> CardList { get; }
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
                var topCard = CardViewSpawner.CreateViewCard(cardObj);
                var cardGameObject = draggableCardFactory.Create(cardObj, topCard);
                cardGameObject.SetStartPos(new Vector3(cardObj.PosOnTable.x, cardObj.PosOnTable.y, -3), CardParent);
            }
        }

        /// <summary>
        /// Create result cards
        /// </summary>
        /// <param name="baseCard"></param>
        public void CreateResultCard(IBaseCard baseCard)
        {
            var topCard = CardViewSpawner.CreateViewCard(baseCard);
            var cardGameObject = draggableCardFactory.Create(baseCard, topCard);
            cardGameObject.SetStartPos(new Vector3(baseCard.PosOnTable.x, baseCard.PosOnTable.y, -3), CardParent);
        }
    }
}