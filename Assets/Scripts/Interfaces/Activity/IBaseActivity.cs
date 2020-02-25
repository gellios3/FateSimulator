using System.Collections.Generic;
using Enums;
using ScriptableObjects.Requires;
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
        List<BaseRequireObj> RequiredObjs { get; }
        List<BaseRequireObj> OptionalObjs { get; }
    }
}