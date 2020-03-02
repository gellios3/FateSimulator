using Enums;

namespace ScriptableObjects.Cards
{
    [UnityEngine.CreateAssetMenu(fileName = "ActivityCardObj", menuName = "Cards/ActivityCardObj", order = 0)]
    public class ActivityCardObj : BaseCardObj
    {
        public ActivityType activityType;
    }
}