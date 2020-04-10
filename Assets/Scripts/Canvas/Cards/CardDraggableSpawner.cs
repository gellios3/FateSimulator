using System.Collections.Generic;
using Canvas.Cards.Views;
using ScriptableObjects.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards
{
    public class CardDraggableSpawner : IInitializable
    {
        [Inject] private List<BaseCardObj> CardList { get; }
        [Inject] private Transform CardParent { get; }
        [Inject] private CardViewSpawner CardViewSpawner { get; }

        private readonly DraggableView.Factory draggableCardFactory;

        public CardDraggableSpawner(DraggableView.Factory draggableCardFactory)
        {
            this.draggableCardFactory = draggableCardFactory;
        }

        public void Initialize()
        {
            foreach (var cardObj in CardList)
            {
                var cardGameObject = draggableCardFactory.Create(cardObj);
                var transform = cardGameObject.transform;
                transform.parent = CardParent;
                transform.localPosition = new Vector3(cardObj.PosOnTable.x, cardObj.PosOnTable.y, -3);
                transform.localRotation = Quaternion.identity;
                var topCard = CardViewSpawner.CreateViewCard(cardObj);
                cardGameObject.SetCardView(topCard,cardObj);
            }
        }
    }
}