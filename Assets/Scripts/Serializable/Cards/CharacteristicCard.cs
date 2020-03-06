using System;
using Enums.Aspects;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class CharacteristicCard : BaseCard, ICharacteristicCard
    {
        public CharacteristicType CharacteristicType { get; }

        public CharacteristicCard(ICharacteristicCard cardObj) : base(cardObj)
        {
            CharacteristicType = cardObj.CharacteristicType;
        }
    }
}