﻿using Enums.Aspects;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Cards
{
    [CreateAssetMenu(fileName = "CharacteristicCardCondition", menuName = "Conditions/Requires/Card/CharacteristicCardCondition", order = 0)]
    public class CharacteristicCardConditionObj : CardConditionObj, ICharacteristicCardCondition
    {
        public CharacteristicType characteristicType;
        public CharacteristicType CharacteristicType => characteristicType;
    }
}