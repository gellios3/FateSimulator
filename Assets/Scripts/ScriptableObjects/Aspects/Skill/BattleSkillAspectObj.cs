using Enums.Aspects;
using Enums.Skill;
using Interfaces.Aspects.Skill;
using UnityEngine;

namespace ScriptableObjects.Aspects.Skill
{
    /// <summary>
    /// Battle skill aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Battle Skill Aspect", menuName = "Aspects/Skill/Create Battle Skill Aspect", order = 0)]
    public class BattleSkillAspectObj : BaseAspectObj, IBattleSkillAspect
    {
        /// <summary>
        /// Battle skill type
        /// </summary>
        public BattleSkillType skillType;
        public BattleSkillType SkillType => skillType;

        /// <summary>
        /// Skill level
        /// </summary>
        public byte level;
        public byte Level => level;
    }
}