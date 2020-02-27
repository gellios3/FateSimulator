using Enums.Aspects;
using UnityEngine;

namespace ScriptableObjects.Requires
{
    [CreateAssetMenu(fileName = "PersonRequireObj", menuName = "Conditions/Requires/PersonRequire", order = 0)]
    public class PersonAspectRequireObj : AspectRequireObj
    {
        public PersonType personType;
        
    }
}