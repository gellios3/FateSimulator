using Interfaces.Conditions;

namespace Interfaces.Result
{
    public interface IBaseResult: IBaseCondition
    {
        byte Percent { get; }
    }
}