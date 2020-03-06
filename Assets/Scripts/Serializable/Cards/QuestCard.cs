using System;
using Cards.Models;
using Interfaces.Cards;
using ScriptableObjects.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class QuestCard : ActivityCard, IQuestCard
    {
        public PersonCardObj FromPerson { get; }
        
        public CardCoordinate QuestCoordinate { get; }
        
        public QuestCard(IQuestCard cardObj) : base(cardObj)
        {
            FromPerson = cardObj.FromPerson;
            QuestCoordinate = cardObj.QuestCoordinate;
        }
    }
}