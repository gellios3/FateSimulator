using Enums;
using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "New Characteristic", menuName = "Aspects/Create Characteristic Aspect", order = 0)]
    public class CharacteristicAspect : BaseBaseAspect, ICharacteristicAspect
    {
        public CharacteristicType characteristicTypeType;
        public CharacteristicType CharacteristicType => characteristicTypeType;
    }
}