using Canvas.Cards.Views;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Cards.Spawners
{
    /// <summary>
    /// Card view spawner
    /// </summary>
    public class CardViewSpawner
    {
        private readonly CardView.Factory cardViewFactory;
        [Inject] private Transform CardParent { get; }

        public CardViewSpawner(CardView.Factory cardViewFactory)
        {
            this.cardViewFactory = cardViewFactory;
        }

        /// <summary>
        /// Create card view
        /// </summary>
        /// <param name="cardObj"></param>
        /// <returns></returns>
        public CardView CreateViewCard(IBaseCard cardObj)
        {
            var cardView = cardViewFactory.Create(cardObj);
            var transform = cardView.transform;
            transform.parent = CardParent;
            transform.localRotation = Quaternion.identity;
            return cardView;
        }
    }
}