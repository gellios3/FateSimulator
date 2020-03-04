using System.Collections.Generic;
using SerializableStructs;

namespace Interfaces.Cards
{
    public interface IResourceCard
    {
        List<ResourceObj> ResourcesList { get; }
    }
}