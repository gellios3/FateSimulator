using Enums.Aspects;
using Interfaces.Result.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "MoneyResultObj", menuName = "Conditions/Results/MoneyResultObj", order = 0)]
    public class MoneyResultObj : AspectResultObj, IMoneyResult
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;

        public MoneyType moneyType;
        public MoneyType MoneyType => moneyType;

        public ushort value;
        public ushort Value => value;
    }
}