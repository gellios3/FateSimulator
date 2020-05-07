using Enums;
using Enums.Activities;
using Serializable;

namespace Interfaces.Conditions.Cards
{
    public interface IActivityCardCondition : ICardCondition
    {
        ActivityType ActivityType { get; }
        
        CardStatus OnEndActivityStatus { get; }
    }
}