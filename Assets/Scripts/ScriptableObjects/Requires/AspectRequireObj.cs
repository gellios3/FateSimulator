using Enums;
using UnityEngine;

namespace ScriptableObjects.Requires
{
    [CreateAssetMenu(fileName = "BaseAspectRequireObj", menuName = "Requires/AspectRequireObj", order = 0)]
    public class AspectRequireObj : BaseRequireObj
    {
        public AspectType aspectType;
    }
}