using Enums.Aspects;
using Enums.Aspects.Equipment;

namespace ScriptableObjects.Interfaces.Aspects.Equipment
{
    /// <summary>
    /// Weapon Equipment Aspect
    /// </summary>
    public interface IWeaponEquipmentAspect : IBaseEquipmentAspect
    {
        /// <summary>
        /// Weapon type
        /// </summary>
        WeaponType WeaponType { get; }

        /// <summary>
        /// Characteristic Type Damage 
        /// </summary>
        CharacteristicType DamageType { get; }

        /// <summary>
        /// Damage value
        /// </summary>
        byte DamageValue { get; }
    }
}