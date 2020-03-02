using Enums;

namespace Interfaces.Conditions.Cards
{
    public interface ICardCondition : IBaseCondition
    {
        CardType CardType { get; }
    }
}