using System;
using Enums.Person;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class PersonCard: BaseCard, IPersonCard
    {
        public PersonType PersonType { get; }
        public PersonStatus PersonStatus { get; }
        
        public PersonCard(IPersonCard cardObj) : base(cardObj)
        {
            PersonType = cardObj.PersonType;
            PersonStatus = cardObj.PersonStatus;
        }
    }
}