using System;
using Enums.Skill;
using Interfaces.Aspects.Skill;

namespace Serializable.Aspects.Skill
{
    /// <summary>
    /// Battle Skill Aspect
    /// </summary>
    [Serializable]
    public class BattleSkillAspect : BaseAspect, IBattleSkillAspect
    {
        public BattleSkillType SkillType { get; }
        public byte Level { get; }

        public BattleSkillAspect(IBattleSkillAspect aspect) : base(aspect)
        {
            SkillType = aspect.SkillType;
            Level = aspect.Level;
        }
    }
}