using Enums;

namespace Interfaces.Cards
{
    public interface ICardData
    {
        IBaseCard BaseCard { get; }
        InventoryType InventoryType { get; }
        byte RowIndex { get; }
        byte ColIndex { get; }
        ushort OwnerId { get; }
    }
}