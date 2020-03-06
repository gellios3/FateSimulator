using System;
using System.Collections.Generic;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class ResourceCard: BaseCard, IResourceCard
    {
        public List<ResourceObj> ResourcesList { get; }
        
        public ResourceCard(IResourceCard cardObj) : base(cardObj)
        {
            ResourcesList = cardObj.ResourcesList;
        }
    }
}