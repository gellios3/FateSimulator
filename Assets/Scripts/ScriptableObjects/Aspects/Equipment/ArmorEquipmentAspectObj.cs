using Enums.Aspects;
using Enums.Aspects.Equipment;
using ScriptableObjects.Interfaces.Aspects.Equipment;
using UnityEngine;

namespace ScriptableObjects.Aspects.Equipment
{
    [CreateAssetMenu(fileName = "New Armor Equipment", menuName = "Aspects/Equipment/Create Armor Equipment Aspect",
        order = 0)]
    public class ArmorEquipmentAspectObj : BaseEquipmentAspectObj, IArmorEquipmentAspect
    {
        public ArmorEquipmentType armorEquipmentType;
        public ArmorEquipmentType ArmorEquipmentType => armorEquipmentType;

        public CharacteristicType defenceType;
        public CharacteristicType DefenceType => defenceType;

        public byte defenceValue;
        public byte DefenceValue => defenceValue;
    }
}