using Enums.Aspects;

namespace Interfaces.Cards
{
    public interface IResourceCard : IBaseCard
    {
        ResourceType ResourceType { get; }
        ushort ResourceValue { get; }
    }
}