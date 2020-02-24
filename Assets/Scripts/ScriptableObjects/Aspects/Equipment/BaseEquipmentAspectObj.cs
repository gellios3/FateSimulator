using Enums.Aspects;
using Enums.Aspects.Equipment;
using ScriptableObjects.Interfaces.Aspects.Equipment;
using UnityEngine;

namespace ScriptableObjects.Aspects.Equipment
{
    /// <summary>
    /// Base Equipment Aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Equipment", menuName = "Aspects/Equipment/Create Equipment Aspect", order = 0)]
    public class BaseEquipmentAspectObj : BaseAspectObj, IBaseEquipmentAspect
    {
        /// <summary>
        /// Equipment Type
        /// </summary>
        public EquipmentType equipmentType;
        public EquipmentType EquipmentType => equipmentType;

        /// <summary>
        /// Equipment Level
        /// </summary>
        public byte level;
        public byte Level => level;

        public byte useCount;


    }
}