using System.Collections.Generic;
using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using SerializableStructs.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Aspects
{
    [CreateAssetMenu(fileName = "MoneyAspectRequireObj", menuName = "Conditions/Requires/Aspect/MoneyAspectRequireObj", order = 0)]
    public class MoneyAspectConditionObj : AspectConditionObj, IMoneyCondition
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;

        public List<MoneyConditionValue> conditionValues;
        public List<MoneyConditionValue> ConditionValues => conditionValues;
    }
}