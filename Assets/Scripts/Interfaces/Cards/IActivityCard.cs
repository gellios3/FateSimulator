using Enums;

namespace Interfaces.Cards
{
    public interface IActivityCard : IBaseCard
    {
        ActivityType ActivityType { get; }
    }
}