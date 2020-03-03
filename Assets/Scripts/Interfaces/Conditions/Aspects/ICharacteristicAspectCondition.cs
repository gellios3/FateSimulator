using Enums.Aspects;

namespace Interfaces.Conditions.Aspects
{
    public interface ICharacteristicAspectCondition : IAspectCondition
    {
        CharacteristicType CharacteristicType { get; }
    }
}