using Canvas.Aspects.Views;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects
{
    /// <summary>
    /// Aspects spawner
    /// </summary>
    public class AspectsSpawner
    {
        [Inject] private Transform AspectParent { get; }

        private readonly AspectIconView.Factory aspectIconFactory;

        public AspectsSpawner(AspectIconView.Factory aspectIconFactory)
        {
            this.aspectIconFactory = aspectIconFactory;
        }

        /// <summary>
        /// Create aspects
        /// </summary>
        /// <param name="baseCard"></param>
        public void CreateAspects(IBaseCard baseCard)
        {
            foreach (var aspect in baseCard.AspectsList)
            {
                var aspectView = aspectIconFactory.Create();
                aspectView.SetAspect(aspect);
                var transform = aspectView.transform;
                transform.parent = AspectParent;
            }
        }
    }
}