using Enums;
using UnityEngine;

namespace ScriptableObjects.Results
{
    [CreateAssetMenu(fileName = "CardResultObj", menuName = "Conditions/Results/CardResultObj", order = 0)]
    public class CardResultObj : BaseResultObj
    {
        public CardType cardType;
    }
}