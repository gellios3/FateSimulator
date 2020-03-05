using Cards.Models;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "QuestCard", menuName = "Cards/Quest Card", order = 0)]
    public class QuestCardObj : ActivityCardObj, IQuestCard
    {
        public PersonCardObj fromPerson;
        public PersonCardObj FromPerson => fromPerson;
        
        public CardCoordinate questCoordinate;
        public CardCoordinate QuestCoordinate => questCoordinate;
    }
}