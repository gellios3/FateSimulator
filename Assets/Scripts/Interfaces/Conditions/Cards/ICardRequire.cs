using Enums;

namespace Interfaces.Conditions.Cards
{
    public interface ICardRequire : IBaseRequire
    {
        CardType CardType { get; }
    }
}