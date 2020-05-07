using Enums.Activities;

namespace Interfaces.Conditions.Cards
{
    public interface IWorkCardCondition : IActivityCardCondition
    {
        WorkType WorkType { get; }
    }
}