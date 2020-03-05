using Enums;
using Enums.Aspects;

namespace Interfaces.Conditions.Aspects
{
    public interface IAspectCondition : IBaseCondition
    {
        AspectType AspectType { get; }
    }
}