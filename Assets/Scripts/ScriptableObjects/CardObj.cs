using Cards.Models;
using Enums;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Card Obj", menuName = "Create Card Obj", order = 0)]
    public class CardObj : ScriptableObject
    {
        public ushort id;

        public string cardName;

        public string shortDescription;

        public CardCoordinate cardCoordinate;

        public CardType type;

        public Sprite cardImg;
    }
}