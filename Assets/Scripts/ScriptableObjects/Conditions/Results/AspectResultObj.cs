using Enums;
using UnityEngine;

namespace ScriptableObjects.Results
{
    [CreateAssetMenu(fileName = "AspectResultObj", menuName = "Conditions/Results/AspectResultObj", order = 0)]
    public class AspectResultObj : BaseResultObj
    {
        public AspectType aspectType;
    }
}