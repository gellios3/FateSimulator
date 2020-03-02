﻿using System.Collections.Generic;
using Enums;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace Interfaces.Activity
{
    public interface IBaseActivity
    {
        ushort Id { get; }
        string ActivityName { get; }
        string ShortDescription { get; }
        ActivityType ActivityType { get; }
        Sprite ActivityIcon { get; }
        List<BaseConditionObj> RequiredList { get; }
        List<BaseConditionObj> OptionalRequiresList { get; }
        List<BaseResultObj> ResultsList { get; } 
        List<BaseResultObj> OptionalResultsList { get; }
    }
}