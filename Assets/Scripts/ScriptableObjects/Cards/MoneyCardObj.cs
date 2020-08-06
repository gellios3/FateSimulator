using Enums.Aspects;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "", menuName = "Cards/Money Card", order = 0)]
    public class MoneyCardObj : ResourceCardObj, IMoneyCard
    {
        public MoneyType moneyType;
        public MoneyType MoneyType => moneyType;
    }
}