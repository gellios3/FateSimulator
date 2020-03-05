using Enums.Aspects;
using Enums.Skill;

namespace Interfaces.Aspects.Skill
{
    /// <summary>
    /// Interface for Battle Skill Aspect
    /// </summary>
    public interface IBattleSkillAspect : IBaseAspect
    {
        /// <summary>
        /// Battle skill type
        /// </summary>
        BattleSkillType SkillType { get; }

        /// <summary>
        /// Skill level
        /// </summary>
        byte Level { get; }
    }
}