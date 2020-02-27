using Enums.Aspects;

namespace Interfaces.Conditions.Aspects
{
    public interface IPersonAspectRequire : IAspectRequire
    {
        PersonType PersonType { get; }
    }
}