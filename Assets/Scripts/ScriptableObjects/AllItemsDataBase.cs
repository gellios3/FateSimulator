using System;
using System.Collections.Generic;
using Enums;
using ScriptableObjects.Activities;
using ScriptableObjects.Aspects;
using ScriptableObjects.Cards;
using ScriptableObjects.Conditions.Requires;
using ScriptableObjects.Conditions.Results;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// All items Data base
    /// </summary>
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public class AllItemsDataBase : ScriptableObject
    {
        public List<BaseCardObj> allCards;
        public List<BaseActivityObj> allActivities;
        public List<BaseAspectObj> allAspects;
        public List<BaseConditionObj> allConditions;
        public List<BaseResultObj> allResults;

        /// <summary>
        /// Get Card by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseCardObj GetCardById(ushort id)
        {
            var index = allCards.FindIndex(obj => obj.id == id);
            return index != -1 ? allCards[index] : null;
        }

        /// <summary>
        /// Get Activity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseActivityObj GetActivityById(ushort id)
        {
            var index = allActivities.FindIndex(obj => obj.id == id);
            return index != -1 ? allActivities[index] : null;
        }

        /// <summary>
        /// Get Aspect by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseAspectObj GetAspectById(ushort id)
        {
            var index = allAspects.FindIndex(obj => obj.id == id);
            return index != -1 ? allAspects[index] : null;
        }

        /// <summary>
        /// Get Condition by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseResultObj GetResultObjById(ushort id)
        {
            var index = allResults.FindIndex(obj => obj.id == id);
            return index != -1 ? allResults[index] : null;
        }

        /// <summary>
        /// Get Condition by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseConditionObj GetConditionById(ushort id)
        {
            var index = allConditions.FindIndex(obj => obj.id == id);
            return index != -1 ? allConditions[index] : null;
        }

        /// <summary>
        /// Check if Id is Unique in current list
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool IsUniqueId(ushort id, GlobalType type)
        {
            switch (type)
            {
                case GlobalType.Card:
                    return allCards.FindIndex(obj => obj != null && obj.id == id) == -1;
                case GlobalType.Activity:
                    return allActivities.FindIndex(obj => obj != null && obj.id == id) == -1;
                case GlobalType.Aspect:
                    return allAspects.FindIndex(obj => obj != null && obj.id == id) == -1;
                case GlobalType.Condition:
                    return allConditions.FindIndex(obj => obj != null && obj.id == id) == -1;
                case GlobalType.Result:
                    return allResults.FindIndex(obj => obj != null && obj.id == id) == -1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}