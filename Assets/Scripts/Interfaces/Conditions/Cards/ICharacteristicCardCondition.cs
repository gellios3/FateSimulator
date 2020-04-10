using Enums.Aspects;

namespace Interfaces.Conditions.Cards
{
    public interface ICharacteristicCardCondition : ICardCondition
    {
        CharacteristicType CharacteristicType { get; }
    }
}