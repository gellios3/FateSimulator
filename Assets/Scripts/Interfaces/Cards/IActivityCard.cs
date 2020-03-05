using Enums;
using Enums.Activities;

namespace Interfaces.Cards
{
    public interface IActivityCard : IBaseCard
    {
        ActivityType ActivityType { get; }
    }
}