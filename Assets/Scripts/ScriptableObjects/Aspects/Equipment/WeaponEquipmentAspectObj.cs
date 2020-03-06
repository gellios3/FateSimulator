using System.Collections.Generic;
using Enums.Aspects;
using Enums.Equipment;
using Interfaces.Aspects.Equipment;
using Serializable.Aspects.Equipment;
using UnityEngine;

namespace ScriptableObjects.Aspects.Equipment
{
    /// <summary>
    /// Weapon equipment Aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Weapon Equipment", menuName = "Aspects/Equipment/Create Weapon Equipment Aspect", order = 0)]
    public class WeaponEquipmentAspectObj : BaseEquipmentAspectObj, IWeaponEquipmentAspect
    {
        public WeaponType weaponType;
        public WeaponType WeaponType => weaponType;

        public List<CharacteristicPair> weaponDamages;
        public List<CharacteristicPair> WeaponDamages => weaponDamages;
    }
}