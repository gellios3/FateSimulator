using System.Collections.Generic;
using Enums.Aspects.Equipment;
using SerializableStructs.Aspects.Equipment;

namespace ScriptableObjects.Interfaces.Aspects.Equipment
{
    /// <summary>
    /// Interface for Armor Equipment Aspect
    /// </summary>
    public interface IArmorEquipmentAspect : IBaseEquipmentAspect
    {
        /// <summary>
        /// Armor equipment type
        /// </summary>
        ArmorEquipmentType ArmorEquipmentType { get; }
        
        /// <summary>
        /// Defence Buffs List
        /// </summary>
        List<CharacteristicPair> DefenceBuffs { get; }
    }
}