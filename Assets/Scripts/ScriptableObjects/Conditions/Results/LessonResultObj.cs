using Enums;
using Interfaces.Result.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    /// <summary>
    /// Lesson result
    /// </summary>
    [CreateAssetMenu(fileName = "LessonResultObj", menuName = "Conditions/Results/LessonResult", order = 0)]
    public class LessonResultObj : BaseResultObj, ILessonResult
    {
        public LessonType lessonType;
        public LessonType LessonType => lessonType;
    }
}