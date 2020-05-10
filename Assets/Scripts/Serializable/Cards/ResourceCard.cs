using System;
using System.Collections.Generic;
using Interfaces.Cards;

namespace Serializable.Cards
{
    [Serializable]
    public class ResourceCard: BaseCard, IResourceCard
    {
        public ResourceObj Resource { get; }
        
        public ResourceCard(IResourceCard cardObj) : base(cardObj)
        {
            Resource = cardObj.Resource;
        }
    }
}