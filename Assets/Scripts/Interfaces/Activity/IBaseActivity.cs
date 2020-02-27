using System.Collections.Generic;
using Enums;
using ScriptableObjects.Requires;
using ScriptableObjects.Results;
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
        List<BaseRequireObj> RequiredList { get; }
        List<BaseRequireObj> OptionalRequiresList { get; }
        List<BaseResultObj> ResultsList { get; } 
        List<BaseResultObj> OptionalResultsList { get; }
    }
}