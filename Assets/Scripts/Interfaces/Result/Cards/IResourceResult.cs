using Enums.Aspects;

namespace Interfaces.Result.Cards
{
    public interface IResourceResult : IBaseResult
    {
        ResourceType ResourceType { get; }
    }
}