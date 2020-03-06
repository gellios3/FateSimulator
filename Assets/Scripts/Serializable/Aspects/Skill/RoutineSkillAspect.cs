using System;
using Enums.Aspects;
using Enums.Skill;
using Interfaces.Aspects.Skill;
using UnityEngine;

namespace Serializable.Aspects.Skill
{
    /// <summary>
    /// Routine Skill Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public class RoutineSkillAspect : BaseAspect, IRoutineSkillAspect
    {
        public RoutineSkillType SkillType { get; }
        public byte Level { get; }

        public RoutineSkillAspect(IRoutineSkillAspect aspect) : base(aspect)
        {
            SkillType = aspect.SkillType;
            Level = aspect.Level;
        }
    }
}