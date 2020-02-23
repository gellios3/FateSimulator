using Enums.Aspects;

namespace ScriptableObjects.Interfaces.Aspects
{
    public interface IResourceAspect : IBaseAspect
    {
        ResourceType ResourceType { get; }
        ushort ResourceValue { get; }
    }
}