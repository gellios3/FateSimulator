using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results
{
    [CreateAssetMenu(fileName = "AspectResultObj", menuName = "Conditions/Results/AspectResultObj", order = 0)]
    public class AspectResultObj : BaseResultObj, IAspectCondition
    {
        public AspectType aspectType;
        public AspectType AspectType => aspectType;
    }
}