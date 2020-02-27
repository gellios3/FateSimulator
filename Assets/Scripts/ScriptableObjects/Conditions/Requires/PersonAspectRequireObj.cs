using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "PersonRequireObj", menuName = "Conditions/Requires/PersonRequire", order = 0)]
    public class PersonAspectRequireObj : AspectRequireObj, IPersonAspectRequire
    {
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}