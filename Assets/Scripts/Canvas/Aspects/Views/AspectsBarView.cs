using System.Collections.Generic;
using Interfaces.Aspects;
using Interfaces.Cards;
using ScriptableObjects.Aspects;
using UnityEngine;
using Zenject;

namespace Canvas.Aspects.Views
{
    public class AspectsBarView : MonoBehaviour
    {
        [Inject] private AspectsSpawner AspectsSpawner { get; }
        
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