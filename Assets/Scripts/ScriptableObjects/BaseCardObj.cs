using System.Collections.Generic;
using Cards.Models;
using Enums;
using Interfaces.Cards;
using SerializableStructs;
using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// Base Card Obj
    /// </summary>
    [CreateAssetMenu(fileName = "New Card Obj", menuName = "Create Card Obj", order = 0)]
    public class BaseCardObj : ScriptableObject, IBaseCard
    {
        public ushort id;
        public ushort Id => id;
        
        public string cardName;
        public string CardName => cardName;
        
        public string shortDescription;
        public string ShortDescription => shortDescription;
        
        public CardCoordinate cardCoordinate;
        public CardCoordinate CardCoordinate => cardCoordinate;
        
        public CardType type;
        public CardType Type => type;
        
        public Sprite cardIcon;
        public Sprite CardIcon => cardIcon;
        
        public List<BaseAspectObj> cardAspects;
        public List<BaseAspectObj> CardAspects => cardAspects;
    }
}