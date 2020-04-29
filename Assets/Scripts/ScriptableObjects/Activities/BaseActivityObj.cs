﻿using System.Collections.Generic;
using Enums;
using Enums.Activities;
using Interfaces.Activity;
using ScriptableObjects.Cards;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace ScriptableObjects.Activities
{
    /// <summary>
    /// Base Activity Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Activity Obj", menuName = "Create Activity", order = 0)]
    public class BaseActivityObj : BaseObj, IBaseActivity
    {
        /// <summary>
        /// Id
        /// </summary>
        public ushort Id => id;

        /// <summary>
        /// Activity name
        /// </summary>
        public string activityName;

        public string ActivityName => activityName;

        /// <summary>
        /// Activity duration
        /// </summary>
        public ushort activityDuration;

        public ushort ActivityDuration => activityDuration;

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
        /// Optional result chance
        /// </summary>
        public byte optionalResultChance;

        public byte OptionalResultChance => optionalResultChance;

        /// <summary>
        /// Start base condition 
        /// </summary>
        public BaseCardObj startActivityCard;

        public BaseCardObj StartActivityCard => startActivityCard;

        /// <summary>
        /// Required aspects or cards for start Activity
        /// </summary>
        public List<BaseConditionObj> requiredList;

        public List<BaseConditionObj> RequiredList => requiredList;


        /// <summary>
        /// Optional aspects or cards for start Activity
        /// </summary>
        public List<BaseConditionObj> optionalRequiresList;

        public List<BaseConditionObj> OptionalRequiresList => optionalRequiresList;

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

        public List<BaseConditionObj> GetCardConditions()
        {
            return RequiredList.FindAll(obj => obj is CardConditionObj);
        }

        /// <summary>
        /// Add card to database
        /// </summary>
        protected override void AddCardToDatabase()
        {
            while (true)
            {
                id = (ushort) (Random.value * 100000f);
                if (dataBase.IsUniqueId(id, GlobalType.Activity))
                {
                    dataBase.allActivities.Add(this);
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}