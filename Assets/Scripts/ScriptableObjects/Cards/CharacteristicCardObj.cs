using Enums.Aspects;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "CharacteristicCardObj", menuName = "Cards/CharacteristicCardObj", order = 0)]
    public class CharacteristicCardObj : BaseCardObj, ICharacteristicCard
    {
        public CharacteristicType characteristicType;
        public CharacteristicType CharacteristicType => characteristicType;
    }
}