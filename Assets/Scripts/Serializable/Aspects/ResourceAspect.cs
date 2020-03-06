using System;
using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace Serializable.Aspects
{
    /// <summary>
    /// Resource Aspect 
    /// </summary>
    [Serializable]
    public class ResourceAspect : BaseAspect, IResourceAspect
    {
        public ResourceType ResourceType { get; }
        public MoneyType MoneyType { get; }
        public ushort ResourceValue { get; }

        public ResourceAspect(IResourceAspect aspect) : base(aspect)
        {
            ResourceType = aspect.ResourceType;
            ResourceValue = aspect.ResourceValue;
            MoneyType = aspect.MoneyType;
        }
    }
}