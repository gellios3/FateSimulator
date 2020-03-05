using Cards.Models;
using ScriptableObjects.Cards;

namespace Interfaces.Cards
{
    public interface IQuestCard : IActivityCard
    {
        PersonCardObj FromPerson { get; }

        CardCoordinate QuestCoordinate { get; }
    }
}