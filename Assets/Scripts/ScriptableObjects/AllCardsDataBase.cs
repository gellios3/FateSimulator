using System;
using System.Collections.Generic;
using Enums;
using ScriptableObjects.Activities;
using ScriptableObjects.Cards;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "", menuName = "", order = 0)]
    public class AllCardsDataBase : ScriptableObject
    {
        public List<BaseCardObj> allCards;
        public List<BaseActivityObj> allActivities;
        
        public bool IsUniqueId(ushort id, GlobalType type)
        {
            switch (type)
            {
                case GlobalType.Card:
                    return allCards.FindIndex(obj => obj.id == id) == -1;
                case GlobalType.Activity:
                    return allActivities.FindIndex(obj => obj.id == id) == -1;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
        
        
    }
}