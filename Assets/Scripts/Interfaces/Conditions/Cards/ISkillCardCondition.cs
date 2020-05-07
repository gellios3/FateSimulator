using Enums.Skill;

namespace Interfaces.Conditions.Cards
{
    public interface ISkillCardCondition : IActivityCardCondition
    {
        RoutineSkillType RoutineSkillType { get; }
        
        BattleSkillType BattleSkillType { get; }
    }
}