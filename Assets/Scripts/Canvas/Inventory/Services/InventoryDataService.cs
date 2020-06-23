using System;
using Enums;
using Interfaces.Cards;
using Serializable.Cards;

namespace Canvas.Inventory.Services
{
    public class InventoryDataService
    {
        public CardInventoryData GetInventoryDataForCard(ICardData card, ushort ownerId)
        {
            var inventoryType = GetInventoryTypeByCardType(card.BaseCard.Type);
            return new CardInventoryData
            {
                inventoryType = inventoryType,
                OwnerId = (ushort) (inventoryType == InventoryType.Personal ? ownerId : 0)
            };
        }

        public InventoryType GetInventoryTypeByCardType(CardType type)
        {
            switch (type)
            {
                case CardType.Resource:
                case CardType.Person:
                case CardType.Lesson:
                case CardType.Characteristic:
                case CardType.Subject:
                    return InventoryType.Common;
                case CardType.Equipment:
                case CardType.Activity:
                case CardType.Skill:
                    return InventoryType.Personal;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}