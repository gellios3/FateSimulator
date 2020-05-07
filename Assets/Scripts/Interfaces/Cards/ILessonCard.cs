using Enums;

namespace Interfaces.Cards
{
    public interface ILessonCard : IBaseCard
    {
        LessonType LessonType { get; }
    }
}