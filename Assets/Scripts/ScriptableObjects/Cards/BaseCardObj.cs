using System.Collections.Generic;
using Enums;
using Interfaces.Cards;
using ScriptableObjects.Aspects;
using Serializable;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    /// <summary>
    /// Base Card Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Card Obj", menuName = "Cards/Create Card Obj", order = 0)]
    public class BaseCardObj : BaseObj, IBaseCard
    {
        /// <summary>
        /// Card name
        /// </summary>
        public string cardName;
        public string CardName => cardName;

        /// <summary>
        /// Short Description
        /// </summary>
        public string shortDescription;
        public string ShortDescription => shortDescription;

        /// <summary>
        /// Max stack count
        /// </summary>
        public ushort maxStackCount;
        public ushort MaxStackCount => maxStackCount;

        /// <summary>
        /// Card type
        /// </summary>
        public CardType type;
        public CardType Type => type;

        /// <summary>
        /// Card level
        /// </summary>
        public byte level;
        public byte Level => level;

        /// <summary>
        /// Card icon
        /// </summary>
        public Sprite cardIcon;
        public Sprite CardIcon => cardIcon;

        /// <summary>
        /// List of spects
        /// </summary>
        public List<BaseAspectObj> aspectsList;
        public List<BaseAspectObj> AspectsList => aspectsList;

        /// <summary>
        /// Card appearances list
        /// </summary>
        public List<CardStatusPreset> appearances;
        public List<CardStatusPreset> StatusPresets => appearances;
        
        
        protected override bool TryAddItemToDatabase()
        {
            if (!dataBase.IsUniqueId(id, GlobalType.Card)) 
                return false;
            dataBase.allCards.Add(this);
            return true;
        }

        protected override void RemoveItemFromDatabase()
        {
            var index = dataBase.allCards.FindIndex(card => card.id == id);
            if (index != -1)
            {
                dataBase.allCards.RemoveAt(index);
            }
        }
    }
}