using Enums.Aspects;
using Interfaces.Aspects.Resource;
using UnityEngine;

namespace ScriptableObjects.Aspects.Resource
{
    [CreateAssetMenu(fileName = "Money Aspect", menuName = "Aspects/Create Money Aspect", order = 0)]
    public class MoneyAspectObj : ResourceAspectObj, IMoneyAspect
    {
        /// <summary>
        /// Money type
        /// </summary>
        public MoneyType moneyType;
        public MoneyType MoneyType => moneyType;
    }
}