using Enums.Aspects;
using Interfaces.Result.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "MoneyResultObj", menuName = "Conditions/Results/MoneyResultObj", order = 0)]
    public class MoneyResultObj : AspectResultObj, IResourceResult
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;
    }
}