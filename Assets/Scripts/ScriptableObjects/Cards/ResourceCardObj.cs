using Interfaces.Cards;
using Serializable;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "ResourceCardObj", menuName = "Cards/Resource Card", order = 0)]
    public class ResourceCardObj : BaseCardObj, IResourceCard
    {
        public ResourceObj resource;

        public ResourceObj Resource => resource;
    }
}