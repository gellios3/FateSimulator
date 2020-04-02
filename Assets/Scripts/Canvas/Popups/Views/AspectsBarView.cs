using System.Collections.Generic;
using ScriptableObjects.Aspects;
using UnityEngine;

namespace Canvas.Popups.Views
{
    public class AspectsBarView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> aspectsList;

        [SerializeField] private GameObject aspectPrefab;

        public void SetAspectsBar(List<BaseAspectObj> cardObjAspectsList)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
            
            foreach (var baseAspectObj in cardObjAspectsList)
            {
                var aspectView = Instantiate(aspectPrefab, transform).GetComponent<AspectIconView>();
                aspectView.SetAspect(baseAspectObj);
            }
        }
    }
}