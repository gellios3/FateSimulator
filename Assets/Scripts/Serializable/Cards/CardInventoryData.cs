using System;
using Enums;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class CardInventoryData : ICardInventoryData
    {
        public InventoryPos inventoryPos;
        public IInventoryPos InventoryPos => inventoryPos;

        public InventoryType inventoryType;
        public InventoryType InventoryType => inventoryType;

        public ushort ownerId;
        public ushort OwnerId
        {
            get => ownerId;
            set => ownerId = value;
        }
    }
}