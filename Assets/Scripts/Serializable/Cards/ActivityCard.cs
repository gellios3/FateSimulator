using System;
using Enums.Activities;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class ActivityCard : BaseCard, IActivityCard
    {
        public ActivityType ActivityType { get; }
        
        public ActivityCard(IActivityCard cardObj) : base(cardObj)
        {
            ActivityType = cardObj.ActivityType;
        }
    }
}