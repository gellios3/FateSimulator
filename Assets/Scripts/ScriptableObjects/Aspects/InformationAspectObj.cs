using Interfaces.Aspects;
using UnityEngine;

namespace ScriptableObjects.Aspects
{
    [CreateAssetMenu(fileName = "InformationAspect", menuName = "Aspects/Information Aspect", order = 0)]
    public class InformationAspectObj : BaseAspectObj, IInformationAspect
    {
        public string popupDescription;
        public string PopupDescription => popupDescription;

        public Sprite popupImg;
        public Sprite PopupImg => popupImg;
    }
}