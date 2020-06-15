using Enums;

namespace Interfaces.Cards
{
    public interface ICardInventoryData
    {
        IInventoryPos InventoryPos { get; }
        InventoryType InventoryType { get; }
        ushort OwnerId { get; set; }
    }
}