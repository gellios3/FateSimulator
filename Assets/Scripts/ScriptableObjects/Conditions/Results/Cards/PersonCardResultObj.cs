using Enums.Person;
using Interfaces.Conditions.Cards;
using UnityEngine;

namespace ScriptableObjects.Conditions.Results.Cards
{
    [CreateAssetMenu(fileName = "PersonCardResultObj", menuName = "Conditions/Results/Card/PersonCardResult",
        order = 0)]
    public class PersonCardResultObj : CardResultObj, IPersonCardCondition
    {
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}