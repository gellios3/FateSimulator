﻿using Enums.Aspects;

namespace Interfaces.Aspects
{
    /// <summary>
    /// Interface for Resource Aspect
    /// </summary>
    public interface IResourceAspect : IBaseAspect
    {
        /// <summary>
        /// Resource type
        /// </summary>
        ResourceType ResourceType { get; }
        
        /// <summary>
        /// Money type
        /// </summary>
        MoneyType MoneyType { get; }
        
        /// <summary>
        /// Resource value
        /// </summary>
        ushort ResourceValue { get; }
    }
}