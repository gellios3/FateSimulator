using Enums.Aspects;
using Interfaces.Aspects.Resource;
using UnityEngine;

namespace ScriptableObjects.Aspects.Resource
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
       

    }
}