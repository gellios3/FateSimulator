using Enums.Aspects;

namespace Interfaces.Conditions.Cards
{
    public interface ICharacteristicCardCondition : IActivityCardCondition
    {
        CharacteristicType CharacteristicType { get; }
    }
}