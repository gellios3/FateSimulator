using System.Collections.Generic;
using Canvas.Cards.Interfaces;
using Canvas.Cards.Signals;
using Canvas.Cards.Views;
using Canvas.Inventory.Signals;
using Enums;
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
        [Inject] private SignalBus SignalBus { get; }

        private readonly DraggableCardView.Factory draggableCardFactory;

        #endregion

        public void Initialize()
        {
            SignalBus.Subscribe<InstallDraggableCardsSignal>(InstallDraggableCards);
        }

        public CardDraggableSpawner(DraggableCardView.Factory draggableCardFactory)
        {
            this.draggableCardFactory = draggableCardFactory;
        }

        private void InstallDraggableCards()
        {
            foreach (var cardObj in CardList)
            {
                var topCard = CardViewSpawner.CreateViewCard(cardObj);
                var cardGameObject = draggableCardFactory.Create(cardObj, topCard);
                var transform = cardGameObject.transform;
                transform.parent = CardParent;
                transform.localRotation = Quaternion.identity;
                SetToInventory(cardGameObject);
            }
        }

        /// <summary>
        /// Create result cards
        /// </summary>
        /// <param name="baseCard"></param>
        public DraggableCardView CreateResultCard(ICardData baseCard)
        {
            var topCard = CardViewSpawner.CreateViewCard(baseCard);
            var cardGameObject = draggableCardFactory.Create(baseCard, topCard);
            var transform = cardGameObject.transform;
            transform.parent = CardParent;
            transform.localRotation = Quaternion.identity;
            return cardGameObject;
        }

        public void SetToInventory(IDraggableCardView cardGameObject)
        {
            if (cardGameObject.CardData.InventoryData.InventoryType == InventoryType.Personal)
            {
                SignalBus.Fire(new SetCardToPersonalInventorySignal
                {
                    SourceView = cardGameObject, OwnerId = cardGameObject.CardData.InventoryData.OwnerId
                });
            }
            else
            {
                SignalBus.Fire(new SetCardToCommonInventorySignal {SourceView = cardGameObject});
            }
        }
    }
}