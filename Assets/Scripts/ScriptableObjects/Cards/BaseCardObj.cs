using System.Collections.Generic;
using Enums;
using Interfaces.Cards;
using ScriptableObjects.Aspects;
using Serializable;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ScriptableObjects.Cards
{
    /// <summary>
    /// Base Card Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Card Obj", menuName = "Cards/Create Card Obj", order = 0)]
    public class BaseCardObj : BaseObj, IBaseCard
    {
        /// <summary>
        /// Card Id
        /// </summary>
        public ushort Id => id;

        /// <summary>
        /// Position on table
        /// </summary>
        public Vector2 posOnTable;

        public Vector2 PosOnTable => posOnTable;

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


        protected override void AddItemToDatabase()
        {
            byte index = 0;
            while (true)
            {
                if (index > 100)
                    break;
                index++;
                id = (ushort) (Random.value * 100000f);
                if (dataBase.IsUniqueId(id, GlobalType.Card))
                {
                    dataBase.allCards.Add(this);
                }
                else
                {
                    continue;
                }

                break;
            }
        }
    }
}