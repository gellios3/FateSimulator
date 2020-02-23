using System;
using Enums;
using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace SerializableStructs.Aspects
{
    /// <summary>
    /// Person Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public struct PersonAspect : IPersonAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public PersonType PersonType { get; }
        
        public PersonAspect(IPersonAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            PersonType = aspect.PersonType;
        }
    }
}