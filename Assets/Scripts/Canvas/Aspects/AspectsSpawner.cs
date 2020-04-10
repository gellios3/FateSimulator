using Canvas.Aspects.Views;
using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects
{
    public class AspectsSpawner
    {
        [Inject] private Transform AspectParent { get; }

        private readonly AspectIconView.Factory AspectIconFactory;

        public AspectsSpawner(AspectIconView.Factory aspectIconFactory)
        {
            AspectIconFactory = aspectIconFactory;
        }

        public void CreateAspects(IBaseCard baseCard)
        {
            foreach (var aspect in baseCard.AspectsList)
            {
                var aspectView = AspectIconFactory.Create();
                aspectView.SetAspect(aspect);
                var transform = aspectView.transform;
                transform.parent = AspectParent;
            }
        }
    }
}