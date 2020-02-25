using Enums;
using UnityEngine;

namespace ScriptableObjects.Requires
{
    [CreateAssetMenu(fileName = "BaseCardRequireObj", menuName = "Requires/CardRequireObj", order = 0)]
    public class CardRequireObj : BaseRequireObj
    {
        public CardType cardType;
    }
}