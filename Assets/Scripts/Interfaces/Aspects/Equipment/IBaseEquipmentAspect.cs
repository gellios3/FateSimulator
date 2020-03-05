using Enums.Equipment;

namespace Interfaces.Aspects.Equipment
{
    /// <summary>
    /// Interface for Base Equipment Aspect
    /// </summary>
    public interface IBaseEquipmentAspect : IBaseAspect
    {
        /// <summary>
        /// Equipment Type
        /// </summary>
        EquipmentType EquipmentType { get; }

        /// <summary>
        /// Equipment Level
        /// </summary>
        byte Level { get; }
    }
}