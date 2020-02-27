using System;
using System.Collections.Generic;
using Enums;
using Interfaces.Activity;
using ScriptableObjects.Requires;
using ScriptableObjects.Results;
using UnityEngine;

namespace SerializableStructs.Activities
{
    [Serializable]
    public struct BaseActivity : IBaseActivity
    {
        public ushort Id { get; }
        public string ActivityName { get; }
        public string ShortDescription { get; }
        public ActivityType ActivityType { get; }
        public Sprite ActivityIcon { get; }
        public List<BaseRequireObj> RequiredList { get; }
        public List<BaseRequireObj> OptionalRequiresList { get; }
        public List<BaseResultObj> ResultsList { get; }
        
        public List<BaseResultObj> OptionalResultsList { get; }

        public BaseActivity(IBaseActivity aspect)
        {
            Id = aspect.Id;
            ActivityName = aspect.ActivityName;
            ShortDescription = aspect.ShortDescription;
            ActivityType = aspect.ActivityType;
            ActivityIcon = aspect.ActivityIcon;
            RequiredList = aspect.RequiredList;
            OptionalRequiresList = aspect.OptionalRequiresList;
            ResultsList = aspect.ResultsList;
            OptionalResultsList = aspect.OptionalResultsList;
        }
    }
}