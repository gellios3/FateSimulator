using Enums;

namespace Interfaces.Cards
{
    public interface ICardInventoryData
    {
        IInventoryPos InventoryPos { get; set; }
        InventoryType InventoryType { get; }
        ushort OwnerId { get; set; }
    }
}