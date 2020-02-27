using System.Collections.Generic;
using Enums;
using Interfaces.Activity;
using ScriptableObjects.Requires;
using ScriptableObjects.Results;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// Base Activity Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Activity Obj", menuName = "Create Activity", order = 0)]
    public class BaseActivityObj : ScriptableObject, IBaseActivity
    {
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
        /// Required aspects or cards for start Activity
        /// </summary>
        public List<BaseRequireObj> requiredList;
        public List<BaseRequireObj> RequiredList => requiredList;
        

        /// <summary>
        /// Optional aspects or cards for start Activity
        /// </summary>
        public List<BaseRequireObj> optionalRequiresList; 
        public List<BaseRequireObj> OptionalRequiresList => optionalRequiresList;
        
        /// <summary>
        /// Results aspects or cards on end activity
        /// </summary>
        public List<BaseResultObj> resultsList;
        public List<BaseResultObj> ResultsList => resultsList;
        
        /// <summary>
        /// Optional results aspects or cards on end activity
        /// </summary>
        public List<BaseResultObj> optionalResultsList;
        public List<BaseResultObj> OptionalResultsList => optionalResultsList;
    }
}