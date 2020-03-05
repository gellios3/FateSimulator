using Enums.Aspects;
using Enums.Person;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Requires
{
    [CreateAssetMenu(fileName = "PersonCardCondition", menuName = "Conditions/Requires/Card/PersonCardCondition", order = 0)]
    public class PersonCardConditionObj : CardConditionObj, IPersonCardCondition
    {
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}