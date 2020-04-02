using Canvas.Popups.Servises;
using Interfaces.Aspects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Popups.Views
{
    public class AspectIconView : MonoBehaviour
    {
        [SerializeField] private Image aspectImg;

        [SerializeField] private Button showAspectPopup;

        private IBaseAspect BaseAspectObj { get; set; }

        [Inject] private ShowAspectService ShowAspectService { get; }

        private void Start()
        {
            showAspectPopup.onClick.AddListener(() =>
            {
                Debug.LogError($"showAspectPopup click!!");
                ShowAspectService.ShowPopup(BaseAspectObj);
            });
        }

        public void SetAspect(IBaseAspect baseAspectObj)
        {
            BaseAspectObj = baseAspectObj;
            aspectImg.sprite = baseAspectObj.AspectImg;
        }
    }
}