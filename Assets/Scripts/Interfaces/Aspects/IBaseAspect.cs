using Enums;
using Enums.Aspects;
using UnityEngine;

namespace Interfaces.Aspects
{
    /// <summary>
    /// Interface for Base Aspect
    /// </summary>
    public interface IBaseAspect : IBaseObj
    {

        /// <summary>
        /// Aspect Name
        /// </summary>
        string AspectName { get; }   
        
        /// <summary>
        /// Aspect Name
        /// </summary>
        string AspectDescription { get; }
        
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