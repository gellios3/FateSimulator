using Enums.Aspects;

namespace Interfaces.Result.Cards
{
    public interface IMoneyResult : IResourceResult
    {
        MoneyType MoneyType { get; }
        ushort Value { get; } 
    }
}