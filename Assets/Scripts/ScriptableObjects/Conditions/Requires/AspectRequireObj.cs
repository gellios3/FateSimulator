using Enums;
using UnityEngine;

namespace ScriptableObjects.Requires
{
    [CreateAssetMenu(fileName = "BaseAspectRequireObj", menuName = "Conditions/Requires/AspectRequireObj", order = 0)]
    public class AspectRequireObj : BaseRequireObj
    {
        public AspectType aspectType;
    }
}