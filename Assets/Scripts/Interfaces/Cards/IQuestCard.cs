using Cards.Models;
using ScriptableObjects.Cards;
using Serializable.Cards;

namespace Interfaces.Cards
{
    public interface IQuestCard : IActivityCard
    {
        PersonCardObj FromPerson { get; }

        CardCoordinate QuestCoordinate { get; }
    }
}