using Interfaces.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "BaseRequireObj", menuName = "", order = 0)]
    public class BaseConditionObj : ScriptableObject, IBaseCondition
    {
        public byte level;
        public byte Level => level;

        public string title;
        public string Title => title;
    }
}