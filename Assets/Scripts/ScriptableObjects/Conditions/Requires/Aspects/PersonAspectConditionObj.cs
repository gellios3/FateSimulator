using Enums.Aspects;
using Interfaces.Conditions.Aspects;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires.Aspects
{
    [CreateAssetMenu(fileName = "PersonRequireObj", menuName = "Conditions/Requires/Aspect/PersonRequire", order = 0)]
    public class PersonAspectConditionObj : AspectConditionObj, IPersonAspectCondition
    {
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}