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
        [Inject] private AllItemsDataBase DataBase { get; }
        
        /// <summary>
        /// Check condition
        /// </summary>
        /// <param name="conditionObj"></param>
        /// <param name="checkedCardId"></param>
        /// <returns></returns>
        public bool CheckCondition(ICardCondition conditionObj, ushort checkedCardId)
        {
            var checkedCard = DataBase.GetCardById(checkedCardId);
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