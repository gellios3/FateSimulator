using Enums;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "LessonCardObj", menuName = "Cards/Lesson Card", order = 0)]
    public class LessonCardObj : BaseCardObj, ILessonCard
    {
        public LessonType lessonType;
        public LessonType LessonType => lessonType;
    }
}