using Canvas.Aspects.Servises;
using Interfaces.Aspects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Aspects.Views
{
    public class AspectIconView : MonoBehaviour
    {
        [SerializeField] private Image aspectImg;

        [SerializeField] private Button showAspectPopup;

        private IBaseAspect BaseAspectObj { get; set; }

        [Inject] private ShowAspectService ShowAspectService { get; }

        [Inject]
        public void Construct()
        {
        }

        public void SetAspect(IBaseAspect baseAspectObj)
        {
            BaseAspectObj = baseAspectObj;
            aspectImg.sprite = baseAspectObj.AspectImg;
            showAspectPopup.onClick.AddListener(() =>
            {
                Debug.LogError($"showAspectPopup click!!");
                ShowAspectService.ShowPopup(BaseAspectObj);
            });
        }
        

        public class Factory : PlaceholderFactory<AspectIconView>
        {
        }
    }
}