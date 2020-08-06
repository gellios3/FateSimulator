using Enums;

namespace Interfaces.Cards
{
    public interface ILessonCard : IBaseCard
    {
        byte Level { get; }
        LessonType LessonType { get; }
    }
}