using Enums.Aspects;

namespace ScriptableObjects.Interfaces.Aspects
{
    /// <summary>
    /// Interface for Person Aspect
    /// </summary>
    public interface IPersonAspect
    {
        /// <summary>
        /// Person type
        /// </summary>
        PersonType PersonType { get; }
    }
}