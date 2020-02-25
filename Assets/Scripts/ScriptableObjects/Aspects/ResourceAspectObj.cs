using Enums.Aspects;
using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    /// <summary>
    /// Resource Aspect
    /// </summary>
    [CreateAssetMenu(fileName = "New Resource Aspect", menuName = "Aspects/Create Resource Aspect", order = 0)]
    public class ResourceAspectObj : BaseAspectObj, IResourceAspect
    {
        /// <summary>
        /// Resource Type
        /// </summary>
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;
        
        /// <summary>
        /// Resource Value
        /// </summary>
        public ushort resourceValue;
        public ushort ResourceValue => resourceValue;
    }
}