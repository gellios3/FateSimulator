using Enums.Aspects;

namespace ScriptableObjects.Interfaces.Aspects
{
    /// <summary>
    /// Interface for Characteristic Aspect
    /// </summary>
    public interface ICharacteristicAspect : IBaseAspect
    {
        /// <summary>
        /// Characteristic Type
        /// </summary>
        CharacteristicType CharacteristicType { get; }
    }
}