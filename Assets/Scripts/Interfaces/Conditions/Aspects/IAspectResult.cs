using Enums;

namespace Interfaces.Conditions.Aspects
{
    public interface IAspectResult  : IBaseResult
    {
        AspectType AspectType { get; }
    }
}