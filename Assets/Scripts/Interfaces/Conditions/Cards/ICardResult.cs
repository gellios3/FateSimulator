using Enums;

namespace Interfaces.Conditions.Cards
{
    public interface ICardResult : IBaseResult
    {
        CardType CardType { get; }
    }
}