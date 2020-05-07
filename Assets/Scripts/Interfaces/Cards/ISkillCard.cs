using Enums.Skill;

namespace Interfaces.Cards
{
    public interface ISkillCard : IBaseCard
    {

        RoutineSkillType RoutineSkillType { get; }
        
        BattleSkillType BattleSkillType { get; }
    }
}