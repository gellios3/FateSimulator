using Interfaces.Cards;
using Interfaces.Conditions.Cards;
using ScriptableObjects;
using Zenject;

namespace Canvas.Services
{
    /// <summary>
    /// Conditions service
    /// </summary>
    public class ConditionsService
    {
        /// <summary>
        /// All items data base
        /// </summary>
        [Inject]
        private AllItemsDataBase DataBase { get; }

        /// <summary>
        /// Check condition
        /// </summary>
        /// <param name="conditionId"></param>
        /// <param name="checkedCardId"></param>
        /// <returns></returns>
        public bool CheckCondition(ushort conditionId, ushort checkedCardId)
        {
            var checkedCard = DataBase.GetCardById(checkedCardId);
            var conditionObj = DataBase.GetConditionById(conditionId);
            switch (conditionObj)
            {
                case ICharacteristicCardCondition charCondition when checkedCard is ICharacteristicCard charCard:
                    return charCondition.CharacteristicType == charCard.CharacteristicType;
                case ICardCondition cardCondition:
                    return cardCondition.CardType == checkedCard.Type;
                default:
                    return false;
            }
        }
    }
}