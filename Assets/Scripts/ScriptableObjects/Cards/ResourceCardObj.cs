using System.Collections.Generic;
using Interfaces.Cards;
using SerializableStructs;
using UnityEngine;

namespace ScriptableObjects.Cards
{
    [CreateAssetMenu(fileName = "ResourceCardObj", menuName = "Cards/Resource Card", order = 0)]
    public class ResourceCardObj : BaseCardObj, IResourceCard
    {
        public List<ResourceObj> resourcesList;
        public List<ResourceObj> ResourcesList => resourcesList;
    }
}