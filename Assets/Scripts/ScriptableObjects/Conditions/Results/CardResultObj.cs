using Enums;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "CardResultObj", menuName = "Conditions/Results/CardResultObj", order = 0)]
    public class CardResultObj : BaseResultObj, ICardResult
    {
        public CardType cardType;
        public CardType CardType => cardType;
    }
}