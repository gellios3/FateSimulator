﻿using System.Collections.Generic;
using Enums.Aspects.Equipment;
using ScriptableObjects.Interfaces.Aspects.Equipment;
using SerializableStructs.Aspects.Equipment;
using UnityEngine;

namespace ScriptableObjects.Aspects.Equipment
{
    [CreateAssetMenu(fileName = "New Armor Equipment", menuName = "Aspects/Equipment/Create Armor Equipment Aspect",
        order = 0)]
    public class ArmorEquipmentAspectObj : BaseEquipmentAspectObj, IArmorEquipmentAspect
    {
        public ArmorEquipmentType armorEquipmentType;
        public ArmorEquipmentType ArmorEquipmentType => armorEquipmentType;
        
        
        public List<CharacteristicPair> defenceBuffs;
        public List<CharacteristicPair> DefenceBuffs => defenceBuffs;
    }
}