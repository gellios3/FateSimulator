using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    
    /// <summary>
    /// Routine skill aspect 
    /// </summary>
    [CreateAssetMenu(fileName = "New Routine Skill Aspect", menuName = "Aspects/Create Routine Skill Aspect",
        order = 0)]
    public class RoutineSkillAspectObj : BaseAspectObj, IRoutineSkillAspect
    {
        
        /// <summary>
        /// Routine Skill Type
        /// </summary>
        public RoutineSkillType skillType;
        public RoutineSkillType SkillType => skillType;

        /// <summary>
        /// Skill Level
        /// </summary>
        public byte level;
        public byte Level => level;
    }
}