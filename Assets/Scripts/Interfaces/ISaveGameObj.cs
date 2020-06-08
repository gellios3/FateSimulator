using System.Collections.Generic;
using Interfaces.Cards;
using ScriptableObjects;
using ScriptableObjects.Cards;
using Serializable;

namespace Interfaces
{
    public interface ISaveGameObj
    {
        AllItemsDataBase DataBase { get; }
        
        List<ICardData> CardDataList { get; }
        
        List<IPartyMember> PartyMembers { get; }
    }
}