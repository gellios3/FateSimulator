using System;
using Enums;
using Enums.Aspects;
using Enums.Skill;
using Interfaces.Aspects.Skill;
using UnityEngine;

namespace SerializableStructs.Aspects.Skill
{
    /// <summary>
    /// Battle Skill Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public struct BattleSkillAspect : IBattleSkillAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public BattleSkillType SkillType { get; }
        public byte Level { get; }

        public BattleSkillAspect(IBattleSkillAspect aspect)
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