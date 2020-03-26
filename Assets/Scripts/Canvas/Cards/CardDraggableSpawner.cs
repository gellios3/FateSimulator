using System.Collections.Generic;
using Canvas.Cards.Views;
using ScriptableObjects.Cards;
using Zenject;

namespace Canvas.Cards
{
    public class CardDraggableSpawner : IInitializable
    {
        [Inject] private List<BaseCardObj> CardList { get; }
        
        readonly DraggableView.Factory _draggableCardFactory;

        public CardDraggableSpawner(DraggableView.Factory draggableCardFactory)
        {
            _draggableCardFactory = draggableCardFactory;
        }

        public void Initialize()
        {
            // var enemy = _enemyFactory.Create(newSpeed);
            foreach (var cardObj in CardList)
            {
                var cardGameObject = _draggableCardFactory.Create(cardObj);
                // var cardGameObject = Instantiate(cardPrefab, transform);
                // cardGameObject.transform.localPosition = new Vector3(cardObj.PosOnTable.x, cardObj.PosOnTable.y, -3);
                // var draggableCard = cardGameObject.GetComponent<DraggableView>();
                // var topCardObject = Instantiate(cardViewPrefab, cardViewParent);
                // draggableCard.SetCardView(topCardObject.GetComponent<CardView>(), cardObj);
            }
        }
    }
}