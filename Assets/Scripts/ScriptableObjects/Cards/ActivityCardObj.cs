using Enums;
using Enums.Activities;
using Interfaces.Cards;

namespace ScriptableObjects.Cards
{
    [UnityEngine.CreateAssetMenu(fileName = "ActivityCardObj", menuName = "Cards/ActivityCardObj", order = 0)]
    public class ActivityCardObj : BaseCardObj, IActivityCard
    {
        public ActivityType activityType;
        public ActivityType ActivityType => activityType;
    }
}