using Enums.Aspects;
using Enums.Person;

namespace Interfaces.Conditions.Aspects
{
    public interface IPersonAspectCondition : IAspectCondition
    {
        PersonType PersonType { get; }
    }
}