using Enums.Aspects;
using Enums.Aspects.Equipment;

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
        /// Defence type
        /// </summary>
        CharacteristicType DefenceType { get; }
        
        /// <summary>
        /// Defence value
        /// </summary>
        byte DefenceValue { get; }
    }
}