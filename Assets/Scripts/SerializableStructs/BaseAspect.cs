using System;
using Enums;
using ScriptableObjects;
using ScriptableObjects.Interfaces;
using UnityEngine;

namespace SerializableStructs
{
    [Serializable]
    public struct BaseAspect : IBaseAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }

        public BaseAspect(IBaseAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
        }
    }
}