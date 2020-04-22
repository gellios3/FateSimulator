using Interfaces.Cards;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects.Views
{
    /// <summary>
    /// Aspect bar view
    /// </summary>
    public class AspectsBarView : MonoBehaviour
    {
        [Inject] private AspectsSpawner AspectsSpawner { get; }
        
        /// <summary>
        /// Set aspects bar
        /// </summary>
        /// <param name="baseCard"></param>
        public void SetAspectsBar(IBaseCard baseCard)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            AspectsSpawner.CreateAspects(baseCard);
        }
    }
}