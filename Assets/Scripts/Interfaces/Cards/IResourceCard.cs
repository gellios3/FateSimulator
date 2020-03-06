using System.Collections.Generic;
using Serializable;

namespace Interfaces.Cards
{
    public interface IResourceCard: IBaseCard
    {
        List<ResourceObj> ResourcesList { get; }
    }
}