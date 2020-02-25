using System;
using System.Collections.Generic;
using Enums;
using Interfaces.Activity;
using ScriptableObjects.Requires;
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
        public List<BaseRequireObj> RequiredObjs { get; }
        public List<BaseRequireObj> OptionalObjs { get; }

        public BaseActivity(IBaseActivity aspect)
        {
            Id = aspect.Id;
            ActivityName = aspect.ActivityName;
            ShortDescription = aspect.ShortDescription;
            ActivityType = aspect.ActivityType;
            ActivityIcon = aspect.ActivityIcon;
            RequiredObjs = aspect.RequiredObjs;
            OptionalObjs = aspect.OptionalObjs;
        }
    }
}