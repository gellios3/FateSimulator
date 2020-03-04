using Enums.Aspects;

namespace Interfaces.Cards
{
    public interface ICharacteristicCard : IBaseCard
    {
        CharacteristicType CharacteristicType { get; }
    }
}