using Enums.Activities;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Cards
{
    [CreateAssetMenu(fileName = "ActivityCardCondition", menuName = "Conditions/Requires/Card/ActivityCardCondition",
        order = 0)]
    public class ActivityCardConditionObj : CardConditionObj, IActivityCardCondition
    {
        public ActivityType activityType;
        public ActivityType ActivityType => activityType;
    }
}