using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    /// <summary>
    /// Person aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Person Aspect", menuName = "Aspects/Create Person Aspect", order = 0)]
    public class PersonAspectObj : BaseAspectObj, IPersonAspect
    {
        /// <summary>
        /// Person type
        /// </summary>
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}