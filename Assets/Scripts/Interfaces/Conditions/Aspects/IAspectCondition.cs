using Enums;

namespace Interfaces.Conditions.Aspects
{
    public interface IAspectCondition : IBaseCondition
    {
        AspectType AspectType { get; }
    }
}