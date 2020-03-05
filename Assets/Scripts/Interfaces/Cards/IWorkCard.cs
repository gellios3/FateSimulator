using Enums.Activities;
using ScriptableObjects.Cards;

namespace Interfaces.Cards
{
    public interface IWorkCard : IBaseCard
    {
        WorkType WorkType { get; }

        SkillCardObj RequireSkill { get; }
    }
}