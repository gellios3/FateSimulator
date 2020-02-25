using System.Collections.Generic;
using Enums;
using Interfaces.Activity;
using ScriptableObjects.Requires;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// Base Activity Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Activity Obj", menuName = "Create Activity", order = 0)]
    public class BaseActivityObj : ScriptableObject, IBaseActivity
    {
        // @Todo Add Return card types
        
        /// <summary>
        /// Id
        /// </summary>
        public ushort id;
        public ushort Id => id;
        
        /// <summary>
        /// Activity name
        /// </summary>
        public string activityName;
        public string ActivityName => activityName;
        
        /// <summary>
        /// Short description
        /// </summary>
        public string shortDescription;
        public string ShortDescription => shortDescription;
        
        /// <summary>
        /// Activity type
        /// </summary>
        public ActivityType activityType;
        public ActivityType ActivityType => activityType;
        
        /// <summary>
        /// Activity icon
        /// </summary>
        public Sprite activityIcon;
        public Sprite ActivityIcon => activityIcon;
        
        /// <summary>
        /// Required aspects for start Activity
        /// </summary>
        public List<BaseRequireObj> requiredObjs;
        public List<BaseRequireObj> RequiredObjs => requiredObjs;  
        
        /// <summary>
        /// Optional aspects for start Activity
        /// </summary>
        public List<BaseRequireObj> optionalObjs;
        public List<BaseRequireObj> OptionalObjs => optionalObjs;
        
    }
}