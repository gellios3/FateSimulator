using System;
using System.Collections.Generic;
using Enums;
using Enums.Aspects;
using Enums.Aspects.Equipment;
using ScriptableObjects.Interfaces.Aspects.Equipment;
using UnityEngine;

namespace SerializableStructs.Aspects.Equipment
{
    [Serializable]
    public struct ArmorEquipmentAspect : IArmorEquipmentAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public EquipmentType EquipmentType { get; }
        public byte Level { get; }
        public ArmorEquipmentType ArmorEquipmentType { get; }
        public List<CharacteristicPair> DefenceBuffs { get; }

        public ArmorEquipmentAspect(IArmorEquipmentAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            EquipmentType = aspect.EquipmentType;
            Level = aspect.Level;
            ArmorEquipmentType = aspect.ArmorEquipmentType;
            DefenceBuffs = aspect.DefenceBuffs;
        }
    }
}