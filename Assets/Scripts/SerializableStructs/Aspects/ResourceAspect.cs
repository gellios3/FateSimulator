using System;
using Enums;
using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace SerializableStructs.Aspects
{
    /// <summary>
    /// Resource Aspect - Serializable struct
    /// </summary>
    [Serializable]
    public struct ResourceAspect : IResourceAspect
    {
        public ushort Id { get; }
        public string AspectName { get; }
        public Sprite AspectImg { get; }
        public AspectType AspectType { get; }
        public ResourceType ResourceType { get; }
        public ushort ResourceValue { get; }

        public ResourceAspect(IResourceAspect aspect)
        {
            Id = aspect.Id;
            AspectName = aspect.AspectName;
            AspectImg = aspect.AspectImg;
            AspectType = aspect.AspectType;
            ResourceType = aspect.ResourceType;
            ResourceValue = aspect.ResourceValue;
        }
    }
}