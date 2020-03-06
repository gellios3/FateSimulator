using System;
using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace Serializable.Aspects
{
    /// <summary>
    /// Characteristic Aspect
    /// </summary>
    [Serializable]
    public class CharacteristicAspect : BaseAspect, ICharacteristicAspect
    {
        public CharacteristicType CharacteristicType { get; }

        public CharacteristicAspect(ICharacteristicAspect aspect) : base(aspect)
        {
            CharacteristicType = aspect.CharacteristicType;
        }
    }
}