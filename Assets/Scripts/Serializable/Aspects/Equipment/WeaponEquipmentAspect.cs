using System;
using System.Collections.Generic;
using Enums.Aspects;
using Enums.Equipment;
using Interfaces.Aspects.Equipment;
using UnityEngine;

namespace Serializable.Aspects.Equipment
{
    [Serializable]
    public class WeaponEquipmentAspect : BaseAspect, IWeaponEquipmentAspect
    {
        public EquipmentType EquipmentType { get; }
        public byte Level { get; }
        public WeaponType WeaponType { get; }
        public List<CharacteristicPair> WeaponDamages { get; }

        public WeaponEquipmentAspect(IWeaponEquipmentAspect aspect) : base(aspect)
        {
            EquipmentType = aspect.EquipmentType;
            Level = aspect.Level;
            WeaponType = aspect.WeaponType;
            WeaponDamages = aspect.WeaponDamages;
        }
    }
}