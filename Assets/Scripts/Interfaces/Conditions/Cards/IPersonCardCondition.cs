using Enums.Aspects;

namespace Interfaces.Conditions.Cards
{
    public interface IPersonCardCondition : ICardCondition
    {
        PersonType PersonType { get; }
    }
}