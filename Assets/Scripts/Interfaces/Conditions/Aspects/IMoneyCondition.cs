﻿using System.Collections.Generic;
using Enums.Aspects;
using SerializableStructs.Conditions;

namespace Interfaces.Conditions.Aspects
{
    public interface IMoneyCondition : IAspectCondition
    {
        ResourceType ResourceType { get; }
        List<MoneyConditionValue> ConditionValues { get; }
    }
}