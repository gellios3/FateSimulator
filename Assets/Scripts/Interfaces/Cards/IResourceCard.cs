using Serializable;

namespace Interfaces.Cards
{
    public interface IResourceCard: IBaseCard
    {
        ResourceObj Resource { get; }
    }
}