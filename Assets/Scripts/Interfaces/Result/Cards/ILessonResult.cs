using Enums;

namespace Interfaces.Result.Cards
{
    public interface ILessonResult : IBaseResult
    {
        LessonType LessonType { get; }
    }
}