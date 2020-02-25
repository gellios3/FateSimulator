using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    /// <summary>
    /// Characteristic aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Characteristic", menuName = "Aspects/Create Characteristic Aspect", order = 0)]
    public class CharacteristicAspectObj : BaseAspectObj, ICharacteristicAspect
    {
        
        /// <summary>
        /// Characteristic type
        /// </summary>
        public CharacteristicType characteristicType;
        public CharacteristicType CharacteristicType => characteristicType;
    }
}