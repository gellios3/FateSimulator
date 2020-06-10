namespace Interfaces.Cards
{
    public interface ICardData
    {
        IBaseCard BaseCard { get; }
        ICardInventoryData InventoryData { get; }
    }
}