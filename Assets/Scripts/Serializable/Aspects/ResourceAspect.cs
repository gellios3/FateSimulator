using System;
using Enums.Aspects;
using Interfaces.Aspects;
using Interfaces.Aspects.Resource;
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

        public ResourceAspect(IResourceAspect aspect) : base(aspect)
        {
            ResourceType = aspect.ResourceType;

        }
    }
}