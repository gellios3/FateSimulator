using Enums;

namespace Interfaces.Conditions.Cards
{
    public interface IActivityCardCondition : ICardCondition
    {
        ActivityType ActivityType { get; }
    }
}