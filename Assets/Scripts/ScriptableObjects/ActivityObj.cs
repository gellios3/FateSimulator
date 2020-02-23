using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Activity Obj", menuName = "Create Activity", order = 0)]
    public class ActivityObj : ScriptableObject
    {
        public ushort id;
        
        public string activityName;

        public string shortDescription;

        public ActivityType activityType;
        
        public Sprite activityIcon;
    }
}