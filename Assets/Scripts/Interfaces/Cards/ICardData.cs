using Enums;

namespace Interfaces.Cards
{
    public interface ICardData
    {
        IBaseCard BaseCard { get; }
        InventoryType InventoryType { get; }
        ushort InventoryIndex { get; }
        ushort OwnerId { get; }
    }
}