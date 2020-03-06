using System.Collections.Generic;
using Enums.Equipment;
using Serializable.Aspects.Equipment;

namespace Interfaces.Aspects.Equipment
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
        /// Defence Buffs List
        /// </summary>
        List<CharacteristicPair> WeaponDamages { get; }
    }
}