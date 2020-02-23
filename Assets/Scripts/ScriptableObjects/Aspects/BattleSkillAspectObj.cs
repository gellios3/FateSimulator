using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    /// <summary>
    /// Battle skill aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Battle Skill Aspect", menuName = "Aspects/Create Battle Skill Aspect", order = 0)]
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