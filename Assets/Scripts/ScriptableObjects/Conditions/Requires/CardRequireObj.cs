using Enums;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "BaseCardRequireObj", menuName = "Conditions/Requires/CardRequireObj", order = 0)]
    public class CardRequireObj : BaseRequireObj, ICardRequire
    {
        public CardType cardType;
        public CardType CardType => cardType;
    }
}