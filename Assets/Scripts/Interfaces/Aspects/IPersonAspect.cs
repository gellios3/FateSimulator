using Enums.Aspects;
using Enums.Person;

namespace Interfaces.Aspects
{
    /// <summary>
    /// Interface for Person Aspect
    /// </summary>
    public interface IPersonAspect : IBaseAspect
    {
        /// <summary>
        /// Person type
        /// </summary>
        PersonType PersonType { get; }
    }
}