using System.Collections.Generic;
using Canvas.Cards.Views;
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
                var cardGameObject = draggableCardFactory.Create(cardObj);
                cardGameObject.SetStartPos(new Vector3(cardObj.PosOnTable.x, cardObj.PosOnTable.y, -3), CardParent);
                var topCard = CardViewSpawner.CreateViewCard(cardObj);
                cardGameObject.Init(topCard, cardObj);
            }
        }
    }
}