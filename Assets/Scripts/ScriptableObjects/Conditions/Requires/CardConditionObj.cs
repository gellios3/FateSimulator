using Enums;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "BaseCardRequireObj", menuName = "Conditions/Requires/Card/CardRequireObj", order = 0)]
    public class CardConditionObj : BaseConditionObj, ICardCondition
    {
        public CardType cardType;
        public CardType CardType => cardType;
        
        
    }
}