using System;
using Enums.Aspects;
using Enums.Person;
using Interfaces.Aspects;
using UnityEngine;

namespace Serializable.Aspects
{
    /// <summary>
    /// Person Aspect 
    /// </summary>
    [Serializable]
    public class PersonAspect : BaseAspect, IPersonAspect
    {
        public PersonType PersonType { get; }
        
        public PersonAspect(IPersonAspect aspect) : base(aspect)
        {
            PersonType = aspect.PersonType;
        }
    }
}