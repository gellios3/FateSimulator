using AbstractViews;
using Canvas.Aspects.Services;
using Interfaces.Aspects;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Canvas.Aspects.Views
{
    public class AspectIconView : BaseView
    {
        #region MyRegion

        [SerializeField] private Image aspectImg;

        [SerializeField] private Button showAspectPopup;

        private IBaseAspect BaseAspectObj { get; set; }

        [Inject] private ShowAspectService ShowAspectService { get; }
        
        #endregion

        [Inject]
        public void Construct()
        {
        }

        /// <summary>
        /// Set aspect
        /// </summary>
        /// <param name="baseAspectObj"></param>
        public void SetAspect(IBaseAspect baseAspectObj)
        {
            BaseAspectObj = baseAspectObj;
            aspectImg.sprite = baseAspectObj.AspectImg;
            showAspectPopup.onClick.AddListener(() =>
            {
                ShowAspectService.ShowPopup(BaseAspectObj.Id);
            });
        }
        
        public class Factory : PlaceholderFactory<AspectIconView>
        {
        }
    }
}