using System;
using Interfaces.Cards;
using ScriptableObjects.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class CardData : ICardData
    {
        public BaseCardObj baseCard;
        public IBaseCard BaseCard => baseCard;

        public CardInventoryData inventoryData;
        public ICardInventoryData InventoryData
        {
            get => inventoryData;
            set => inventoryData = value as CardInventoryData;
        }
    }
}