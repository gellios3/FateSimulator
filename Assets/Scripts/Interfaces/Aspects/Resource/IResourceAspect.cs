using Enums.Aspects;

namespace Interfaces.Aspects.Resource
{
    /// <summary>
    /// Interface for Resource Aspect
    /// </summary>
    public interface IResourceAspect : IBaseAspect
    {
        /// <summary>
        /// Resource type
        /// </summary>
        ResourceType ResourceType { get; }
    }
}