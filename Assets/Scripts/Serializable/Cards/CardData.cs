using System;
using Enums;
using Interfaces.Cards;
using ScriptableObjects.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class CardData : ICardData
    {
        public BaseCardObj baseCard;
        public IBaseCard BaseCard => baseCard;

        public InventoryType inventoryType;
        public InventoryType InventoryType => inventoryType;

        public ushort inventoryIndex;
        public ushort InventoryIndex => inventoryIndex;
        
        public ushort ownerId;
        public ushort OwnerId => ownerId;
    }
}