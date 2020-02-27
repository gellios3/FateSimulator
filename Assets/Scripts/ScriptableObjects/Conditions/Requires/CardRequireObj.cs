using Enums;
using UnityEngine;

namespace ScriptableObjects.Requires
{
    [CreateAssetMenu(fileName = "BaseCardRequireObj", menuName = "Conditions/Requires/CardRequireObj", order = 0)]
    public class CardRequireObj : BaseRequireObj
    {
        public CardType cardType;
    }
}