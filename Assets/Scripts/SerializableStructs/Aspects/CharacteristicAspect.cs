using System;
using Enums;
using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace SerializableStructs.Aspects
{
    /// <summary>
    /// Characteristic Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public struct CharacteristicAspect : ICharacteristicAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public CharacteristicType CharacteristicType { get; }

        public CharacteristicAspect(ICharacteristicAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            CharacteristicType = aspect.CharacteristicType;
        }
    }
}