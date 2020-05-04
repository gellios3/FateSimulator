using System.Collections.Generic;
using Enums.Activities;
using ScriptableObjects.Cards;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace Interfaces.Activity
{
    public interface IBaseActivity : IBaseObj
    {
        string ActivityName { get; }
        ushort ActivityDuration { get; }
        string ShortDescription { get; }
        ActivityType ActivityType { get; }
        Sprite ActivityIcon { get; }
        byte OptionalResultChance { get; }
        BaseCardObj StartActivityCard { get; }
        List<BaseConditionObj> RequiredList { get; }
        List<BaseConditionObj> OptionalRequiresList { get; }
        List<BaseResultObj> ResultsList { get; } 
        List<BaseResultObj> OptionalResultsList { get; }
        List<BaseConditionObj> GetCardConditions();
    }
}