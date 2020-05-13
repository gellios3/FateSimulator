using Enums.Aspects;

namespace Interfaces.Cards
{
    public interface IMoneyCard : IResourceCard
    {
        MoneyType MoneyType { get; }
    }
}