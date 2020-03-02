using Enums.Aspects;

namespace Interfaces.Conditions.Aspects
{
    public interface IMoneyConditionValue
    {
        MoneyType MoneyType { get; }
        ushort Value { get; }
    }
}