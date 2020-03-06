using System;
using System.Collections.Generic;
using Enums.Aspects;
using Enums.Equipment;
using Interfaces.Aspects.Equipment;
using UnityEngine;

namespace Serializable.Aspects.Equipment
{
    [Serializable]
    public class ArmorEquipmentAspect : BaseAspect, IArmorEquipmentAspect
    {
        public EquipmentType EquipmentType { get; }
        public byte Level { get; }
        public ArmorEquipmentType ArmorEquipmentType { get; }
        public List<CharacteristicPair> DefenceBuffs { get; }

        public ArmorEquipmentAspect(IArmorEquipmentAspect aspect) : base(aspect)
        {
            EquipmentType = aspect.EquipmentType;
            Level = aspect.Level;
            ArmorEquipmentType = aspect.ArmorEquipmentType;
            DefenceBuffs = aspect.DefenceBuffs;
        }
    }
}