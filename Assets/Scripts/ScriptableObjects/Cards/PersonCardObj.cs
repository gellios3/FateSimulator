using Enums.Aspects;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "PersonCardObj", menuName = "Cards/PersonCardObj", order = 0)]
    public class PersonCardObj : BaseCardObj, IPersonCard
    {
        public PersonType personType;
        public PersonType PersonType => personType;
    }
}