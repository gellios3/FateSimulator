using Interfaces.Cards;
using Interfaces.Conditions.Cards;

namespace Canvas.Services
{
    public class ConditionsService
    {
        public bool CheckCondition(ICardCondition conditionObj, IBaseCard checkedCard)
        {
            switch (conditionObj)
            {
                case ICharacteristicCardCondition charCondition when checkedCard is ICharacteristicCard charCard:
                    return charCondition.CharacteristicType == charCard.CharacteristicType;
                default:
                    return conditionObj.CardType == checkedCard.Type;
            }
        }
    }
}