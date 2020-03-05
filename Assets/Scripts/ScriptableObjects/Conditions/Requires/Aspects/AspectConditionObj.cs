using Enums;
using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Aspects
{
    [CreateAssetMenu(fileName = "BaseAspectRequireObj", menuName = "Conditions/Requires/Aspect/AspectRequireObj", order = 0)]
    public class AspectConditionObj : BaseConditionObj, IAspectCondition
    {
        public AspectType aspectType;
        public AspectType AspectType => aspectType;
    }
}