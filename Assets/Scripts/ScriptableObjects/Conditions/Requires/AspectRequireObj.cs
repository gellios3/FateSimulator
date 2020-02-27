using Enums;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "BaseAspectRequireObj", menuName = "Conditions/Requires/AspectRequireObj", order = 0)]
    public class AspectRequireObj : BaseRequireObj, IAspectRequire
    {
        public AspectType aspectType;
        public AspectType AspectType => aspectType;
    }
}