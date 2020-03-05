using Enums;
using Enums.Activities;

namespace Interfaces.Conditions.Cards
{
    public interface IActivityCardCondition : ICardCondition
    {
        ActivityType ActivityType { get; }
    }
}