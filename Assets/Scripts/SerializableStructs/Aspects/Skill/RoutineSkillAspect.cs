using System;
using Enums;
using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects.Skill;
using UnityEngine;

namespace SerializableStructs.Aspects.Skill
{
    /// <summary>
    /// Routine Skill Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public struct RoutineSkillAspect : IRoutineSkillAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public RoutineSkillType SkillType { get; }
        public byte Level { get; }

        public RoutineSkillAspect(IRoutineSkillAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            SkillType = aspect.SkillType;
            Level = aspect.Level;
        }
    }
}