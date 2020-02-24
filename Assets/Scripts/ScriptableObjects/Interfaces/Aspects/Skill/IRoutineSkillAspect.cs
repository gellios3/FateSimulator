using Enums.Aspects;

namespace ScriptableObjects.Interfaces.Aspects.Skill
{
    /// <summary>
    /// Interface for Routine Skill Aspect
    /// </summary>
    public interface IRoutineSkillAspect : IBaseAspect
    {
        /// <summary>
        /// Routine Skill type
        /// </summary>
        RoutineSkillType SkillType { get; }

        /// <summary>
        /// Level
        /// </summary>
        byte Level { get; }
    }
}