using System.Collections.Generic;
using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using SerializableStructs.Conditions;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "MoneyResultObj", menuName = "Conditions/Results/MoneyResultObj", order = 0)]
    public class MoneyResultObj : AspectResultObj, IMoneyCondition
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;
        
        public List<MoneyConditionValue> conditionValues;
        public List<MoneyConditionValue> ConditionValues => conditionValues;
    }
}