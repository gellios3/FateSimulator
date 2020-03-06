using System;
using Enums.Activities;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class LocationCard : ActivityCard, ILocationCard
    {
        public LocationType LocationType { get; }
        
        public LocationCard(ILocationCard cardObj) : base(cardObj)
        {
            LocationType = cardObj.LocationType;
        }
    }
}