using Cards.Models;
using ScriptableObjects.Cards;
using UnityEngine;

namespace Cards.Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private BaseCardObj sourceCard;
        
        public CardData CardData { get; private set; }
    }
}