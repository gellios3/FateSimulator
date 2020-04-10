using Enums.Skill;

namespace Interfaces.Conditions.Cards
{
    public interface ISkillCardCondition : ICardCondition
    {
        RoutineSkillType RoutineSkillType { get; }
        
        BattleSkillType BattleSkillType { get; }
    }
}