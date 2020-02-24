using System;
using Enums;
using Enums.Aspects;
using Enums.Aspects.Equipment;
using ScriptableObjects.Interfaces.Aspects.Equipment;
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
        public CharacteristicType DamageType { get; }
        public byte DamageValue { get; }

        public WeaponEquipmentAspect(IWeaponEquipmentAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            EquipmentType = aspect.EquipmentType;
            Level = aspect.Level;
            WeaponType = aspect.WeaponType;
            DamageType = aspect.DamageType;
            DamageValue = aspect.DamageValue;
        }
    }
}