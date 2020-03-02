using Enums.Aspects;

namespace Interfaces.Conditions.Aspects
{
    public interface IPersonAspectCondition : IAspectCondition
    {
        PersonType PersonType { get; }
    }
}