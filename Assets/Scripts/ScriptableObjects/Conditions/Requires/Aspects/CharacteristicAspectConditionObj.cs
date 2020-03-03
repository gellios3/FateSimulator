using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Aspects
{
    [CreateAssetMenu(fileName = "CharacteristicAspectCondition",
        menuName = "Conditions/Requires/Aspect/CharacteristicAspectCondition", order = 0)]
    public class CharacteristicAspectConditionObj : AspectConditionObj, ICharacteristicAspectCondition
    {
        public CharacteristicType characteristicType;
        public CharacteristicType CharacteristicType => characteristicType;
    }
}