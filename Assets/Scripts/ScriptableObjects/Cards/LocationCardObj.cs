using Enums;
using Enums.Activities;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "LocationCardObj", menuName = "Cards/Location Card", order = 0)]
    public class LocationCardObj : ActivityCardObj, ILocationCard
    {
        public LocationType locationType;
        public LocationType LocationType => locationType;
    }
}