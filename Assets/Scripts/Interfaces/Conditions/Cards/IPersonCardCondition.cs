using Enums.Aspects;
using Enums.Person;

namespace Interfaces.Conditions.Cards
{
    public interface IPersonCardCondition : ICardCondition
    {
        PersonType PersonType { get; }
    }
}