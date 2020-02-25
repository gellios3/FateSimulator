using System;
using System.Collections.Generic;
using Enums;
using Enums.Aspects;
using Enums.Aspects.Equipment;
using Interfaces.Aspects.Equipment;
using UnityEngine;

namespace SerializableStructs.Aspects.Equipment
{
    [Serializable]
    public struct WeaponEquipmentAspect : IWeaponEquipmentAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public EquipmentType EquipmentType { get; }
        public byte Level { get; }
        public WeaponType WeaponType { get; }
        public List<CharacteristicPair> WeaponDamages { get; }

        public WeaponEquipmentAspect(IWeaponEquipmentAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            EquipmentType = aspect.EquipmentType;
            Level = aspect.Level;
            WeaponType = aspect.WeaponType;
            WeaponDamages = aspect.WeaponDamages;
        }
    }
}