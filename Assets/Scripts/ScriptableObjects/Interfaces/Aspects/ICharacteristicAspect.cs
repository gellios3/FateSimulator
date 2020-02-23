using Enums.Aspects;

namespace ScriptableObjects.Interfaces.Aspects
{
    public interface ICharacteristicAspect : IBaseAspect
    {
        CharacteristicType CharacteristicType { get; }
    }
}