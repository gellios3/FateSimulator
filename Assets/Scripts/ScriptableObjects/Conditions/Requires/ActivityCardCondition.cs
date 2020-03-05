using Enums;
using Enums.Activities;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "ActivityCardCondition", menuName = "Conditions/Requires/Card/ActivityCardCondition",
        order = 0)]
    public class ActivityCardCondition : CardConditionObj, IActivityCardCondition
    {
        public ActivityType activityType;
        public ActivityType ActivityType => activityType;
    }
}