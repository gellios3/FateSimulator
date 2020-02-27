using Enums;

namespace Interfaces.Conditions.Aspects
{
    public interface IAspectRequire : IBaseRequire
    {
        AspectType AspectType { get; }
    }
}