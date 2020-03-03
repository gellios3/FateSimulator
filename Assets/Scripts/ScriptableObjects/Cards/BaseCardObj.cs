using System.Collections.Generic;
using Enums;
using Interfaces.Cards;
using ScriptableObjects.Aspects;
using UnityEngine;

namespace ScriptableObjects.Cards
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

        public CardType type;
        public CardType Type => type;
        
        public Sprite cardIcon;
        public Sprite CardIcon => cardIcon;
        
        public List<BaseAspectObj> aspectsList;
        public List<BaseAspectObj> AspectsList => aspectsList;
    }
}