using System;
using System.Collections.Generic;
using System.Linq;
using Enums.Activities;
using Interfaces.Activity;
using Interfaces.Conditions.Cards;
using ScriptableObjects.Cards;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace Serializable.Activities
{
    /// <summary>
    /// Base activity
    /// </summary>
    [Serializable]
    public class BaseActivity : IBaseActivity
    {
        public ushort Id { get; }
        public string ActivityName { get; }
        public ushort ActivityDuration { get; }
        public string ShortDescription { get; }
        public ActivityType ActivityType { get; }
        public Sprite ActivityIcon { get; }
        public BaseCardObj StartActivityCard { get; }
        public List<BaseConditionObj> RequiredList { get; }
        public List<BaseConditionObj> OptionalRequiresList { get; }
        public List<BaseResultObj> ResultsList { get; }
        public List<BaseResultObj> OptionalResultsList { get; }
        
        public List<BaseConditionObj> GetCardConditions()
        {
            return RequiredList.FindAll(obj => obj is CardConditionObj);
        }

        public BaseActivity(IBaseActivity baseActivity)
        {
            Id = baseActivity.Id;
            ActivityName = baseActivity.ActivityName;
            ShortDescription = baseActivity.ShortDescription;
            ActivityDuration = baseActivity.ActivityDuration;
            ActivityType = baseActivity.ActivityType;
            ActivityIcon = baseActivity.ActivityIcon;
            StartActivityCard = baseActivity.StartActivityCard;
            RequiredList = baseActivity.RequiredList;
            OptionalRequiresList = baseActivity.OptionalRequiresList;
            ResultsList = baseActivity.ResultsList;
            OptionalResultsList = baseActivity.OptionalResultsList;
        }
    }
}