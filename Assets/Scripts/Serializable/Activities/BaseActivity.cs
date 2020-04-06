﻿using System;
using System.Collections.Generic;
using Enums.Activities;
using Interfaces.Activity;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace Serializable.Activities
{
    [Serializable]
    public class BaseActivity : IBaseActivity
    {
        public ushort Id { get; }
        public string ActivityName { get; }
        public string ShortDescription { get; }
        public ActivityType ActivityType { get; }
        public Sprite ActivityIcon { get; }
        public BaseConditionObj StartActivityCondition { get; }
        public List<BaseConditionObj> RequiredList { get; }
        public List<BaseConditionObj> OptionalRequiresList { get; }
        public List<BaseResultObj> ResultsList { get; }
        public List<BaseResultObj> OptionalResultsList { get; }

        public BaseActivity(IBaseActivity baseActivity)
        {
            Id = baseActivity.Id;
            ActivityName = baseActivity.ActivityName;
            ShortDescription = baseActivity.ShortDescription;
            ActivityType = baseActivity.ActivityType;
            ActivityIcon = baseActivity.ActivityIcon;
            StartActivityCondition = baseActivity.StartActivityCondition;
            RequiredList = baseActivity.RequiredList;
            OptionalRequiresList = baseActivity.OptionalRequiresList;
            ResultsList = baseActivity.ResultsList;
            OptionalResultsList = baseActivity.OptionalResultsList;
        }
    }
}