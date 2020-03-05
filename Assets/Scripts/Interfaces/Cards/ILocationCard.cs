using Enums;
using Enums.Activities;

namespace Interfaces.Cards
{
    public interface ILocationCard : IActivityCard
    {
        LocationType LocationType { get; }
    }
}