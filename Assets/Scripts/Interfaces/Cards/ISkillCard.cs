using Enums.Skill;

namespace Interfaces.Cards
{
    public interface ISkillCard : IBaseCard
    {
        byte Level { get; }
        RoutineSkillType RoutineSkillType { get; }
        BattleSkillType BattleSkillType { get; }
    }
}