using System;
using Enums.Aspects;
using Interfaces.Conditions.Aspects;

namespace SerializableStructs.Conditions
{
    /// <summary>
    /// Money condition value
    /// </summary>
    [Serializable]
    public struct MoneyConditionValue : IMoneyConditionValue
    {
        public MoneyType MoneyType => moneyType;
        public MoneyType moneyType;
        
        public ushort Value => value;
        public ushort value;
    }
}