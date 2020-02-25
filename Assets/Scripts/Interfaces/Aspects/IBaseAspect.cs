using Enums;
using UnityEngine;

namespace Interfaces.Aspects
{
    /// <summary>
    /// Interface for Base Aspect
    /// </summary>
    public interface IBaseAspect
    {
        /// <summary>
        /// Aspect Id
        /// </summary>
        ushort Id { get; }
        
        /// <summary>
        /// Aspect Name
        /// </summary>
        string AspectName { get; }
        
        /// <summary>
        /// Aspect img
        /// </summary>
        Sprite AspectImg { get; }
        
        /// <summary>
        /// Aspect Type
        /// </summary>
        AspectType AspectType { get; }
    }
}