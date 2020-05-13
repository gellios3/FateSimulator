using Enums.Aspects;
using Interfaces.Cards;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "ResourceCardObj", menuName = "Cards/Resource Card", order = 0)]
    public class ResourceCardObj : BaseCardObj, IResourceCard
    {
        public ResourceType resourceType;
        public ResourceType ResourceType => resourceType;

        public ushort resourceValue;
        public ushort ResourceValue => resourceValue;
    }
}