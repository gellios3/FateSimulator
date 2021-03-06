﻿using Interfaces.Cards;
using Interfaces.Conditions;
using Interfaces.Conditions.Cards;
using ScriptableObjects;
using Zenject;

namespace Services
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
                // try find Characteristic Card by Condition
                case ICharacteristicCardCondition charCondition when checkedCard is ICharacteristicCard charCard:
                    return charCondition.CharacteristicType == charCard.CharacteristicType;
                // try find skill card by condition
                case ISkillCardCondition skillCardCondition when checkedCard is ISkillCard skillCard: 
                    return skillCardCondition.RoutineSkillType == skillCard.RoutineSkillType &&
                           skillCardCondition.BattleSkillType == skillCard.BattleSkillType;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Try find condition by card id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public IBaseCondition TryFindConditionByCardId(ushort cardId)
        {
            var sourceCard = DataBase.GetCardById(cardId);
            var allConditions = DataBase.allConditions;

            foreach (var condition in allConditions)
            {
                switch (condition)
                {
                    case IWorkCardCondition workCardCondition when sourceCard is IWorkCard workCard:
                        if (workCardCondition.WorkType == workCard.WorkType)
                            return condition;
                        break;
                }
            }

            return null;
        }
    }
}