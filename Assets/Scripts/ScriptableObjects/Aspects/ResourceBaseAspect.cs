using Enums.Aspects;
using ScriptableObjects.Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "New Resource Aspect", menuName = "Aspects/Create Resource Aspect", order = 0)]
    public class ResourceBaseAspect : BaseBaseAspect, IResourceAspect
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;
        
        public ushort resourceValue;
        public ushort ResourceValue => resourceValue;
    }
}