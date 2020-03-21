using System.Collections.Generic;
using ScriptableObjects.Cards;

namespace Interfaces
{
    public interface ISaveGameObj
    {
        List<BaseCardObj> CardList { get; }
    }
}